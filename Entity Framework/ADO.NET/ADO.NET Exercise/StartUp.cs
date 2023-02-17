using Microsoft.Data.SqlClient;
using System.Text;

namespace ADO.NET_Exercise
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            
            await using SqlConnection sqlConnection = new SqlConnection (Config.ConnectionString); // placing hte using at the front is the new way of makeing sure the connection
            //will be closed because SqlConnection is Idisposable
            await sqlConnection.OpenAsync();

          //  string result = await GetAllVillainsWithTHeirMinions(sqlConnection);
          //  Console.WriteLine(result);

           // int villainId = int.Parse(Console.ReadLine());

          // string resultOfMinions = await GetMinionasNameByTheirVillainId(sqlConnection, villainId);
           // Console.WriteLine(resultOfMinions);

            string minion = Console.ReadLine();
            string villain = Console.ReadLine();

            string resultOfAddingMinion = await AddMinion(sqlConnection,minion,villain);
            Console.WriteLine(resultOfAddingMinion);


        }

        static async Task<string> GetAllVillainsWithTHeirMinions(SqlConnection sqlConnection)
        {          
            SqlCommand sqlCommand = new SqlCommand(DBqueries.MinionsCount, sqlConnection);

            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                string villianName = (string)reader["Name"];
                int villiansCount = (int)reader["MinionsCount"];

                sb.AppendLine($"{villianName} - {villiansCount}");
            }

            return sb.ToString();
        }

        static async Task<string> GetMinionasNameByTheirVillainId(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand getVillainByIdCommand = new SqlCommand(DBqueries.VillainById, sqlConnection);
            getVillainByIdCommand.Parameters.AddWithValue("@Id", villainId);
           object? villainNameObj = await getVillainByIdCommand.ExecuteScalarAsync(); // Once we execute the SQL query it will return an object that can be null

            if (villainNameObj == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
            }
            else
            {
                string villainName = (string)villainNameObj;
                sb.AppendLine($"Villain: {villainName}");
            }

            SqlCommand getMinionsCommand = new SqlCommand(DBqueries.GetMinions, sqlConnection);
            getMinionsCommand.Parameters.AddWithValue("@Id", villainId);

            SqlDataReader getAllMinionsReader = await getMinionsCommand.ExecuteReaderAsync();

            while (getAllMinionsReader.Read()) //Loop until we have rows in the reader
            {
                    long rowNum = (long)getAllMinionsReader["RowNum"];
                    string name = (string)getAllMinionsReader["Name"];
                    int age = (int)getAllMinionsReader["Age"];

                    sb.AppendLine($"{rowNum}. {name} {age}");
            }

            if (!getAllMinionsReader.HasRows)
            {
                sb.AppendLine("(no minions)");
            }

            return sb.ToString();
        }

        static async Task<string> AddMinion(SqlConnection sqlConnection, string minion, string villain) 
        {
            StringBuilder sb = new StringBuilder();
            string[] minionsArgs = minion.Split(" ");
            string name = minionsArgs[1];
            int age = int.Parse(minionsArgs[2]);
            string town = minionsArgs[3];
            string[] villainArgs = villain.Split(" ");
            string villainName = villainArgs[1];

            SqlCommand getTownByIdCommand = new SqlCommand(DBqueries.TownById, sqlConnection);
            getTownByIdCommand.Parameters.AddWithValue("@townName", town);
            object? TownId = await getTownByIdCommand.ExecuteScalarAsync();

            if (TownId == null) // If town does not exists - Add it.
            {
                SqlCommand insertTownCommand = new SqlCommand(DBqueries.InsertTown, sqlConnection);
                insertTownCommand.Parameters.AddWithValue("@townName", town);
                await insertTownCommand.ExecuteNonQueryAsync();
                sb.AppendLine($"Town {town} was added to the database.");
            }

            SqlCommand getVillainByNameCommand = new SqlCommand(DBqueries.VillainByName, sqlConnection);
            getVillainByNameCommand.Parameters.AddWithValue("@Name", villainName);
            object? villainNameObj = await getVillainByNameCommand.ExecuteScalarAsync();
            

            if (villainNameObj == null) // If Villain does not exists - Add it. 
            {
                SqlCommand insertVillainCommand = new SqlCommand(DBqueries.InsertVillain, sqlConnection);
                insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);
                await insertVillainCommand.ExecuteNonQueryAsync();
                sb.AppendLine($"Villain {villainName} was added to the database.");
            }

            SqlCommand getMinionByName = new SqlCommand(DBqueries.GetMinionByName, sqlConnection);
            getMinionByName.Parameters.AddWithValue(@"Name", name);
           // SqlDataReader getMinionReader = await getMinionByName.ExecuteReaderAsync();
            int minionId = (int)await getMinionByName.ExecuteScalarAsync();

            if (minionId == null) // if the Minion does not exists - Insert it. 
            {
                SqlCommand insertMinionCommand = new SqlCommand(DBqueries.InsertMinion, sqlConnection);
                insertMinionCommand.Parameters.AddWithValue("@name", name);
                insertMinionCommand.Parameters.AddWithValue("@age", age);
                insertMinionCommand.Parameters.AddWithValue("@townId", (int?)TownId);
                await insertMinionCommand.ExecuteNonQueryAsync();
               
               
            }
            else // If the minion Exists add it to the Villain.
            {
                SqlCommand getVillainByNameCmd = new SqlCommand(DBqueries.VillainByName, sqlConnection);
                
                object? villainIdObj = await getVillainByNameCommand.ExecuteScalarAsync();
                int villId = (int)villainIdObj;
                SqlCommand insertMinionVillain = new SqlCommand(DBqueries.InsertMinionVillain, sqlConnection);

                insertMinionVillain.Parameters.AddWithValue("@minionId", minionId);
                insertMinionVillain.Parameters.AddWithValue("VillainId", villId);
                await insertMinionVillain.ExecuteNonQueryAsync();


                sb.AppendLine($"Successfully added {name} to be minion of {villainName}.");
            }

            return sb.ToString();
        }

    }
}
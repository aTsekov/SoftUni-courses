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

            string result = await GetAllVillainsWithTHeirMinions(sqlConnection);
            Console.WriteLine(result);

            int villainId = int.Parse(Console.ReadLine());

           string resultOfMinions = await GetMinionasNameByTheirVillainId(sqlConnection, villainId);
            Console.WriteLine(resultOfMinions);
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

    }
}
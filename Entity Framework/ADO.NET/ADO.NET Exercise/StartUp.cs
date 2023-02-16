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

            Console.WriteLine("The connection is open..");
            string result = await GetAllVillainsWithTHeirMinions(sqlConnection);
            Console.WriteLine(result);
        }

        static async Task<string> GetAllVillainsWithTHeirMinions(SqlConnection sqlConnection)
        {
            string query = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
    FROM Villains AS v 
    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
GROUP BY v.Id, v.Name 
  HAVING COUNT(mv.VillainId) > 3 
ORDER BY COUNT(mv.VillainId)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

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
    }
}
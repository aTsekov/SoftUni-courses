

using System.Data.SqlClient;



SqlConnection connection = new SqlConnection(Config.ConnectionString); //Using the Config class which consists the connection string so I can avoid uploading it
//to github since it cointains info how to get connected to the DB. the config class should be part of GitIgnore.
//With the help of this connection string we can give it as param to the Sql connection class and we would connect to the DB.

connection.Open(); // Opens the connection to the DB

using (connection) //we use using because SqlConnection is IDisposible. Meaning we must close the connection once we are done using it. 
{
    string query = "SELECT * FROM Employees WHERE DepartmentID = 7";
    SqlCommand command = new SqlCommand(query, connection); // We provide the query and the connection. 
    SqlDataReader reader = await command.ExecuteReaderAsync(); // We provide the query and the connection. 
    
    //int emplCount = (int) await command.ExecuteScalarAsync(); //Scalar means it will returns only one value. 

    //Console.WriteLine($"There are {emplCount} empls. in our company");

    using (reader)
    {
        int index = 0;
        while(reader.Read())//While we have rows to read, the loop will beitterating
        {
            string? name = reader["FirstName"]?.ToString(); //The ? is used to check if the field is null/
            string lastName = reader[2]?.ToString();
            Console.WriteLine($"{index++}. {name} {lastName}");
        }
    }
    
}
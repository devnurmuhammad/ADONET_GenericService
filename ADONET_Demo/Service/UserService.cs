using System.Data.SqlClient;
using ADONET_Demo.Model;

namespace ADONET_Demo.Service
{
    public class UserService
    {
        public static void CreateTable(string TableName, string DatabaseName, List<User> columns)
        {
            string connectionString = $"Server = DESKTOP-02F3BCI; Database = {DatabaseName}; Trusted_Connection = True;";

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                //string linq = String.Join(",", columns.Select(x => x.Name + " " + x.Age).ToList());

                //string query = $"create table {TableName}(Id int not null, " +
                //                                        $"Name varchar(30)," +
                //                                        $"Age int not null)";


                string nimadur = $"create table {TableName}(";

                string query = columns.Aggregate(nimadur, (x1, x2) => x1 += x2.Name + " " + x2.Age + ","
                                                , (x) => x.Substring(0, x.Length - 1) + ");");

                SqlCommand cmd = new SqlCommand(query, connect);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Succesfully table created");

            }
        }
        public static void GetAll(string TableName, string DatabaseName)
        {
            string connectionString = $"Server = DESKTOP-02F3BCI; Database = {DatabaseName}; Trusted_Connection = True;";

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                string query = $"select * from {TableName}";

                SqlCommand sqlCommand = new SqlCommand(query, connect);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    int count = reader.FieldCount;

                    while (reader.Read())
                    {
                        for (int j = 0; j < count; j++)
                        {
                            Console.Write($"Col{j} {reader[j]} \t");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
        public static void GetById(string DatabaseName, string TableName, string Condition)
        {
            string connectionString = $"Server = DESKTOP-02F3BCI; Database = '{DatabaseName}'; Trusted_Connection = True;";

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                string query = $"SELECT * FROM {TableName} {Condition};";

                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.ExecuteNonQuery();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int count = reader.FieldCount;

                    while (reader.Read())
                    {
                        for (int j = 0; j < count; j++)
                        {
                            Console.Write($"Col{j} {reader[j]} \t");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
        public static void GenericUserDelete(string DatabaseName, string TableName, string Condition)
        {
            string connectionString = $"Server = DESKTOP-02F3BCI; Database = {DatabaseName}; Trusted_Connection = True;";
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                string query = $"DELETE FROM {TableName} {Condition}";

                SqlCommand cmd = new SqlCommand(query, connect);

                int count = cmd.ExecuteNonQuery();
                if (count == 0)
                {
                    Console.WriteLine("Bunday column topilmadi!");
                }
                else
                {
                    Console.WriteLine("O'chirildi!");
                }
            }
        }
    }
}
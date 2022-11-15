using System.Data;
using System.Data.SqlClient;

namespace DataLibrary.DataAccessLayer
{
    public class DataAccess : IDataAccess
    {
        private string _connectionString;
        public DataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public object DeleteDataViaStoredProcedure(string storedProcName, Dictionary<string, object> parameters)
        {
            object data;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(storedProcName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                        }
                        data = command.ExecuteScalar();
                    }
                    connection.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return data;
        }
        public DataTable PopulateDataTableViaStoredProcedure(string storedProcName, Dictionary<string, object> parameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(storedProcName, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dataTable);
                    }
                    connection.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dataTable;
        }
        public List<T> ReadDataViaStoredProcedure<T>(string storedProcName, Dictionary<string, object> parameters)
        {
            List<T> dataList = new List<T>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(storedProcName, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach(var parameter in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                    }

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var value = reader.GetValue(0);
                            try
                            {
                                dataList.Add((T)Convert.ChangeType(value, typeof(T)));
                            }
                            catch (InvalidCastException)
                            {
                                dataList.Add(default(T));
                            }
                        }
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }
            return dataList;
        }

        public void UpdateDataViaStoredProcedure<T>(string storedProcName, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }
    }
}

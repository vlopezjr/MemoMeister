using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MemoMeister
{
    public static class DAL
    {
        private static string connectionString;
        internal static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    SetConnectionString(Database.Development);
                }

                return connectionString;
            }
            private set { connectionString = value; }
        }

        internal static void SetConnectionString(Database database)
        {
            connectionString = ConfigurationManager.ConnectionStrings[database.ToString()].ConnectionString;
        }


        internal static void AddRemark(Remark remark)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                remark.MemoKey = GetSurrogateKey("tciMemo");

                var parameters = new SqlParameter[]
                {
                   new SqlParameter("@MemoKey", remark.MemoKey),
                   new SqlParameter("@MemoType", remark.TypeId),
                   new SqlParameter("@EntityType", remark.EntityType),
                   new SqlParameter("@OwnerKey", remark.OwnerKey),
                   new SqlParameter("@MemoText", remark.MemoText),
                   new SqlParameter("@UserID", remark.UserId)
                };

                var command = new SqlCommand("spCPCmmAddRemark", conn);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
            }
        }

        internal static void UpdateRemark(Remark remark)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var parameters = new SqlParameter[]
                {
                   new SqlParameter("@MemoKey", remark.MemoKey),
                   new SqlParameter("@MemoType", remark.TypeId),
                   new SqlParameter("@EntityType", remark.EntityType),
                   new SqlParameter("@OwnerKey", remark.OwnerKey),
                   new SqlParameter("@MemoText", remark.MemoText),
                   new SqlParameter("@UserID", remark.UserId)
                };

                var command = new SqlCommand("spCPCmmUpdateRemark", conn);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
            }
        }

        internal static void DeleteRemark(int memoKey)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var param = new SqlParameter("@MemoKey", memoKey);

                var command = new SqlCommand("spCPCmmDeleteRemark", conn);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(param);
                command.ExecuteNonQuery();
            }
        }


        private static int GetSurrogateKey(string tableName)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();


                var param = new SqlParameter("@iTableName", tableName);
                var newKey = new SqlParameter("@oNewKey", SqlDbType.Int);
                newKey.Direction = ParameterDirection.Output;

                var command = new SqlCommand("spGetNextSurrogateKey", conn);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(param);
                command.Parameters.Add(newKey);
                command.ExecuteNonQuery();

                return (int)newKey.Value;
            }
        }
    }
}

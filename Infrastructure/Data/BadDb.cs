using System;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Data;

using System.Data;
using System.Data.SqlClient;

public static class BadDb
{

    public static string ConnectionString = "";


    public static int ExecuteNonQueryUnsafe(string sql)
    {
        using (var conn = new SqlConnection(ConnectionString))
        using (var cmd = new SqlCommand(sql, conn))
        {
            conn.Open();
            return cmd.ExecuteNonQuery();
        }
        
    }

    public static IDataReader ExecuteReaderUnsafe(string sql)
    {
        using (var conn = new SqlConnection(ConnectionString))
        using (var cmd = new SqlCommand(sql, conn))
        {
            conn.Open();
            return cmd.ExecuteReader();
        }
    }
}

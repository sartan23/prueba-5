using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Data
{
    public static class BadDb
    {
        // Se crea una propiedad pública controlada
        // Esta propiedad permite leer el valor pero no permite modificarlo libremente.
        // Con esto no expone un campo mutable.
        public static string ConnectionString { get; set;}
        public static int ExecuteNonQueryUnsafe(string sql)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public static IDataReader ExecuteReaderUnsafe(string sql)
        {
            var conn = new SqlConnection(ConnectionString);
            var cmd = new SqlCommand(sql, conn);
            conn.Open();
            // Esto asegura que al cerrar el IDataReader, la conexión también se cierre
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}

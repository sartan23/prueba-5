using Domain.Abstractions;
using Domain.Entities;
using Microsoft.Data.SqlClient;



namespace Infrastructure.Data
{
    public class SqlOrderRepository: IOrderRepository
    {
        private readonly string _connectionString;

        public SqlOrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void SaveOrder(Order order)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                @"INSERT INTO Orders(Id, CustomerName, ProductName, Quantity, UnitPrice)
                 VALUES (@Id, @CustomerName, @ProductName, @Quantity, @UnitPrice)",
                conn
             );

            cmd.Parameters.AddWithValue("@Id", order.Id);
            cmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
            cmd.Parameters.AddWithValue("@ProductName", order.ProductName);
            cmd.Parameters.AddWithValue("@Quantity", order.Quantity);
            cmd.Parameters.AddWithValue("@UnitPrice", order.UnitPrice);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}

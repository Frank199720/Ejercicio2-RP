
using Dapper;
using Microsoft.Extensions.Configuration;
using RP.Domain.Entities;
using RP.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Common.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(Product entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@nombre", entity.Nombre);
            parameters.Add("@stock", entity.Stock);
            parameters.Add("@precio", entity.Precio);
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var result = await connection.ExecuteAsync("SP_INSERT_PRODUCT", parameters, commandType: CommandType.StoredProcedure);
                    return result;

        }

        public async Task<int> DeleteAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var result = await connection.ExecuteAsync("SP_DELETE_PRODUCT", parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

       

        public async Task<IEnumerable<Product>> GetAllAsync(int pageNumber, int pageSize)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@offset", (pageNumber-1)*pageSize);
            parameters.Add("@pageSize", pageSize);

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Product>("SP_GET_ALL_PRODUCTS", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<Product>("SP_GET_PRODUCT_BY_ID", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<Product> GetByName(string productName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@name", productName);

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<Product>("SP_GET_PRODUCT_BY_NAME", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }

        }
        
        public async Task<int> GetCount()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>("SP_GET_COUNT_ALL", commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> UpdateAsync(Product entity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@nombre", entity.Nombre);
            parameters.Add("@stock", entity.Stock);
            parameters.Add("@precio", entity.Precio);
            parameters.Add("@id", entity.Id);
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var result = await connection.ExecuteAsync("SP_UPDATE_PRODUCT", parameters, commandType: CommandType.StoredProcedure);
            return result;
        }


    }
}

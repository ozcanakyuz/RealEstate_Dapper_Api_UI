using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Runtime.InteropServices;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRespository : ICategoryRepository
    {
        private readonly Context _context;
        public CategoryRespository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "Insert Into Category (CategoryName,CategoryStatus) " +
                "values (@categoryName,@categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategory(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                string query = "Delete From Category Where CategoryId = @Id";
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

    }
}

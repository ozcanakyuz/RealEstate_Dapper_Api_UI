using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }

        public async void CreateBottomGrid(CreateBottomGridDto bottomGridDto)
        {
            string query = "Insert Into BottomGrid (Icon,Title,Description) " +
                        "values (@icon,@title,@description)";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", bottomGridDto.Icon);
            parameters.Add("@title", bottomGridDto.Title);
            parameters.Add("@description", bottomGridDto.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteBottomGrid(int id)
        {
            string query = "Delete From BottomGrid Where BottomGridId = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = "Select * From BottomGrid";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<GetByIdBottomGridDto>> GetBottomGrid(int id)
        {
            string query = "Select * From BottomGrid Where BottomGridId = @Id";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetByIdBottomGridDto>(query, new { Id = id });
                return values.ToList();
            }
        }

        public async void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            string query = "Update BottomGrid Set Icon = @icon, Title = @title, Description = @description Where BottomGridId = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@icon", updateBottomGridDto.Icon);
            parameters.Add("@title", updateBottomGridDto.Title);
            parameters.Add("@description", updateBottomGridDto.Description);
            parameters.Add("@Id", updateBottomGridDto.BottomGridId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

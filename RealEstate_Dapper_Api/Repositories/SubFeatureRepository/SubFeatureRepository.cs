using Dapper;
using RealEstate_Dapper_Api.Dtos.SubFeatureDtos;
using RealEstate_Dapper_Api.Dtos.SubFeatureDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.SubFeatureRepository
{
    public class SubFeatureRepository : ISubFeatureRepository
    {
        private readonly Context _context;
        public SubFeatureRepository(Context context)
        {
            _context = context;
        }

        public async void CreateSubFeature(CreateSubFeatureDto createSubFeatureDto)
        {
            string query = "Insert Into SubFeature (Icon, Title, Description1, Description2) " +
                        "values (@icon, @title, @description1, @description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", createSubFeatureDto.Icon);
            parameters.Add("@title", createSubFeatureDto.Title);
            parameters.Add("@description1", createSubFeatureDto.Description1);
            parameters.Add("@description2", createSubFeatureDto.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async void DeleteSubFeature(int id)
        {
            string query = "Delete From SubFeature Where SubFeatureId = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }

        }

        public async Task<List<ResultSubFeatureDto>> GetAllSubFeatureAsync()
        {
            string query = "Select * From SubFeature";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultSubFeatureDto>(query);
                return values.ToList();
            }

        }

        public async Task<List<GetByIdSubFeatureDto>> GetSubFeature(int id)
        {
            string query = "Select * From SubFeature Where SubFeatureId = @Id";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetByIdSubFeatureDto>(query, new { Id = id });
                return values.ToList();
            }

        }

        public async void UpdateSubFeature(UpdateSubFeatureDto updateSubFeatureDto)
        {
            string query = "Update SubFeature Set Icon = @icon, Title = @title, Description1 = @description1, Description2 = @description2 Where SubFeatureId = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@icon", updateSubFeatureDto.Icon);
            parameters.Add("@title", updateSubFeatureDto.Title);
            parameters.Add("@description1", updateSubFeatureDto.Description1);
            parameters.Add("@description2", updateSubFeatureDto.Description2);
            parameters.Add("@Id", updateSubFeatureDto.SubFeatureId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }
}

﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreRepository : IWhoWeAreRepository
    {
        private readonly Context _context;

        public WhoWeAreRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            string query = "Insert Into WhoWeAreDetail (Title, Subtitle, Description1, Description2) " +
                            "values (@title, @subtitle, @description1, @description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createWhoWeAreDetailDto.Title);
            parameters.Add("@subtitle", createWhoWeAreDetailDto.Subtitle);
            parameters.Add("@description1", createWhoWeAreDetailDto.Description1);
            parameters.Add("@description2", createWhoWeAreDetailDto.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAreDetail(int id)
        {
            string query = "Delete From WhoWeAreDetail Where WhoWeAreDetailId = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "Select * From WhoWeAreDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<GetByIdWhoWeAreDeatailDto>> GetWhoWeAreDetail(int id)
        {
            string query = "Select * From WhoAreDetail Where WhoAreDetailId = @Id";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetByIdWhoWeAreDeatailDto>(query, new { Id = id });
                return values.ToList();
            }
        }

        public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            string query = "Update WhoWeAreDetail Set Title = @title, Subtitle = @subtitle, Description1 = @description1, Description2 = @description2 Where WhoWeAreDetailId = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@title", updateWhoWeAreDetailDto.Title);
            parameters.Add("@subtitle", updateWhoWeAreDetailDto.Subtitle);
            parameters.Add("@description1", updateWhoWeAreDetailDto.Description1);
            parameters.Add("@description2", updateWhoWeAreDetailDto.Description2);
            parameters.Add("@Id", updateWhoWeAreDetailDto.WhoWeAreDetailId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

    }
}

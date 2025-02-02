﻿using RealEstate_Dapper_Api.Dtos.BottomGridDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
        void CreateBottomGrid(CreateBottomGridDto bottomGridDto);
        void DeleteBottomGrid(int id);
        void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto);
        Task<List<GetByIdBottomGridDto>> GetBottomGrid(int id);
    }
}

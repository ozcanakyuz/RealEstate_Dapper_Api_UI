using RealEstate_Dapper_Api.Dtos.SubFeatureDtos;

namespace RealEstate_Dapper_Api.Repositories.SubFeatureRepository
{
    public interface ISubFeatureRepository
    {
        Task<List<ResultSubFeatureDto>> GetAllSubFeatureAsync();
        void CreateSubFeature(CreateSubFeatureDto createSubFeatureDto);
        void DeleteSubFeature(int id);
        void UpdateSubFeature(UpdateSubFeatureDto updateSubFeatureDto);
        Task<List<GetByIdSubFeatureDto>> GetSubFeature(int id);
    }
}

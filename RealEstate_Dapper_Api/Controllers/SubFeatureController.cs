using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.SubFeatureDtos;
using RealEstate_Dapper_Api.Repositories.SubFeatureRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubFeatureController : ControllerBase
    {
        private readonly ISubFeatureRepository _subFeatureRepository;

        public SubFeatureController(ISubFeatureRepository subFeatureRepository)
        {
            _subFeatureRepository = subFeatureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> SubFeatureList()
        {
            var values = await _subFeatureRepository.GetAllSubFeatureAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubFeature(CreateSubFeatureDto createSubFeatureDto)
        {
            _subFeatureRepository.CreateSubFeature(createSubFeatureDto);
            return Ok("SubFeature Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubFeature(int id)
        {
            _subFeatureRepository.DeleteSubFeature(id);
            return Ok("Silme işlemi başarılı.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubFeature(UpdateSubFeatureDto updateSubFeatureDto)
        {
            _subFeatureRepository.UpdateSubFeature(updateSubFeatureDto);
            return Ok("Güncelleme işlemi başarılı.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubFeature(int id)
        {
            var values = await _subFeatureRepository.GetSubFeature(id);
            return Ok(values);
        }
    }
}

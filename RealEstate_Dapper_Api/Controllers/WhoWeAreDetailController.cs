using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase
    {
        private readonly IWhoWeAreRepository _whoWeAreRepository;

        public WhoWeAreDetailController(IWhoWeAreRepository whoWeAreRepository)
        {
            _whoWeAreRepository = whoWeAreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> WhoWeAreDeatilList()
        {
            var values = await _whoWeAreRepository.GetAllWhoWeAreDetailAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto whoWeAreDetailDto)
        {
            _whoWeAreRepository.CreateWhoWeAreDetail(whoWeAreDetailDto);
            return Ok("Biz Kimiz Detay Eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
        {
            _whoWeAreRepository.DeleteWhoWeAreDetail(id);
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            _whoWeAreRepository.UpdateWhoWeAreDetail(updateWhoWeAreDetailDto);
            return Ok("Güncelleme Başarılı");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAreDetail(int id)
        {
            var values = await _whoWeAreRepository.GetWhoWeAreDetail(id);
            return Ok(values);
        }
    }
}


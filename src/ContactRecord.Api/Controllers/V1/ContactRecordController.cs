using ContactRecord.Application.DTOs;
using ContactRecord.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContactRecord.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ContactRecordController: ControllerBase
    {
        private readonly IContactRecordService _contactRecordService;

        public ContactRecordController(IContactRecordService contactRecordService)
        {
            _contactRecordService = contactRecordService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var mResult = await _contactRecordService.GetByIdAsync(id);
            if (mResult == null)
                return NotFound();

            return Ok(mResult);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var mResult = await _contactRecordService.GetAllAsync();
            if (mResult == null)
                return NotFound();

            return Ok(mResult);
        }

        [HttpGet]
        [Route("ByEmail/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var mResult = await _contactRecordService.GetByEmailAsync(email);
            return Ok(mResult);
        }

        [HttpGet]
        [Route("BySatateOrCity/{stateOrCity}")]
        public async Task<IActionResult> GetByStateOrCity(string stateOrCity)
        {
            var mResult = await _contactRecordService.GetByStateOrCityAsync(stateOrCity);
            return Ok(mResult);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] CreateContactRecordInput input)
        {
            await _contactRecordService.AddAsync(input);
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Update([FromBody] UpdateContactRecordInput input)
        {
            await _contactRecordService.UpdateAsync(input);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactRecordService.DeleteAsync(id);
            return Ok();
        }
    }
}

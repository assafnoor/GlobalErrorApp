using GlobalErrorApp.Excepetions;
using GlobalErrorApp.Models;
using GlobalErrorApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalErrorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriversController(IDriverService driverService)
        {
          _driverService = driverService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetDrivers()
        {
           var result= await _driverService.GetDrivers();
            return Ok(result);
        }
        [HttpGet("getById{id}")]
        public async Task<IActionResult> GetDriverById(int id)
        {
            var result = await _driverService.GetDriverById(id);

            if (result == null)
            {
               // return BadRequest();
                throw new NotFoundException("invalid ID");
            }
                
            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddDriver(Driver driver)
        {
            var result = await _driverService.Add(driver);
            return Ok(result);
        }

    }
}

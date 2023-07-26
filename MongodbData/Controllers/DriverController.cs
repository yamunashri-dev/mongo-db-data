using MongodbData.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace MongodbData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IMongoCollection<Driver> _collection;


        public DriverController(DriverContext driverContext)
        {
            _collection = driverContext.Drivers;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> Get()
        {
            var result = await _collection.Find(d => true).ToListAsync();
            return Ok(result);
        }



    }
}

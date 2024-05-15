using Microsoft.AspNetCore.Mvc;
using SalonAppointment.Server.Models;
using SalonAppointment.Server.Repository;
using SalonAppointment.Server.Repository.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalonAppointment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public ServiceController(IUnitOfWork uow)
        {
            _uow = uow;
        }


        // GET: api/<ServiceController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetAll()
        {
            var service = await _uow.ServiceRepository.FindAllAsync();
            return Ok(service);
        }

        // GET api/<ServiceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetById(int id)
        {
            var service = await _uow.ServiceRepository.FindByIdAsync(id);
            return Ok(service);
        }

        // POST api/<ServiceController>
        [HttpPost]
        public async Task<ActionResult<Service>> Post([FromBody] Service service)
        {
            await _uow.ServiceRepository.Create(service);
            _uow.Commit();
            return Ok(service);
        }

        // PUT api/<ServiceController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Service>> Put(int id, [FromBody] Service service)
        {
            if (service.Id != id)
            {
                return BadRequest("Id incorreto");
            }

            await _uow.ServiceRepository.Update(service);
            _uow.Commit();

            return Ok(service);
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Service>> Delete(int id)
        {
            var service = await _uow.ServiceRepository.FindByIdAsync(id);
            if (service == null)
            {
                return NotFound("Id incorreto");
            }
            await _uow.ServiceRepository.Delete(service);
            _uow.Commit();

            return Ok("Deletado com Sucesso");
        }
    }
}

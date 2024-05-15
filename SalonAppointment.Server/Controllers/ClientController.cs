using Microsoft.AspNetCore.Mvc;
using SalonAppointment.Server.Models;
using SalonAppointment.Server.Repository.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalonAppointment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public ClientController(IUnitOfWork uow)
        {
            _uow = uow;
        }


        // GET: api/<ClientController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            var client = await _uow.ClientRepository.FindAllAsync();
            return Ok(client);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Appointment>> GetById(Guid id)
        {
            var client = await _uow.ClientRepository.FindByIdAsync(id);
            if (client == null)
            { 
                return NotFound("Id não encontrado");
            }
            return Ok(client);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult<Appointment>> Post([FromBody] Client client)
        {
            await _uow.ClientRepository.Create(client);
            _uow.Commit();
            return Ok(client);
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Appointment>> Put(Guid id, [FromBody] Client client)
        {

            if (client.ClientId != id) 
            {
                return NotFound("Id incorreto");
            }

            await _uow.ClientRepository.Update(client);
            _uow.Commit();

            return Ok(client);
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Appointment>> Delete(Guid id)
        {

            var client = await _uow.ClientRepository.FindByIdAsync(id);
            if (client == null)
            {
                return NotFound("Id incorreto");
            }
            await _uow.ClientRepository.Delete(client);
            _uow.Commit();

            return Ok("Deletado com Sucesso");
        }
    }
}

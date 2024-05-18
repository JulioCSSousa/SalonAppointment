using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalonAppointment.Server.Models;
using SalonAppointment.Server.Repository.Interface;
using System.Diagnostics.Eventing.Reader;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalonAppointment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger _logger;

        public AppointmentController(IUnitOfWork uow, ILogger<AppointmentController> logger)
        {
            _uow = uow;
            _logger = logger;
        }


        // GET: api/<AppointmentController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAll()
        {
            var appointment = await _uow.AppointmentRepository.FindAllAsync();
            return Ok(appointment);
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Appointment>> GetById(Guid id)
        {

            var appoint = await _uow.AppointmentRepository.FindByIdAsync(id);
            if (appoint == null)
            {
                return NotFound("Id não encontrado");
            }
            return Ok(appoint);

        }

        // POST api/<AppointmentController>
        [HttpPost]
        public async Task<ActionResult<Appointment>> Post([FromBody] Appointment appointment)
        {
            try
            {
                await _uow.AppointmentRepository.Create(appointment);
            }
            catch (DuplicateWaitObjectException ex) { return BadRequest(ex); }
            _uow.Commit();
            return Ok(appointment);
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Appointment>> Put(Guid id, [FromBody] Appointment appointment)
        {

            if (appointment.AppointmentCode != id)
            {
                return NotFound("Id não encontrado");
            }
            await _uow.AppointmentRepository.Update(appointment);
            _uow.Commit();
            
            return Ok(appointment);
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Appointment>> Delete(Guid id)
        {

            var appointment = await _uow.AppointmentRepository.FindByIdAsync(id);
            if (appointment == null)
            {
                return NotFound("Id não encontrado");
            }
            var appoint = await _uow.AppointmentRepository.Delete(appointment);
            _uow.Commit();
            
            return Ok("Deletado com sucesso");
        }
    }
}

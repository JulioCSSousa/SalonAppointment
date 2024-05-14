using Microsoft.AspNetCore.Mvc;
using SalonAppointment.Server.Models;
using SalonAppointment.Server.Repository.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalonAppointment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public AppointmentController(IUnitOfWork uow)
        {
            _uow = uow;
        }


        // GET: api/<AppointmentController>
        [HttpGet]
        public async Task<IEnumerable<Appointment>> GetAll()
        {
            return await _uow.AppointmentRepository.FindAllAsync();
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                await _uow.AppointmentRepository.FindByIdAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound("Appointment not found"); 
            }
            return Ok(new List<Appointment>());
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Appointment appointment)
        {
            await _uow.AppointmentRepository.Create(appointment);
            _uow.Commit();
            return Ok(appointment);
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Appointment appointment)
        {

            var appoint = await _uow.AppointmentRepository.FindByIdAsync(id);
            if (appoint == null)
            {
                return NotFound("Appointment not found");
            }
            await _uow.AppointmentRepository.Update(id, appoint);
            _uow.Commit();
            
            return Ok(appointment);
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var appoint = await _uow.AppointmentRepository.FindByIdAsync(id);
            if (appoint == null)
            {
                return NotFound("Appointment not found");
            }
            await _uow.AppointmentRepository.Delete(appoint);
            _uow.Commit();
            
            return Ok(appoint);
        }
    }
}

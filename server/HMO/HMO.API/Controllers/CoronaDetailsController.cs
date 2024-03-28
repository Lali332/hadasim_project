using AutoMapper;
using HMO.API.Models;
using HMO.Core.Entities;
using HMO.Core.Services;
using HMO.Service;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoronaDetailsController : ControllerBase
    {
        private readonly ICoronaDetailsService _coronaDetailsService;
        private readonly IMapper _mapper;
        public CoronaDetailsController(ICoronaDetailsService coronaDetailsService, IMapper mapper)
        {
            _coronaDetailsService = coronaDetailsService;
            _mapper = mapper;
        }
        // GET: api/<CoronaDetailsController>
        [HttpGet]
        public ActionResult<List<CoronaDetails>> Get()
        {
            return Ok(_coronaDetailsService.GetCoronaDetails());
        }

        // GET api/<CoronaDetailsController>/5
        [HttpGet("{id}")]
        public ActionResult<CoronaDetails> Get(int id)
        {
            return Ok(_coronaDetailsService.GetCoronaDetailsById(id));  
        }

        // POST api/<CoronaDetailsController>
        [HttpPost]
        public ActionResult<CoronaDetails> Post([FromBody] CoronaModel c)
        {
            if (c.DataRecover <= c.DataSick)
            {
                return BadRequest("date recover before date sick");
            }
            if(c.FirstVaccination>DateTime.Now||c.SecondVaccination>DateTime.Now||c.ThirdVaccination>DateTime.Now||c.FourhVaccination>DateTime.Now||c.DataRecover>DateTime.Now||c.DataSick>DateTime.Now)
            {
                return BadRequest("date is not correct");
            }
            if(c.SecondVaccination<= c.FirstVaccination || c.ThirdVaccination <= c.SecondVaccination || c.FourhVaccination <= c.ThirdVaccination)
            {
                return BadRequest("date of vaccination is not correct");
            }
            var corona = new CoronaDetails();
            _mapper.Map(c, corona);
            _coronaDetailsService.AddCoronaDetails(corona);
            return Ok(corona);
        }

        // PUT api/<CoronaDetailsController>/5
        [HttpPut("{id}")]
        public ActionResult<CoronaDetails> Put(int id, [FromBody] CoronaModel c)
        {
            if (c.DataRecover <= c.DataSick)
            {
                return BadRequest("date recover before date sick");
            }
            if (c.FirstVaccination > DateTime.Now || c.SecondVaccination > DateTime.Now || c.ThirdVaccination > DateTime.Now || c.FourhVaccination > DateTime.Now || c.DataRecover > DateTime.Now || c.DataSick > DateTime.Now)
            {
                return BadRequest("date is not correct");
            }
            if (c.SecondVaccination <= c.FirstVaccination || c.ThirdVaccination <= c.SecondVaccination || c.FourhVaccination <= c.ThirdVaccination)
            {
                return BadRequest("date of vaccination is not correct");
            }
            var corona = _coronaDetailsService.GetCoronaDetailsById(id);
            if (corona is null)
            {
                return NotFound();
            }
            _mapper.Map(c, corona);
            _coronaDetailsService.UpDateCoronaDetails(id, corona);
            return Ok(corona);
        }

        // DELETE api/<CoronaDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _coronaDetailsService.DeleteCoronaDetails(id);
        }
    }
}

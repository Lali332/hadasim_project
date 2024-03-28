using AutoMapper;
using HMO.API.Models;
using HMO.Core.Dtos;
using HMO.Core.Entities;
using HMO.Core.Services;
using HMO.Service;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPersonalDetailsService _personalDetailsService;
        private readonly IMapper _mapper;
        public PatientsController(IPersonalDetailsService personalDetailsService, IMapper mapper)
        {
            _personalDetailsService = personalDetailsService;
            _mapper = mapper;
        }
        // GET: api/<personalDetailsController>
        [HttpGet]
        public ActionResult<List<PersonalDetailsDto>> Get()
        {
            var pDetails=_personalDetailsService.GetPersonalDetails();
            var url = MakeUrl();
            List<PersonalDetailsDto> pDetailsDto = _mapper.Map<IEnumerable<PersonalDetailsDto>>(pDetails, opt => opt.Items["Url"] = url).ToList();
            return Ok(pDetailsDto);
        }

        // GET api/<personalDetailsController>/5
        [HttpGet("{id}")]
        public ActionResult<PersonalDetails> Get(int id)
        {
            var pDetails = _personalDetailsService.GetPersonalDetailsById(id);
            var url = MakeUrl();
            var pDetailsDto = _mapper.Map<PersonalDetailsDto>(pDetails, opt => opt.Items["Url"] = url);
            return Ok(pDetailsDto);
        }
        //[HttpGet("{id}/Image", Name = "GetImageByMemberId")]
        [HttpGet("{id}/Image")]
        public  ActionResult GetFileById(int id)
        {
            var pDetails = _personalDetailsService.GetPersonalDetailsById(id);
            if (pDetails is null)
            {
                return NotFound();
            }
            if (pDetails.FileData is not null)
            {
                return File(pDetails.FileData, pDetails.FileType);
            }
            else
            {
                return NotFound();
            }
        }
        // POST api/<personalDetailsController>
        [HttpPost]
        public ActionResult<PersonalDetailsDto> Post([FromForm] PersonalModel p)
        {
            if (p.DateBirth > DateTime.Now)
            {
                return BadRequest("date is not valid");
            }
            var personal = new PersonalDetails();
            _mapper.Map(p, personal);
            if (p.ImageFile is not null)
            {
                try
                {
                    using (var stream = new MemoryStream())
                    {
                        p.ImageFile.CopyTo(stream);
                        personal.FileData = stream.ToArray();
                        personal.FileType = p.ImageFile.ContentType;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            _personalDetailsService.AddPersonalDetails(personal);
            var url = MakeUrl();
            var pDetailsDto = _mapper.Map<PersonalDetailsDto>(personal, opt => opt.Items["Url"] = url);
            return Ok(pDetailsDto);
        }

        // PUT api/<personalDetailsController>/5
        [HttpPut("{id}")]
        public ActionResult<PersonalDetailsDto> Put(int id, [FromForm] PersonalModel p)
        {
            var personal = _personalDetailsService.GetPersonalDetailsById(id);
            if(personal is null)
            {
                return NotFound();
            }
            _mapper.Map(p, personal);
            if (p.ImageFile is not null)
            {
                try
                {
                    using (var stream = new MemoryStream())
                    {
                        p.ImageFile.CopyTo(stream);
                        personal.FileData = stream.ToArray();
                        personal.FileType = p.ImageFile.ContentType;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            _personalDetailsService.UpDatePersonalDetails(id, personal);
            var url = MakeUrl();
            var pDetailsDto = _mapper.Map<PersonalDetailsDto>(personal, opt => opt.Items["Url"] = url);
            return Ok(pDetailsDto);
        }

        // DELETE api/<personalDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _personalDetailsService.DeletePersonalDetails(id);
        }

        private string MakeUrl()
        {
            var request = HttpContext.Request;
            var scheme = request.Scheme;
            var host = request.Host.Host;
            var port = request.Host.Port;
            var url = $"{scheme}://{host}:{port}/api/{HttpContext.Request.RouteValues["controller"]}/";
            return url;
        }
    }
}

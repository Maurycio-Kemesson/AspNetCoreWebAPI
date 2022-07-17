using AutoMapper;
using LibraryWda.API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LibraryWda.API.V1.Dtos;
using LibraryWda.API.Models;

namespace LibraryWda.API.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PublishingCompanyController : ControllerBase
    {
        public readonly IRepository _repo;

        public readonly IMapper _mapper;

        public PublishingCompanyController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var publishingscompanys = _repo.GetAllPublishingsCompanys();

            return Ok(_mapper.Map<IEnumerable<PublishingCompanyDto>>(publishingscompanys));
        }

        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(new PublishingCompanyDto());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var publishingcompany = _repo.GetAllPublishingCompanyByID(id);
            if (publishingcompany == null) return BadRequest("The publishing company was not found.");

            var publishingcompanyDto = _mapper.Map<PublishingCompanyDto>(publishingcompany);

            return Ok(publishingcompanyDto);
        }


        [HttpPost]
        public IActionResult Post(PublishingCompanyDto model)
        {

            var publishingcompany = _mapper.Map<PublishingCompany>(model);
            _repo.Add(publishingcompany);
            if (_repo.SaveChanges())
            {
                return Created($"/api/publishingcompany/{model.Id}", _mapper.Map<PublishingCompanyDto>(publishingcompany));
            }
            return BadRequest("Unregistered publishing company!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, PublishingCompanyDto model)
        {
            var publishingcompany = _repo.GetAllPublishingCompanyByID(id);
            if (publishingcompany == null) return BadRequest("The student was not found.");

            _mapper.Map(model, publishingcompany);

            _repo.Update(publishingcompany);
            if (_repo.SaveChanges())
            {
                return Created($"/api/publishingcompany/{model.Id}", _mapper.Map<PublishingCompanyDto>(publishingcompany));
            }
            return BadRequest("Publishing company not updated!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, PublishingCompanyDto model)
        {
            var publishingcompany = _repo.GetAllPublishingCompanyByID(id);
            if (publishingcompany == null) return BadRequest("The publishing company was not found.");

            _mapper.Map(model, publishingcompany);


            _repo.Update(publishingcompany);
            if (_repo.SaveChanges())
            {
                return Created($"/api/publishingcompany/{model.Id}", _mapper.Map<PublishingCompanyDto>(publishingcompany));
            }
            return BadRequest("Publishing company not updated!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publishingcompany = _repo.GetAllPublishingCompanyByID(id);
            if (publishingcompany == null) return BadRequest("The publishing company was not found.");

            _repo.Delete(publishingcompany);
            if (_repo.SaveChanges())
            {
                return Ok("Deleted publishing company!");
            }
            return BadRequest("Undeleted publishing company!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bsctmplt.BusinessLayer;
using Bsctmplt.EntityFrameworkCore;
using Bsctmplt.WebApi.Contracts.Sample;
using Bsctmplt.Dto.Sample;
using Bsctmplt.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bsctmplt.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class SampleController(ISampleRepository repository) : Controller
    {
        private readonly SampleBusinessLayer _BusinessLayer = new(repository);

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_BusinessLayer.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_BusinessLayer.GetValueById(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] SamplePostContract contract)
        {
            var errors = _BusinessLayer.Create((SampleDto)contract);

            if (errors.Any())
            {
                return UnprocessableEntity();
            }
            return Ok();
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] SamplePutContract contract)
        {
            var errors = _BusinessLayer.Update((SampleDto)contract);

            if (errors.Any())
            {
                return UnprocessableEntity();
            }
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var errors = _BusinessLayer.Delete(id);

            if (errors.Any())
            {
                return UnprocessableEntity();
            }
            return Ok();
        }
    }
}


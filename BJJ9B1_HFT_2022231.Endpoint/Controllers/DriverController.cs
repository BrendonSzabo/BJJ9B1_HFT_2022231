﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BJJ9B1_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        // GET: api/<DriverController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DriverController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DriverController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DriverController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

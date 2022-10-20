﻿using BJJ9B1_HFT_2022231.Logic;
using BJJ9B1_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BJJ9B1_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        IDriver logic;

        public DriverController(IDriver logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<Drivers> ReadAll()
        {
            return this.logic.ReadAll();
        }
        [HttpPost]
        public void Create([FromBody] Drivers value)
        {
            this.logic.Create(value);
        }
        [HttpGet("{id}")]
        public Drivers Read(int id)
        {
            return this.logic.Read(id);
        }
        [HttpPut]
        public void Update([FromBody] Drivers value)
        {
            this.logic.Update(value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}

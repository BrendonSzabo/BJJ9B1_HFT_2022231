using BJJ9B1_HFT_2022231.Logic;
using BJJ9B1_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BJJ9B1_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamPrincipalController : ControllerBase
    {
        ITeamPrincipal logic;

        public TeamPrincipalController(ITeamPrincipal logic)
        {
            this.logic = logic;
        }
        // GET: api/<TeamPrincipalController>
        [HttpGet]
        public IEnumerable<TeamPrincipals> ReadAll()
        {
            return logic.ReadAllTeamPrincipal();
        }

        // GET api/<TeamPrincipalController>/5
        [HttpGet("{id}")]
        public TeamPrincipals Read(int id)
        {
            return logic.ReadTeamPrincipal(id);
        }

        // POST api/<TeamPrincipalController>
        [HttpPost]
        public void Create([FromBody] TeamPrincipals value)
        {
            logic.CreateTeamPrincipal(value);
        }

        // PUT api/<TeamPrincipalController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] TeamPrincipals value)
        {
            logic.UpdateTeamPrincipal(value);
        }

        // DELETE api/<TeamPrincipalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.DeleteTeamPrincipal(id);
        }
    }
}

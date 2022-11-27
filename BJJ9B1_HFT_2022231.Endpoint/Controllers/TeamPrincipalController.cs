using BJJ9B1_HFT_2022231.Logic.Interface;
using BJJ9B1_HFT_2022231.Logic.Logic;
using BJJ9B1_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BJJ9B1_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamPrincipalsController : ControllerBase
    {
        ITeamPrincipal logic;

        public TeamPrincipalsController(ITeamPrincipal logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<TeamPrincipals> ReadAll()
        {
            return this.logic.ReadAllTeamPrincipal();
        }

        [HttpGet("{id}")]
        public TeamPrincipals Get(int id)
        {
            return this.logic.ReadTeamPrincipal(id);
        }

        [HttpPost]
        public void Create([FromBody] TeamPrincipals value)
        {
            this.logic.CreateTeamPrincipal(value);
        }

        [HttpPut]
        public void Update([FromBody] TeamPrincipals value)
        {
            this.logic.UpdateTeamPrincipal(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.DeleteTeamPrincipal(id);
        }
    }
}

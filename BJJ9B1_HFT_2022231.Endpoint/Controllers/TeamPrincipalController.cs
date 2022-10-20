using BJJ9B1_HFT_2022231.Logic;
using BJJ9B1_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BJJ9B1_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamPrincipalController : ControllerBase
    {
        ITeamPrincipal logic;

        public TeamPrincipalController(ITeamPrincipal logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<TeamPrincipals> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public TeamPrincipals Get(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] TeamPrincipals value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] TeamPrincipals value)
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

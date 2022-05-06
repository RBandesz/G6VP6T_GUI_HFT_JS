using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TireShop.Endpoint;
using TireShop.Logic;
using TireShop.Data;
using System.Collections.Generic;
using TireShop.Endpoint.Services;
using TireShop.Logic.Logics;
using TireShop.Logic.Logicinterfaces;
using TireShop.Data.Tables;

namespace TireSpecificationsShop.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TireSpecificationController : ControllerBase
    {
        ITireShopLogic logic;
        ILogicAdministration logicAdministration;
        IHubContext<SignalRHub> hub;

        public TireSpecificationController(ITireShopLogic logic, ILogicAdministration logicAdministration,IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.logicAdministration = logicAdministration;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<TireSpecification> ReadAll()
        {
            return this.logic.GetAllTireSpecifications();
        }

        [HttpGet("{id}")]
        public TireSpecification Read(int id)
        {
            return this.logic.GetTireSpecificationById(id);
        }

        [HttpPost]
        public void Create([FromBody] TireSpecification value)
        {
            this.logicAdministration.CrateNewTireSpecification(value);
            this.hub.Clients.All.SendAsync("TireSpecificationCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] TireSpecification value)
        {
            this.logicAdministration.UpdateTireSpec(value);
            this.hub.Clients.All.SendAsync("UpdatedTireSpecification", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var tireDelete = this.logic.GetTireSpecificationById(id);
            this.logicAdministration.RemoveNewTireSpecification(id);
            this.hub.Clients.All.SendAsync("TireSpecificationDeleted", tireDelete);
        }
    }
}

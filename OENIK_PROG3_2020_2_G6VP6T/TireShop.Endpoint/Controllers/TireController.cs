using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TireShop.Endpoint;
using TireShop.Logic;
using System.Collections.Generic;
using TireShop.Endpoint.Services;
using TireShop.Logic.Logics;
using TireShop.Logic.Logicinterfaces;
using TireShop.Data.Tables;


namespace TireShop.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TireController : ControllerBase
    {
        ITireShopLogic logic;
        ILogicAdministration logicAdministration;
        IHubContext<SignalRHub> hub;

        public TireController(ITireShopLogic logic, ILogicAdministration logicAdministration,IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.logicAdministration = logicAdministration;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Tire> ReadAll()
        {
            return this.logic.GetAllTires();
        }

        [HttpGet("{id}")]
        public Tire Read(int id)
        {
            return this.logic.GetTireById(id);
        }

        [HttpPost]
        public void Create([FromBody] Tire value)
        {
            this.logicAdministration.CrateNewTire(value);
            this.hub.Clients.All.SendAsync("TireCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Tire value)
        {
            this.logicAdministration.UpdateTire(value);
            this.hub.Clients.All.SendAsync("TireUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var tireDelete = this.logic.GetTireById(id);
            this.logicAdministration.RemoveNewTire(id);            
            this.hub.Clients.All.SendAsync("TireDeleted", tireDelete);
        }
    }
}

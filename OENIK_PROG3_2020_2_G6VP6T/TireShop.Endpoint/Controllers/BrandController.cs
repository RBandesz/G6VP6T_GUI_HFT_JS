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

namespace BrandShop.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        ITireShopLogic logic;
        ILogicAdministration logicAdministration;
        IHubContext<SignalRHub> hub;

        public BrandController(ITireShopLogic logic, ILogicAdministration logicAdministration,IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.logicAdministration = logicAdministration;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Brand> ReadAll()
        {
            return this.logic.GetAllBrands();
        }

        [HttpGet("{id}")]
        public Brand Read(int id)
        {
            return this.logic.GetBrandById(id);
        }

        [HttpPost]
        public void Create([FromBody] Brand value)
        {
            this.logicAdministration.CrateNewBrand(value);
            this.hub.Clients.All.SendAsync("BrandCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Brand value)
        {
            this.logicAdministration.UpdateBrand(value);
            this.hub.Clients.All.SendAsync("BrandUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var tireDelete = this.logic.GetBrandById(id);
            this.logicAdministration.RemoveNewBrand(id);
            this.hub.Clients.All.SendAsync("BrandDeleted", tireDelete);
        }
    }
}

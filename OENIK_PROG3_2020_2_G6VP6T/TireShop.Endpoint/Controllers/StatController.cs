using Microsoft.AspNetCore.Mvc;
using TireShop.Logic;
using System.Collections.Generic;

namespace MovieDbApp.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ITireShopLogic logic;

        public StatController(ITireShopLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IList<AvarageResult> AveragePerBrand()
        {
            return logic.BrandAvarages();
        }

        [HttpGet]
        public IList<TirePriceSUM> TirePriceSUMs()
        {
            return logic.TirePriceSUMs();
        }

        [HttpGet]
        public IList<TireByDiameter> TireByDiameters(int diameter)
        {
            return logic.TireByDiameters(diameter);
        }

        [HttpGet]
        public IList<TireRecommendation> TireRecommendations(int maxPrice, int width, int aspectRatio, int diameter)
        {
            return logic.TireRecommendations(maxPrice, width, aspectRatio, diameter);
        }

        [HttpGet]
        public IList<HQMadeofPlace> HQMadeofPlaces(string brandName, string tireName)
        {
            return logic.HQMadeofPlaces(brandName, tireName);
        }

    }
}

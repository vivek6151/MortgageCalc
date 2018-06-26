using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MortgageCalculator.Api.Services;

namespace MortgageCalculator.Api.Controllers
{
    public class MortgageController : ApiController
    {
        IMortgageService _mortgageService = null;
        public MortgageController()
        {
            _mortgageService = new MortgageService();
        }

        public MortgageController(IMortgageService mortgageService)
        {
            _mortgageService = mortgageService;
        }
        // GET: api/Mortgage
        public IEnumerable<Dto.Mortgage> Get()
        {
           return _mortgageService.GetAllMortgages();
        }

        // GET: api/Mortgage/5
        public Dto.Mortgage Get(int id)
        {
            return _mortgageService.GetAllMortgages().FirstOrDefault(x => x.MortgageId == id);
        }
    }
}

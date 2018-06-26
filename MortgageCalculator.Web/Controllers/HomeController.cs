using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using MortgageCalculator.Dto;
using System.Threading.Tasks;

namespace MortgageCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            string Baseurl = "http://localhost:49608/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage httpResponseMsg = await client.GetAsync("api/mortgage");
                //HttpResponseMessage httpResponseMsg = client.GetAsync("api/mortgage").GetAwaiter().GetResult();

                IEnumerable<Mortgage> mortgagesList = null;
                if (httpResponseMsg.IsSuccessStatusCode)
                {
                    var result = httpResponseMsg.Content.ReadAsStringAsync().Result;
                    //var result = httpResponseMsg.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    mortgagesList = JsonConvert.DeserializeObject<List<Mortgage>>(result);
                    if (mortgagesList != null && mortgagesList.Count() > 0)
                    {
                        mortgagesList = mortgagesList.OrderBy(m => m.MortgageType).ThenBy(m => m.InterestRepayment);
                    }
                }
                return View(mortgagesList);
            }
            //return View();
        }

    }
}
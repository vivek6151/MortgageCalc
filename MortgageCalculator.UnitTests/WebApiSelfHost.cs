using System.Web.Http;
using System.Web.Http.SelfHost;

namespace MortgageCalculator.UnitTests
{
    public class WebApiSelfHost
    {
        public void Start()
        {
            var config = new HttpSelfHostConfiguration("http://localhost:49068");

            config.Routes.MapHttpRoute(
                "DefaultApi", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
            }
        }
    }
}

using MortgageCalculator.Web.Controllers;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MortgageCalculator.UnitTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Positive_IndexTest()
        {
            try
            {
                //new WebApiSelfHost().Start();
                var controller = new HomeController();
                var actResult = controller.Index();
                actResult.Wait();
                var viewResult = actResult.Result as ViewResult;
                //var viewResult = actResult as ViewResult;
                Assert.That(viewResult.ViewName, Is.EqualTo(string.Empty));
                Assert.IsNotNull(viewResult.Model, "Model is null");
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}

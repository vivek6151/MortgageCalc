using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using MortgageCalculator.Api.Services;
using MortgageCalculator.Api.Controllers;

namespace MortgageCalculator.UnitTests
{
    [TestFixture]
    public class MortgageCalculatorTest
    {
        [Test]
        public void Positive_GetMortgages()
        {
            var mortgageService = new Mock<IMortgageService>();
            var items = new List<Dto.Mortgage>
                {
                    new Dto.Mortgage{MortgageId=1,MortgageType=Dto.MortgageType.Fixed, Name="Mortgage1"},
                    new Dto.Mortgage{MortgageId=2,MortgageType=Dto.MortgageType.Variable, Name="Mortgage2"},
                };
            mortgageService.Setup(x => x.GetAllMortgages()).Returns(() => items);

            var controller = new MortgageController(mortgageService.Object);
            var results = controller.Get();

            Assert.AreEqual(items.Count, results.Count(), "Mortgages count mismatch");
        }
    }
}

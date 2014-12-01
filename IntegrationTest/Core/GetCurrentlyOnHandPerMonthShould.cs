using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;
using WildCard.Core.Interfaces;

namespace IntegrationTest.Core
{
    [TestClass]
    public class GetCurrentlyOnHandPerMonthShould
    {
        [TestMethod]
        public void GetCurrentlyOnHandForAllMonths()
        {
            var container = new Container(c => c.AddRegistry<LiteratureAssistant.CompositionRoot.DefaultRegistry>());

            var countService = container.GetInstance<ICountService>();

            var result = countService.GetCurrentlyOnHandPerMonth();

            Assert.IsNotNull(result);
        }
    }
}

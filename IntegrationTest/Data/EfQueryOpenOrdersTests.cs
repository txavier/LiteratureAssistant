using Microsoft.VisualStudio.TestTools.UnitTesting;
using LiteratureAssistant.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using LiteratureAssistant.Core.Interfaces;

namespace LiteratureAssistant.Infrastructure.Data.Tests
{
    [TestClass()]
    public class EfQueryOpenOrdersTests
    {
        [TestMethod()]
        public void QueryOpenOrdersTest()
        {
            var container = new Container(c => c.AddRegistry<LiteratureAssistant.CompositionRoot.DefaultRegistry>());

            var queryOpenOrders = container.GetInstance<IEfQueryOpenOrders>();

            var result = queryOpenOrders.QueryOpenOrders();

            Assert.IsNotNull(result);
        }
    }
}
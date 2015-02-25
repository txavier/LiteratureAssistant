using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildCard.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap.AutoMocking;
using Rhino.Mocks;
using WildCard.Core.Models;
using AutoClutch.Auto.Service.Interfaces;
using AutoClutch.Auto.Repo.Interfaces;
using XavierEnterpriseLibrary.Core.Interfaces;

namespace WildCard.Core.Services.Tests
{
    [TestClass()]
    public class TemplateAttributeService_GetBarcodeViewModels_Should
    {
        [TestMethod()]
        public void GetBarcodeViewModels()
        {
            // Arrange.
            var autoMocker = new RhinoAutoMocker<ItemService>(MockMode.AAA);

            var partNumberTemplateAttribute = new templateAttribute() 
                { 
                    templateAttributeId = 1, 
                    itemTemplateId = 1, 
                    templateAttributeName = "Part #", 
                    barcode = true, 
                };

            var partDescriptionTemplateAttribute =new templateAttribute() 
                { 
                    templateAttributeId = 2, 
                    itemTemplateId = 1, 
                    templateAttributeName = "Part Description", 
                    barcode = false, 
                };

            var itemAttributeList = new List<itemAttribute>()
            {
                new itemAttribute() 
                { 
                    itemAttributeId = 1, 
                    itemId = 1, 
                    templateAttributeId = 1, 
                    value = "234213", 
                    templateAttribute = partNumberTemplateAttribute 
                },
                new itemAttribute() 
                { 
                    itemAttributeId = 2, 
                    itemId = 1, 
                    templateAttributeId = 2, 
                    value = "Xavier Wrench", 
                    templateAttribute = partDescriptionTemplateAttribute 
                },
            };

            partNumberTemplateAttribute.itemAttributes = itemAttributeList;

            partDescriptionTemplateAttribute.itemAttributes = itemAttributeList;

            var templateAttributeList = new List<templateAttribute>()
            {
                partNumberTemplateAttribute,
            };

            autoMocker.Get<IRepository<templateAttribute>>().Stub(x => x.Get(
                filter: Arg<System.Linq.Expressions.Expression<Func<templateAttribute, bool>>>.Is.Anything,
                distinctBy: Arg<Func<System.Linq.IQueryable<templateAttribute>, IEnumerable<templateAttribute>>>.Is.Anything,
                orderBy: Arg<Func<System.Linq.IQueryable<templateAttribute>, System.Linq.IOrderedQueryable<templateAttribute>>>.Is.Anything,
                maxBy: Arg<Func<IEnumerable<templateAttribute>, IEnumerable<templateAttribute>>>.Is.Anything,
                skip: Arg<int?>.Is.Anything,
                take: Arg<int?>.Is.Anything,
                includeProperties: Arg<string>.Is.Anything
            )).Return(templateAttributeList);

            var ItemService = autoMocker.ClassUnderTest;

            // Act.
            var barcodes = ItemService.GetBarcodeViewModels(1).ToList();

            // Assert.
            Assert.IsTrue(barcodes != null);

            autoMocker.Get<IImageManipulationService>()
                .AssertWasCalled(x => x.GetBarcodeDataUri(
                    Arg<ZXing.BarcodeFormat>.Is.Equal(ZXing.BarcodeFormat.CODE_128)
                    , Arg<string>.Is.Equal("234213")
                    , rotateFlipType: Arg<System.Drawing.RotateFlipType>.Is.Anything),
                options => options.Repeat.Times(1));
        }
    }
}

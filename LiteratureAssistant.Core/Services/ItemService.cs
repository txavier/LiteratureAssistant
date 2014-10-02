using Auto.Repo.Interfaces;
using Auto.Service.Interfaces;
using Auto.Service.Services;
using LiteratureAssistant.Core.Interfaces;
using LiteratureAssistant.Core.Models;
using LiteratureAssistant.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureAssistant.Core.Services
{
    public class ItemService : Service<item>, IItemService
    {
        private readonly IRepository<item> _itemRepository;
        
        private readonly IService<itemAttribute> _itemAttributeService;

        private readonly IService<templateAttribute> _templateAttributeService;

        public int ItemTemplateId { get; set; }

        public ItemService(IRepository<item> itemRepository, IService<itemAttribute> itemAttributeService,
            IService<templateAttribute> templateAttributeService) :
            base(itemRepository)
        {
            _itemRepository = itemRepository;

            _itemAttributeService = itemAttributeService;

            _templateAttributeService = templateAttributeService;
        }

        public async Task<item> AddRange(IEnumerable<itemAttribute> newItemAttributes, int? itemTemplateId = null)
        {
            var item = new item() { itemTemplateId = itemTemplateId ?? ItemTemplateId };

            Add(item);

            newItemAttributes = newItemAttributes.Select(i =>
            {
                i.itemId = item.itemId;
                return i;
            }).ToList();

            var newItemAttributesEnumerable = await _itemAttributeService.AddRangeAsync(newItemAttributes);

            return item;
        }

        public List<itemAttribute> DynamicItemAttributeToItemAttribute(dynamic newItemAttributesDynamic, int? itemTemplateId = null)
        {
            //var childCategory = data1.item.itemAttributes["Child Category"];
            
            var templateAttributes = _templateAttributeService.Get(filter: i => i.itemTemplateId == (itemTemplateId ?? ItemTemplateId));

            var newItemAttributes = new List<itemAttribute>();

            foreach (var templateAttribute in templateAttributes)
            {
                var value = newItemAttributesDynamic.item.itemAttributes[templateAttribute.templateAttributeName];

                newItemAttributes.Add(new itemAttribute()
                {
                    templateAttributeId = templateAttribute.templateAttributeId,

                    value = value
                });
            }

            return newItemAttributes;
        }
    }
}

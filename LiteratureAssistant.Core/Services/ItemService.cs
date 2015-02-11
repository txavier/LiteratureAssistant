using AutoClutch.Auto.Repo.Interfaces;
using AutoClutch.Auto.Service.Interfaces;
using AutoClutch.Auto.Service.Services;
using WildCard.Core.Interfaces;
using WildCard.Core.Models;
using WildCard.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildCard.Core.Services
{
    public class ItemService : Service<item>, IItemService
    {
        private readonly IRepository<item> _itemRepository;
        
        private readonly IService<itemAttribute> _itemAttributeService;

        private readonly IService<templateAttribute> _templateAttributeService;
        
        private readonly IService<organization> _organizationService;

        public int ItemTemplateId { get; set; }

        public ItemService(IRepository<item> itemRepository, IService<itemAttribute> itemAttributeService,
            IService<templateAttribute> templateAttributeService, IService<organization> organizationService) :
            base(itemRepository)
        {
            _itemRepository = itemRepository;

            _itemAttributeService = itemAttributeService;

            _templateAttributeService = templateAttributeService;

            _organizationService = organizationService;

            var defaultOrganization = _organizationService.Get(i => i.defaultOrganization.HasValue ? i.defaultOrganization.Value : true).FirstOrDefault();

            ItemTemplateId = defaultOrganization == null || !defaultOrganization.itemTemplates.Any() ? 
                0 : defaultOrganization.itemTemplates.FirstOrDefault().itemTemplateId;
        }

        /// <summary>
        /// This method adds an entire range of item attributes to the database.
        /// </summary>
        /// <param name="newItemAttributes"></param>
        /// <param name="itemTemplateId"></param>
        /// <returns>Returns null if the entity values are required but are not supplied.</returns>
        public async Task<item> AddRange(IEnumerable<itemAttribute> newItemAttributes, int? itemTemplateId = null)
        {
            if(!newItemAttributes.Any())
            {
                return null;
            }

            var item = new item() { itemTemplateId = itemTemplateId ?? ItemTemplateId };
            
            Add(item);

            // Check to make sure required values are included.
            foreach(var itemAttribute in newItemAttributes)
            {
                if(IsValueRequired(itemAttribute) && string.IsNullOrEmpty(itemAttribute.value))
                {
                    return null;
                }
            }

            newItemAttributes = newItemAttributes.Select(i =>
            {
                i.itemId = item.itemId;
                return i;
            }).ToList();

            var newItemAttributesEnumerable = await _itemAttributeService.AddRangeAsync(newItemAttributes);

            return item;
        }

        public bool IsValueRequired(itemAttribute itemAttribute)
        {
            var required = _templateAttributeService.Get(filter: i => i.templateAttributeId == itemAttribute.templateAttributeId).SingleOrDefault().required;

            var result = required ?? false;

            return result;
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
                    itemId = newItemAttributesDynamic.item.itemId ?? 0,

                    templateAttributeId = templateAttribute.templateAttributeId,

                    value = value
                });
            }

            return newItemAttributes;
        }

        public ItemViewModel ToViewModel(item item)
        {
            var items = new List<item> { item };

            var results = ToViewModels(items);

            return results.FirstOrDefault();
        }

        public IEnumerable<ItemViewModel> ToViewModels(IEnumerable<item> items)
        {
            var results = items.Select(i => new ItemViewModel
            {
                itemLabel = GetItemLabel(i),
                itemId = i.itemId,
                itemTemplateId = i.itemTemplateId,
                itemTemplate = new ItemTemplateViewModel { itemTemplateName = i.itemTemplate.itemTemplateName },
                itemAttributes = i.itemAttributes.Select(j => new ItemAttributeViewModel
                {
                    templateAttribute = new { templateAttributeName = j.templateAttribute.templateAttributeName },
                    value = j.value
                })
            });

            return results;
        }

        public string GetItemLabel(item item)
        {
            if(item == null || !item.itemAttributes.Any())
            {
                return null;
            }
            
            var result = item.itemAttributes.Select(j => j.value).Aggregate((current, next) => current + " - " + next);

            return result;
        }

        /// <summary>
        /// This method assumes that all of the itemAttributes have the same itemId.
        /// </summary>
        /// <param name="itemAttributes"></param>
        /// <returns></returns>
        public List<itemAttribute> UpdateRange(List<itemAttribute> itemAttributes)
        {
            if(!itemAttributes.Any())
            {
                return itemAttributes;
            }

            var firstItemAttribute = itemAttributes.First();

            //var item = GetSingle(itemAttributes.First().itemId);
            var items = Get(filter: i => i.itemId == firstItemAttribute.itemId).ToList();

            var item = items.SingleOrDefault();

            // Set all the item attribute id's to the correct value from the stored ones in the database.
            itemAttributes = itemAttributes.Select(i => 
                {
                    i.item = item;
                    i.itemAttributeId = item.itemAttributes == null || !item.itemAttributes.Any() ? 0 : item.itemAttributes.
                        FirstOrDefault(j => j.templateAttributeId == i.templateAttributeId).itemAttributeId;
                    i.templateAttribute = _templateAttributeService.Find(i.templateAttributeId);
                    return i;
                }).ToList();

            // Make sure each item attribute has the correct item attribute id.
            foreach(var itemAttribute in itemAttributes)
            {
                _itemAttributeService.Update(itemAttribute);
            }

            return itemAttributes;
        }

        public async new Task<item> DeleteAsync(int id, bool dontSave = false)
        {
            var item = await FindAsync(id);

            item.itemAttributes.ToList().ForEach(i => _itemAttributeService.Delete(i, dontSave: true));

            item = await base.DeleteAsync(id, dontSave: dontSave);

            return item;
        }

        public item ToEntity(ItemViewModel itemViewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<item> ToEntities(IEnumerable<ItemViewModel> itemViewModels)
        {
            var results = itemViewModels.Select(i => new item
            {
                itemId = i.itemId,
                itemTemplateId = i.itemTemplateId,
                itemTemplate = new itemTemplate { itemTemplateName = i.itemTemplate.itemTemplateName },
                itemAttributes = i.itemAttributes.Select(j => new itemAttribute
                {
                    templateAttribute = new templateAttribute { templateAttributeName = j.templateAttribute.ToString() },
                    value = j.value
                }).ToList()
            });

            return results;
        }
    }
}

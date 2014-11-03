using AutoClutch.Auto.Service.Interfaces;
using LiteratureAssistant.Core.Models;
using System;
namespace LiteratureAssistant.Core.Interfaces
{
    public interface IItemService : IService<item>
    {
        System.Threading.Tasks.Task<LiteratureAssistant.Core.Models.item> AddRange(System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.Models.itemAttribute> newItemAttributes, int? itemTemplateId = null);
        System.Threading.Tasks.Task<LiteratureAssistant.Core.Models.item> DeleteAsync(int id, bool dontSave = false);
        System.Collections.Generic.List<LiteratureAssistant.Core.Models.itemAttribute> DynamicItemAttributeToItemAttribute(dynamic newItemAttributesDynamic, int? itemTemplateId = null);
        string GetItemLabel(LiteratureAssistant.Core.Models.item item);
        int ItemTemplateId { get; set; }
        System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.Models.item> ToEntities(System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.ViewModels.ItemViewModel> itemViewModels);
        LiteratureAssistant.Core.Models.item ToEntity(LiteratureAssistant.Core.ViewModels.ItemViewModel itemViewModel);
        LiteratureAssistant.Core.ViewModels.ItemViewModel ToViewModel(LiteratureAssistant.Core.Models.item item);
        System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.ViewModels.ItemViewModel> ToViewModels(System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.Models.item> items);
        System.Collections.Generic.List<LiteratureAssistant.Core.Models.itemAttribute> UpdateRange(System.Collections.Generic.List<LiteratureAssistant.Core.Models.itemAttribute> itemAttributes);
    }
}


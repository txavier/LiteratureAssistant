using AutoClutch.Auto.Service.Interfaces;
using WildCard.Core.Models;
using System;
namespace WildCard.Core.Interfaces
{
    public interface IItemService : IService<item>
    {
        System.Threading.Tasks.Task<WildCard.Core.Models.item> AddRange(System.Collections.Generic.IEnumerable<WildCard.Core.Models.itemAttribute> newItemAttributes, int? itemTemplateId = null);
        System.Threading.Tasks.Task<WildCard.Core.Models.item> DeleteAsync(int id, bool dontSave = false);
        System.Collections.Generic.List<WildCard.Core.Models.itemAttribute> DynamicItemAttributeToItemAttribute(dynamic newItemAttributesDynamic, int? itemTemplateId = null);
        string GetItemLabel(WildCard.Core.Models.item item);
        int ItemTemplateId { get; set; }
        System.Collections.Generic.IEnumerable<WildCard.Core.Models.item> ToEntities(System.Collections.Generic.IEnumerable<WildCard.Core.ViewModels.ItemViewModel> itemViewModels);
        WildCard.Core.Models.item ToEntity(WildCard.Core.ViewModels.ItemViewModel itemViewModel);
        WildCard.Core.ViewModels.ItemViewModel ToViewModel(WildCard.Core.Models.item item);
        System.Collections.Generic.IEnumerable<WildCard.Core.ViewModels.ItemViewModel> ToViewModels(System.Collections.Generic.IEnumerable<WildCard.Core.Models.item> items);
        System.Collections.Generic.List<WildCard.Core.Models.itemAttribute> UpdateRange(System.Collections.Generic.List<WildCard.Core.Models.itemAttribute> itemAttributes);
        System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.ViewModels.BarcodeViewModel> GetBarcodeViewModels(int itemId);
    }
}


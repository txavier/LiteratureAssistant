using Auto.Service.Interfaces;
using LiteratureAssistant.Core.Models;
using System;
namespace LiteratureAssistant.Core.Interfaces
{
    public interface IItemService : IService<item>
    {
        int ItemTemplateId { get; set; }
        System.Threading.Tasks.Task<item> AddRange(System.Collections.Generic.IEnumerable<itemAttribute> newItemAttributes, int? itemTemplateId = null);
        System.Collections.Generic.List<itemAttribute> DynamicItemAttributeToItemAttribute(dynamic newItemAttributesDynamic, int? itemTemplateId = null);
    }
}

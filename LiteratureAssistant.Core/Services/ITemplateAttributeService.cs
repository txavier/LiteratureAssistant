using AutoClutch.Auto.Service.Interfaces;
using LiteratureAssistant.Core.Models;
using System;
namespace LiteratureAssistant.Core.Services
{
    public interface ITemplateAttributeService : IService<templateAttribute>
    {
        System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.Models.templateAttribute> ToEntities(System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.Models.TemplateAttributeViewModel> templateAttributeViewModels);
        LiteratureAssistant.Core.Models.templateAttribute ToEntity(LiteratureAssistant.Core.Models.TemplateAttributeViewModel templateAttributeViewModel);
        LiteratureAssistant.Core.Models.TemplateAttributeViewModel ToViewModel(LiteratureAssistant.Core.Models.templateAttribute templateAttribute);
        System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.Models.TemplateAttributeViewModel> ToViewModels(System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.Models.templateAttribute> templateAttributes);
    }
}

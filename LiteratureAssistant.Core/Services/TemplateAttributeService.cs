using AutoClutch.Auto.Repo.Interfaces;
using AutoClutch.Auto.Service.Services;
using LiteratureAssistant.Core.Interfaces;
using LiteratureAssistant.Core.Models;
using LiteratureAssistant.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omu.ValueInjecter;

namespace LiteratureAssistant.Core.Services
{
    public class TemplateAttributeService : Service<templateAttribute>, ITemplateAttributeService
    {
        private readonly IRepository<templateAttribute> _templateAttributeRepository;

        public TemplateAttributeService(IRepository<templateAttribute> templateAttributeRepository)
            : base(templateAttributeRepository)
        {
            _templateAttributeRepository = templateAttributeRepository;
        }

        public TemplateAttributeViewModel ToViewModel(templateAttribute templateAttribute)
        {
            var result = (TemplateAttributeViewModel)(new TemplateAttributeViewModel()).InjectFrom(templateAttribute);

            return result;
        }

        public IEnumerable<TemplateAttributeViewModel> ToViewModels(IEnumerable<templateAttribute> templateAttributes)
        {
            var results = templateAttributes.Select(i => ToViewModel(i));

            return results;
        }

        public templateAttribute ToEntity(TemplateAttributeViewModel templateAttributeViewModel)
        {
            var result = (templateAttribute)(new templateAttribute()).InjectFrom(templateAttributeViewModel);

            return result;
        }

        public IEnumerable<templateAttribute> ToEntities(IEnumerable<TemplateAttributeViewModel> templateAttributeViewModels)
        {
            var results = templateAttributeViewModels.Select(i => ToEntity(i));

            return results;
        }
    }
}

using AutoClutch.Auto.Service.Interfaces;
using LiteratureAssistant.Core.Models;
using System;

namespace LiteratureAssistant.Core.Interfaces
{
    public interface IUserService : IService<user>
    {
        System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.Models.user> ToEntities(System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.ViewModels.UserViewModel> userViewModels);
        LiteratureAssistant.Core.Models.user ToEntity(LiteratureAssistant.Core.ViewModels.UserViewModel userViewModel);
        LiteratureAssistant.Core.ViewModels.UserViewModel ToViewModel(LiteratureAssistant.Core.Models.user user);
        System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.ViewModels.UserViewModel> ToViewModels(System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.Models.user> users);
    }
}

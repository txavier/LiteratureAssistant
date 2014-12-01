using AutoClutch.Auto.Service.Interfaces;
using WildCard.Core.Models;
using System;

namespace WildCard.Core.Interfaces
{
    public interface IUserService : IService<user>
    {
        System.Collections.Generic.IEnumerable<WildCard.Core.Models.user> ToEntities(System.Collections.Generic.IEnumerable<WildCard.Core.ViewModels.UserViewModel> userViewModels);
        WildCard.Core.Models.user ToEntity(WildCard.Core.ViewModels.UserViewModel userViewModel);
        WildCard.Core.ViewModels.UserViewModel ToViewModel(WildCard.Core.Models.user user);
        System.Collections.Generic.IEnumerable<WildCard.Core.ViewModels.UserViewModel> ToViewModels(System.Collections.Generic.IEnumerable<WildCard.Core.Models.user> users);
    }
}

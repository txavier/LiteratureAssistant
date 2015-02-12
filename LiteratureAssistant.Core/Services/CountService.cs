﻿using AutoClutch.Auto.Repo.Interfaces;
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
    public class CountService : Service<count>, ICountService
    {
        private readonly IRepository<count> _countRepository;

        private readonly IItemService _itemService;

        public CountService(IRepository<count> countRepository, IItemService itemService)
            : base(countRepository)
        {
            _countRepository = countRepository;

            _itemService = itemService;
        }

        public CountViewModel ToViewModel(count count)
        {
            var counts = new List<count>() { count };

            var result = ToViewModels(counts).SingleOrDefault();

            return result;
        }

        public IEnumerable<CountViewModel> ToViewModels(IEnumerable<count> counts)
        {
            var result = counts.Select(i =>  new CountViewModel
            {
                itemLabel = i.item.itemAttributes.Select(j => j.value).Aggregate((current, next) => current + " - " + next),

                countId = i.countId,

                currentlyOnHand = i.currentlyOnHand,

                currentlyOnHandDate = i.currentlyOnHandDate.HasValue ? i.currentlyOnHandDate.Value.ToShortDateString() : null, 

                itemId = i.itemId,

                received = i.received,

                receivedDate = i.receivedDate.HasValue ? i.receivedDate.Value.ToShortDateString() : null
            });

            return result;
        }

        public count ToEntity(CountViewModel countViewModel)
        {
            var countViewModels = new List<CountViewModel>() { countViewModel };

            var result = ToEntities(countViewModels).SingleOrDefault();

            return result;
        }

        public IEnumerable<count> ToEntities(IEnumerable<CountViewModel> countViewModels)
        {
            DateTime receivedDate = new DateTime();

            DateTime currentlyOnHandDate = new DateTime();

            var result = countViewModels.Select(i => new count
            {
                countId = i.countId,

                currentlyOnHand = i.currentlyOnHand,

                currentlyOnHandDate = i.currentlyOnHand.HasValue ? 
                    (DateTime.TryParse(i.currentlyOnHandDate, out currentlyOnHandDate) ? currentlyOnHandDate : (DateTime?)null) :
                    null,

                itemId = i.itemId == 0 && !string.IsNullOrEmpty(i.itemLabel) ? (_itemService.GetAll().Where(j => _itemService.GetItemLabel(j) == i.itemLabel).SingleOrDefault().itemId) : i.itemId,

                received = i.received,

                receivedDate = i.received.HasValue ?
                    (DateTime.TryParse(i.receivedDate, out receivedDate) ? receivedDate : (DateTime?)null) :
                    null,
            }).ToList();

            return result;
        }
        
        public object GetCurrentlyOnHandPerMonth()
        {
            var result = Get().GroupBy(i => i.currentlyOnHandDate.HasValue ? i.currentlyOnHandDate.Value.Month : -1);

            return result;
        }

        public CountViewModel ToNewCountViewModel(int itemId)
        {
            // The Get method on the generic service was not used because the 
            // order by seems to have a problem with it as of the time of this
            // writing 2/12/2014.
            var lastCount = Get(filter: i => i.itemId == itemId).OrderBy(i => i.currentlyOnHandDate).LastOrDefault();

            var newCount = new count()
            {
                countId = 0,
                currentlyOnHand = lastCount.currentlyOnHand,
                currentlyOnHandDate = DateTime.Now,
                itemId = lastCount.itemId,
            };

            var newCountViewModel = ToViewModel(newCount);

            newCountViewModel.barcodeTemplateAttributeName = lastCount.item.itemAttributes.Where(i => i.templateAttribute.barcode).FirstOrDefault() == null ?
                                                lastCount.item.itemAttributes.FirstOrDefault().templateAttribute.templateAttributeName :
                                                lastCount.item.itemAttributes.Where(i => i.templateAttribute.barcode).FirstOrDefault().templateAttribute.templateAttributeName;

            return newCountViewModel;
        }

        public CountViewModel AddCount(CountViewModel countViewModel)
        {
            throw new NotImplementedException();            
        }

        public CountViewModel SubtractCount(CountViewModel countViewModel)
        {
            throw new NotImplementedException();
        }
    }
}

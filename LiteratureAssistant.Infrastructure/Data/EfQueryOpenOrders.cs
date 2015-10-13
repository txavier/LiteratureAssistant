using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteratureAssistant.Data;
using WildCard.Core.Models;
using LiteratureAssistant.Core.ViewModels;
using LiteratureAssistant.Core.Interfaces;

namespace LiteratureAssistant.Infrastructure.Data
{
    public class EfQueryOpenOrders : IEfQueryOpenOrders
    {
        private readonly LiteratureAssistantDbContext _context;

        public EfQueryOpenOrders(LiteratureAssistant.Data.LiteratureAssistantDbContext context)
        {
            _context = context;
        }

        public IEnumerable<LiteratureAssistant.Core.ViewModels.OrderByItemViewModel> QueryOpenOrders()
        {
            var result =
                _context.orders
                .Where(i => i.date > (_context.orders
                                        .Where(k => k.orderSent ?? false)
                                        .OrderByDescending(j => j.date)
                                        .Select(m => m.date)
                                        .FirstOrDefault()))
                .Select(i => new
                {
                    itemId = i.itemId,
                    language = i.language ?? "English",
                    quantity = i.quantity,
                    item = i.item,
                    user1 = i.user1
                })
                .GroupBy(i => new { i.itemId, i.language })
                .ToList()
                .Select(i => new OrderByItemViewModel
                {
                    itemId = i.Key.itemId,
                    language = i.Key.language,
                    quantity = i.Select(j => j.quantity ?? 1)
                            .ToList()
                            .Aggregate((current, next) => current + next),
                    name = i.Select(j => j.item).SelectMany(j => j.itemAttributes.Where(k => k.templateAttribute.templateAttributeName == "Name")).FirstOrDefault().value,
                    itemNumber = i.Select(j => j.item).SelectMany(j => j.itemAttributes.Where(k => k.templateAttribute.templateAttributeName == "Item Number")).FirstOrDefault().value,
                    orderFor = i.Select(j => j.user1.firstName + " " + j.user1.lastName)
                                .ToList()
                                .Aggregate((current, next) => current + ", " + next),
                    onHand = null
                });

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LiteratureAssistant.Core.Models;
using LiteratureAssistant.Data;
using StructureMap;
using AutoClutch.Auto.Service;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;
using AutoClutch.Auto.Service.Interfaces;
using WildCard.Core.Interfaces;
using WildCard.Core.Models;
using LiteratureAssistant.DependencyResolution;

namespace LiteratureAssistant.Controllers
{
    [RoutePrefix("api/itemsApi")]
    public class itemsApiController : ApiController
    {
        private LiteratureAssistantDbContext db = new LiteratureAssistantDbContext();

        private readonly IItemService _itemService;
        
        private readonly IService<itemAttribute> ItemAttributeService;

        private readonly IService<templateAttribute> TemplateAttributeService;

        public itemsApiController()
        {
            IContainer container = IoC.Initialize();

            _itemService = container.GetInstance<IItemService>();

            ItemAttributeService = container.GetInstance<IService<itemAttribute>>();

            TemplateAttributeService = container.GetInstance<IService<templateAttribute>>();
        }

        //[ResponseType(typeof(List<ItemViewModel>))]
        // GET: api/itemsApi
        public IHttpActionResult Getitems()
        {
            try
            {
                var lightResultList = _itemService.ToViewModels(_itemService.GetAll());

                return Ok(lightResultList);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // GET: api/itemsApi/5
        //[ResponseType(typeof(ItemViewModel))]
        public IHttpActionResult Getitem(int id)
        {
            try
            {
                var item = _itemService.Find(id);

                //if (item == null)
                //{
                //    return NotFound();
                //}

                var itemViewModel = _itemService.ToViewModel(item);

                return Ok(itemViewModel);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // PUT: api/itemsApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putitem(int id, item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.itemId)
            {
                return BadRequest();
            }

            db.Entry(item).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!itemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("GetBarcodes/{itemId}")]
        public IHttpActionResult GetBarcodes(int itemId)
        {
            var barcodes = _itemService.GetBarcodeViewModels(itemId);

            return Ok(barcodes);
        }

        // POST: api/itemsApi
        //[ResponseType(typeof(List<itemAttribute>))]
        public IHttpActionResult Postitem(JObject data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newItemAttributes = _itemService.DynamicItemAttributeToItemAttribute(data);

                var updatedItems = _itemService.UpdateRange(newItemAttributes.Where(i => i.itemId != 0).ToList());

                var newItems = _itemService.AddRange(newItemAttributes.Where(i => i.itemId == 0).ToList());

                return Ok(newItems);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // DELETE: api/itemsApi/5
        [ResponseType(typeof(item))]
        public async Task<IHttpActionResult> Deleteitem(int id)
        {
            try
            {
                var item = await _itemService.DeleteAsync(id);

                return Ok(item);

                //item item = await db.items.FindAsync(id);
                //if (item == null)
                //{
                //    return NotFound();
                //}

                //db.items.Remove(item);
                //await db.SaveChangesAsync();

                //return Ok(item);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool itemExists(int id)
        {
            return db.items.Count(e => e.itemId == id) > 0;
        }
    }
}
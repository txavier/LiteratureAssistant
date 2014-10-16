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
using Auto.Service;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;
using Auto.Service.Interfaces;
using LiteratureAssistant.Core.Interfaces;
using LiteratureAssistant.Core.ViewModels;
using LiteratureAssistant.Core.Services;

namespace LiteratureAssistant.Controllers
{
    public class itemsApiController : ApiController
    {
        private LiteratureAssistantDbContext db = new LiteratureAssistantDbContext();

        private readonly IItemService _itemService;
        
        private readonly IService<itemAttribute> ItemAttributeService;
        
        private readonly IService<templateAttribute> TemplateAttributeService;

        public itemsApiController(IContainer container)
        {
            _itemService = container.GetInstance<IItemService>();

            _itemService.ItemTemplateId = 4; // This item template id indicates literature.

            ItemAttributeService = container.GetInstance<IService<itemAttribute>>();

            TemplateAttributeService = container.GetInstance<IService<templateAttribute>>();
        }

        //[ResponseType(typeof(List<ItemViewModel>))]
        // GET: api/itemsApi
        public HttpResponseMessage Getitems()
        {
            try
            {
                var lightResultList = ItemService.ToViewModels(_itemService.GetAll()).ToList();

                return this.Request.CreateResponse(
                    HttpStatusCode.OK,
                    lightResultList.ToArray());
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        // GET: api/itemsApi/5
        //[ResponseType(typeof(ItemViewModel))]
        public HttpResponseMessage Getitem(int id)
        {
            try
            {
                var item = _itemService.Find(id);

                //if (item == null)
                //{
                //    return NotFound();
                //}

                var itemViewModel = ItemService.ToViewModel(item);

                return this.Request.CreateResponse(HttpStatusCode.OK, itemViewModel);
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

                //dynamic data1 = data;

                var newItemAttributes = _itemService.DynamicItemAttributeToItemAttribute(data);

                var updatedItems = _itemService.UpdateRange(newItemAttributes.Where(i => i.itemId != 0).ToList());

                var newItems = _itemService.AddRange(newItemAttributes.Where(i => i.itemId == 0).ToList());

                return CreatedAtRoute("DefaultApi", new { }, newItems);
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
            catch (Exception)
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
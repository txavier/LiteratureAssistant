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

namespace LiteratureAssistant.Controllers
{
    public class itemsApiController : ApiController
    {
        private LiteratureAssistantDbModel db = new LiteratureAssistantDbModel();

        private readonly IItemService ItemService;
        
        private readonly IService<itemAttribute> ItemAttributeService;
        
        private readonly IService<templateAttribute> TemplateAttributeService;

        public itemsApiController(IContainer container)
        {
            ItemService = container.GetInstance<IItemService>();

            ItemService.ItemTemplateId = 4; // This item template id indicates literature.

            ItemAttributeService = container.GetInstance<IService<itemAttribute>>();

            TemplateAttributeService = container.GetInstance<IService<templateAttribute>>();
        }

        // GET: api/itemsApi
        public HttpResponseMessage Getitems()
        {
            var lightResultList = ItemService.GetAll().Select(i => new 
            {
                itemId = i.itemId,
                itemTemplateId = i.itemTemplateId,
                itemTemplate = new { itemTemplateName = i.itemTemplate.itemTemplateName },
                itemAttributes = i.itemAttributes.Select(j => new
                {
                    templateAttribute = new { templateAttributeName = j.templateAttribute.templateAttributeName },
                    value = j.value
                })
            });

            return this.Request.CreateResponse(
                HttpStatusCode.OK,
                lightResultList);
        }

        // GET: api/itemsApi/5
        [ResponseType(typeof(item))]
        public async Task<IHttpActionResult> Getitem(int id)
        {
            item item = await db.items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
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
        public async Task<IHttpActionResult> Postitem(JObject data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //dynamic data1 = data;

            var newItemAttributes = ItemService.DynamicItemAttributeToItemAttribute(data);

            var item = await ItemService.AddRange(newItemAttributes);

            return CreatedAtRoute("DefaultApi", new { }, item);
        }

        // DELETE: api/itemsApi/5
        [ResponseType(typeof(item))]
        public async Task<IHttpActionResult> Deleteitem(int id)
        {
            item item = await db.items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            db.items.Remove(item);
            await db.SaveChangesAsync();

            return Ok(item);
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
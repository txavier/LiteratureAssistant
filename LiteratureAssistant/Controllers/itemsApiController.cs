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
using Auto.WebApiController;
using System.Runtime.Serialization;

namespace LiteratureAssistant.Controllers
{
    public class itemsApiController : ApiController
    {
        private LiteratureAssistantDbModel db = new LiteratureAssistantDbModel();

        private readonly IApiController<item> apiController;

        public itemsApiController()
        {
            apiController = ObjectFactory.GetInstance<IApiController<item>>();
        }

        // GET: api/itemsApi
        public HttpResponseMessage Getitems()
        {
            var lightResultList = apiController.Get().Select(i => new 
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
            //return db.items;
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
        [ResponseType(typeof(item))]
        public async Task<IHttpActionResult> Postitem(item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.items.Add(item);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = item.itemId }, item);
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
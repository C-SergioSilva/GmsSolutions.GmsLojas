using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GmsSolutions.DBreposotorio.Context;
using GmsSolutions.Entities;

namespace GmsSolutions.UI.Controllers
{
    public class CategoriaAPIController : ApiController
    {
        private LojaContext db = new LojaContext();

        // GET: api/CategoriaAPI
        public IQueryable<CategoriaPg> GetCategoriaPgs()
        {
            return db.CategoriaPgs;
        }

        // GET: api/CategoriaAPI/5
        [ResponseType(typeof(CategoriaPg))]
        public IHttpActionResult GetCategoriaPg(int id)
        {
            CategoriaPg categoriaPg = db.CategoriaPgs.Find(id);
            if (categoriaPg == null)
            {
                return NotFound();
            }

            return Ok(categoriaPg);
        }

        // PUT: api/CategoriaAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategoriaPg(int id, CategoriaPg categoriaPg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoriaPg.Id)
            {
                return BadRequest();
            }

            db.Entry(categoriaPg).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaPgExists(id))
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

        // POST: api/CategoriaAPI
        [ResponseType(typeof(CategoriaPg))]
        public IHttpActionResult PostCategoriaPg(CategoriaPg categoriaPg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CategoriaPgs.Add(categoriaPg);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categoriaPg.Id }, categoriaPg);
        }

        // DELETE: api/CategoriaAPI/5
        [ResponseType(typeof(CategoriaPg))]
        public IHttpActionResult DeleteCategoriaPg(int id)
        {
            CategoriaPg categoriaPg = db.CategoriaPgs.Find(id);
            if (categoriaPg == null)
            {
                return NotFound();
            }

            db.CategoriaPgs.Remove(categoriaPg);
            db.SaveChanges();

            return Ok(categoriaPg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriaPgExists(int id)
        {
            return db.CategoriaPgs.Count(e => e.Id == id) > 0;
        }
    }
}
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
using WebApiProyectoFinal;

namespace WebApiProyectoFinal.Controllers
{
    public class CiudadanoesController : ApiController
    {
        private Proyecto_FinalEntities db = new Proyecto_FinalEntities();

        // GET: api/Ciudadanoes
        public IQueryable<Ciudadano> GetCiudadanos()
        {
            return db.Ciudadanos;
        }

        // GET: api/Ciudadanoes/5
        [ResponseType(typeof(Ciudadano))]
        public IHttpActionResult GetCiudadano(int id)
        {
            Ciudadano ciudadano = db.Ciudadanos.Find(id);
            if (ciudadano == null)
            {
                return NotFound();
            }

            return Ok(ciudadano);
        }

        // PUT: api/Ciudadanoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCiudadano(int id, Ciudadano ciudadano)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ciudadano.Id_Ciudadanos)
            {
                return BadRequest();
            }

            db.Entry(ciudadano).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CiudadanoExists(id))
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

        // POST: api/Ciudadanoes
        [ResponseType(typeof(Ciudadano))]
        public IHttpActionResult PostCiudadano(Ciudadano ciudadano)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ciudadanos.Add(ciudadano);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CiudadanoExists(ciudadano.Id_Ciudadanos))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ciudadano.Id_Ciudadanos }, ciudadano);
        }

        // DELETE: api/Ciudadanoes/5
        [ResponseType(typeof(Ciudadano))]
        public IHttpActionResult DeleteCiudadano(int id)
        {
            Ciudadano ciudadano = db.Ciudadanos.Find(id);
            if (ciudadano == null)
            {
                return NotFound();
            }

            db.Ciudadanos.Remove(ciudadano);
            db.SaveChanges();

            return Ok(ciudadano);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CiudadanoExists(int id)
        {
            return db.Ciudadanos.Count(e => e.Id_Ciudadanos == id) > 0;
        }
    }
}
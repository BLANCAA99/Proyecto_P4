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
    public class VacunasxCiudadanoesController : ApiController
    {
        private Proyecto_FinalEntities db = new Proyecto_FinalEntities();

        // GET: api/VacunasxCiudadanoes
        public IQueryable<VacunasxCiudadano> GetVacunasxCiudadanoes()
        {
            return db.VacunasxCiudadanoes;
        }

        // GET: api/VacunasxCiudadanoes/5
        [ResponseType(typeof(VacunasxCiudadano))]
        public IHttpActionResult GetVacunasxCiudadano(int id)
        {
            VacunasxCiudadano vacunasxCiudadano = db.VacunasxCiudadanoes.Find(id);
            if (vacunasxCiudadano == null)
            {
                return NotFound();
            }

            return Ok(vacunasxCiudadano);
        }

        // PUT: api/VacunasxCiudadanoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVacunasxCiudadano(int id, VacunasxCiudadano vacunasxCiudadano)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vacunasxCiudadano.Numero_Dosis)
            {
                return BadRequest();
            }

            db.Entry(vacunasxCiudadano).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacunasxCiudadanoExists(id))
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

        // POST: api/VacunasxCiudadanoes
        [ResponseType(typeof(VacunasxCiudadano))]
        public IHttpActionResult PostVacunasxCiudadano(VacunasxCiudadano vacunasxCiudadano)
        {
            vacunasxCiudadano.Fecha_Aplicacion = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VacunasxCiudadanoes.Add(vacunasxCiudadano);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VacunasxCiudadanoExists(vacunasxCiudadano.Numero_Dosis))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vacunasxCiudadano.Numero_Dosis }, vacunasxCiudadano);
        }

        // DELETE: api/VacunasxCiudadanoes/5
        [ResponseType(typeof(VacunasxCiudadano))]
        public IHttpActionResult DeleteVacunasxCiudadano(int id)
        {
            VacunasxCiudadano vacunasxCiudadano = db.VacunasxCiudadanoes.Find(id);
            if (vacunasxCiudadano == null)
            {
                return NotFound();
            }

            db.VacunasxCiudadanoes.Remove(vacunasxCiudadano);
            db.SaveChanges();

            return Ok(vacunasxCiudadano);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VacunasxCiudadanoExists(int id)
        {
            return db.VacunasxCiudadanoes.Count(e => e.Numero_Dosis == id) > 0;
        }
    }
}
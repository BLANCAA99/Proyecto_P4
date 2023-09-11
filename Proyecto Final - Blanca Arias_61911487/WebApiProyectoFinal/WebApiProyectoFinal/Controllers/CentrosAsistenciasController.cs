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
    public class CentrosAsistenciasController : ApiController
    {
        private Proyecto_FinalEntities db = new Proyecto_FinalEntities();

        // GET: api/CentrosAsistencias
        public IQueryable<CentrosAsistencia> GetCentrosAsistencias()
        {
            return db.CentrosAsistencias;
        }

        // GET: api/CentrosAsistencias/5
        [ResponseType(typeof(CentrosAsistencia))]
        public IHttpActionResult GetCentrosAsistencia(int id)
        {
            CentrosAsistencia centrosAsistencia = db.CentrosAsistencias.Find(id);
            if (centrosAsistencia == null)
            {
                return NotFound();
            }

            return Ok(centrosAsistencia);
        }

        // PUT: api/CentrosAsistencias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCentrosAsistencia(int id, CentrosAsistencia centrosAsistencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != centrosAsistencia.Id_Asistencia)
            {
                return BadRequest();
            }

            db.Entry(centrosAsistencia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CentrosAsistenciaExists(id))
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

        // POST: api/CentrosAsistencias
        [ResponseType(typeof(CentrosAsistencia))]
        public IHttpActionResult PostCentrosAsistencia(CentrosAsistencia centrosAsistencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CentrosAsistencias.Add(centrosAsistencia);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CentrosAsistenciaExists(centrosAsistencia.Id_Asistencia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = centrosAsistencia.Id_Asistencia }, centrosAsistencia);
        }

        // DELETE: api/CentrosAsistencias/5
        [ResponseType(typeof(CentrosAsistencia))]
        public IHttpActionResult DeleteCentrosAsistencia(int id)
        {
            CentrosAsistencia centrosAsistencia = db.CentrosAsistencias.Find(id);
            if (centrosAsistencia == null)
            {
                return NotFound();
            }

            db.CentrosAsistencias.Remove(centrosAsistencia);
            db.SaveChanges();

            return Ok(centrosAsistencia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CentrosAsistenciaExists(int id)
        {
            return db.CentrosAsistencias.Count(e => e.Id_Asistencia == id) > 0;
        }
    }
}
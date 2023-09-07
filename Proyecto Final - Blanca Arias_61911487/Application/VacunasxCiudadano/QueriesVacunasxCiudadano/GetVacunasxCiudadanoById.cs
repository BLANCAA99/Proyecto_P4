using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.VacunasxCiudadano.QueriesVacunasxCiudadano
{
    public class GetVacunasxCiudadanoById
    {
        private readonly Proyecto_FinalEntities db;

        public GetVacunasxCiudadanoById()
        {
            this.db = new Proyecto_FinalEntities();
        }
        public GetVacunasxCiudadanoByIdModel Execute(int codigo)
        {
            var VacunasxCiudadanoes = this.db.VacunasxCiudadanoes.FirstOrDefault(x => x.Numero_Dosis == codigo);
            var model = new GetVacunasxCiudadanoByIdModel { Numero_Dosis = VacunasxCiudadanoes.Numero_Dosis, Ciudadano_ID = VacunasxCiudadanoes.Ciudadano_ID, Centro_Asistencia_ID = VacunasxCiudadanoes.Centro_Asistencia_ID, Codigo_Vacuna = VacunasxCiudadanoes.Codigo_Vacuna, Fecha_Aplicacion = VacunasxCiudadanoes.Fecha_Aplicacion };
            return model;
        }
    }
}

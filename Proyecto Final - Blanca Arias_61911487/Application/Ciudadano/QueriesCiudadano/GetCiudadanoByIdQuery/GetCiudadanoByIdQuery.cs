using Applicacion.Ciudadano.QueriesCiudadano.GetCiudadanoByIdQuery;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.Ciudadano.QueriesCiudadano.GetCiudadanoByIdQuery
{
    public class GetCiudadanoByIdQuery
    {
        private readonly Proyecto_FinalEntities db;

        public GetCiudadanoByIdQuery()
        {
            this.db = new Proyecto_FinalEntities();
        }
        public GetCiudadanoByIdQueryModel Execute(int codigo)
        {
            var Ciudadano = this.db.Ciudadanos.FirstOrDefault(x => x.Id_Ciudadanos == codigo);
            var model = new GetCiudadanoByIdQueryModel { Id_Ciudadanos = Ciudadano.Id_Ciudadanos, Nombre_Completo = Ciudadano.Nombre_Completo, Fecha_Nacimiento = Ciudadano.Fecha_Nacimiento, Edad = Ciudadano.Edad, Genero = Ciudadano.Genero, Telefono = Ciudadano.Telefono, Direccion_Domicilio = Ciudadano.Direccion_Domicilio, Estado_Civil = Ciudadano.Estado_Civil, Enfermedades_Base = Ciudadano.Enfermedades_Base };
            return model;
        }
    }
}

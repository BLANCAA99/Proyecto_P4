using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.Vacuna.QueriesVacuna.GetVacunaByIdQuery
{
    public class GetVacunaByIdQuery
    {
        private readonly Proyecto_FinalEntities db;

        public GetVacunaByIdQuery()
        {
            this.db = new Proyecto_FinalEntities();
        }
        public GetVacunaByIdQueryModel Execute(int codigo)
        {
            var Vacuna = this.db.Vacunas.FirstOrDefault(x => x.Codigo == codigo);
            var model = new GetVacunaByIdQueryModel { Codigo = Vacuna.Codigo, Nombre = Vacuna.Nombre, Fabricante = Vacuna.Fabricante, Fecha_Emision = Vacuna.Fecha_Emision, Fecha_Vencimiento = Vacuna.Fecha_Vencimiento, Numero_Lote = Vacuna.Numero_Lote, Estatus = Vacuna.Estatus };
            return model;
        }
    }
}

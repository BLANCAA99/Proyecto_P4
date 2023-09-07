using Applicacion.CentrosAsistencia.Map;
using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Applicacion.CentrosAsistencia.Commands.CreateAsistenciaCommand
{
    public class CreateAsistenciaCommand : DB
    {
       // private readonly Proyecto_FinalEntities db;

        public CreateAsistenciaCommand() : base()
        {
        //    this.db = new Proyecto_FinalEntities();
        }
        public void Execute(CreateAsistenciaCommandModel model)
        {
            DataAccess.CentrosAsistencia asistencia  = AutoMapperCentrosAsistencia.getMapper()
                                                                                  .Map<DataAccess.CentrosAsistencia>(model);
            this.db.CentrosAsistencias.Add(asistencia);
            this.db.SaveChanges();
        }
    }
}

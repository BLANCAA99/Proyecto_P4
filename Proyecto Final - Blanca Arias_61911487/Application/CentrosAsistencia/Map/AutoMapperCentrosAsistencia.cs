using Applicacion.CentrosAsistencia.Commands.CreateAsistenciaCommand;
using Applicacion.CentrosAsistencia.Commands.UpdateAsistenciaCommand;
using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.CentrosAsistencia.Map
{
    public class AutoMapperCentrosAsistencia : Profile 
    {
        public AutoMapperCentrosAsistencia()
        {

            CreateMap<CreateAsistenciaCommandModel, DataAccess.CentrosAsistencia>();
            CreateMap<UpdateAsistenciaCommandModel, DataAccess.CentrosAsistencia>();
            // Adicione outros mapeamentos conforme necessário.
        }
        public static IMapper getMapper()
        {
          return  new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperCentrosAsistencia>()).CreateMapper();
        }
    }
}

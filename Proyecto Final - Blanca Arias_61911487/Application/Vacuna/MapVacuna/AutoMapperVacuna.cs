using Applicacion.Vacuna.Commands.CreateVacunaCommand;
using Applicacion.Vacuna.Commands.UpdateVacunaCommand;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.Vacuna.MapVacuna
{
    public class AutoMapperVacuna : Profile
    {
        public AutoMapperVacuna()
        {

            CreateMap<CreateVacunaCommandModel, DataAccess.Vacuna>();
            CreateMap<UpdateVacunaCommandModel, DataAccess.Vacuna>();
            // Adicione outros mapeamentos conforme necessário.
        }
        public static IMapper getMapper()
        {
            return new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperVacuna>()).CreateMapper();
        }
    }
}

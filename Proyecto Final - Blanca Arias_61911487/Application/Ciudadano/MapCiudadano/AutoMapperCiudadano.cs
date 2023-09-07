using Applicacion.Ciudadano.Commands.CreateCiudadanoCommand;
using Applicacion.Ciudadano.Commands.UpdateCiudadanoCommand;
using Applicacion.Ciudadano.MapCiudadano;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.Ciudadano.MapCiudadano
{
    public class AutoMapperCiudadano : Profile
    {
        public AutoMapperCiudadano()
        {

            CreateMap<CreateCiudadanoCommandModel, DataAccess.Ciudadano>();
            CreateMap<UpdateCiudadanoCommandModel, DataAccess.Ciudadano>();
            // Adicione outros mapeamentos conforme necessário.
        }
        public static IMapper getMapper()
        {
            return new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperCiudadano>()).CreateMapper();
        }
    }
}

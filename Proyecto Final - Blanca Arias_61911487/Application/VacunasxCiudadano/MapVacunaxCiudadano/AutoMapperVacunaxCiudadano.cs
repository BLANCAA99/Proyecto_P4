using Applicacion.VacunasxCiudadano.Commands.CreateVacunasxCiudadanoCommand;
using Applicacion.VacunasxCiudadano.Commands.UpdateVacunasxCiudadanoCommand;
using Applicacion.VacunasxCiudadano.MapVacunaxCiudadano;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.VacunasxCiudadano.MapVacunaxCiudadano
{
    public class AutoMapperVacunaxCiudadano : Profile
    {
        public AutoMapperVacunaxCiudadano()
        {

            CreateMap<CreateVacunasxCiudadanoCommand, DataAccess.VacunasxCiudadano>();
            CreateMap<UpdateVacunasxCiudadanoCommand, DataAccess.VacunasxCiudadano>();
            // Adicione outros mapeamentos conforme necessário.
        }
        public static IMapper getMapper()
        {
            return new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperVacunaxCiudadano>()).CreateMapper();
        }
    }
}

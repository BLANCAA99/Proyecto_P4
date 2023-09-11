using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiProyectoFinal.Controllers
{

    public class CentroAsistencia
    {
        public int Id_Asistencia { get; set; }
        public string Descripcion { get; set; }
    }
    public class LoginViewModel
    {
        public List<CentroAsistencia> centrosAsistencia { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applicacion.Usuarios.Queries.GetUserByIdQuery;
using Applicacion.CentrosAsistencia.QueriesAsistencia.GetAttendanceByIdQuery;
using WebApiProyectoFinal.Controllers;

namespace WebApiProyectoFinal
{
    public class Auth
    {
        public int codUsuario { get; set; }

        public string nomRol { get; set; }


        public string nomUsuario { get; set; }

        public int codCentroAsistencia { get; set; }

        public string centroAsistencia { get; set; }
        public static Auth currentAuth { get; set; }

        public static bool isAuth { get; set; }


        public static void login(int codUsuario, string password,int codCentro)
        {
            const string codRolDigitador = "2";
            /*GetUserByIdQuery getUserByIdQuery = new GetUserByIdQuery();
            GetUserByIdQueryModel usuario = getUserByIdQuery.Execute(codUsuario);

            if( usuario == null) throw new Exception("No existe el usuario: "+ codUsuario);
            if( usuario.Contraseña != password) throw new Exception("La contraseña es incorrecta, intenta de nuevo");
            if( usuario.Rol != codRolDigitador) throw new Exception("Solo un usuario digitador puede iniciar sesion en la web app.");
            //Si el inicio de sesion es correcto entonces guardamos el usuario y sus datos en una clase estatica*/

            var getAsistenciaByIdQueryModel = new GetAsistenciaByIdQuery();
            //var centroAsistencia = getAsistenciaByIdQuery.Execute(codCentro);
            var centroAsistencia = "Centro de salud"; 
            var newCurrentAuth = new Auth();
            newCurrentAuth.codUsuario = codUsuario;
           // newCurrentAuth.nomUsuario = usuario.NombreCompleto;
            newCurrentAuth.nomRol = "Digitador";
            newCurrentAuth.codCentroAsistencia = codCentro;
            newCurrentAuth.centroAsistencia = centroAsistencia;
            Auth.currentAuth = newCurrentAuth;
            Auth.isAuth = true;
        }

        public static void logout()
        {
            Auth.currentAuth = null;
            Auth.isAuth = false;
        }
    }
}

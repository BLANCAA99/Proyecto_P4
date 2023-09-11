using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiProyectoFinal.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public IHttpActionResult Login([FromBody] LoginModel loginModel)
        {
            try
            {
                int codigoUsuario = Convert.ToInt32(loginModel.username);
                int centroAsistencia = Convert.ToInt32(loginModel.centroasistencia);
                Auth.login(codigoUsuario, loginModel.password, centroAsistencia);
                return Ok(new { success = true });
            }
            catch (Exception e)
            {

                return Ok(new { success = false, message = e.Message });
            }
        }

        [Route("api/logout")]
        [HttpPost]
        public IHttpActionResult Logout()
        {
            try
            {
                Auth.logout();
                return Ok(new { success = true });
            }
            catch (Exception e)
            {
                return Ok(new { success = false, message = e.Message });
            }
        }
    }
}

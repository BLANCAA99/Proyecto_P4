using DataAccess;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion.Usuarios.Queries.GetAllUsersQuery
{
    public class GetAllUsersQuery
    {
        private readonly Proyecto_FinalEntities db;

        public GetAllUsersQuery()
        {
            this.db = new Proyecto_FinalEntities();
        }
       public List<GetAllUsersQueryModel> Execute()
        {
            List<GetAllUsersQueryModel> list = this.db.Usuarios.Select(x => new GetAllUsersQueryModel { Codigo = x.Codigo, NumeroIdentidad = x.NumeroIdentidad, NombreCompleto = x.NombreCompleto, Rol = x.Rol }).ToList();
            return list;
        }
    }
}

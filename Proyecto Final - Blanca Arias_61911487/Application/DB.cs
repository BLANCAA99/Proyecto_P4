using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicacion
{
    public class DB
    {
        protected readonly Proyecto_FinalEntities db;
        public DB()
        {
            this.db = new Proyecto_FinalEntities();
        }

    }
}

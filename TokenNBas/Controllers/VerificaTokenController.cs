using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TokenNBas.Models;

namespace TokenNBas.Controllers
{
    public class VerificaTokenController : ApiController
    {

        public Boolean VerificacionDeToken(String token)
        {
            using (TestEntities db = new TestEntities())
            {
                if (db.usuarios.Where(d => d.token == token && d.estatus == true).Count() > 0)
                    return true;
            }

            return false;
        }

    }
}

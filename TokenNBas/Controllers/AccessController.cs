using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TokenNBas.Models;
using TokenNBas.Models.ServiciosC;

namespace TokenNBas.Controllers
{
    public class AccessController : ApiController
    {
        TestEntities db = new TestEntities();

        [Route("api/usuario")]
        [HttpPost]
        public Respuesta Login([FromBody] ModelGSUsuarios modelo)
        {

            Respuesta respuesta = new Respuesta();
            respuesta.result = 0;

            try
            {
                var lst = db.usuarios.Where(d => d.email == modelo.email && d.psw == modelo.psw && d.estatus == true);

                if (lst.Count() > 0)
                {
                    respuesta.result = 1;
                    respuesta.data = Guid.NewGuid().ToString();
                    respuesta.message = "Todo salio bien";

                    usuarios rsUsuario = lst.First();
                    rsUsuario.token = (String)respuesta.data;

                    db.Entry(rsUsuario).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    respuesta.message = "error 1";
                }

            }
            catch (Exception ex)
            {
                
                respuesta.message = "ocurrio un error";
            }


            //return Request.CreateResponse(HttpStatusCode.OK,
            //    db.usuarios.Where(usr => usr.nombre == "adrian garcia"));

            return respuesta;
        }
    }
}

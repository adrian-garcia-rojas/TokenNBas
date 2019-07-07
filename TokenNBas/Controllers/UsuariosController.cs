using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TokenNBas.Models.ServiciosC;
using TokenNBas.Models;

namespace TokenNBas.Controllers
{
    public class UsuariosController : VerificaTokenController
    {

        [Route("api/usuario/autorizacion")]
        [HttpPost]
        public Respuesta GetUsuarios([FromBody]ModelVerificaToken model)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.result = 0;

            if (!VerificacionDeToken(model.token))
            {
                respuesta.message = "No autorizado";
                return respuesta;
            }
                

            try
            {
                using (TestEntities db = new TestEntities())
                {
                    List<ModelListaDeUsuarios> listaDeUsuarios = (
                                     from d in db.usuarios
                                     where d.email != null
                                     select new ModelListaDeUsuarios
                                     {
                                         id = d.usuarioId,
                                         nombre = d.nombre,
                                         email = d.email
                                     }).ToList();

                    respuesta.data = listaDeUsuarios;
                }
            }
            catch (Exception ex)
            {
                respuesta.message = "Ocurri un error en la peticion";
            }

            return respuesta;
        }
    }
}

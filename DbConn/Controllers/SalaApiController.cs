using DbConn.Data;
using DbConn.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DbConn.Controllers
{
    public class SalaApiController : ApiController
    {

        private SalaContext db = new SalaContext();


        // GET: api/SalaApi
        public IEnumerable<Sala> Get()
        {
            return db.Salas.ToList();
        }

        // GET: api/SalaApi/5
        public HttpResponseMessage Get(int id)
        {
           try
           {
                Sala sala = db.Salas.Find(id);
                if (sala != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, sala);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nie znaleziono sali");
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Blad wewnetrznyc \n" + ex.Message);
            }
           

        }

        // POST: api/SalaApi
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Sala sala)
        {
            db.Salas.Add(sala);
            if (db.SaveChangesAsync().Result == 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Blad wewnetrzny");
            }
        }

        // PUT: api/SalaApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SalaApi/5
        public void Delete(int id)
        {
        }
    }
}

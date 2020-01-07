using DbConn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Net;
using Newtonsoft.Json;

namespace DbConn.Controllers
{
    public class SpektaklApiController : ApiController
    {
        private SpektaklContext spektakl = new SpektaklContext();

        // GET /api/SpektaklApi
        public List<Spektakl> Get()
        {
            return spektakl.spektakls.ToList();
        }

        // GET /api/SpektaklApi/2
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Spektakl spl = spektakl.spektakls.Find(id);
                if(spl != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, spl);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nie znalezniono spektaklu o podanym id");
                }
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Blad wewnetrzny");
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Spektakl spl)
        {
            try
            {
                spektakl.spektakls.Add(spl);
                if (spektakl.SaveChangesAsync().Result == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, spl.id);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Zly request");
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Blad wewnetrzny \n" + ex.Message);
            }
        }
    }
}
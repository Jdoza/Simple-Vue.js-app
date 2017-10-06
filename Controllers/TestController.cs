using StartEx.Domain;
using StartEx.Models.Request;
using StartEx.Models.Response;
using StartEx.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StartEx.Controllers
{
    [RoutePrefix("startex")]
    public class TestController : ApiController
    {
        readonly ITestService testService;

        public TestController(ITestService testService)
        {
            this.testService = testService;
        }

        [Route(), HttpGet]
        public HttpResponseMessage GetAll()
        {
            List<jobs> response = new List<jobs>();
            response = testService.GetAllJobs();

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("add"), HttpPost]
        public HttpResponseMessage Insert(addJob model)
        {
            addResponse response = new addResponse();
            response.id = testService.Insert(model);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("remove/{Id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int Id)
        {
            testService.Delete(Id);
            SuccessResponse response = new SuccessResponse();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("update/{Id:int}"), HttpPut]
        public  HttpResponseMessage Update (int Id, updateJob model)
        {
            if(Id != model.Id)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Ids Dont Match");
            }
            testService.Update(model);
            SuccessResponse response = new SuccessResponse();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

    }
}

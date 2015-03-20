using MI9Challenge.ApplicationServices;
using MI9Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MI9Challenge.Controllers
{

    public class FilterShowController : ApiController
    {
        //Service to be injected via constructor , safe to be used in the registration process 
        //of the extension implementation of DI using an Ioc container (my favorite : AutoFac) 
        IFilterShowService _service;
        public FilterShowController(IFilterShowService service)
        {
            _service = service;
        }
        //Default constructor requiredfor controller
        public FilterShowController()
            : this(new FilterShowService())
        { }


        //Post method on the root,  accessible for anonymous access
        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post([FromBody]FilterShowRequest request)
        {
            //Check if a vaid json request is sent
            if ((ModelState.IsValid)&&(request!=null))
            {
                var result = new FilterShowResponse();
                var filteredShows = _service.FilterDRMMinimumEpisodeCount(request.payload, true, 0);
                result.response = filteredShows;
                //return a seccess result back 
                return this.Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
                //Bad Request sent on invalid or empty json payload
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { error = "Could not decode request: JSON parsing failed" });
        }
    }
}

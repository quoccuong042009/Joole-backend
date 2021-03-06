﻿using Joole_BackEnd.Core;
using Joole_BackEnd.Core.Domain;
using Joole_BackEnd.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Joole_BackEnd.Controllers
{
    [JwtAuthentication]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    //[JwtAuthentication]
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        public IUnitOfWork UnitOfWork { get; }
        public CategoryController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return UnitOfWork.Categories.GetAll();
        }
    }
}

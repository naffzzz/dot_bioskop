using dot_bioskop.DBContexts;
using dot_bioskop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dot_bioskop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        private MyDBContext myDbContext;

        public usersController(MyDBContext context)
        {
            myDbContext = context;
        }

        [HttpGet]
        public IList<users> Get()
        {
            return (this.myDbContext.users.ToList());
        }
    }
}
using ExpressoApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExpressoApi.Controllers
{
    public class MenusController : ApiController
    {
        private ExpressoDbContext _dbContext = new ExpressoDbContext();

        public IHttpActionResult getMenus()
        {
            var menus = _dbContext.Menus.Include("Submenus");

            return Ok(menus);
        }

        public IHttpActionResult GetMenu(int id)
        {
            var menu = _dbContext.Menus.Include("Submenus").FirstOrDefault(x => x.Id == id);
            if (menu == null) return BadRequest("not exisit");
            return Ok(menu);
        }
    }
}

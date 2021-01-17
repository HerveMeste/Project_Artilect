using artilectBigBro.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artilectBigBro.Models;
using Microsoft.AspNetCore.Authorization;

namespace artilectBigBro.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private ApplicationDbContext _context;
        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IActionResult Search(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var tupleModel = new Tuple<List<User>, List<Project>> (GetUser(searchString),GetProject(searchString));
                return View(tupleModel);
            }
            return View();
        }

        private List<Project> GetProject(string searchString)
        {
            var projectName = _context.Projects.Where(p => p.Name.Contains(searchString));
            var projectDescription = _context.Projects.Where(p => p.Description.Contains(searchString)).Concat(projectName).ToList();
            return projectDescription;
        }

        private List<User> GetUser(string searchString)
        {
            var userLastName = _context.Users.Where(u => u.LastName.Contains(searchString));
            var userFirstName = _context.Users.Where(u => u.FirstName.Contains(searchString)).Concat(userLastName).ToList();
            return userFirstName;
        }
    }
}

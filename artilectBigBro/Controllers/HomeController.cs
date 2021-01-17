using artilectBigBro.Data;
using artilectBigBro.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace artilectBigBro.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<User> userManager)
		{
			_logger = logger;
			_context = context;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult ProjectList()
		{
			IEnumerable<Project> projects = (from a in _context.Projects select a).ToList();

			return View(projects);
		}
		public IActionResult Project(Guid IdProject)
		{
			IEnumerable<Project> projects = new List<Project>();
			Project project = new Project();
			projects = from a in _context.Projects where (a.ProjectId == IdProject) select a;
			project = projects.LastOrDefault();
			return View(project);
		}
		public IActionResult Tuto()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

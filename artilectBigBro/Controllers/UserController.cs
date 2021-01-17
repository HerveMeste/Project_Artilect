using artilectBigBro.Data;
using artilectBigBro.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artilectBigBro.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public UserController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            List<User> userList = _context.Users.Include(u => u.Skills)
                                                .Include(u => u.Projects)
                                                .Include(u => u.Interests)
                                                .Include(u => u.Badges)
                                                .ToList();

            return View(userList);
        }
        public IActionResult UserProfile(String UserId)
        {
            if(UserId==null)
			{
                return View();

			}
			else
			{
                User user = _context.Users.Where(u => u.Id == UserId).Include(u => u.Skills)
                                               .Include(u => u.Projects)
                                               .Include(u => u.Interests)
                                               .Include(u => u.Badges)
                                               .First();

                return View(user);
            }
           
        }

        public async void AddSkill(string name)
        {
            User userConnected = await _userManager.GetUserAsync(this.User);
            User userData = _context.Users.Where(u => u.Id == userConnected.Id).First();

            Skill skill = _context.Skills.FirstOrDefault(s => s.Name == name);

            userData.Skills.Add(skill);
            _context.Update(userData);
            _context.SaveChanges();

            RedirectToAction("Index", "Dashboard");
        }
    }
}

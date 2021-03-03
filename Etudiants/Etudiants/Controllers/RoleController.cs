using Etudiants.Data;
using Etudiants.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etudiants.Controllers
{
    public class RoleController : Controller
    {
        private readonly aspnetEtudiantsD5174EA46BB34FCD8212E7CB11AD47BAContext _applicationDbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleController(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager, aspnetEtudiantsD5174EA46BB34FCD8212E7CB11AD47BAContext applicationDbContext) 
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;

        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult RoleToUser()
        {
            var UserList = _applicationDbContext.AspNetUsers.ToList();
            var RoleList = _applicationDbContext.AspNetRoles.ToList();

            ViewBag.Users = new SelectList(UserList, "Id", "Email");
            ViewBag.Roles = new SelectList(RoleList, "Name", "Name");
            
            return View();
        } 
        
        
        [HttpPost]
        public async Task<IActionResult>  RoleToUser(AspNetRoles UserRole)
        {
            var User = await _userManager.FindByIdAsync(UserRole.Id);
            await _userManager.AddToRoleAsync(User, UserRole.Name);
            //var u_r = new AspNetUserRoles { RoleId = UserRole.Id, UserId = UserRole.Name };
            //await _applicationDbContext.AspNetUserRoles.AddAsync(u_r);
            //await _applicationDbContext.SaveChangesAsync();

            return View();


        }

        
    }
}

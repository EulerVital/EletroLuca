using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAO;
using ENT;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc.Models;
using NEG.Interfaces;

namespace Mvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginNEG loginNEG;
        private readonly ApplicationDbContext context;

        public LoginController(ILoginNEG _loginNEG, ApplicationDbContext _context)
        {
            loginNEG = _loginNEG;
            context = _context;
        }

        // GET: Login
        public async Task<IActionResult> Index()
        {
            ViewBag.Perfis = await context.Perfis.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(Login model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await loginNEG.GetUserLogin(model.Email, model.Senha, model.PerfilId);

                    if (user != null && user.Id > 0)
                    {
                        ModelState.Clear();
                        var claims = new List<Claim>
                        {
                            new Claim("SysAdmin", user.Perfil.Nome)
                        };

                        ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "SysAdmin");
                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        if (User.Identity.IsAuthenticated)
                            return RedirectToAction("Home", "Index");
                        else
                            TempData["LoginUsuarioFalhou"] = "O login Falhou. Informe as credenciais corretas " + User.Identity.Name;

                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return View();
        }
    }
}
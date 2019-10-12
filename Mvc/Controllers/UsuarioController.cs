using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAO;
using ENT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Controllers
{
    [Authorize(Policy = "SysAdmin")]
    public class UsuarioController : BaseController
    {

        public UsuarioController(ApplicationDbContext _context) : base(_context)
        {
        }

        public async Task<IActionResult> Index()
        {
            var listaUser = await context.Usuarios.ToListAsync();

            return View(listaUser);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Perfis = await context.Perfis.ToListAsync();

            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Usuarios.Add(user);
                    await context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var user = await context.Usuarios.FirstAsync(c => c.Id == id);

            if (user == null)
                return NotFound();

            ViewBag.Perfis = await context.Perfis.ToListAsync(); 

            return View(user);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Usuario user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _user = await context.Usuarios.FirstAsync(c => c.Id == user.Id);
                    _user.Email = user.Email;
                    _user.PerfilId = user.PerfilId;
                    _user.Senha = user.Senha;

                    await context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await context.Usuarios.FirstAsync(c => c.Id == id);

                context.Usuarios.Remove(user);
                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.IsErro = true;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Controllers
{
    [Authorize(Policy = "SysAdmin")]
    public class PerfilController : BaseController
    {

        public PerfilController(ApplicationDbContext _context) : base(_context)
        {
        }

        // GET: Perfil
        public async Task<IActionResult> Index()
        {
            var listaPerfil = await context.Perfis.ToListAsync();

            return View(listaPerfil);
        }
    }
}
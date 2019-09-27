using DAO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext context;
        public BaseController(ApplicationDbContext _context)
        {
            context = _context;
        }
    }
}

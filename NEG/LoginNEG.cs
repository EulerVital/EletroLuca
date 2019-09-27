using DAO;
using ENT;
using Microsoft.EntityFrameworkCore;
using NEG.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NEG
{
    public class LoginNEG : ILoginNEG
    {
        private readonly ApplicationDbContext context;

        public LoginNEG(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<bool> GetLogin(string login, string senha, int perfilId)
        {
            try
            {
                var user = await GetUserLogin(login, senha, perfilId);

                return user != null && user.Id > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Usuario> GetUserLogin(string login, string senha, int perfilId)
        {
            try
            {                
                var user = await context.Usuarios.FirstAsync(c => c.Email == login && c.Senha == senha && c.Perfil.Id == perfilId);

                return user;
            }
            catch
            {
                return null;
            }
        }
    }
}

using ENT;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NEG.Interfaces
{
    public interface ILoginNEG
    {
        Task<bool> GetLogin(string login, string senha, int perfilId);
        Task<Usuario> GetUserLogin(string login, string senha, int perfilId);
    }
}

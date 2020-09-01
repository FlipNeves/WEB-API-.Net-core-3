using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Repository
{
    public static class UserRepositoryTraining
    {
        public static User Get(string Username, string Senha)
        {
            //"Banco de dados" para treino de Login
            var users = new List<User>();

            users.Add(new User { ID = 1, Username = "Aprendiz", Senha = "Aprendendo" });
            users.Add(new User { ID = 2, Username = "Mestre", Senha = "Ensinando" });

            return users.Where(x => x.Username.ToLower() == Username.ToLower() && x.Senha == x.Senha).FirstOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class User
    {
        //Dados do Objeto User
        public int ID { get; set; }

        public string Username { get; set; }

        public string Senha { get; set; }
    }
}

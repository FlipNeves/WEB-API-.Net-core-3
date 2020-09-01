using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;
using WebApi.Repository;
using WebApi.Services;

namespace WebApi.Controlers
{
    [Route("system/login")]
    public class UserController : ControllerBase
    {

        //Rota livre para o login no sistema.
        //Username: Aprendiz  / Mestre
        //Senha:    Aprendendo/ Ensinando
        //localhost/system/login/
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var User
                = UserRepositoryTraining.Get(model.Username, model.Senha);

            if (User == null)
            {
                return NotFound("Usuário ou senha inválidos");
            }

            var Token = TokenService.GenerateToken(User);
            User.Senha = ""; //Escondendo a senha digitada
            return new
            {
                User,   //Devolvendo o usuário cadastrado
                Token   //e o Token para autorizar as outras rotas
            };
        }
    }
}

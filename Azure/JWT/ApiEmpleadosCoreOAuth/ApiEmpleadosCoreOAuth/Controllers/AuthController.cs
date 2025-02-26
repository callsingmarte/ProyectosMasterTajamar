using ApiEmpleadosCoreOAuth.Models;
using ApiEmpleadosCoreOAuth.Repositories;
using ApiEmpleadosCoreOAuth.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace ApiEmpleadosCoreOAuth.Controllers
{
    //www.apiempleados/Auth
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        RepositoryEmpleados _repo;
        HelperToken helper;

        public AuthController(RepositoryEmpleados repo, IConfiguration configuration)
        {
            helper = new HelperToken(configuration);
            _repo = repo;
        }

        //Endpoint para que el cliente envie datos de validacion
        //post que hemos incluido en la clase LoginModel

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login(LoginModel model)
        {
            Empleado empleado = _repo.ExisteEmpleado(model.UserName!, int.Parse(model.Password!));
            if (empleado != null)
            {
                //Genero el Token
                Claim[] claims = new[]
                {
                    new Claim("UserData", JsonConvert.SerializeObject(empleado)),
                };

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: helper._Issuer,
                    audience: helper._Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(helper.GetKeyToken(), SecurityAlgorithms.HmacSha256)
                );

                //Devolvemos respuesta afirmativa con este token
                return Ok(new
                {
                    response = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}

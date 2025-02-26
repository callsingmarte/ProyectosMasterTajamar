using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;

namespace ApiEmpleadosCoreOAuth.Token
{
    public class HelperToken
    {
        public string? _Issuer { get; set; }
        public string? _Audience { get; set; }
        public string? _SecretKey { get; set; }

        public HelperToken(IConfiguration configuration) 
        {
            _Issuer = configuration["ApiAuth:Issuer"];
            _Audience = configuration["ApiAuth:Audience"];
            _SecretKey = configuration["ApiAuth:SecretKey"];
        }
        //Creacion de una clave simetrica para encriptar el SecretKey
        public SymmetricSecurityKey GetKeyToken()
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(_SecretKey!);
            return new SymmetricSecurityKey(data);
        }
        //Configurar todas las opciones de seguridad del Token
        public Action<JwtBearerOptions> GetJwtOptions()
        {
            Action<JwtBearerOptions> jwtOptions = new Action<JwtBearerOptions>(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateActor = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = _Audience,
                    ValidIssuer = _Issuer,
                    IssuerSigningKey = GetKeyToken()
                };
            });

            return jwtOptions;
        }

        //Validar la autenticacion
        public Action<AuthenticationOptions> GetAuthOptions()
        {
            Action<AuthenticationOptions> authOptions = new Action<AuthenticationOptions>(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            return authOptions;
        }
    }
}

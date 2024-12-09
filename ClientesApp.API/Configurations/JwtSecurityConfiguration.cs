using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ClientesApp.API.Configurations
{
    /// <summary>
    /// Classe para configuração da politica de autenticação do JWT
    /// </summary>
    public class JwtSecurityConfiguration
    {
        public static void AddJwtSecurity(IServiceCollection services)
        {
            var secretKey = "EB1AB146-C07B-48D0-81FD-C42AF391790F";

            services.AddAuthentication( 
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                ).AddJwtBearer(options => 
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false, //não precisa validar a origem do token
                        ValidateAudience = false, //não precisa validar o destinatário do token
                        ValidateLifetime = true, //verificar o tempo de expiração do TOKEN,
                        //Verificando se o TOKEN está assinado com a minha chave de identificação
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });
        }
    }
}

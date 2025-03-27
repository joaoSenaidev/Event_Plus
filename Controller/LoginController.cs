using Event_Plus.Domains;
using Event_Plus.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Event_Plus.Interface;

namespace Event_Plus.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuariosRepository _usuarioRepository;
        public LoginController(IUsuariosRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        /// <summary>
        /// Login do Usuario
        /// </summary>
        /// <param name="loginDTO">Email e Senha do Usuario</param>
        /// <returns>Usuario</returns>
        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                Usuarios usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(loginDTO.Email!, loginDTO.Senha!);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuario nao encontrado, email ou senha invalidos");
                }
                //caso o usuario seja encontrado, prossegue para a criacao do token

                //1 Passo - definir as claims() que serao fornecidos no token

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!),

                    //podemos definir uma claim personalizada
                    new Claim("Nome da claim","Valor da claim")

                };
                //2 Passo - definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("EventPlus-chave-autenticacao-webapi-dev"));

                //3 Passo - definir as credenciais do token (header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4 passo - gerar o token
                var token = new JwtSecurityToken(
                    //emisor do token
                    issuer: "Event_Plus",

                    //destinatario do token
                    audience: "Event_Plus",

                    //dados definidos nas claims
                    claims: claims,

                    //tempo de expiracao do token
                    expires: DateTime.Now.AddMinutes(5),

                    //credenciais do token
                    signingCredentials: creds

                 );
                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    }
                    );

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}

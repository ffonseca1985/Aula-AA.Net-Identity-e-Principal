using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityPrincipal
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Todo os sistema funciona com os seguintes passos:

            //Preciso criar uma identidade
            //Para este fim preciso criar algumas declarações
            //Como nome, Telefone, papeis etc.
            //=> no mínimo devemos adicionar um nome
            var claim1 = new Claim(ClaimTypes.Name, "Fabio Rodrigues Fonseca");
            var claim2 = new Claim("Telefone", "22436391");
            var claim3 = new Claim(ClaimTypes.Role, "Admin");

            //Coloco em uma lista de declarações
            var claims = new List<Claim>()
            {
                claim1,
                claim2, 
                claim3
            };

            //Crio uma identidade
            //Devemos Adicionar um tipo de autenticação
            var identity = new ClaimsIdentity(claims, "LGroupAuteticationn", ClaimTypes.Name, ClaimTypes.Role);

            //Crio um ambiente
            var principal = new ClaimsPrincipal(identity);

            //Adciono estas declarações no ambiente
            Thread.CurrentPrincipal = principal;

            //Verificando..
            Console.WriteLine(Thread.CurrentPrincipal.Identity.IsAuthenticated);
            Console.WriteLine(Thread.CurrentPrincipal.IsInRole("Admin"));
            Console.WriteLine(Thread.CurrentPrincipal.Identity.Name);

            Console.ReadKey();

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Newtonsoft.Json;
using MotorsUp_.Models;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.JavaScript;
using Newtonsoft.Json.Linq;

namespace MotorsUp_.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("token", "");
            return View();
        }

        [HttpPost]
        public async Task<dynamic> Validar(string usuario, string contrasenha)
        {
            var datos = JsonConvert.SerializeObject(new
            {
                
                correo_usuario = usuario,
                contraseña_usuario = contrasenha
            });

            var htpContent = new StringContent(datos.ToString(), Encoding.UTF8, "application/json");

            using (var cliente = new HttpClient())
            {
                string url = "http://localhost:5038/api/Usuario/Autenticar";
                cliente.DefaultRequestHeaders.Clear();
                var response = cliente.PostAsync(url, htpContent).Result;
                var res = response.Content.ReadAsStringAsync().Result;
                dynamic data = JsonConvert.DeserializeObject<LoginResponse>(res);
               
                if (data.Resultado)
                {
                    string token = data.Token;

                    HttpContext.Session.SetString("token", token);
                    return RedirectToAction("Index", "Home");
                }
                HttpContext.Session.SetString("token", "");
                return RedirectToAction("Index", "Login");
            }

        }
    }
}

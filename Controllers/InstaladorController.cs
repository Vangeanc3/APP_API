using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace APP_API.Controllers
{
    [ApiController]
    [Route("v1")]
    public class InstaladorController : ControllerBase
    {
        [HttpGet]
        [Route("anonima")]
        [AllowAnonymous]
        public string Anonimo() => "Anônimo";

        [HttpGet]
        [Route("autenticado")]
        [Authorize]
        public string Autenticado() => $"Autenticado - {User.Identity.Name}";

        [HttpGet]
        [Route("instalador")]
        [Authorize(Roles = "Instalador")]
        public string Instalador() => $"Instalador";

        [HttpGet]
        [Route("vendedor")]
        [Authorize(Roles = "Vendedor")]
        public string Vendedor() => $"Vendedor";
    }
}
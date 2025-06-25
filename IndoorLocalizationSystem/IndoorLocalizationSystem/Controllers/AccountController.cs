using IndoorLocalizationSystem.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IndoorLocalizationSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AccountController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public IActionResult Login() => View();

        // AccountController.cs
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var client = _clientFactory.CreateClient("api");

            var json = System.Text.Json.JsonSerializer.Serialize(dto);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/auth/login", content);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Login failed.");
                return View(dto);
            }

            var result = await response.Content.ReadFromJsonAsync<JwtTokenResponse>();
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(result.Token);

            var identity = new ClaimsIdentity(jwtToken.Claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            HttpContext.Session.SetString("JWToken", result.Token);

            return RedirectToAction("Index", "Home");
        }




        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var client = _clientFactory.CreateClient("api");

            var json = System.Text.Json.JsonSerializer.Serialize(dto);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/auth/signup", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Login");

            ModelState.AddModelError(string.Empty, "Registration failed.");
            return View(dto);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("JWToken");
            return RedirectToAction("Login");
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AssignRole()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole(AssignRoleDTO dto)
        {
            var client = _clientFactory.CreateClient("api");
            var response = await client.PostAsJsonAsync("api/auth/assign-role", dto);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "Role assigned successfully.";
            }
            else
            {
                ViewBag.Message = "Failed to assign role.";
            }

            return View();
        }



    }
}

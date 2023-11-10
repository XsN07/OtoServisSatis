using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.WebUI.Models;
using System.Security.Claims;

namespace OtoServisSatis.WebUI.Controllers
{
	public class AccountController : Controller
	{

    private readonly IService<Rol> _serviceRol;
    private readonly IService<Kullanici> _service;

    public AccountController(IService<Kullanici> service, IService<Rol> serviceRol)
    {
      _serviceRol = serviceRol;
      _service = service;
    }

    public IActionResult Index()
		{
			return View();
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
    public async Task<IActionResult> RegisterAsync(Kullanici kullanici)
    {

      if (ModelState.IsValid)
      {
        try
        {
          var rol = await _serviceRol.GetAsync(r => r.Adi == "Customer");
          if (rol == null) 
          {
            ModelState.AddModelError(" ", "Kayıt Başarısız!");
            return View();
          }
          kullanici.RolId = rol.Id;

          kullanici.AktifMi = true;
         
          _service.Add(kullanici);
          await _service.SaveAsync();
          return RedirectToAction(nameof(Index));
        }
        catch
        {
          ModelState.AddModelError(" ", "Hata Oluştu!");
        }
      }    
      return View();
    }


    public IActionResult Login()
    {
      return View();
    }


    [HttpPost]
    public async Task<IActionResult> LoginAsync(CustomerLoginViewModel customerViewModel)
    {
      try
      {
        var account =await _service.GetAsync(k => k.Email == customerViewModel.Email && k.Sifre == customerViewModel.Sifre && k.AktifMi == true);

        if (account == null)
        {
        
          ModelState.AddModelError(" ", "Giriş Başarısız!");

        }

        else
        {

          var rol = _serviceRol.Get(r => r.Id == account.RolId);
          var claims = new List<Claim>()
          {
             new Claim(ClaimTypes.Name,account.Adi)
          };
          if (rol != null)
          {

            claims.Add(new Claim(ClaimTypes.Role, rol.Adi));
          }
          var userIdentity = new ClaimsIdentity(claims, "Login");
          ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
          await HttpContext.SignInAsync(principal);
          return Redirect("/Account");

        }
      }
      catch (Exception)
      {

        ModelState.AddModelError(" ", "Hata Oluştu!");
      }
      return View();
    }


		public async Task<IActionResult> Logout()
		{

			await HttpContext.SignOutAsync();
			return Redirect("/");
		}
	}
}

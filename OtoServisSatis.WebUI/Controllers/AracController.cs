using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.Service.Concrete;

namespace OtoServisSatis.WebUI.Controllers
{
	public class AracController : Controller
	{
		private readonly ICarService _serviceArac;
		private readonly IService<Musteri> _serviceMusteri;

		public AracController(ICarService serviceArac, IService<Musteri> serviceMusteri)
		{
			_serviceArac = serviceArac;
			_serviceMusteri = serviceMusteri;
		}

		public async Task<IActionResult> Index(int id)
		{
			var model = await _serviceArac.GetCustomerCar(id);
			return View(model);
		}

		[Route("tum-araclar")]
		public async Task<IActionResult> List()
		{
			var model = await _serviceArac.GetCustomerList(c=>c.SatistaMi);
			return View(model);
	
		}


    public async Task<IActionResult> Ara(string q)
    {
      var model = await _serviceArac.GetCustomerList(c => c.SatistaMi && c.Marka.Adi.Contains(q) || c.KasaTipi.Contains(q) || c.Modeli.Contains(q));
      return View(model);
    }

		[HttpPost]
		public async Task<IActionResult> MusteriKayit(Musteri musteri)
		{
			if (ModelState.IsValid)
			{
				try
				{
					_serviceMusteri.Add(musteri);
					await _serviceMusteri.SaveAsync();
					return Redirect(nameof(Index));
				}
				catch
				{
					ModelState.AddModelError("", "Hata Oluştu!");
				}
			}
			return View();
		}
	}
}

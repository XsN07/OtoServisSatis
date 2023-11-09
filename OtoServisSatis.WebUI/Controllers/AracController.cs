using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatis.WebUI.Controllers
{
	public class AracController : Controller
	{
		private readonly ICarService _serviceArac;

		public AracController(ICarService serviceArac)
		{
			_serviceArac = serviceArac;
		}

		public async Task<IActionResult> Index(int id)
		{
			var model = await _serviceArac.GetCustomerCar(id);
			return View(model);
		}
	}
}

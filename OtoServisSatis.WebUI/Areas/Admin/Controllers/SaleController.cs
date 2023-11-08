using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{

  [Area("Admin"), Authorize]
  public class SaleController : Controller
  {

    private readonly IService<Satis> _service;
    private readonly IService<Arac> _serviceArac;
    private readonly IService<Musteri> _serviceMusteri;

    public SaleController(IService<Satis> service, IService<Arac> serviceArac, IService<Musteri> serviceMusteri)
    {
      _service = service;
      _serviceArac = serviceArac;
      _serviceMusteri = serviceMusteri;
    }

    // GET: SaleController


    // GET: SaleController/Details/5
    public async Task<IActionResult> IndexAsync()
    {
      
      var model = await _service.GetAllAsync();
      return View(model);
    }

    // GET: SaleController/Create
    public async Task<ActionResult> CreateAsync()
    {
      ViewBag.AracId=new SelectList(await _serviceArac.GetAllAsync(),"Id","Modeli");
      ViewBag.MusteriId= new SelectList(await _serviceMusteri.GetAllAsync(), "Id", "Adi");
      return View();
    }

    // POST: SaleController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> CreateAsync(Satis satis)
    {
      if (ModelState.IsValid)
      {
        try
        {


          _service.Add(satis);
          await _service.SaveAsync();
          return RedirectToAction(nameof(Index));
        }
        catch
        {
          ModelState.AddModelError("", "Hata Oluştu!");
        }
      }
      ViewBag.AracId = new SelectList(await _serviceArac.GetAllAsync(), "Id", "Modeli");
      ViewBag.MusteriId = new SelectList(await _serviceMusteri.GetAllAsync(), "Id", "Adi");
      return View(satis);
    }

    // GET: SaleController/Edit/5
    public async Task<ActionResult> EditAsync(int id)
    {

      ViewBag.AracId = new SelectList(await _serviceArac.GetAllAsync(), "Id", "Modeli");
      ViewBag.MusteriId = new SelectList(await _serviceMusteri.GetAllAsync(), "Id", "Adi");
      var model =await _service.FindAsync(id);
      return View(model);
    }

    // POST: SaleController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditAsync(int id, Satis satis)
    {
      if (ModelState.IsValid)
      {
        try
        {


          _service.Update(satis);
          await _service.SaveAsync();
          return RedirectToAction(nameof(Index));
        }
        catch
        {
          ModelState.AddModelError("", "Hata Oluştu!");
        }
      }
      ViewBag.AracId = new SelectList(await _serviceArac.GetAllAsync(), "Id", "Modeli");
      ViewBag.MusteriId = new SelectList(await _serviceMusteri.GetAllAsync(), "Id", "Adi");
      return View(satis);
    }

    // GET: SaleController/Delete/5
    public async Task<ActionResult> DeleteAsync(int id)
    {
      var model = await _service.FindAsync(id);
      return View(model);
    }

    // POST: SaleController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id,Satis satis)
    {
      try
      {

        _service.Delete(satis);
        _service.Save();
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
  }
}

using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace OtoServisSatis.Entities
{//2
  public class Arac : IEntity
  {
    public int Id { get; set; }


    [Display(Name = "Marka Adı"), Required(ErrorMessage = "{0} boş bırakılamaz!")]
    public int MarkaId { get; set; }

    [StringLength(50), Required(ErrorMessage = "{0} boş bırakılamaz!")]
    public string Renk { get; set; }
    public decimal Fiyati { get; set; }

    [StringLength(50), Required(ErrorMessage = "{0} boş bırakılamaz!")]
    public string Modeli { get; set; }

    [StringLength(50), Required(ErrorMessage = "{0} boş bırakılamaz!")]

    [Display(Name = "Kasa Tipi")]
    public string KasaTipi { get; set; }

    [Display(Name = "Model Yılı?")]
    public int ModelYili { get; set; }

    [Display(Name = "Satışta mı?")]
    public bool SatistaMi { get; set; }

    [Display(Name = "Ana Sayfa")]
    public bool AnaSayfa { get; set; }
    public string? Notlar { get; set; }
    [StringLength(100)]
    public string? Resim1 { get; set; }

    [StringLength(100)]
    public string? Resim2 { get; set; }

    [StringLength(100)]
    public string? Resim3 { get; set; }
    public virtual Marka? Marka { get; set; } //Araç sınıfı ile Marka sınıf arasında bağlantı
  }
}

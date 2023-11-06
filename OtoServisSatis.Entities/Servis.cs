using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Entities
{//8
  public class Servis : IEntity
  {
  
    public int Id { get; set; }
    [Display(Name = "Servise Geliş Tarihi")]
    public DateTime ServiseGelisTarihi { get; set; }

    [Display(Name = "Araç Sorunu"), Required(ErrorMessage = "{0} boş bırakılamaz!")]
    public string AracSorunu { get; set; }

    [Display(Name = "Servise Ücreti")]
    public decimal ServisUcreti { get; set; }

    [Display(Name = "Servisten Çıkış Tarihi"), Required(ErrorMessage = "{0} boş bırakılamaz!")]
    public DateTime ServistenCikisTarihi { get; set; }

    [Display(Name = "Yapılan İşlemler")]
    public string? YapilanIslemler { get; set; }

    [Display(Name = "Garanti Kapsamında mı?")]
    public bool GarantiKapsamindaMi { get; set; }
    [DisplayName("Araç Plaka"),StringLength(15), Required(ErrorMessage = "{0} boş bırakılamaz!")]
    public string AracPlaka { get; set; }
    [StringLength(50), Required(ErrorMessage = "{0} boş bırakılamaz!")]
    public string Marka { get; set; }
    [StringLength(50), Required(ErrorMessage = "{0} boş bırakılamaz!")]
    public string? Model { get; set; }
    [StringLength(50)]

    [Display(Name = "Kasa Tipi"), Required(ErrorMessage = "{0} boş bırakılamaz!")]
    public string? KasaTipi { get; set; }
    [StringLength(50)]

    [Display(Name = "Şase No")]
    public string? SaseNo { get; set; }
    public string Notlar { get; set; }
  }
}

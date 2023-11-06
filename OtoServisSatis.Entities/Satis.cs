using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Entities
{//7
  public class Satis : IEntity
  {
    public int Id { get; set; }

    [Display(Name = "Araç"), Required(ErrorMessage = "{0} boş bırakılamaz!")]
    public int AracId { get; set; }

    [Display(Name = "Müşteri"), Required(ErrorMessage = "{0} boş bırakılamaz!")]
    public int MusteriId { get; set; }

    [Display(Name = "Satış Fiyat"), Required(ErrorMessage = "{0} boş bırakılamaz!")]
    public decimal SatisFiyati { get; set; }

    [Display(Name = "Satış Tarihi"), Required(ErrorMessage = "{0} boş bırakılamaz!")]
    public DateTime SatisTarihi { get; set; }
    public virtual Arac? Arac { get; set; }
    public virtual Musteri? Musteri { get; set; }
  }
}

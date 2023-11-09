using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Entities
{//6
  public class Musteri : IEntity
  {


    public int Id { get; set; }

    [Display(Name = "Araç"), Required(ErrorMessage = "{0} boş bırakılamaz!")]
    public int AracId { get; set; }
    [StringLength(50)]

    [Display(Name = "Adı"), Required(ErrorMessage = "{0} boş bırakılamaz!")]
    public string Adi { get; set; }
    [StringLength(50)]

    [Display(Name = "Soyadı"), Required(ErrorMessage = "{0} boş bırakılamaz!")]
    public string Soyadi { get; set; }

    [StringLength(11)]

    [Display(Name = "TC Numarası")]
    public string? TcNo { get; set; }
    [StringLength(50)]

		[Display(Name = "Email"), Required(ErrorMessage = "{0} boş bırakılamaz!")]
		public string Email { get; set; }
    [StringLength(500)]
    public string? Adres { get; set; }
    [StringLength(15)]
    public string? Telefon { get; set; }
    public string? Notlar { get; set; }

    [Display(Name = "Araç")]
    public virtual Arac? Arac { get; set; }
  }
}

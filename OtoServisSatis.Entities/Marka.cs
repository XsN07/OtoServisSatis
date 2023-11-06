using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Entities
{//3
  public class Marka : IEntity
  {
    public int Id { get; set; }

    [StringLength(50)]
    [Display(Name = "Adı"), Required(ErrorMessage = "{0} boş bırakılamaz!")]
    public string Adi { get; set; }
  }
}
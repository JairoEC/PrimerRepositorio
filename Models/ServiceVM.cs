using System.ComponentModel.DataAnnotations;
using WebApplication_NET_CORE.Entities;

namespace WebApplication_NET_CORE.Models
{
    public class ServiceVM
    {
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Ingresar nombre")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings =false)]
        public string Type { get; set; }
    }
}

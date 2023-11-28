using System.ComponentModel.DataAnnotations.Schema;

namespace FaxDev.Models
{
    public class Homepage
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string nom {  get; set; }
    }
}

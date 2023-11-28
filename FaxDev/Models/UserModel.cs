using System.ComponentModel.DataAnnotations.Schema;

namespace FaxDev.Models
{
    public class UserModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirtName { get; set; }   
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    

    }
}

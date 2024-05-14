using System.ComponentModel.DataAnnotations;

namespace MovieManagementSystem.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="ProfilePicture")]
        public String ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]

        public String FulllName { get; set; }


        [Display(Name = "Biography")]

        public String Bio { get; set; }

        //relationships

        public List<Movie> Movies { get; set; }
    }
}

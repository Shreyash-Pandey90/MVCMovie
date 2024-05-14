using System.ComponentModel.DataAnnotations;

namespace MovieManagementSystem.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }


        [Display(Name ="Profile Picture URL")]
        [Required(ErrorMessage = "Picture is Required")]
        public String ProfilePictureURL { get; set; }

       
        [Display(Name = "Full Name")]

        [Required(ErrorMessage ="Name is Required")]
        public String FulllName { get; set; }


        [Display(Name = "Biography")]

        [Required(ErrorMessage = "Bio is Required")]
        public String Bio { get; set; }

        //relation

 
        public List<Actor_Movie> Actors_Movies { get; set; } 
    }
}

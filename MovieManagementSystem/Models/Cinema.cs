using System.ComponentModel.DataAnnotations;

namespace MovieManagementSystem.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Cinema Logo")]
        public String Logo { get; set; }


        [Display(Name = "Cinema Name")]

        public String Name { get; set; }

        [Display(Name = "Description")]

        public string Description { get; set; }


        //relations

        public List<Movie> Movies { get; set;}
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstAppWith2Tables.Models
{
    [Table("tblTutorial")]
    public class Tutorial
    {
        public int TutorialId { get; set; }
        [RegularExpression(@"^[a-zA-Z-_]*$",ErrorMessage ="please enter text")]
        [Required]
        [Display(Name ="Tutorial Description")]
        public string? Description { get; set; }

        public virtual ICollection<Article> Articles { get; set; }=new List<Article>();
    }
}

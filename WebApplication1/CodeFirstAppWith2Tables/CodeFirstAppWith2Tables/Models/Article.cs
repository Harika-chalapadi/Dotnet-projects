using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstAppWith2Tables.Models
{
    [Table("tblArticle")]
    public class Article
    {
        
        public int? ArticleId { get; set; }
        //[Key]
        [Required(ErrorMessage ="Please enter article title")]
        public string ArticleTitle { get; set; }
        [Required(ErrorMessage = "Please enter article content")]
        public string ArticleContent { get; set; }

        public int TutorialId { get; set; }
        public Tutorial? Tutorials { get; set; }
    }
}

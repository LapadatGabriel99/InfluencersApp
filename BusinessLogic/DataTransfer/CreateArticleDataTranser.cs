using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.DataTransfer
{
    public class CreateArticleDataTranser
    {        
        [MinLength(5, ErrorMessage = "The title must be at least 5 characters...")]
        [MaxLength(20, ErrorMessage = "The title cannot have more than 20 characters...")]
        [Required(ErrorMessage = "You must enter some text...")]
        public string Title { get; set; }
        
        [MinLength(10, ErrorMessage = "The content must be at least 5 characters...")]
        [MaxLength(8192, ErrorMessage = "Wow you wrote that much :)")]
        [Required(ErrorMessage = "You must enter some text...")]
        public string Content { get; set; }

        [DisplayName("Nickname")]
        [MinLength(5, ErrorMessage = "Your nickname must be at least 5 characters...")]
        [MaxLength(20, ErrorMessage = "Yout nickname cannot have more than 20 characters...")]
        [Required(ErrorMessage = "You must enter a nickname...")]
        public string AuthorNickname { get; set; }

        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Please enter your email")]
        [DataType(DataType.EmailAddress)]
        public string AuthorEmail { get; set; }
    
        [Required(ErrorMessage = "You must enter a tag...")]
        [MinLength(5, ErrorMessage = "The tag must have at least 5 charcters...")]
        [MaxLength(10, ErrorMessage = "The tag cannot have more than 10 characters...")]
        public string Tags { get; set; }
    }
}

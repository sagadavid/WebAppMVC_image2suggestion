using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace image2suggestion.Models
{
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        //[Column(TypeName = "nvarchar(100)")]
        //[DisplayName("Upload Name")]
        //public string Description { get; set; }

        //[NotMapped]
        [DisplayName("Upload File")]
        public IFormFile File { get; set; }

        //navigation property
        public Suggestion Suggestion { get; set; }
    }
}

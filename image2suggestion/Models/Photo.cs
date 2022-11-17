using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace image2suggestion.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        //[Column(TypeName = "nvarchar(100)")]
        //[DisplayName("Upload Name")]
        //public string Description { get; set; }


        //-The property 'Photo.File' is of an interface type ('IFormFile').
        //If it is a navigation, manually configure the relationship for
        //this property by casting it to a mapped entity type. Otherwise,
        //ignore the property using the [NotMapped] attribute
        //or 'Ignore' in 'OnModelCreating'.
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile File { get; set; }

        ////navigation property
        //public Suggestion Suggestion { get; set; }

        public byte[] Bytes { get; set; }
        //public string Description { get; set; }
        //public string FileExtension { get; set; }
        //public decimal Size { get; set; }

    }
}

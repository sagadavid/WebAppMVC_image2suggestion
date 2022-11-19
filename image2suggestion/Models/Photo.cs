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

        //-The property 'Photo.PhotoInIForm' is of an interface type ('IFormFile').
        //If it is a navigation, manually configure the relationship for
        //this property by casting it to a mapped entity type. Otherwise,
        //ignore the property using the [NotMapped] attribute
        //or 'Ignore' in 'OnModelCreating'.
        [NotMapped]
        [DisplayName("Upload PhotoInIForm")]
        public IFormFile PhotoInIForm { get; set; }

        public byte[] PhotoInBytes { get; set; }
        
        public int SuggestionID { get; set; }
        public Suggestion Suggestion { get; set; }

    }
}

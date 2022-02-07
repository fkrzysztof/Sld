using Microsoft.AspNetCore.Http;
using Sald.Data.Data.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sasso.Data.Data.Data
{
    public class MyFile
    {
        [Key]
        public int FileID { get; set; }
        public string Path { get; set; }

        [NotMapped]
        //[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.doc|.docx|.pdf)$", ErrorMessage = "akceptowalne fomaty to: .doc, .docx, .pdf")]
        public IFormFile FileItem { get; set; }

        public int? OfferID { get; set; }
        [ForeignKey("OfferID")]
        public Offer Offer { get; set; }

        public int? SettingsID { get; set; }
        [ForeignKey("SettingsID")]
        public Settings Logo { get; set; }

        [ForeignKey("BackgroundList")]
        public int? BackgroundListID { get; set; }
        public Settings BackgroundList { get; set; }




        
    }
}


//public int? PageSettingsID { get; set; }
//[ForeignKey("PageSettingsID")]
//public PageSettings PageSettingsItem { get; set; }


//[ForeignKey("Background")]
//public int? BackgroundID { get; set; }
//public PageSettings Background { get; set; }

//public int? PageSettingsID { get; set; }
//[ForeignKey("PageSettingsID")]
//public PageSettings Background { get; set; }
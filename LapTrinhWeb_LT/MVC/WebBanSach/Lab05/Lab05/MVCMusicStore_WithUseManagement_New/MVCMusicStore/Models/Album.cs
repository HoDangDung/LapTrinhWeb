using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCMusicStore.Models
{
    [Bind(Exclude = "AlbumID")]
    public class Album
    {
        [ScaffoldColumn(false)]
        public int AlbumID { get; set; }

        [DisplayName("Genre")]
        public int GenreID { get; set; }

        [DisplayName("Artist")]
        public int ArtistID { get; set; }

        [Required(ErrorMessage = "An Album title is required")]
        [StringLength(1024, ErrorMessage = "The title max length is 1024 char.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The price is required")]
        [Range(0.01, 100.00, ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }

        [DisplayName("Album Art URL")]
        [StringLength(1024, ErrorMessage = "The Album Art Url max length is 1024 char.")]
        public string AlbumArtUrl { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
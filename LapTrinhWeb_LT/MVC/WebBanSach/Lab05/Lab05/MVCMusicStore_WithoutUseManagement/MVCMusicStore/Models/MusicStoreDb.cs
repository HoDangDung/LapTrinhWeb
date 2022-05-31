using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace MVCMusicStore.Models
{
    public class MusicStoreDb : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Album> Albums { get; set; }

        public DbSet<MVCMusicStore.Models.Artist> Artists { get; set; }
    }
}
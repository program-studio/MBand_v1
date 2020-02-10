using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MBand.Models
{
    public class MusicContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<MemberType> MemberTypes { get; set; }
    }
}
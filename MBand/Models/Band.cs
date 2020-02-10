using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MBand.Models
{
    public class Band
    {
        public int BandId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Year Foundation")]
        public int YearFoundation { get; set; }
        //public string ImgPath { get; set; }
        [Display(Name = "Logo")]
        public byte[] BandImg { get; set; }

        public virtual ICollection<Member> Members { get; set; }

        public Band()
        {
            Members = new List<Member>();
        }
    }
}
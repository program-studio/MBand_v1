using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MBand.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        //public string ImgPath { get; set; }

        [Display(Name = "Type")]
        public int MemberTypeId { get; set; }
        public virtual MemberType MemberType { get; set; }
        [Display(Name = "Band")]
        public int BandId { get; set; }
        public virtual Band Band { get; set; }

        [Display(Name = "Logo")]
        public byte[] MemberImg { get; set; }

        //public virtual ICollection<Band> Bands { get; set; }

        //public Member()
        //{
        //    Bands = new List<Band>();
        //}
    }
}
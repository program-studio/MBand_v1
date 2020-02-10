using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MBand.Models;
using System.Collections.Generic;
using MBand.Controllers;
using System.Web.Mvc;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        MusicContext db = new MusicContext();

        Band band = new Band();
        Member member = new Member();
        List<Band> bands = new List<Band>();
        List<Member> members = new List<Member>();

        [TestInitialize]
        public void TestInitialize()
        {  
            bands.Add(new Band { BandId = 1, Name = "Mobi", YearFoundation = 2015 });
            bands.Add(new Band { BandId = 2, Name = "Kazka", YearFoundation = 2016 });
            bands.Add(new Band { BandId = 3, Name = "Tik", YearFoundation = 2017 });
            bands.Add(new Band { BandId = 4, Name = "OE", YearFoundation = 2018 });
            bands.Add(new Band { BandId = 5, Name = "Mobilend", YearFoundation = 2019 });

            members.Add(new Member { MemberId = 1, FullName = "Jon Smith", MemberTypeId = 1, BandId = 1 });
            members.Add(new Member { MemberId = 2, FullName = "Max Din", MemberTypeId = 2, BandId = 1 });
            members.Add(new Member { MemberId = 3, FullName = "Sid Lex", MemberTypeId = 1, BandId = 2 });
            members.Add(new Member { MemberId = 4, FullName = "Lin Min", MemberTypeId = 2, BandId = 2 });
            members.Add(new Member { MemberId = 5, FullName = "Key Rex", MemberTypeId = 1, BandId = 3 });

            db.Members.Add(new Member { MemberId = 1, FullName = "Jon Smith", MemberTypeId = 1, BandId = 1 });
            db.Members.Add(new Member { MemberId = 2, FullName = "Max Din", MemberTypeId = 2, BandId = 1 });
            db.Members.Add(new Member { MemberId = 3, FullName = "Sid Lex", MemberTypeId = 1, BandId = 2 });
            db.Members.Add(new Member { MemberId = 4, FullName = "Key Rex", MemberTypeId = 2, BandId = 3 });

            db.Bands.Add(new Band { BandId = 1, Name = "Mobi", YearFoundation = 2015 });
            db.Bands.Add(new Band { BandId = 2, Name = "Kazka", YearFoundation = 2016 });
            db.Bands.Add(new Band { BandId = 3, Name = "Tik", YearFoundation = 2017 });
            db.Bands.Add(new Band { BandId = 4, Name = "OE", YearFoundation = 2018 });
        }

        [TestMethod]
        public void TestModel()
        {
            Assert.AreEqual(bands[0].Name, "Mobi");
        }

        [TestMethod]
        public void TestController()
        {
            // Arrange
            BandsController controller = new BandsController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            BandsController controller = new BandsController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }


    }

}

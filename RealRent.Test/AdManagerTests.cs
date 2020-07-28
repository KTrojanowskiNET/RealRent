using Microsoft.AspNetCore.Hosting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting.Internal;
using System.IO;
using RentModel;
using Xunit;
using FluentAssertions;
using Xunit.Abstractions;
using FluentAssertions.Types;
using System.Reflection;

namespace RealRent.Test
{
    public class AdManagerTests
    {

        [Fact]

        public void ReturnUniqueFileName_ShouldReturnJpegFile()
        {
            var mockWebHost = new Mock<IWebHostEnvironment>();
            mockWebHost.SetupProperty(w => w.ContentRootPath);
            IFormFile photo = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.jpg");


            var adManager = new AdManager(mockWebHost.Object);
            var testPhoto = adManager.ReturnUniqueName(photo);


            testPhoto.Should().EndWith("jpg");
        }

        [Fact]

        public void SetExpirationDate_ShouldReturnDateTime()
        {
            var mockWebHost = new Mock<IWebHostEnvironment>();
            var adManager = new AdManager(mockWebHost.Object);

            var result = adManager.SetExpirationDate(2);

            result.Should().HaveYear(2020);
        }

        [Fact]

        public void HasExpired_ShouldReturnFalse()
        {
            var mockWebHost = new Mock<IWebHostEnvironment>();
            var adManager = new AdManager(mockWebHost.Object);
            var date = new DateTime(2022, 1, 1);

            var result = adManager.HasExpired(date);

            result.Should().BeFalse();
        }

        [Fact]

        public void HasExpired_ShouldReturnTrue()
        {
            var mockWebHost = new Mock<IWebHostEnvironment>();
            var adManager = new AdManager(mockWebHost.Object);
            var date = new DateTime(2018, 1, 1);

            var result = adManager.HasExpired(date);

            result.Should().BeTrue();
        }



    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.InMemory;
using RentData;
using Xunit;
using RentData.Repositories;
using FluentAssertions;
using RentModel.Models;
using Microsoft.Extensions.DependencyInjection;

namespace RealRent.Test
{
    public class AdvertisementsRepositoryTests
    {
        //private readonly AppDbContext context;

        private void AddData(AppDbContext context)
        {
            context.AddRange(new List<Advertisement>
            {
                new Advertisement
                {
                    AdvertisementId = 1,
                    Name = "TestAd",
                    IsPromoted = false,
                    PropertyType = PropertyType.Dom,
                    Home = new Home
                    {
                    HomeId = 1,
                    Name = "Dom nad jeziorem",
                    NumberOfFloors = 2,
                    NumberOfRooms = 6,
                    Price = 2500,
                    SquareMetrage = 140,
                    HaveFurnishings = false,
                    ConstructionYear = 2000,
                    City = "Warszawa",
                    TotalArea = 200,
                    HaveGarage = false,
                    Address = "Wiązów 3/9",
                    Advance = 4000,
                    PropertyType = PropertyType.Dom,
                    FullDescription = "Przykładowy opis domu na potrzeby testowania aplikacji"
                    },
                    User = new AppUser
                    {
                        FirstName = "Robert"
                    }
                    
                }
            });
            context.SaveChanges();

        }
        private DbContextOptions<AppDbContext> GetOptions()
        {
            var serviceProvider = new ServiceCollection().
                AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())
                .UseInternalServiceProvider(serviceProvider).Options;
            return options;
        }

        public AdvertisementsRepositoryTests()
        {
        }
        [Fact]
        public void GetAdertisements_ShouldReturnCorrectType()
        {
            //Arrange
            using var context = new AppDbContext(GetOptions());
            AddData(context);
            var repo = new AdvertismentRepository(context);

            //Act

            var result = repo.GetAdvertisements();

            //Assert

            result.Should().AllBeAssignableTo<Advertisement>();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void GetAdvertisement_ShouldIncludeHome()
        {

            using var context = new AppDbContext(GetOptions());
            AddData(context);
            var repo = new AdvertismentRepository(context);

            var result = repo.GetAdvertisement(1);

            result.Home.Should().NotBeNull();
            result.Home.City.Should().Be("Warszawa");

            Assert.NotNull(result.Home);
        }

        [Fact]

        public void GetAdvertisementShouldIncudeUser()
        {
            using var context = new AppDbContext(GetOptions());
            AddData(context);
            var repo = new AdvertismentRepository(context);

            var result = repo.GetAdvertisement(1);

            result.User.Should().NotBeNull();
        }

        //public void Dispose()
        //{
        //    context.Database.EnsureDeleted();
        //    context.Dispose();
        //}
    }
}

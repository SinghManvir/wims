using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wims.Data.Models;
using Wims.Data.Repositories;
using Wims.Domain;

namespace Wims.Data.Tests
{
    [TestClass]
    public class VenueRepositoryTest : BaseTest
    {
        [TestMethod]
        public async Task GivenANewVenue_WhenICreateAVenue_ItCreatesAVenue()
        {
            using (var context = new DefaultContext(DbContextOptions))
            {
                var venue = GetNewVenue();
                var venueRepository = new VenueRepository(context);

                await venueRepository.CreateAsync(venue);

                List<VenueDb> allVenuesDb = await context.Venues.ToListAsync();
                Assert.AreEqual(1, allVenuesDb.Count);
                Assert.AreEqual(1, allVenuesDb[0].Id);
                Assert.AreEqual(venue.Email, allVenuesDb[0].Email);
                Assert.AreEqual(venue.Website, allVenuesDb[0].Website);
                Assert.AreEqual(venue.Name, allVenuesDb[0].Name);
                Assert.AreEqual(venue.Phone, allVenuesDb[0].Phone);
                Assert.AreEqual(venue.VenueType, allVenuesDb[0].VenueType);
                Assert.AreEqual(venue.Address, allVenuesDb[0].Address);
                Assert.IsNotNull(venue.Address);
                Assert.IsNotNull(venue.createdDateUtc);
                Assert.IsNotNull(venue.modifiedDateUtc);
            }
        }

        [TestMethod]
        public async Task GivenTwoVenuesInDatabase_WhenIGetAll_ItReturns2Venues()
        {
            using (var context = new DefaultContext(DbContextOptions))
            {
                var venueRepository = new VenueRepository(context);

                await venueRepository.CreateAsync(GetNewVenue());
                await venueRepository.CreateAsync(GetNewVenue());

                List<VenueDb> allVenues = await context.Venues.ToListAsync();
                Assert.AreEqual(2, allVenues.Count);
            }
        }

        [TestMethod]
        public async Task GivenTwoAddressesInDatabase_WhenIGetById_ItReturnsTheCorrectAddress()
        {
            using (var context = new DefaultContext(DbContextOptions))
            {
                var venueRepository = new VenueRepository(context);

                await venueRepository.CreateAsync(GetNewVenue());
                await venueRepository.CreateAsync(GetNewVenue());

                VenueDb venue = await context.Venues.FindAsync(2);
                Assert.AreEqual(2, venue.Id);
            };
        }

        [TestMethod]
        public async Task GivenTwoAddressesInDatabase_WhenIUpdate_ItUpdatesTheCorrectAddress()
        {
            using (var context = new DefaultContext(DbContextOptions))
            {
                var venueRepository = new VenueRepository(context);

                var venue1 = GetNewVenue();
                var venue2 = GetNewVenue();
                venue1 = await venueRepository.CreateAsync(venue1);
                venue2 = await venueRepository.CreateAsync(venue2);
                venue2.Name = "test update";

                await venueRepository.UpdateAsync(venue2);

                var updatedVenue = await context.FindAsync<VenueDb>(venue2.Id);

                Assert.AreEqual(venue2.Name, updatedVenue.Name);
                Assert.AreEqual(venue2.Email, updatedVenue.Email);
                Assert.AreEqual(venue2.Phone, updatedVenue.Phone);
                Assert.AreEqual(venue2.Website, updatedVenue.Website);
            }
        }

        [TestMethod]
        public async Task GivenTwoAddressesInDatabase_WhenIDelete_ItDeletesTheCorrectAddress()
        {
            var venue1 = GetNewVenue();
            var venue2 = GetNewVenue();
            using (var context = new DefaultContext(DbContextOptions))
            {
                var venueRepository = new VenueRepository(context);

                venue1 = await venueRepository.CreateAsync(venue1);
                venue2 = await venueRepository.CreateAsync(venue2);

                List<VenueDb> allVenues = await context.Venues.ToListAsync();
                Assert.AreEqual(2, allVenues.Count);
            }
            using (var context = new DefaultContext(DbContextOptions))
            {
                var venueRepository = new VenueRepository(context);
                await venueRepository.DeleteAsync(venue2.Id);

                List<VenueDb> allVenues = await context.Venues.ToListAsync();
                Assert.AreEqual(1, allVenues.Count);

                Assert.IsNull(await context.Venues.FindAsync(venue2.Id));
            }
        }

        private static VenueDb GetNewVenue()
        {
            return new VenueDb()
            {
                Address = new AddressDb()
                {
                    AddressLine1 = "123 Some Avenue",
                    AddressLine2 = "Some Street",
                    City = "Some City",
                    Province = "Some Province",
                    PostalCode = "Some Post Code"
                },
                Email = "somevenue@venue.com",
                Name = "GurudwaraSahib",
                Phone = "0000",
                VenueType = VenueType.Gurudwara,
                Website = "www.venue.com"
            };
        }
    }
}

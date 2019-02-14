using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wims.Data.Models;
using Wims.Data.Repositories;

namespace Wims.Data.Tests
{
    [TestClass]
    public class AddressRepositoryTest : BaseTest
    {

        [TestMethod]
        public async Task GivenANewAddress_WhenICreateAnAddress_ItCreatesAnAddress()
        {
            using (var context = new DefaultContext(DbContextOptions))
            {
                var address = GetNewAddress();
                var addressRepository = new AddressRepository(context);

                await addressRepository.CreateAsync(address);

                List<AddressDb> allAddresses = await context.Addresses.ToListAsync();
                Assert.AreEqual(1, allAddresses.Count);
                Assert.AreEqual(1, allAddresses[0].Id);
                Assert.AreEqual(address.AddressLine1, allAddresses[0].AddressLine1);
                Assert.AreEqual(address.AddressLine2, allAddresses[0].AddressLine2);
                Assert.AreEqual(address.City, allAddresses[0].City);
                Assert.AreEqual(address.Province, allAddresses[0].Province);
                Assert.AreEqual(address.PostalCode, allAddresses[0].PostalCode);
                Assert.IsNotNull(address.createdDateUtc);
                Assert.IsNotNull(address.modifiedDateUtc);
            }
        }

        [TestMethod]
        public async Task GivenTwoAddressesInDatabase_WhenIGetAll_ItReturns2Addresses()
        {
            using (var context = new DefaultContext(DbContextOptions))
            {
                var addressRepository = new AddressRepository(context);

                await addressRepository.CreateAsync(GetNewAddress());
                await addressRepository.CreateAsync(GetNewAddress());

                List<AddressDb> allAddresses = await context.Addresses.ToListAsync();
                Assert.AreEqual(2, allAddresses.Count);
            }
        }

        [TestMethod]
        public async Task GivenTwoAddressesInDatabase_WhenIGetById_ItReturnsTheCorrectAddress()
        {
            using (var context = new DefaultContext(DbContextOptions))
            {
                var addressRepository = new AddressRepository(context);

                await addressRepository.CreateAsync(GetNewAddress());
                await addressRepository.CreateAsync(GetNewAddress());

                AddressDb address = await context.Addresses.FindAsync(2);
                Assert.AreEqual(2, address.Id);
            };
        }

        [TestMethod]
        public async Task GivenTwoAddressesInDatabase_WhenIUpdate_ItUpdatesTheCorrectAddress()
        {
            using (var context = new DefaultContext(DbContextOptions))
            {
                var addressRepository = new AddressRepository(context);

                var address1 = GetNewAddress();
                var address2 = GetNewAddress();
                address1 = await addressRepository.CreateAsync(address1);
                address2 = await addressRepository.CreateAsync(address2);
                address2.PostalCode = "test update";

                await addressRepository.UpdateAsync(address2);

                var updatedAddress = await context.FindAsync<AddressDb>(address2.Id);

                Assert.AreEqual(address2.PostalCode, updatedAddress.PostalCode);
                Assert.AreEqual(address2.AddressLine1, updatedAddress.AddressLine1);
                Assert.AreEqual(address2.AddressLine2, updatedAddress.AddressLine2);
                Assert.AreEqual(address2.City, updatedAddress.City);
                Assert.AreEqual(address2.Province, updatedAddress.Province);
            }
        }

        [TestMethod]
        public async Task GivenTwoAddressesInDatabase_WhenIDelete_ItDeletesTheCorrectAddress()
        {
            var address1 = GetNewAddress();
            var address2 = GetNewAddress();
            using (var context = new DefaultContext(DbContextOptions))
            {
                var addressRepository = new AddressRepository(context);

                address1 = await addressRepository.CreateAsync(address1);
                address2 = await addressRepository.CreateAsync(address2);

                List<AddressDb> allAddresses = await context.Addresses.ToListAsync();
                Assert.AreEqual(2, allAddresses.Count);
            }
            using (var context = new DefaultContext(DbContextOptions))
            {
                var addressRepository = new AddressRepository(context);
                await addressRepository.DeleteAsync(address2.Id);

                List<AddressDb> allAddresses = await context.Addresses.ToListAsync();
                Assert.AreEqual(1, allAddresses.Count);

                Assert.IsNull(await context.Addresses.FindAsync(address2.Id));
            }

        }

        private static AddressDb GetNewAddress()
        {
            return new AddressDb()
            {
                AddressLine1 = "123 Some Avenue",
                AddressLine2 = "Some Street",
                City = "Some City",
                Province = "Some Province",
                PostalCode = "Some Post Code"
            };
        }
    }
}

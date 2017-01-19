using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using EntityFramework.MoqHelper;
using AuctionContext;
using AuctionPOCOs;
using System.Data.Entity;

namespace UnitTests
{
    [TestFixture]
    class SqlServerListingsRepositoryTests
    {
        Context context = new Context();

        [Test]
        public void GetAllListings_ReturnsAListingListOfValueZero_WhenCalledAndDatabaseIsEmpty()
        {
            // Arrange
            int expected = 0;
            List<Listing> listingList = new List<Listing>();
            var mockDbSet = EntityFrameworkMoqHelper.CreateMockForDbSet<Listing>()
                .SetupForQueryOn(listingList);
            var mockeAuctionData = EntityFrameworkMoqHelper.CreateMockForDbContext<Context, Listing>(mockDbSet);
            SqlServerListingRepository listingRepo = new SqlServerListingRepository(mockeAuctionData.Object);

            // Act
            List<Listing> actual = listingRepo.GetAllListings();

            // Assert
            Assert.AreEqual(actual.Count(), expected);
        }
    }
}

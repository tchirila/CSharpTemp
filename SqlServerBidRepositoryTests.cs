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
    class SqlServerBidRepositoryTests
    {
        SqlServerBidRepository bidRepo = new SqlServerBidRepository();
        Context context = new Context();

        //[SetUp]
        //public void PreTestEmptyDB()
        //{
        //    context.Users.RemoveRange(context.Users);
        //    context.Bids.RemoveRange(context.Bids);
        //    context.Comments.RemoveRange(context.Comments);
        //    context.Listings.RemoveRange(context.Listings);
        //    context.ProductCategories.RemoveRange(context.ProductCategories);
        //    context.Statuses.RemoveRange(context.Statuses);
        //    context.Shippings.RemoveRange(context.Shippings);
        //    context.SaveChanges();
        //}

        //[TearDown]
        //public void PostTestEmptyDB()
        //{
        //    context.Users.RemoveRange(context.Users);
        //    context.Bids.RemoveRange(context.Bids);
        //    context.Comments.RemoveRange(context.Comments);
        //    context.Listings.RemoveRange(context.Listings);
        //    context.ProductCategories.RemoveRange(context.ProductCategories);
        //    context.Statuses.RemoveRange(context.Statuses);
        //    context.Shippings.RemoveRange(context.Shippings);
        //    context.SaveChanges();
        //}

        [Test]
        public void GetAllBidsForUser_ReturnsABidListOfValueZero_WhenUserIdIsPassedAndDatabaseIsEmpty()
        {
            // Arrange
            int expected = 0;
            int Id = 1;
            List<Bid> bidList = new List<Bid>();
            var mockDbSet = EntityFrameworkMoqHelper.CreateMockForDbSet<Bid>()
                .SetupForQueryOn(bidList);
            var mockeAuctionData = EntityFrameworkMoqHelper.CreateMockForDbContext<Context, Bid>(mockDbSet);
            SqlServerBidRepository bidRepo = new SqlServerBidRepository(mockeAuctionData.Object);
            
            // Act
            List<Bid> actual = bidRepo.GetAllBidsForUser(Id);

            // Assert
            Assert.AreEqual(actual.Count(), expected);
        }

        //[Test]
        //public void GetAllBidsForUser_ReturnsABidListOfOneBidWithUserIdOne_WhenUserIdOneIsPassedInDatabaseWithOneBid()
        //{
        //    // Arrange
        //    int Id = 1;
        //    int expected = 1;
        //    //User user = new User() { Id = 1, Username = "Blue Peter", EmailAddress = "BP@domain.com", Password = "admin", Address = "100 Bond Street" };
        //    //Shipping shipping = new Shipping() { Id = 1, ShipMode = "Free" };
        //    //Status status = new Status() { Id = 1, StatusName = "Current" };
        //    //ProductCategory category = new ProductCategory() { Id = 1, ProductCategoryName = "Decorative" };
        //    //Listing listing = new Listing() { Id = 1, ItemName = "Stuff", Description = "Stuff I'm Selling", AuctionStartTime = DateTime.Now.Date, AuctionEndTime = DateTime.Now.Date, Price = 0, ProductCategory = category, Shipping = shipping, User = user, Status = status, ImageUrl = "/notfound" };
        //    //Bid bid = new Bid() { Id = 1, Listing = listing, User = user, BidAmount = 0.0m };
        //    //context.Users.Add(user);
        //    //context.Shippings.Add(shipping);
        //    //context.Statuses.Add(status);
        //    //context.ProductCategories.Add(category);
        //    //context.SaveChanges();
        //    //context.Listings.Add(listing);
        //    //context.SaveChanges();
        //    //context.Bids.Add(bid);
        //    //context.SaveChanges();

        //    // Act
        //    List<Bid> objectBid = context.Bids.ToList();
        //    List<Bid> actual = bidRepo.GetAllBidsForUser(Id);

        //    // Assert
        //    Assert.AreEqual(actual.FirstOrDefault().UserId, expected);
        //}

        [Test]
        public void GetAllBidsForListing_ReturnsABidListOfValueZero_WhenListingIdIsPassedAndDatabaseIsEmpty()
        {
            // Arrange
            int expected = 0;
            int Id = 1;
            List<Bid> bidList = new List<Bid>();
            var mockDbSet = EntityFrameworkMoqHelper.CreateMockForDbSet<Bid>()
                .SetupForQueryOn(bidList);
            var mockeAuctionData = EntityFrameworkMoqHelper.CreateMockForDbContext<Context, Bid>(mockDbSet);
            SqlServerBidRepository bidRepo = new SqlServerBidRepository(mockeAuctionData.Object);

            // Act
            List<Bid> actual = bidRepo.GetAllBidsForListing(Id);

            // Assert
            Assert.AreEqual(actual.Count(), expected);
        }

        //[Test]
        //public void BidOnListing_AddsANewBidToDatabase_WhenCalled()
        //{
        //    // Arrange
        //    int expected = 2;
        //    Bid bid = new Bid() { Id = 2, Listing = 1, User = 1, BidAmount = 0.0m };

        //    // Act
        //    bidRepo.BidOnListing(bid);
        //    int actual = context.Bids.ToList().Count();

        //    // Assert
        //    Assert.AreEqual(actual, expected);
        //}
    }
}

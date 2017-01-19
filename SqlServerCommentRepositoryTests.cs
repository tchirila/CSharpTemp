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
    class SqlServerCommentRepositoryTests
    {
        Context context = new Context();

        [Test]
        public void GetAllCommentsForListing_ReturnsACommentListOfValueZero_WhenListingIdIsPassedAndDatabaseIsEmpty()
        {
            // Arrange
            int expected = 0;
            int Id = 1;
            List<Comment> commentList = new List<Comment>();
            var mockDbSet = EntityFrameworkMoqHelper.CreateMockForDbSet<Comment>()
                .SetupForQueryOn(commentList);
            var mockeAuctionData = EntityFrameworkMoqHelper.CreateMockForDbContext<Context, Comment>(mockDbSet);
            SqlServerCommentRepository commentRepo = new SqlServerCommentRepository(mockeAuctionData.Object);

            // Act
            List<Comment> actual = commentRepo.GetAllCommentsForListing(Id);

            // Assert
            Assert.AreEqual(actual.Count(), expected);
        }
    }
}

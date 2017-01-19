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
    class SqlServerUserRepositoryTests
    {
        Context context = new Context();
        SqlServerUserRepository userRepo = new SqlServerUserRepository();

        [Test]
        public void GetAllUsers_ReturnsAListOfUsersOfLengthZero_WhenCalledAndTheDatabaseIsEmpty()
        {
            // Arrange
            int expected = 0;
            List<User> userList = new List<User>();
            var mockDbSet = EntityFrameworkMoqHelper.CreateMockForDbSet<User>()
                .SetupForQueryOn(userList);
            var mockeAuctionData = EntityFrameworkMoqHelper.CreateMockForDbContext<Context, User>(mockDbSet);
            SqlServerUserRepository userRepo = new SqlServerUserRepository(mockeAuctionData.Object);

            // Act
            List<User> actual = userRepo.GetAllUsers();

            // Assert
            Assert.AreEqual(actual.Count(), expected);
        }

        [Test]
        public void GetAllUsers_ReturnsAListOfUsersOfLengthOne_WhenCalledAndTheDatabaseHasOneUserObject()
        {
            // Arrange
            int expected = 1;
            List<User> userList = new List<User>();
            Mock<User> mockUser = new Mock<User>();
            userList.Add(mockUser.Object);
            var mockDbSet = EntityFrameworkMoqHelper.CreateMockForDbSet<User>()
                .SetupForQueryOn(userList);
            var mockeAuctionData = EntityFrameworkMoqHelper.CreateMockForDbContext<Context, User>(mockDbSet);
            SqlServerUserRepository userRepo = new SqlServerUserRepository(mockeAuctionData.Object);

            // Act
            List<User> actual = userRepo.GetAllUsers();

            // Assert
            Assert.AreEqual(actual.Count(), expected);
        }

        [Test]
        public void GetUserByUsername_ReturnsAUserOfUsernameValueOfUsername_WhenCalledWithValidUsername()
        {
            // Arrange
            string expected = "username";
            string username = "username";
            Mock<User> user = new Mock<User>();
            user.Object.Id = 1;
            user.Object.EmailAddress = "email@address.com";
            user.Object.Password = "password";
            user.Object.Username = "username";
            List<User> userList = new List<User>();
            userList.Add(user.Object);
            var mockDbSet = EntityFrameworkMoqHelper.CreateMockForDbSet<User>()
                .SetupForQueryOn(userList);
            var mockeAuctionData = EntityFrameworkMoqHelper.CreateMockForDbContext<Context, User>(mockDbSet);
            SqlServerUserRepository userRepo = new SqlServerUserRepository(mockeAuctionData.Object);

            // Act
            User actual = userRepo.GetUserByUsername(username);

            // Assert
            Assert.AreEqual(actual.Username, expected);
        }

        [Test]
        public void GetUserById_ReturnsAUserOfIdValueOfOne_WhenCalledWithValidId()
        {
            // Arrange
            int expected = 1;
            int Id = 1;
            Mock<User> user = new Mock<User>();
            user.Object.Id = 1;
            user.Object.EmailAddress = "email@address.com";
            user.Object.Password = "password";
            user.Object.Username = "username";
            List<User> userList = new List<User>();
            userList.Add(user.Object);
            var mockDbSet = EntityFrameworkMoqHelper.CreateMockForDbSet<User>()
                .SetupForQueryOn(userList);
            var mockeAuctionData = EntityFrameworkMoqHelper.CreateMockForDbContext<Context, User>(mockDbSet);
            SqlServerUserRepository userRepo = new SqlServerUserRepository(mockeAuctionData.Object);

            // Act
            User actual = userRepo.GetUserById(Id);

            // Assert
            Assert.AreEqual(actual.Id, expected);
        }

        [Test]
        public void AddNewUser_AddsANewUserToDatabase_WhenCalledWithValidUserObject()
        {
            // Arrange
            int expected = 1;
            User user = new User();
            user.Id = 1;
            user.EmailAddress = "email@address.com";
            user.Password = "password";
            user.Username = "username";
            List<User> userList = new List<User>();
            var mockDbSet = EntityFrameworkMoqHelper.CreateMockForDbSet<User>()
                .SetupForQueryOn(userList);
            var mockeAuctionData = EntityFrameworkMoqHelper.CreateMockForDbContext<Context, User>(mockDbSet);
            SqlServerUserRepository userRepo = new SqlServerUserRepository(mockeAuctionData.Object);

            // Act
            userRepo.AddNewUser(user);
            int actual = context.Users.ToList().Count();

            // Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void UpdateUser_ReturnsAUserOfIdValueOfOne_WhenCalledWithValidId()
        {
            // Arrange
            string expected = "new_username";
            Mock<User> mockUser = new Mock<User>();
            mockUser.Object.Id = 1;
            mockUser.Object.EmailAddress = "email@address.com";
            mockUser.Object.Password = "password";
            mockUser.Object.Username = "username";
            List<User> userList = new List<User>();
            userList.Add(mockUser.Object);

            User user = new User();
            user.Id = 1;
            user.EmailAddress = "email@address.com";
            user.Password = "password";
            user.Username = "new_username";

            var mockDbSet = EntityFrameworkMoqHelper.CreateMockForDbSet<User>()
                .SetupForQueryOn(userList);
            var mockeAuctionData = EntityFrameworkMoqHelper.CreateMockForDbContext<Context, User>(mockDbSet);
            SqlServerUserRepository userRepo = new SqlServerUserRepository(mockeAuctionData.Object);

            // Act
            userRepo.UpdateUser(user);
            List<User> actual = context.Users.ToList();

            // Assert
            Assert.AreEqual(actual.FirstOrDefault().Username, expected);
        }
    }
}

using Entity.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Repository;
using Services;
using Services.Impl;
using System.Collections.Generic;

namespace ServicesTests
{
    [TestClass]
    public class UserServiceTests
    {
        private IUserService _userServiceTestTarget;
        private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();

        [TestInitialize]
        public void TestInitialize()
        {
            _userServiceTestTarget = new UserService(_userRepository);
            Assert.IsNotNull(_userRepository);
        }

        [TestMethod]
        public void Method_GetUsers_ShouldReturnListOfUsers()
        {
            //Arrange
            var users = new List<UserModel>()
            {
                new UserModel()
                {
                    Bio = "bio",
                    Email = "email",
                    Id = 1,
                    Login = "login",
                    Name = "name",
                    Password = "password"
                },
                new UserModel()
                {
                    Bio = "bio1",
                    Email = "email1",
                    Id = 2,
                    Login = "login1",
                    Name = "name1",
                    Password = "password1"
                }
            };

            _userRepository.GetUsers().Returns(users);
            //Act
            var response = _userServiceTestTarget.GetUsers();

            //Assert
            Assert.AreEqual(users, response);
        }
    }
}

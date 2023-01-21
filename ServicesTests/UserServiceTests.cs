using AutoMapper;
using DTO;
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
        private readonly IMapper _mapper = Substitute.For<IMapper>();

        [TestInitialize]
        public void TestInitialize()
        {
            _userServiceTestTarget = new UserService(_userRepository, _mapper);
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

        [TestMethod]
        public void Method_SaveUser_ShouldReturnNewUser()
        {
            //Arrange
            var newUserPayload = new CreateUserDTO()
            {
                Login = "login",
                Email = "email",
                ConfirmPassword = "password",
                Password = "password",
                Name = "name",
            };

            var newUser = new UserModel()
            {
                Login = "login",
                Email = "email",
                Password = "password",
                Name = "name",
                Bio = null,
                Id = 1
            };

            _userRepository.SaveUser(Arg.Any<UserModel>()).Returns(newUser);

            //Act
            var response = _userServiceTestTarget.SaveUser(newUserPayload);

            //Assert
            Assert.AreEqual(newUser, response);
        }

        [TestMethod]
        public void Method_GetUserByLogin_ShouldReturnUser()
        {
            //Arrange
            string login = "login";

            var user = new UserModel()
            {
                Login = "login",
                Email = "email",
                Password = "password",
                Name = "name",
                Bio = null,
                Id = 1
            };

            _userRepository.GetUserByLogin(login).Returns(user);
            //Act
            var response = _userServiceTestTarget.GetUserByLogin(login);

            //Assert
            Assert.AreEqual(user, response);
        }
    }
}

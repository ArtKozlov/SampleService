using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using DAL;

namespace BLL.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        #region Bad behavior
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_NullUser_ExceptionThrown()
        {
            UserService userService = new UserService();

            userService.AddUser(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserException))]
        public void Add_EmptyFirstName_InvalidUserThrown()
        {
            UserService userService = new UserService();

            userService.AddUser(new User("", "Kazlou", new DateTime(2015, 10, 14)));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserException))]
        public void Add_EmptyLastName_InvalidUserThrown()
        {
            UserService userService = new UserService();

            userService.AddUser(new User("Artsiom", "", new DateTime(2015, 10, 15)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Delete_NullUser_ExceptionThrown()
        {
            UserService userService = new UserService();
            userService.DeleteUser(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetUserById_NullUser_ExceptionThrown()
        {
            UserService userService = new UserService();
            userService.GetUserById(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetUserById_ArgumentOfRange_ExceptionThrown()
        {
            UserService userService = new UserService();
            userService.GetUserById(1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetUserByPredicate_NullPredicate_ExceptionThrown()
        {
            UserService userService = new UserService();
            userService.GetUserByPredicate(null);
        }
        #endregion
        #region Good behavior
        [TestMethod]
        public void AddUser_GoodUser_GoodBehavior()
        {
            IRepository<User> repository = new UserRepository(1,3);
            UserService userService = new UserService(repository);
            User user = new User("Artyom", "Kozlov", new DateTime(2015, 09, 10));
            Assert.AreEqual(user, userService.AddUser(user));
        }

        [TestMethod]
        public void AddUser_GoodUser_GoodGenerateId()
        {
            IRepository<User> repository = new UserRepository(2, 5);
            UserService userService = new UserService(repository);
            User firstUser = new User("Artyom", "Kozlov", new DateTime(2015, 09, 10));
            User secondUser = new User("Artyom", "Kozlov", new DateTime(2015, 09, 10));
            User thirdUser = new User("Artyom", "Kozlov", new DateTime(2015, 09, 10));
            Assert.AreEqual(2, userService.AddUser(firstUser).Id);
            Assert.AreEqual(7, userService.AddUser(secondUser).Id);
            Assert.AreEqual(12, userService.AddUser(thirdUser).Id);
        }

        [TestMethod]
        public void GetuserById_GoodUser_GoodBehavior()
        {
            IRepository<User> repository = new UserRepository(3, 10);
            UserService userService = new UserService(repository);
            User firstUser = new User("Artyom", "Kozlov", new DateTime(2015, 09, 10));
            User secondUser = new User("Artyom", "Kozlov", new DateTime(2015, 09, 10));
            userService.AddUser(firstUser);
            userService.AddUser(secondUser);
            Assert.AreEqual(firstUser, userService.GetUserById(3));
            Assert.AreEqual(secondUser, userService.GetUserById(13));
        }

        [TestMethod]
        public void GetUserByPredicate_GoodUsers_GoodBehavior()
        {
            UserService userService = new UserService();
            User firstUser = new User("Artyom", "Kozlov", new DateTime(2015, 09, 10));
            User secondUser = new User("Art", "Kozlov", new DateTime(2015, 09, 10));
            userService.AddUser(firstUser);
            userService.AddUser(secondUser);
            Assert.AreEqual(firstUser, userService.GetUserByPredicate(m => m.FirstName == "Artyom").First());
            Assert.AreEqual(secondUser, userService.GetUserByPredicate(m => m.FirstName == "Art").First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteUser_GoodUser_ArgumentOutOfRange()
        {
            UserService userService = new UserService();
            User firstUser = new User("Artyom", "Kozlov", new DateTime(2015, 09, 10));
            userService.AddUser(firstUser);
            Assert.AreEqual(firstUser, userService.GetUserByPredicate(m => m.FirstName == "Artyom").First());
            userService.DeleteUser(firstUser);
            userService.GetUserById(1);
        }
        #endregion
    }
}

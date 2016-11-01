using System;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }


        public User AddUser(User user)
        {
            if (ReferenceEquals(user, null))
                throw new ArgumentNullException();
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
                throw new InvalidUserException();
            return _userRepository.Add(user);
        }

        public void DeleteUser(User user)
        {
            if (ReferenceEquals(user, null))
                throw new ArgumentNullException();
            _userRepository.Delete(user);
        }

        public User GetUserById(int? id)
        {
            if (ReferenceEquals(id, null))
                throw new ArgumentNullException();
            if (_userRepository.GetById(id) == null)
                throw new ArgumentOutOfRangeException();
            return _userRepository.GetById(id);
        }

        public IEnumerable<User> GetUserByPredicate(Func<User, bool> predicate)
        {
            if(ReferenceEquals(predicate, null))
                throw new ArgumentNullException();
            return _userRepository.GetByPredicate(predicate);
        }

    }
}

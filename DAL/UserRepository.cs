using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class UserRepository : IRepository<User>
    {
        private List<User> _userRepository = new List<User>();
        private int _startId;
        private int _stepId;

        public UserRepository()
        {
            _startId = 1;
            _stepId = 1;
        }

        public UserRepository(int startId)
        {
            _startId = startId;
            _stepId = 1;
        }

        public UserRepository(int startId, int stepId)
        {
            _startId = startId;
            _stepId = stepId;
        }
        public User Add(User user)
        {
            if (_userRepository.Contains(user))
                return user;
            if(_userRepository.Count != 0)
                user.Id = _userRepository.Last().Id + _stepId;        
            else
                user.Id = _startId;
            _userRepository.Add(user);
            return user;
        }

        public void Delete(User user)
        {
            _userRepository.Remove(user);
        }

        public User GetById(int? id)
        {
            return _userRepository.Find(m => m.Id == id);
        }

        public IEnumerable<User> GetByPredicate(Func<User, bool> predicate)
        {
            return _userRepository.Where(predicate);
        }
    }
}

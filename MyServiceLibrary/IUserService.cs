using System;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public interface IUserService
    {

        IEnumerable<User> GetUserByPredicate(Func<User, bool> predicate);

        void DeleteUser(User user);

        User AddUser(User user);

        User GetUserById(int? id);
    }
}

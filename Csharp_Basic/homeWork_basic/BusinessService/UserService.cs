using homeWork_basic.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_basic.bunises_logic
{
    public class UserService
    {

        public void  DisplayUser(List<User> listUser)
        {
            foreach (User user in listUser)
            {
                Console.WriteLine($"index: {user.Id} , Name: {user.Name}, Price: {user.Password}");
            }
        }
    }
}

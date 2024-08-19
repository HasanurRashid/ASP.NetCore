using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public class MemberShip
    {
        public void CreateAccount(string userName, string email,  string password)
        {
            string encryptedPassword = EncryptPassword(password);
        }

        public string EncryptPassword(string password) // Here SRP violation occured
        {
            throw new NotImplementedException();
        }
    }
}

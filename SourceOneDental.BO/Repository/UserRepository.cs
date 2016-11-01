using OFUtility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceOneDental.BO.Repository
{
    public class UserRepository : Framework.BaseRepository<User>, Framework.IBaseRepository<User>
    {
        public User ValidateUser(string UsernameOrEmail)
        {
            try
            {
                var result = UsernameOrEmail.Contains("@") ? context.User.FirstOrDefault(i => i.Email == UsernameOrEmail.Trim())
                : context.User.FirstOrDefault(i => i.Username == UsernameOrEmail.Trim());

                return result ?? new User();
            }
            catch (Exception)
            {
                return new User();

            }
        }

        public User ValidateUser(string UsernameOrEmail, string password)
        {
            password = OFUtility.Security.EncryptPassword(password);

            try
            {
                var result = UsernameOrEmail.Contains("@") ? context.User.FirstOrDefault(i => i.Email == UsernameOrEmail.Trim() && i.Password == password)
                : context.User.FirstOrDefault(i => i.Username == UsernameOrEmail.Trim() && i.Password == password);

                return result ?? new User();
            }
            catch (Exception)
            {
                return new User();
            }
        }
    }
}

using Antonino.Classes;
using Antonino.Infrastructure.Abstract;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace Antonino.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        private IDataBase db;

        public FormsAuthProvider(IDataBase dbParam)
        {
            db = dbParam;
        }

        public User Authenticate(string email, string passwordClearText)
        {
            User model = new User();
            model.Email = email;
            model.Password = Encrypt(passwordClearText);
            User loggedUser = db.GetUser(model);
            if (loggedUser != null)
            {
                FormsAuthentication.SetAuthCookie(email, false);
            }
            return loggedUser;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        private string Encrypt(string password)
        {
            byte[] data = Encoding.UTF8.GetBytes(password);
            byte[] hash;
            using (SHA512 shaM = new SHA512Managed())
            {
                hash = shaM.ComputeHash(data);
            }
            StringBuilder encryptedPsw = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                encryptedPsw.Append(hash[i].ToString("X2"));
            }
            return encryptedPsw.ToString().ToLower();
        }
    }
}
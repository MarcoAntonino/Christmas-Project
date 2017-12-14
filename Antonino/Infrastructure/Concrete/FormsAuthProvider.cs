using Antonino.Classes;
using Antonino.Infrastructure.Abstract;
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

        public User Authenticate(string email, string password)
        {
            User loggedUser = db.GetUser(new User { Email = email, PasswordClearText = password });
            if (loggedUser != null)
            {
                FormsAuthentication.SetAuthCookie(email, false);
            }
            return loggedUser;
        }
    }
}
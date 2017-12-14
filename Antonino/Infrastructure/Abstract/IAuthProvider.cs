using Antonino.Classes;

namespace Antonino.Infrastructure.Abstract
{
    public interface IAuthProvider
    {
        User Authenticate(string email, string password);
    }
}

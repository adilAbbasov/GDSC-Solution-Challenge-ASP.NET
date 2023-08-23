using GoogleSolution.Models.Entity;
using PhotoHome.Models;
using PhotoHome.Models.Entity;

namespace PhotoHome.IRepository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(User users);
    }
}

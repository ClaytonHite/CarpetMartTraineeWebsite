using WebsiteProjectCarpetMart.Models;
using WebsiteProjectCarpetMart.ViewModels;

namespace WebsiteProjectCarpetMart.Factories
{
    public class UserFactory
    {
        public static IUserModel CreateUserModel()
        {
            return new UserModel();
        }

    }
}

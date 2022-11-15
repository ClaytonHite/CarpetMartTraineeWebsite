using Microsoft.Extensions.Configuration;
using WebsiteProjectCarpetMart;
using WebsiteProjectCarpetMart.BusinessLogic;
using WebsiteProjectCarpetMart.ViewModels;

namespace WebsiteProject.Tests
{
    public class UserTests
    {
        [Fact]
        public void TestCreateUserProfile()
        {
            InitializeConnectionString();
            string userId = "9999";
            UserViewModel userTest = new UserViewModel();
            userTest.FirstName = "Bob";
            userTest.MiddleName = "Ronald";
            userTest.LastName = "Smith";
            userTest.AddressLine1 = "10 Unit Test Street";
            userTest.AddressLine2 = "Unit #2";
            userTest.City = "Louisville";
            userTest.State = "KY";
            userTest.Zip = "40203";
            userTest.Phone = "1 (888) 867-5309";
            userTest.Email = "Bob.Smith@gmail.com";

            UserBL userBL = new UserBL();
            UserViewModel user = new UserViewModel();
            user = userBL.AddUserProfile(userTest, userId);

            Assert.Equal(user, userTest);
        }
        [Fact]
        public void TestReadUserProfile()
        {
            TestCreateUserProfile();
            InitializeConnectionString();
            string userId = "9999";
            UserViewModel userTest = new UserViewModel();
            UserBL userBL = new UserBL();

            userTest = userBL.CheckExistingProfile(userId);

            Assert.NotNull(userTest);
            TestDeleteUserProfile();
        }
        [Fact]
        public void TestUpdateUserProfile()
        {
            TestCreateUserProfile();
            InitializeConnectionString();
            string userId = "9999";
            UserBL userBL = new UserBL();
            UserViewModel userExisting = new UserViewModel();
            userExisting = userBL.CheckExistingProfile(userId);
            UserViewModel userTest = new UserViewModel();
            userTest.FirstName = "Bob";
            userTest.MiddleName = "Ronald";
            userTest.LastName = "Smith";
            userTest.AddressLine1 = "10 Moved Out Street";
            userTest.AddressLine2 = "";
            userTest.City = "Louisville";
            userTest.State = "KY";
            userTest.Zip = "40203";
            userTest.Phone = "1 (502) 867-5309";
            userTest.Email = "Bob.Smith@gmail.com";

            UserViewModel userResult = new UserViewModel();
            userResult = userBL.UpdateUserProfile(userTest, userId);

            Assert.NotSame(userResult, userExisting);
            TestDeleteUserProfile();
        }
        [Fact]
        public void TestDeleteUserProfile()
        {
            InitializeConnectionString();
            string userId = "9999";
            int result;
            UserBL userBL = new UserBL();

            result = userBL.DeleteProfile(userId);

            Assert.True(result == 0);
        }
        public static void InitializeConnectionString()
        {
            var connBuilder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");
            IConfiguration configuration = connBuilder.Build();
            Config.Initialize(configuration.GetValue<string>("ConnectionStrings:DefaultConnection"));
        }
    }
}

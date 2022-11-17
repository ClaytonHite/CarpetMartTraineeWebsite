using DataLibrary.DTOs;
using WebsiteProjectCarpetMart.BusinessLogic;
using WebsiteProjectCarpetMart.ViewModels;

namespace WebsiteProject.Tests
{
    public class UserTests
    {
        [Fact]
        public void TestCreateUserProfile()
        {
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

            UserViewModel user = new UserViewModel();
            FakeUserRepository fakeUserRepository = new FakeUserRepository();
            UserBL userBL = new UserBL(fakeUserRepository);
            user = userBL.AddUserProfile(userTest, userId);

            UserDTO addedUser = fakeUserRepository.CheckExistingProfile("9999");
            Assert.Equal(userTest.FirstName, addedUser.FirstName);
            Assert.Equal(userTest.MiddleName, addedUser.MiddleName);
            Assert.Equal(userTest.LastName, addedUser.LastName);
            Assert.Equal(userTest.AddressLine1, addedUser.AddressLine1);
            Assert.Equal(userTest.City, addedUser.City);
            Assert.Equal(userTest.State, addedUser.State);
            Assert.Equal(userTest.Zip, addedUser.Zip);
            Assert.Equal(userTest.Phone, addedUser.Phone);
            Assert.Equal(userTest.Email, addedUser.Email);
        }
        
        [Fact]
        public void TestReadUserProfile()
        {
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
            UserViewModel user = new UserViewModel();
            FakeUserRepository fakeUserRepository = new FakeUserRepository();
            UserBL userBL = new UserBL(fakeUserRepository);
            user = userBL.AddUserProfile(userTest, userId);

            UserDTO addedUser = fakeUserRepository.CheckExistingProfile("9999");

            Assert.NotNull(addedUser.FirstName);
            Assert.NotNull(addedUser.MiddleName);
            Assert.NotNull(addedUser.LastName);
            Assert.NotNull(addedUser.AddressLine1);
            Assert.NotNull(addedUser.AddressLine2);
            Assert.NotNull(addedUser.City);
            Assert.NotNull(addedUser.State);
            Assert.NotNull(addedUser.Zip);
            Assert.NotNull(addedUser.Phone);
            Assert.NotNull(addedUser.Email);
        }
        
        [Fact]
        public void TestUpdateUserProfile()
        {
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
            FakeUserRepository fakeUserRepository = new FakeUserRepository();
            UserBL userBL = new UserBL(fakeUserRepository);
            userTest = userBL.AddUserProfile(userTest, userId);

            string userIdUpdate = "9999";
            UserViewModel userUpdate = new UserViewModel();
            userUpdate.FirstName = "Bobby";
            userUpdate.MiddleName = "Ronny";
            userUpdate.LastName = "Smithson";
            userUpdate.AddressLine1 = "10 Moved Street";
            userUpdate.AddressLine2 = "";
            userUpdate.City = "Nashville";
            userUpdate.State = "TN";
            userUpdate.Zip = "50980";
            userUpdate.Phone = "1 (857) 867-5309";
            userUpdate.Email = "Bob.SmithMovedToTN@gmail.com";
            userUpdate = userBL.UpdateUserProfile(userUpdate, userIdUpdate);

            Assert.NotSame(userTest.FirstName, userUpdate.FirstName);
            Assert.NotSame(userTest.MiddleName, userUpdate.MiddleName);
            Assert.NotSame(userTest.LastName, userUpdate.LastName);
            Assert.NotSame(userTest.AddressLine1, userUpdate.AddressLine1);
            Assert.NotSame(userTest.City, userUpdate.City);
            Assert.NotSame(userTest.State, userUpdate.State);
            Assert.NotSame(userTest.Zip, userUpdate.Zip);
            Assert.NotSame(userTest.Phone, userUpdate.Phone);
            Assert.NotSame(userTest.Email, userUpdate.Email);
        }

        [Fact]
        public void TestDeleteUserProfile()
        {
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
            FakeUserRepository fakeUserRepository = new FakeUserRepository();
            UserBL userBL = new UserBL(fakeUserRepository);
            userTest = userBL.AddUserProfile(userTest, userId);

            int result = userBL.DeleteProfile(userId);

            Assert.False(result == 0);
        }
    }
}

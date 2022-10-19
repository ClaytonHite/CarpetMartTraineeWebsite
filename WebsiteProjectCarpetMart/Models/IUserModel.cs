namespace WebsiteProjectCarpetMart.Models
{
    public interface IUserModel
    {
        int Account_Id { get; set; }
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string City { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        string Phone { get; set; }
        string State { get; set; }
        string Zip { get; set; }
    }
}
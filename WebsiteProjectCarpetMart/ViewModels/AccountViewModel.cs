namespace WebsiteProjectCarpetMart.ViewModels
{
	public class AccountViewModel
	{
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AccessRights { get; set; }
        public bool EntrySuccessfull { get; set; }
    }
}

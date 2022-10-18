using WebsiteProjectCMart.ViewModels;
using DataLibrary.DTOs;
using DataLibrary.Repository;
using WebsiteProjectCMart.Models;
using System.Security.Principal;

namespace WebsiteProjectCMart.BusinessLogic
{
	public class AccountBL
	{
		public AccountViewModel VerifyAccount(AccountViewModel avm)
		{
			AccountRepository accountRepository = new AccountRepository();
            AccountDTO accountDTO = accountRepository.VerifyAccount(ConvertAccVMToAccDTO(avm));
			AccountViewModel accountVM = new AccountViewModel();
            if (accountDTO.Username == avm.Username && accountDTO.Password == avm.Password)
			{
				accountVM = ConvertAccDTOToAccVM(accountDTO);
				accountVM.EntrySuccessfull = true;
                return accountVM;
            }
			else
			{
                accountVM.EntrySuccessfull = false;
				return accountVM;
			}
		}
		public AccountViewModel ConvertAccDTOToAccVM(AccountDTO accountDTO)
		{
			AccountViewModel accountVM = new AccountViewModel();
            accountVM.Username = accountDTO.Username;
            accountVM.Password = accountDTO.Password;
			return accountVM;
		}
		public AccountDTO ConvertAccVMToAccDTO(AccountViewModel avm)
		{
			AccountDTO accDTO = new AccountDTO();
			accDTO.Username = avm.Username;
			accDTO.Password = avm.Password;
			return accDTO;
		}
	}
}

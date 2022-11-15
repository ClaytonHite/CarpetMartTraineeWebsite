using DataLibrary.DTOs;
using DataLibrary.Repository;
using Microsoft.AspNetCore.Identity;
using WebsiteProjectCarpetMart.Models;
using WebsiteProjectCarpetMart.ViewModels;

namespace WebsiteProjectCarpetMart.BusinessLogic
{
    public class UserBL
    {
        public UserViewModel CheckExistingProfile(string id)
        {
            string connString = Config.GetConnectionString("WebsiteDatabase");
            UserRepository userRepository = new UserRepository();
            UserDTO userDTO = userRepository.CheckExistingProfile(id, connString);
            UserModel userModel = ConvertDTOToModel(userDTO);
            return ConvertModelToViewModel(userModel);
        }
        public UserViewModel AddUserProfile(UserViewModel uvm, string MSId)
        {
            UserModel uM = ConvertViewModelToModel(uvm);
			UserDTO userDTO = ConvertModelToDTO(uM);
            userDTO.MSId = MSId;
			string connString = Config.GetConnectionString("WebsiteDatabase");
			UserRepository userRepository = new UserRepository();
            userDTO = userRepository.AddUserProfile(userDTO, connString);
			return uvm;
        }
		public UserViewModel UpdateUserProfile(UserViewModel uvm, string MSId)
        {
			UserModel uM = ConvertViewModelToModel(uvm);
			UserDTO userDTO = ConvertModelToDTO(uM);
			userDTO.MSId = MSId;
			string connString = Config.GetConnectionString("WebsiteDatabase");
			UserRepository userRepository = new UserRepository();
			userDTO = userRepository.UpdateUserProfile(userDTO, connString);
			return uvm;
		}
        public int DeleteProfile(string MSId)
        {
            string connString = Config.GetConnectionString("WebsiteDatabase");
            UserRepository userRepository = new UserRepository();
            return userRepository.DeleteProfile(MSId, connString);
        }
        public UserModel ConvertViewModelToModel(UserViewModel uvm)
        {
            UserModel userModel = new UserModel();
			userModel.Id = uvm.Account_Id;
			userModel.FirstName = uvm.FirstName;
			userModel.MiddleName = uvm.MiddleName;
			userModel.LastName = uvm.LastName;
			userModel.AddressLine1 = uvm.AddressLine1;
			userModel.AddressLine2 = uvm.AddressLine2;
			userModel.City = uvm.City;
			userModel.State = uvm.State;
			userModel.Zip = uvm.Zip;
			userModel.Phone = uvm.Phone;
			userModel.Email = uvm.Email;
            return userModel;
		}
		public UserDTO ConvertModelToDTO(UserModel uM)
		{
			UserDTO userDTO = new UserDTO();
			userDTO.Id = uM.Id;
			userDTO.FirstName = uM.FirstName;
			userDTO.MiddleName = uM.MiddleName;
			userDTO.LastName = uM.LastName;
			userDTO.AddressLine1 = uM.AddressLine1;
			userDTO.AddressLine2 = uM.AddressLine2;
			userDTO.City = uM.City;
			userDTO.State = uM.State;
			userDTO.Zip = uM.Zip;
			userDTO.Phone = uM.Phone;
			userDTO.Email = uM.Email;
			return userDTO;
		}
		public UserModel ConvertDTOToModel(UserDTO uDTO)
        {
            UserModel userModel = new UserModel();
            userModel.Id = uDTO.Id;
            userModel.MSId = uDTO.MSId;
            userModel.FirstName = uDTO.FirstName;
            userModel.MiddleName = uDTO.MiddleName;
            userModel.LastName = uDTO.LastName;
            userModel.AddressLine1 = uDTO.AddressLine1;
            userModel.AddressLine2 = uDTO.AddressLine2;
            userModel.City = uDTO.City;
            userModel.State = uDTO.State;
            userModel.Zip = uDTO.Zip;
            userModel.Phone = uDTO.Phone;
            userModel.Email = uDTO.Email;
            return userModel;
        }
        public UserViewModel ConvertModelToViewModel(UserModel uM)
        {
            UserViewModel uVModel = new UserViewModel();
            uVModel.Account_Id = uM.Id;
            uVModel.FirstName = uM.FirstName;
            uVModel.MiddleName = uM.MiddleName;
            uVModel.LastName = uM.LastName;
            uVModel.AddressLine1 = uM.AddressLine1;
            uVModel.AddressLine2 = uM.AddressLine2;
            uVModel.City = uM.City;
            uVModel.State = uM.State;
            uVModel.Zip = uM.Zip;
            uVModel.Phone = uM.Phone;
            uVModel.Email = uM.Email;
            return uVModel;
        }
    }
}

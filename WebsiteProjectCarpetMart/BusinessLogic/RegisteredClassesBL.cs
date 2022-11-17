using DataLibrary.DTOs;
using DataLibrary.Repository;
using System.Collections.Generic;
using WebsiteProjectCarpetMart.Models;
using WebsiteProjectCarpetMart.ViewModels;

namespace WebsiteProjectCarpetMart.BusinessLogic
{
    public class RegisteredClassesBL
    {
        private IRegisteredClassesRepository _registeredClassesRepository;
        public RegisteredClassesBL(IRegisteredClassesRepository registeredClassesRepository)
        {
            _registeredClassesRepository = registeredClassesRepository;
        }
        public List<RegisteredClassesViewModel> GetListOfTraineesForClass(string className)
        {
            List<RegisteredClassesDTO> rCDTOList = _registeredClassesRepository.GetListOfTraineesForClass(className);
            List<RegisteredClassesModel> rCMList = ConvertDTOListToModelList(rCDTOList);
            return ConvertModelListToViewModelList(rCMList);
        }
        private List<RegisteredClassesModel> ConvertDTOListToModelList(List<RegisteredClassesDTO> rCDTO)
        {
            List<RegisteredClassesModel> modelList = new List<RegisteredClassesModel>();
            for(int i = 0; i < rCDTO.Count; i++)
            {
                RegisteredClassesModel rCM = new RegisteredClassesModel();
                List<UserModel> userModelList = new List<UserModel>();
                for (int j = 0; j < rCDTO[i].userDTOList.Count; j++)
                {
                    UserModel userModel = new UserModel();
                    userModel.Id = rCDTO[i].userDTOList[j].Id;
                    userModel.FirstName = rCDTO[i].userDTOList[j].FirstName;
                    userModel.MiddleName = rCDTO[i].userDTOList[j].MiddleName;
                    userModel.LastName = rCDTO[i].userDTOList[j].LastName;
                    userModel.AddressLine1 = rCDTO[i].userDTOList[j].AddressLine1;
                    userModel.AddressLine2 = rCDTO[i].userDTOList[j].AddressLine2;
                    userModel.City = rCDTO[i].userDTOList[j].City;
                    userModel.State = rCDTO[i].userDTOList[j].State;
                    userModel.Zip = rCDTO[i].userDTOList[j].Zip;
                    userModel.Phone = rCDTO[i].userDTOList[j].Phone;
                    userModel.Email = rCDTO[i].userDTOList[j].Email;
                    userModelList.Add(userModel);
                }
                ClassModel classModel = new ClassModel();
                classModel.ClassName = rCDTO[i].classDTO.ClassName;
                classModel.ClassStartDate = rCDTO[i].classDTO.ClassStartDate;
                classModel.ClassEndDate = rCDTO[i].classDTO.ClassEndDate;
                classModel.ClassStartTime = rCDTO[i].classDTO.ClassStartTime;
                classModel.ClassEndTime = rCDTO[i].classDTO.ClassEndTime;
                classModel.ClassInformation = rCDTO[i].classDTO.ClassInformation;
                classModel.ClassHost = rCDTO[i].classDTO.ClassHost;
                classModel.ClassAddress = rCDTO[i].classDTO.ClassAddress;
                classModel.ClassId = rCDTO[i].classDTO.ClassId;
                rCM.ClassModel = classModel;
                rCM.UserModelList = userModelList;
                modelList.Add(rCM);
            }
            return modelList;
        }
        private List<RegisteredClassesViewModel> ConvertModelListToViewModelList(List<RegisteredClassesModel> rCVMList)
        {
            List<RegisteredClassesViewModel> modelList = new List<RegisteredClassesViewModel>();
            for (int i = 0; i < rCVMList.Count; i++)
            {
                RegisteredClassesViewModel rCVM = new RegisteredClassesViewModel();
                List<UserViewModel> userViewModelList = new List<UserViewModel>();
                for (int j = 0; j < rCVMList[i].UserModelList.Count; j++)
                {
                    UserViewModel userViewModel = new UserViewModel();
                    userViewModel.FirstName = rCVMList[i].UserModelList[j].FirstName;
                    userViewModel.MiddleName = rCVMList[i].UserModelList[j].MiddleName;
                    userViewModel.LastName = rCVMList[i].UserModelList[j].LastName;
                    userViewModel.AddressLine1 = rCVMList[i].UserModelList[j].AddressLine1;
                    userViewModel.AddressLine2 = rCVMList[i].UserModelList[j].AddressLine2;
                    userViewModel.City = rCVMList[i].UserModelList[j].City;
                    userViewModel.State = rCVMList[i].UserModelList[j].State;
                    userViewModel.Zip = rCVMList[i].UserModelList[j].Zip;
                    userViewModel.Phone = rCVMList[i].UserModelList[j].Phone;
                    userViewModel.Email = rCVMList[i].UserModelList[j].Email;
                    userViewModelList.Add(userViewModel);
                }
                ClassViewModel classViewModel = new ClassViewModel();
                classViewModel.ClassName = rCVMList[i].ClassModel.ClassName;
                classViewModel.ClassStartDate = rCVMList[i].ClassModel.ClassStartDate;
                classViewModel.ClassEndDate = rCVMList[i].ClassModel.ClassEndDate;
                classViewModel.ClassStartTime = rCVMList[i].ClassModel.ClassStartTime;
                classViewModel.ClassEndTime = rCVMList[i].ClassModel.ClassEndTime;
                classViewModel.ClassInformation = rCVMList[i].ClassModel.ClassInformation;
                classViewModel.ClassHost = rCVMList[i].ClassModel.ClassHost;
                classViewModel.ClassAddress = rCVMList[i].ClassModel.ClassAddress;
                rCVM.ClassViewModel = classViewModel;
                rCVM.UserViewModelList = userViewModelList;
                modelList.Add(rCVM);
            }
            return modelList;
        }
    }
}

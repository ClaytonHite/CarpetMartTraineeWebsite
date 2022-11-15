using DataLibrary.DataAccessLayer;
using DataLibrary.DTOs;
using DataLibrary.Repository;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using WebsiteProjectCarpetMart.Models;
using WebsiteProjectCarpetMart.ViewModels;

namespace WebsiteProjectCarpetMart.BusinessLogic
{
    public class ClassBL
    {
        public List<ClassViewModel> ClassList()
        {
            string connString = Config.GetConnectionString("WebsiteDatabase");
            List<ClassViewModel> list = new List<ClassViewModel>();
            ClassRepository classRepository = new ClassRepository();
            List<ClassDTO> classDTOList = classRepository.ClassList(connString);
            for (int i = 0; i < classDTOList.Count; i++)
            {
                ClassModel cM = ConvertDTOToModel(classDTOList[i]);
                ClassViewModel cVM = ConvertModelToViewModel(cM);
                list.Add(cVM);
            }
            return list;
        }
        public ClassViewModel CheckExistingClass(string name)
        {
            string connString = Config.GetConnectionString("WebsiteDatabase");
            ClassRepository classRepository = new ClassRepository();
            ClassDTO classDTO = classRepository.ReadClass(name, connString);
            ClassModel classModel = ConvertDTOToModel(classDTO);
            return ConvertModelToViewModel(classModel);
        }
        public ClassViewModel AddClass(ClassViewModel cVM)
        {
            ClassModel cM = ConvertViewModelToModel(cVM);
            ClassDTO classDTO = ConvertModelToDTO(cM);
            string connString = Config.GetConnectionString("WebsiteDatabase");
            ClassRepository classRepository = new ClassRepository();
            cM = ConvertDTOToModel(classRepository.AddClass(classDTO, connString));
            return ConvertModelToViewModel(cM);
        }
        public ClassViewModel UpdateClass(ClassViewModel cVm)
        {
            ClassModel cM = ConvertViewModelToModel(cVm);
            ClassDTO ClassDTO = ConvertModelToDTO(cM);
            string connString = Config.GetConnectionString("WebsiteDatabase");
            ClassRepository ClassRepository = new ClassRepository();
            cM = ConvertDTOToModel(ClassRepository.UpdateClass(ClassDTO, connString));
            return ConvertModelToViewModel(cM);
        }
        public int DeleteClass(string className)
        {
            string connString = Config.GetConnectionString("WebsiteDatabase");
            ClassRepository ClassRepository = new ClassRepository();
            return ClassRepository.DeleteClass(className, connString);
        }
        public ClassModel ConvertViewModelToModel(ClassViewModel cVm)
        {
            ClassModel ClassModel = new ClassModel();
            ClassModel.ClassName = cVm.ClassName;
            ClassModel.ClassStartDate = cVm.ClassStartDate;
            ClassModel.ClassEndDate = cVm.ClassEndDate;
            ClassModel.ClassStartTime = cVm.ClassStartTime;
            ClassModel.ClassEndTime = cVm.ClassEndTime;
            ClassModel.ClassInformation = cVm.ClassInformation;
            ClassModel.ClassHost = cVm.ClassHost;
            ClassModel.ClassAddress = cVm.ClassAddress;
            return ClassModel;
        }
        public ClassDTO ConvertModelToDTO(ClassModel cM)
        {
            ClassDTO ClassDTO = new ClassDTO();
            ClassDTO.ClassName = cM.ClassName;
            ClassDTO.ClassStartDate = cM.ClassStartDate;
            ClassDTO.ClassEndDate = cM.ClassEndDate;
            ClassDTO.ClassStartTime = cM.ClassStartTime;
            ClassDTO.ClassEndTime = cM.ClassEndTime;
            ClassDTO.ClassInformation = cM.ClassInformation;
            ClassDTO.ClassHost = cM.ClassHost;
            ClassDTO.ClassAddress = cM.ClassAddress;
            ClassDTO.ClassId = cM.ClassId;
            return ClassDTO;
        }
        public ClassModel ConvertDTOToModel(ClassDTO cDTO)
        {
            ClassModel ClassModel = new ClassModel();
            ClassModel.ClassName = cDTO.ClassName;
            ClassModel.ClassStartDate = cDTO.ClassStartDate;
            ClassModel.ClassEndDate = cDTO.ClassEndDate;
            ClassModel.ClassStartTime = cDTO.ClassStartTime;
            ClassModel.ClassEndTime = cDTO.ClassEndTime;
            ClassModel.ClassInformation = cDTO.ClassInformation;
            ClassModel.ClassHost = cDTO.ClassHost;
            ClassModel.ClassAddress = cDTO.ClassAddress;
            ClassModel.ClassId = cDTO.ClassId;
            return ClassModel;
        }
        public ClassViewModel ConvertModelToViewModel(ClassModel cM)
        {
            ClassViewModel cVModel = new ClassViewModel();
            cVModel.ClassName = cM.ClassName;
            cVModel.ClassStartDate = cM.ClassStartDate;
            cVModel.ClassEndDate = cM.ClassEndDate;
            cVModel.ClassStartTime = cM.ClassStartTime;
            cVModel.ClassEndTime = cM.ClassEndTime;
            cVModel.ClassInformation = cM.ClassInformation;
            cVModel.ClassHost = cM.ClassHost;
            cVModel.ClassAddress = cM.ClassAddress;
            return cVModel;
        }
    }
}

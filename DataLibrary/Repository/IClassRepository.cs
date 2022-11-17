using DataLibrary.DTOs;
using System.Data;

namespace DataLibrary.Repository
{
    public interface IClassRepository
    {
        ClassDTO AddClass(ClassDTO addClass);
        List<ClassDTO> ClassList();
        ClassDTO ConvertDataTableToDTO(DataTable dataTable);
        List<ClassDTO> ConvertDataTableToDTOList(DataTable dataTable);
        int DeleteClass(string className);
        ClassDTO ReadClass(string name);
        ClassDTO UpdateClass(ClassDTO updateClass);
        string RegisterForClass(string className, string MSId);
    }
}
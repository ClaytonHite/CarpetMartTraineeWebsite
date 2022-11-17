using DataLibrary.DTOs;
using System.Data;

namespace DataLibrary.Repository
{
    public interface IRegisteredClassesRepository
    {
        List<RegisteredClassesDTO> ConvertDataTableToDTO(DataTable dataTable);
        List<RegisteredClassesDTO> GetListOfTraineesForClass(string className);
    }
}
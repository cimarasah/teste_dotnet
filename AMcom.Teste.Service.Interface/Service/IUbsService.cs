using AMcom.Teste.Service.Interface.DTO;
using System.Collections.Generic;

namespace AMcom.Teste.Service.Interface.Service
{
    public interface IUbsService
    {
        IEnumerable<UbsDTO> GetUbs();
        UbsDTO GetUbsByID(int Id);
        void Add(UbsDTO ubs);
        void AddRange(IEnumerable<UbsDTO> ubsList);
        void Delete(int Id);
        IEnumerable<UbsDTO> GetByLocationAsync(double latitude, double longitude, int count);
        bool ImportCsvUbs(string path);
        IEnumerable<double> GetDistancia(double latitude, double longitude);
    }
}

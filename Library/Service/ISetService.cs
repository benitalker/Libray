using Library.Models;
using Library.ViewModel;

namespace Library.Service
{
    public interface ISetService
    {
        List<SetModel> GetAllSetsById(long id);
        void CreateSet(SetVM newSet);
        void DeleteSet(long id);
    }
}

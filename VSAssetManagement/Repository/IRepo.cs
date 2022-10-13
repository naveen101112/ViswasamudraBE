using System.Collections.Generic;
using VSAssetManagement.IOModels;

namespace VSAssetManagement.Repo
{
    public interface IRepo
    {
        public List<T> getAllList<T>(Pagination page);
    }
}

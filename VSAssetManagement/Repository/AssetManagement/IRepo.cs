using System.Collections.Generic;
using ViswasamudraCommonObjects.Util;

namespace VSManagement.Repository.AssetManagement
{
    public interface IRepo
    {
        public List<T> getAllList<T>(Pagination page);
    }
}

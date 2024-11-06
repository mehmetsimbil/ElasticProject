using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IBrandDal BrandDal { get; }
        public IProductDal ProductDal { get; }
        public ICategoryDal CategoryDal { get; }   
        public IUserDal UserDal { get; }
        public IRoleDal RoleDal { get; }
        public IUserRoleDal UserRoleDal { get;}
        int Save();
    }
}

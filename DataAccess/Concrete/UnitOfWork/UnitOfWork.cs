using DataAccess.Abstract;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IBrandDal brandDal, IProductDal productDal, ICategoryDal categoryDal, IUserDal userDal, IRoleDal roleDal, IUserRoleDal userRoleDal, ProjectContext projectContext)
        {
            BrandDal = brandDal;
            ProductDal = productDal;
            CategoryDal = categoryDal;
            UserDal = userDal;
            RoleDal = roleDal;
            UserRoleDal = userRoleDal;
            _projectContext = projectContext;
        }
        private readonly ProjectContext _projectContext;
        public IBrandDal BrandDal { get; set; }
        public IProductDal ProductDal { get ; set; }
        public ICategoryDal CategoryDal { get ; set ; }
        public IUserDal UserDal { get ; set ; }
        public IRoleDal RoleDal { get ; set ; }
        public IUserRoleDal UserRoleDal { get; set; }

        public void Dispose()
        {
            _projectContext.Dispose();
        }

        public int Save()
        {
          return _projectContext.SaveChanges();
        }
    }
}

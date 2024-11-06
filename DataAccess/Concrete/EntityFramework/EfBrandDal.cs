using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfRepositoryBase<Brand, ProjectContext>, IBrandDal
    {
        public EfBrandDal(ProjectContext context) : base(context)
        {
        }
    }
}

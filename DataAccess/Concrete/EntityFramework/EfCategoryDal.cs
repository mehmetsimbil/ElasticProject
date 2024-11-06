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
    public class EfCategoryDal : EfRepositoryBase<Category, ProjectContext>, ICategoryDal
    {
        public EfCategoryDal(ProjectContext context) : base(context)
        {
        }
    }
}

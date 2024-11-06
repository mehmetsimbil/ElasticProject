using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRoleDal : EfRepositoryBase<Role, ProjectContext>, IRoleDal
    {
        public EfRoleDal(ProjectContext context) : base(context)
        {
        }
    }
}

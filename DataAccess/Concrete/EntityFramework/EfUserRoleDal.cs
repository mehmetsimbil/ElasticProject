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
    public class EfUserRoleDal : EfRepositoryBase<UserRole, ProjectContext>, IUserRoleDal
    {
        public EfUserRoleDal(ProjectContext context) : base(context)
        {
        }
    }
}

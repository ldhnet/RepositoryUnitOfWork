using Framework.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.EFCore
{
    public interface IUserRepository : IBaseRepository<UserEntity, int>
    { 
       public List<UserEntity> GetAll();
    }
}

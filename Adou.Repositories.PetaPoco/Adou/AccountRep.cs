using Adou.Entity.PetaPocoModels.AdouModel;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adou.Repositories.PetaPoco.Adou
{
    public class AccountRep
    {
        /// <summary>
        /// 添加账户
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns>int</returns>
        public long InsertAccount(adAccount model)
        {
            PetaPocoAdouDB.GetInstance().Insert(model);
            return model.Id;
        }
    }
}

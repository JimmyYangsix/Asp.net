using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace BLL
{
    public class UserInfoBll
    {
        DAL.UserInfoDal userinfodal = new DAL.UserInfoDal();
        public List<UserInfo> GetList()
        {
            return userinfodal.GetList();
        }
    }
}

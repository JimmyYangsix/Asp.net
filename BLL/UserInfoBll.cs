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
        public bool DeleteUserInfo(int id)
        {
            return userinfodal.DeleteUserInfo(id) > 0;
        }
        public bool  AddUser(string[] Allinfo)
        {
            return userinfodal.AddUser(Allinfo) > 0;
        }
        public bool UpdateInfo(string[] Allinfo)
        {
            return userinfodal.UpdateInfo(Allinfo) > 0;
        }
    }
}

using System;
using System.Collections.Generic;
using DBHelper.SQLHelper;
using Hoshino.Entity;
using Hoshino.IRepository;

namespace Hoshino.Repository
{
    public class sys_user_Repository : Isys_user_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        public bool Insert(sys_user_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (model.User_Account != null)
            {
                dic["User_Account"] = model.User_Account;
            }
            if (model.Password != null)
            {
                dic["Password"] = model.Password;
            }
            if (model.User_Name != null)
            {
                dic["User_Name"] = model.User_Name;
            }
            if (model.User_Status != null && model.User_Status.HasValue)
            {
                dic["User_Status"] = model.User_Status;
            }
            if (model.Create_UserId != null)
            {
                dic["Create_UserId"] = model.Create_UserId;
            }
            if (model.Create_User != null)
            {
                dic["Create_User"] = model.Create_User;
            }
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_sys_user", dic) > 0;
        }

        /// <summary>
        /// 修改
        /// <summary>
        public bool Update(sys_user_Entity model, int User_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["User_ID"] = User_ID;
            if (model.User_Account != null)
            {
                dic["User_Account"] = model.User_Account;
            }
            if (model.Password != null)
            {
                dic["Password"] = model.Password;
            }
            if (model.User_Name != null)
            {
                dic["User_Name"] = model.User_Name;
            }
            if (model.User_Status != null && model.User_Status.HasValue)
            {
                dic["User_Status"] = model.User_Status;
            }
            if (model.Update_UserId != null)
            {
                dic["Update_UserId"] = model.Update_UserId;
            }
            if (model.Update_User != null)
            {
                dic["Update_User"] = model.Update_User;
            }
            return SQLHelperFactory.Instance.ExecuteNonQuery("Update_sys_user", dic) > 0;
        }

        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(int User_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["User_ID"] = User_ID;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_sys_user", dic) > 0;
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        public sys_user_Entity Get(int User_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["User_ID"] = User_ID;
            return SQLHelperFactory.Instance.QueryForObjectByT<sys_user_Entity>("Select_sys_user", dic);
        }
        public sys_user_Entity GetUserByAccount(string Account)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["User_Account"] = Account;
            return SQLHelperFactory.Instance.QueryForObjectByT<sys_user_Entity>("Select_sys_user_by_account", dic);
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<sys_user_Entity>, int) GetList(sys_user_Entity model, int pageindex, int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (model.User_ID != 0)
            {
                dic["User_ID"] = model.User_ID;
            }
            if (model.User_Account != null)
            {
                dic["User_Account"] = model.User_Account;
            }
            if (model.Password != null)
            {
                dic["Password"] = model.Password;
            }
            if (model.User_Name != null)
            {
                dic["User_Name"] = model.User_Name;
            }
            if (model.User_Status != null && model.User_Status.HasValue)
            {
                dic["User_Status"] = model.User_Status;
            }
            if (pageindex >= 0)
            {
                dic["StartIndex"] = pageindex <= 1 ? 0 : (pageindex - 1) * pagesize + 1;
            }
            if (pagesize > 0)
            {
                dic["SelectCount"] = pagesize;
            }
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<sys_user_Entity>("Select_sys_user_List", dic, out int total);
            return (list, total);
        }

    }
}

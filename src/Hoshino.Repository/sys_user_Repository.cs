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
            dic["User_ID"] = model.User_ID;
            dic["User_Account"] = model.User_Account;
            dic["Password"] = model.Password;
            dic["User_Name"] = model.User_Name;
            dic["User_Status"] = model.User_Status;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_sys_user", dic) >0 ;
        }

        /// <summary>
        /// 修改
        /// <summary>
        public bool Update(sys_user_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["User_ID"] = model.User_ID;
            dic["User_Account"] = model.User_Account;
            dic["Password"] = model.Password;
            dic["User_Name"] = model.User_Name;
            dic["User_Status"] = model.User_Status;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Update_sys_user", dic) >0 ;
        }

        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(sys_user_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["User_ID"] = model.User_ID;
            dic["User_Account"] = model.User_Account;
            dic["Password"] = model.Password;
            dic["User_Name"] = model.User_Name;
            dic["User_Status"] = model.User_Status;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_sys_user", dic) >0 ;
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        public sys_user_Entity Get(sys_user_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["User_ID"] = model.User_ID;
            dic["User_Account"] = model.User_Account;
            dic["Password"] = model.Password;
            dic["User_Name"] = model.User_Name;
            dic["User_Status"] = model.User_Status;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.QueryForObjectByT<sys_user_Entity>("Select_sys_user", dic);
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<sys_user_Entity>,int) GetList(sys_user_Entity model,int pageindex,int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["User_ID"] = model.User_ID;
            dic["User_Account"] = model.User_Account;
            dic["Password"] = model.Password;
            dic["User_Name"] = model.User_Name;
            dic["User_Status"] = model.User_Status;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<sys_user_Entity>("Select_sys_user_List", dic,out int total);
            return (list,total);
        }

    }
}

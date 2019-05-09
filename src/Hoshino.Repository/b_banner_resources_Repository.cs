using System;
using System.Collections.Generic;
using DBHelper.SQLHelper;
using Hoshino.Entity;
using Hoshino.IRepository;

namespace Hoshino.Repository
{
    public class b_banner_resources_Repository : Ib_banner_resources_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        public bool Insert(b_banner_resources_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Banner_ID"] = model.Banner_ID;
            dic["Banner_Name_CH"] = model.Banner_Name_CH;
            dic["Banner_Name_HK"] = model.Banner_Name_HK;
            dic["Banner_URL"] = model.Banner_URL;
            dic["Banner_Type"] = model.Banner_Type;
            dic["Banner_Location"] = model.Banner_Location;
            dic["Banner_Status"] = model.Banner_Status;
            dic["Banner_Seq"] = model.Banner_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_b_banner_resources", dic) >0 ;
        }

        /// <summary>
        /// 修改
        /// <summary>
        public bool Update(b_banner_resources_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Banner_ID"] = model.Banner_ID;
            dic["Banner_Name_CH"] = model.Banner_Name_CH;
            dic["Banner_Name_HK"] = model.Banner_Name_HK;
            dic["Banner_URL"] = model.Banner_URL;
            dic["Banner_Type"] = model.Banner_Type;
            dic["Banner_Location"] = model.Banner_Location;
            dic["Banner_Status"] = model.Banner_Status;
            dic["Banner_Seq"] = model.Banner_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Update_b_banner_resources", dic) >0 ;
        }

        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(b_banner_resources_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Banner_ID"] = model.Banner_ID;
            dic["Banner_Name_CH"] = model.Banner_Name_CH;
            dic["Banner_Name_HK"] = model.Banner_Name_HK;
            dic["Banner_URL"] = model.Banner_URL;
            dic["Banner_Type"] = model.Banner_Type;
            dic["Banner_Location"] = model.Banner_Location;
            dic["Banner_Status"] = model.Banner_Status;
            dic["Banner_Seq"] = model.Banner_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_b_banner_resources", dic) >0 ;
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        public b_banner_resources_Entity Get(b_banner_resources_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Banner_ID"] = model.Banner_ID;
            dic["Banner_Name_CH"] = model.Banner_Name_CH;
            dic["Banner_Name_HK"] = model.Banner_Name_HK;
            dic["Banner_URL"] = model.Banner_URL;
            dic["Banner_Type"] = model.Banner_Type;
            dic["Banner_Location"] = model.Banner_Location;
            dic["Banner_Status"] = model.Banner_Status;
            dic["Banner_Seq"] = model.Banner_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.QueryForObjectByT<b_banner_resources_Entity>("Select_b_banner_resources", dic);
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<b_banner_resources_Entity>,int) GetList(b_banner_resources_Entity model,int pageindex,int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Banner_ID"] = model.Banner_ID;
            dic["Banner_Name_CH"] = model.Banner_Name_CH;
            dic["Banner_Name_HK"] = model.Banner_Name_HK;
            dic["Banner_URL"] = model.Banner_URL;
            dic["Banner_Type"] = model.Banner_Type;
            dic["Banner_Location"] = model.Banner_Location;
            dic["Banner_Status"] = model.Banner_Status;
            dic["Banner_Seq"] = model.Banner_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<b_banner_resources_Entity>("Select_b_banner_resources_List", dic,out int total);
            return (list,total);
        }

    }
}

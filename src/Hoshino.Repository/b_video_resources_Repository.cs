using System;
using System.Collections.Generic;
using DBHelper.SQLHelper;
using Hoshino.Entity;
using Hoshino.IRepository;

namespace Hoshino.Repository
{
    public class b_video_resources_Repository : Ib_video_resources_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        public bool Insert(b_video_resources_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Video_ID"] = model.Video_ID;
            dic["Video_Name_CH"] = model.Video_Name_CH;
            dic["Video_Name_HK"] = model.Video_Name_HK;
            dic["Video_URL"] = model.Video_URL;
            dic["Video_Location"] = model.Video_Location;
            dic["Video_Status"] = model.Video_Status;
            dic["Video_Seq"] = model.Video_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_b_video_resources", dic) >0 ;
        }

        /// <summary>
        /// 修改
        /// <summary>
        public bool Update(b_video_resources_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Video_ID"] = model.Video_ID;
            dic["Video_Name_CH"] = model.Video_Name_CH;
            dic["Video_Name_HK"] = model.Video_Name_HK;
            dic["Video_URL"] = model.Video_URL;
            dic["Video_Location"] = model.Video_Location;
            dic["Video_Status"] = model.Video_Status;
            dic["Video_Seq"] = model.Video_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Update_b_video_resources", dic) >0 ;
        }

        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(b_video_resources_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Video_ID"] = model.Video_ID;
            dic["Video_Name_CH"] = model.Video_Name_CH;
            dic["Video_Name_HK"] = model.Video_Name_HK;
            dic["Video_URL"] = model.Video_URL;
            dic["Video_Location"] = model.Video_Location;
            dic["Video_Status"] = model.Video_Status;
            dic["Video_Seq"] = model.Video_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_b_video_resources", dic) >0 ;
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        public b_video_resources_Entity Get(b_video_resources_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Video_ID"] = model.Video_ID;
            dic["Video_Name_CH"] = model.Video_Name_CH;
            dic["Video_Name_HK"] = model.Video_Name_HK;
            dic["Video_URL"] = model.Video_URL;
            dic["Video_Location"] = model.Video_Location;
            dic["Video_Status"] = model.Video_Status;
            dic["Video_Seq"] = model.Video_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.QueryForObjectByT<b_video_resources_Entity>("Select_b_video_resources", dic);
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<b_video_resources_Entity>,int) GetList(b_video_resources_Entity model,int pageindex,int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Video_ID"] = model.Video_ID;
            dic["Video_Name_CH"] = model.Video_Name_CH;
            dic["Video_Name_HK"] = model.Video_Name_HK;
            dic["Video_URL"] = model.Video_URL;
            dic["Video_Location"] = model.Video_Location;
            dic["Video_Status"] = model.Video_Status;
            dic["Video_Seq"] = model.Video_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<b_video_resources_Entity>("Select_b_video_resources_List", dic,out int total);
            return (list,total);
        }

    }
}

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
            if(model.Video_ID != 0)
            {
                dic["Video_ID"] = model.Video_ID;
            }
            if(model.Video_Name_CH != null)
            {
                dic["Video_Name_CH"] = model.Video_Name_CH;
            }
            if(model.Video_Name_HK != null)
            {
                dic["Video_Name_HK"] = model.Video_Name_HK;
            }
            if(model.Video_URL != null)
            {
                dic["Video_URL"] = model.Video_URL;
            }
            if(model.Video_Location != null)
            {
                dic["Video_Location"] = model.Video_Location;
            }
            if(model.Video_Status != null && model.Video_Status.HasValue)
            {
                dic["Video_Status"] = model.Video_Status;
            }
            if(model.Video_Seq >= 0)
            {
                dic["Video_Seq"] = model.Video_Seq;
            }
            if(model.Create_Time != null && model.Create_Time.HasValue)
            {
                dic["Create_Time"] = model.Create_Time;
            }
            if(model.Create_UserId != null)
            {
                dic["Create_UserId"] = model.Create_UserId;
            }
            if(model.Create_User != null)
            {
                dic["Create_User"] = model.Create_User;
            }
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_b_video_resources", dic) >0 ;
        }

        /// <summary>
        /// 修改
        /// <summary>
        public bool Update(int Video_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Video_ID"] = Video_ID;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Update_b_video_resources", dic) >0 ;
        }

        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(int Video_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Video_ID"] = Video_ID;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_b_video_resources", dic) >0 ;
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        public b_video_resources_Entity Get(int Video_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Video_ID"] = Video_ID;
            return SQLHelperFactory.Instance.QueryForObjectByT<b_video_resources_Entity>("Select_b_video_resources", dic);
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<b_video_resources_Entity>,int) GetList(b_video_resources_Entity model,int pageindex,int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.Video_ID != 0)
            {
                dic["Video_ID"] = model.Video_ID;
            }
            if(model.Video_Name_CH != null)
            {
                dic["Video_Name_CH"] = model.Video_Name_CH;
            }
            if(model.Video_Name_HK != null)
            {
                dic["Video_Name_HK"] = model.Video_Name_HK;
            }
            if(model.Video_URL != null)
            {
                dic["Video_URL"] = model.Video_URL;
            }
            if(model.Video_Location != null)
            {
                dic["Video_Location"] = model.Video_Location;
            }
            if(model.Video_Status != null && model.Video_Status.HasValue)
            {
                dic["Video_Status"] = model.Video_Status;
            }
            if(model.Video_Seq >= 0)
            {
                dic["Video_Seq"] = model.Video_Seq;
            }
            if (pageindex >= 0)
            {
                dic["StartIndex"] = pageindex == 0 ? 0 : pageindex * pagesize + 1;
            }
            if (pagesize > 0)
            {
                dic["SelectCount"] = pagesize;
            }
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<b_video_resources_Entity>("Select_b_video_resources_List", dic,out int total);
            return (list,total);
        }

    }
}

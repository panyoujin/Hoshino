﻿using System;
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
            if(model.Banner_ID != 0)
            {
                dic["Banner_ID"] = model.Banner_ID;
            }
            if(model.Banner_Name_CH != null)
            {
                dic["Banner_Name_CH"] = model.Banner_Name_CH;
            }
            if(model.Banner_Name_HK != null)
            {
                dic["Banner_Name_HK"] = model.Banner_Name_HK;
            }
            if(model.Banner_URL != null)
            {
                dic["Banner_URL"] = model.Banner_URL;
            }
            if(model.Banner_Type != null)
            {
                dic["Banner_Type"] = model.Banner_Type;
            }
            if(model.Banner_Location != null)
            {
                dic["Banner_Location"] = model.Banner_Location;
            }
            if(model.Banner_Status != null && model.Banner_Status.HasValue)
            {
                dic["Banner_Status"] = model.Banner_Status;
            }
            if(model.Banner_Seq >= 0)
            {
                dic["Banner_Seq"] = model.Banner_Seq;
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
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_b_banner_resources", dic) >0 ;
        }

        /// <summary>
        /// 修改
        /// <summary>
        public bool Update(int Banner_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Banner_ID"] = Banner_ID;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Update_b_banner_resources", dic) >0 ;
        }

        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(int Banner_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Banner_ID"] = Banner_ID;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_b_banner_resources", dic) >0 ;
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        public b_banner_resources_Entity Get(int Banner_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Banner_ID"] = Banner_ID;
            return SQLHelperFactory.Instance.QueryForObjectByT<b_banner_resources_Entity>("Select_b_banner_resources", dic);
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<b_banner_resources_Entity>,int) GetList(b_banner_resources_Entity model,int pageindex,int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.Banner_ID != 0)
            {
                dic["Banner_ID"] = model.Banner_ID;
            }
            if(model.Banner_Name_CH != null)
            {
                dic["Banner_Name_CH"] = model.Banner_Name_CH;
            }
            if(model.Banner_Name_HK != null)
            {
                dic["Banner_Name_HK"] = model.Banner_Name_HK;
            }
            if(model.Banner_URL != null)
            {
                dic["Banner_URL"] = model.Banner_URL;
            }
            if(model.Banner_Type != null)
            {
                dic["Banner_Type"] = model.Banner_Type;
            }
            if(model.Banner_Location != null)
            {
                dic["Banner_Location"] = model.Banner_Location;
            }
            if(model.Banner_Status != null && model.Banner_Status.HasValue)
            {
                dic["Banner_Status"] = model.Banner_Status;
            }
            if(model.Banner_Seq >= 0)
            {
                dic["Banner_Seq"] = model.Banner_Seq;
            }
            if (pageindex >= 0)
            {
                dic["StartIndex"] = pageindex == 0 ? 0 : pageindex * pagesize + 1;
            }
            if (pagesize > 0)
            {
                dic["SelectCount"] = pagesize;
            }
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<b_banner_resources_Entity>("Select_b_banner_resources_List", dic,out int total);
            return (list,total);
        }

    }
}

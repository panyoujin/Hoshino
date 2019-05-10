using System;
using System.Collections.Generic;
using DBHelper.SQLHelper;
using Hoshino.Entity;
using Hoshino.IRepository;

namespace Hoshino.Repository
{
    public class b_category_Repository : Ib_category_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        public bool Insert(b_category_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Category_ID"] = model.Category_ID;
            dic["Parent_Category_ID"] = model.Parent_Category_ID;
            dic["Category_Name_CH"] = model.Category_Name_CH;
            dic["Category_Name_HK"] = model.Category_Name_HK;
            dic["Category_Status"] = model.Category_Status;
            dic["Category_Seq"] = model.Category_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_b_category", dic) >0 ;
        }

        /// <summary>
        /// 修改
        /// <summary>
        public bool Update(b_category_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Category_ID"] = model.Category_ID;
            dic["Parent_Category_ID"] = model.Parent_Category_ID;
            dic["Category_Name_CH"] = model.Category_Name_CH;
            dic["Category_Name_HK"] = model.Category_Name_HK;
            dic["Category_Status"] = model.Category_Status;
            dic["Category_Seq"] = model.Category_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Update_b_category", dic) >0 ;
        }

        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(b_category_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Category_ID"] = model.Category_ID;
            dic["Parent_Category_ID"] = model.Parent_Category_ID;
            dic["Category_Name_CH"] = model.Category_Name_CH;
            dic["Category_Name_HK"] = model.Category_Name_HK;
            dic["Category_Status"] = model.Category_Status;
            dic["Category_Seq"] = model.Category_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_b_category", dic) >0 ;
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        public b_category_Entity Get(b_category_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Category_ID"] = model.Category_ID;
            dic["Parent_Category_ID"] = model.Parent_Category_ID;
            dic["Category_Name_CH"] = model.Category_Name_CH;
            dic["Category_Name_HK"] = model.Category_Name_HK;
            dic["Category_Status"] = model.Category_Status;
            dic["Category_Seq"] = model.Category_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.QueryForObjectByT<b_category_Entity>("Select_b_category", dic);
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<b_category_Entity>,int) GetList(b_category_Entity model,int pageindex,int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Category_ID"] = model.Category_ID;
            dic["Parent_Category_ID"] = model.Parent_Category_ID;
            dic["Category_Name_CH"] = model.Category_Name_CH;
            dic["Category_Name_HK"] = model.Category_Name_HK;
            dic["Category_Status"] = model.Category_Status;
            dic["Category_Seq"] = model.Category_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            dic["StartIndex"] = pageindex == 0 ? 0 : pageindex * pagesize + 1;
            dic["SelectCount"] = pagesize;
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<b_category_Entity>("Select_b_category_List", dic,out int total);
            return (list,total);
        }
    }
}

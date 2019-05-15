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
            if (model.Parent_Category_ID != null && model.Parent_Category_ID.HasValue)
            {
                dic["Parent_Category_ID"] = model.Parent_Category_ID;
            }
            if (model.Category_Name_CH != null)
            {
                dic["Category_Name_CH"] = model.Category_Name_CH;
            }
            if (model.Category_Name_HK != null)
            {
                dic["Category_Name_HK"] = model.Category_Name_HK;
            }
            if (model.Category_Status != null && model.Category_Status.HasValue)
            {
                dic["Category_Status"] = model.Category_Status;
            }
            if (model.Category_Seq >= 0)
            {
                dic["Category_Seq"] = model.Category_Seq;
            }
            if (model.Create_UserId != null)
            {
                dic["Create_UserId"] = model.Create_UserId;
            }
            if (model.Create_User != null)
            {
                dic["Create_User"] = model.Create_User;
            }
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_b_category", dic) > 0;
        }

        /// <summary>
        /// 修改
        /// <summary>
        public bool Update(b_category_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (model.Category_ID != 0)
            {
                dic["Category_ID"] = model.Category_ID;
            }
            if (model.Parent_Category_ID != null && model.Parent_Category_ID.HasValue)
            {
                dic["Parent_Category_ID"] = model.Parent_Category_ID;
            }
            if (model.Category_Name_CH != null)
            {
                dic["Category_Name_CH"] = model.Category_Name_CH;
            }
            if (model.Category_Name_HK != null)
            {
                dic["Category_Name_HK"] = model.Category_Name_HK;
            }
            if (model.Category_Status != null && model.Category_Status.HasValue)
            {
                dic["Category_Status"] = model.Category_Status;
            }
            if (model.Category_Seq >= 0)
            {
                dic["Category_Seq"] = model.Category_Seq;
            }
            if (model.Update_Time != null && model.Update_Time.HasValue)
            {
                dic["Update_Time"] = model.Update_Time;
            }
            if (model.Update_UserId != null)
            {
                dic["Update_UserId"] = model.Update_UserId;
            }
            if (model.Update_User != null)
            {
                dic["Update_User"] = model.Update_User;
            }
            return SQLHelperFactory.Instance.ExecuteNonQuery("Update_b_category", dic) > 0;
        }

        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(int Category_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Category_ID"] = Category_ID;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_b_category", dic) > 0;
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        public b_category_Entity Get(int Category_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Category_ID"] = Category_ID;
            return SQLHelperFactory.Instance.QueryForObjectByT<b_category_Entity>("Select_b_category", dic);
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<b_category_Entity>, int) GetList(int pageindex, int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (pageindex >= 0)
            {
                dic["StartIndex"] = pageindex <= 1 ? 0 : (pageindex - 1) * pagesize + 1;
            }
            if (pagesize > 0)
            {
                dic["SelectCount"] = pagesize;
            }
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<b_category_Entity>("Select_b_category_List", dic, out int total);
            return (list, total);
        }

    }
}

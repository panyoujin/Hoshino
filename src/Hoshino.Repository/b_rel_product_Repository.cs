using System;
using System.Collections.Generic;
using DBHelper.SQLHelper;
using Hoshino.Entity;
using Hoshino.IRepository;

namespace Hoshino.Repository
{
    public class b_rel_product_Repository : Ib_rel_product_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        public bool Insert(List<b_rel_product_Entity> list)
        {
            List<Dictionary<string, object>> dicList = new List<Dictionary<string, object>>();
            foreach (var model in list)
            {

                Dictionary<string, object> dic = new Dictionary<string, object>();
                if (model.Source_Product_ID != 0)
                {
                    dic["Source_Product_ID"] = model.Source_Product_ID;
                }
                if (model.Rel_Product_ID != 0)
                {
                    dic["Rel_Product_ID"] = model.Rel_Product_ID;
                }
                if (model.P_Relevant_Status != null && model.P_Relevant_Status.HasValue)
                {
                    dic["P_Relevant_Status"] = model.P_Relevant_Status;
                }
                if (model.P_Relevant_Seq >= 0)
                {
                    dic["P_Relevant_Seq"] = model.P_Relevant_Seq;
                }
                if (model.Create_UserId != null)
                {
                    dic["Create_UserId"] = model.Create_UserId;
                }
                if (model.Create_User != null)
                {
                    dic["Create_User"] = model.Create_User;
                }
                dicList.Add(dic);
            }
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_b_rel_product", dicList) > 0;
        }

        /// <summary>
        /// 修改
        /// <summary>
        public bool Update(List<b_rel_product_Entity> list)
        {
            List<Dictionary<string, object>> dicList = new List<Dictionary<string, object>>();
            foreach (var model in list)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic["P_Relevant_ID"] = model.P_Relevant_ID;
                if (model.Source_Product_ID != 0)
                {
                    dic["Source_Product_ID"] = model.Source_Product_ID;
                }
                if (model.Rel_Product_ID != 0)
                {
                    dic["Rel_Product_ID"] = model.Rel_Product_ID;
                }
                if (model.P_Relevant_Status != null && model.P_Relevant_Status.HasValue)
                {
                    dic["P_Relevant_Status"] = model.P_Relevant_Status;
                }
                if (model.P_Relevant_Seq >= 0)
                {
                    dic["P_Relevant_Seq"] = model.P_Relevant_Seq;
                }
                if (model.Update_UserId != null)
                {
                    dic["Update_UserId"] = model.Update_UserId;
                }
                if (model.Update_User != null)
                {
                    dic["Update_User"] = model.Update_User;
                }
                dicList.Add(dic);
            }
            return SQLHelperFactory.Instance.ExecuteNonQuery("Update_b_rel_product", dicList) > 0;
        }

        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(List<int> idList)
        {
            List<Dictionary<string, object>> dicList = new List<Dictionary<string, object>>();
            foreach (var id in idList)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic["P_Relevant_ID"] = id;
                dicList.Add(dic);
            }
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_b_rel_product", dicList) > 0;
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        public b_rel_product_Entity Get(int P_Relevant_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["P_Relevant_ID"] = P_Relevant_ID;
            return SQLHelperFactory.Instance.QueryForObjectByT<b_rel_product_Entity>("Select_b_rel_product", dic);
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<b_rel_product_Entity>, int) GetList(int Product_ID, int pageindex, int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (Product_ID > 0)
            {
                dic["Product_ID"] = Product_ID;
            }
            if (pageindex >= 0)
            {
                dic["StartIndex"] = pageindex <= 1 ? 0 : (pageindex - 1) * pagesize;
            }
            if (pagesize > 0)
            {
                dic["SelectCount"] = pagesize;
            }
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<b_rel_product_Entity>("Select_b_rel_product_List", dic, out int total);
            return (list, total);
        }

    }
}

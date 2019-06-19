using System;
using System.Collections.Generic;
using DBHelper.SQLHelper;
using Hoshino.Entity;
using Hoshino.IRepository;

namespace Hoshino.Repository
{
    public class b_product_attribute_template_Repository : Ib_product_attribute_template_Repository
    {
        /// <summary>
        /// 新增
        /// </summary>
        public bool Insert(List<b_product_attribute_template_Entity> list)
        {
            List<Dictionary<string, object>> dicList = new List<Dictionary<string, object>>();
            foreach (var model in list)
            {

                Dictionary<string, object> dic = new Dictionary<string, object>();
                if (model.P_Attribute_Name_CH != null)
                {
                    dic["P_Attribute_Name_CH"] = model.P_Attribute_Name_CH;
                }
                if (model.P_Attribute_Name_HK != null)
                {
                    dic["P_Attribute_Name_HK"] = model.P_Attribute_Name_HK;
                }
                dic["P_Attribute_Seq"] = model.P_Attribute_Seq;
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
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_b_product_attribute_template", dicList) > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Delete()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_b_product_attribute_template", dic) > 0;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        public List<T> GetList<T>()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            var list = SQLHelperFactory.Instance.QueryForListByT<T>("Select_b_product_attribute_template_List", dic);
            return list;
        }

    }
}

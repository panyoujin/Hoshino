using System;
using System.Collections.Generic;
using DBHelper.SQLHelper;
using Hoshino.Entity;
using Hoshino.IRepository;

namespace Hoshino.Repository
{
    public class b_product_attribute_Repository : Ib_product_attribute_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        public bool Insert(b_product_attribute_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.Product_ID != 0)
            {
                dic["Product_ID"] = model.Product_ID;
            }
            if(model.P_Attribute_Name_CH != null)
            {
                dic["P_Attribute_Name_CH"] = model.P_Attribute_Name_CH;
            }
            if(model.P_Attribute_Name_HK != null)
            {
                dic["P_Attribute_Name_HK"] = model.P_Attribute_Name_HK;
            }
            if(model.P_Attribute_Value_CH != null)
            {
                dic["P_Attribute_Value_CH"] = model.P_Attribute_Value_CH;
            }
            if(model.P_Attribute_Value_EN != null)
            {
                dic["P_Attribute_Value_EN"] = model.P_Attribute_Value_EN;
            }
            if(model.P_Attribute_Status != null && model.P_Attribute_Status.HasValue)
            {
                dic["P_Attribute_Status"] = model.P_Attribute_Status;
            }
            if(model.P_Attribute_Seq >= 0)
            {
                dic["P_Attribute_Seq"] = model.P_Attribute_Seq;
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
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_b_product_attribute", dic) >0 ;
        }

        /// <summary>
        /// 修改
        /// <summary>
        public bool Update(b_product_attribute_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (model.P_Attribute_ID != 0)
            {
                dic["P_Attribute_ID"] = model.P_Attribute_ID;
            }
            if (model.Product_ID != 0)
            {
                dic["Product_ID"] = model.Product_ID;
            }
            if (model.P_Attribute_Name_CH != null)
            {
                dic["P_Attribute_Name_CH"] = model.P_Attribute_Name_CH;
            }
            if (model.P_Attribute_Name_HK != null)
            {
                dic["P_Attribute_Name_HK"] = model.P_Attribute_Name_HK;
            }
            if (model.P_Attribute_Value_CH != null)
            {
                dic["P_Attribute_Value_CH"] = model.P_Attribute_Value_CH;
            }
            if (model.P_Attribute_Value_EN != null)
            {
                dic["P_Attribute_Value_EN"] = model.P_Attribute_Value_EN;
            }
            if (model.P_Attribute_Status != null && model.P_Attribute_Status.HasValue)
            {
                dic["P_Attribute_Status"] = model.P_Attribute_Status;
            }
            if (model.P_Attribute_Seq >= 0)
            {
                dic["P_Attribute_Seq"] = model.P_Attribute_Seq;
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
            return SQLHelperFactory.Instance.ExecuteNonQuery("Update_b_product_attribute", dic) >0 ;
        }

        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(int P_Attribute_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["P_Attribute_ID"] = P_Attribute_ID;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_b_product_attribute", dic) >0 ;
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        public b_product_attribute_Entity Get(int P_Attribute_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["P_Attribute_ID"] = P_Attribute_ID;
            return SQLHelperFactory.Instance.QueryForObjectByT<b_product_attribute_Entity>("Select_b_product_attribute", dic);
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<b_product_attribute_Entity>,int) GetList(b_product_attribute_Entity model,int pageindex,int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.P_Attribute_ID != 0)
            {
                dic["P_Attribute_ID"] = model.P_Attribute_ID;
            }
            if(model.Product_ID != 0)
            {
                dic["Product_ID"] = model.Product_ID;
            }
            if(model.P_Attribute_Name_CH != null)
            {
                dic["P_Attribute_Name_CH"] = model.P_Attribute_Name_CH;
            }
            if(model.P_Attribute_Name_HK != null)
            {
                dic["P_Attribute_Name_HK"] = model.P_Attribute_Name_HK;
            }
            if(model.P_Attribute_Value_CH != null)
            {
                dic["P_Attribute_Value_CH"] = model.P_Attribute_Value_CH;
            }
            if(model.P_Attribute_Value_EN != null)
            {
                dic["P_Attribute_Value_EN"] = model.P_Attribute_Value_EN;
            }
            if(model.P_Attribute_Status != null && model.P_Attribute_Status.HasValue)
            {
                dic["P_Attribute_Status"] = model.P_Attribute_Status;
            }
            if(model.P_Attribute_Seq >= 0)
            {
                dic["P_Attribute_Seq"] = model.P_Attribute_Seq;
            }
            if (pageindex >= 0)
            {
                dic["StartIndex"] = pageindex <= 1 ? 0 : (pageindex - 1) * pagesize + 1;
            }
            if (pagesize > 0)
            {
                dic["SelectCount"] = pagesize;
            }
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<b_product_attribute_Entity>("Select_b_product_attribute_List", dic,out int total);
            return (list,total);
        }

    }
}

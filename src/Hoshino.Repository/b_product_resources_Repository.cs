using System;
using System.Collections.Generic;
using DBHelper.SQLHelper;
using Hoshino.Entity;
using Hoshino.IRepository;

namespace Hoshino.Repository
{
    public class b_product_resources_Repository : Ib_product_resources_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        public bool Insert(b_product_resources_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["P_Resources_ID"] = model.P_Resources_ID;
            dic["Product_ID"] = model.Product_ID;
            dic["P_Resources_Name_CH"] = model.P_Resources_Name_CH;
            dic["P_Resources_Name_HK"] = model.P_Resources_Name_HK;
            dic["P_Resources_URL"] = model.P_Resources_URL;
            dic["P_Resources_Type"] = model.P_Resources_Type;
            dic["P_Resources_Status"] = model.P_Resources_Status;
            dic["P_Resources_Seq"] = model.P_Resources_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_b_product_resources", dic) >0 ;
        }

        /// <summary>
        /// 修改
        /// <summary>
        public bool Update(b_product_resources_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["P_Resources_ID"] = model.P_Resources_ID;
            dic["Product_ID"] = model.Product_ID;
            dic["P_Resources_Name_CH"] = model.P_Resources_Name_CH;
            dic["P_Resources_Name_HK"] = model.P_Resources_Name_HK;
            dic["P_Resources_URL"] = model.P_Resources_URL;
            dic["P_Resources_Type"] = model.P_Resources_Type;
            dic["P_Resources_Status"] = model.P_Resources_Status;
            dic["P_Resources_Seq"] = model.P_Resources_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Update_b_product_resources", dic) >0 ;
        }

        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(b_product_resources_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["P_Resources_ID"] = model.P_Resources_ID;
            dic["Product_ID"] = model.Product_ID;
            dic["P_Resources_Name_CH"] = model.P_Resources_Name_CH;
            dic["P_Resources_Name_HK"] = model.P_Resources_Name_HK;
            dic["P_Resources_URL"] = model.P_Resources_URL;
            dic["P_Resources_Type"] = model.P_Resources_Type;
            dic["P_Resources_Status"] = model.P_Resources_Status;
            dic["P_Resources_Seq"] = model.P_Resources_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_b_product_resources", dic) >0 ;
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        public b_product_resources_Entity Get(b_product_resources_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["P_Resources_ID"] = model.P_Resources_ID;
            dic["Product_ID"] = model.Product_ID;
            dic["P_Resources_Name_CH"] = model.P_Resources_Name_CH;
            dic["P_Resources_Name_HK"] = model.P_Resources_Name_HK;
            dic["P_Resources_URL"] = model.P_Resources_URL;
            dic["P_Resources_Type"] = model.P_Resources_Type;
            dic["P_Resources_Status"] = model.P_Resources_Status;
            dic["P_Resources_Seq"] = model.P_Resources_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.QueryForObjectByT<b_product_resources_Entity>("Select_b_product_resources", dic);
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<b_product_resources_Entity>,int) GetList(b_product_resources_Entity model,int pageindex,int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["P_Resources_ID"] = model.P_Resources_ID;
            dic["Product_ID"] = model.Product_ID;
            dic["P_Resources_Name_CH"] = model.P_Resources_Name_CH;
            dic["P_Resources_Name_HK"] = model.P_Resources_Name_HK;
            dic["P_Resources_URL"] = model.P_Resources_URL;
            dic["P_Resources_Type"] = model.P_Resources_Type;
            dic["P_Resources_Status"] = model.P_Resources_Status;
            dic["P_Resources_Seq"] = model.P_Resources_Seq;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<b_product_resources_Entity>("Select_b_product_resources_List", dic,out int total);
            return (list,total);
        }

    }
}

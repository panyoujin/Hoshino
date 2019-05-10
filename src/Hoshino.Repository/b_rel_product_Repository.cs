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
        public bool Insert(b_rel_product_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.P_Relevant_ID != 0)
            {
                dic["P_Relevant_ID"] = model.P_Relevant_ID;
            }
            if(model.Source_Product_ID != 0)
            {
                dic["Source_Product_ID"] = model.Source_Product_ID;
            }
            if(model.Rel_Product_ID != 0)
            {
                dic["Rel_Product_ID"] = model.Rel_Product_ID;
            }
            if(model.P_Relevant_Status != null && model.P_Relevant_Status.HasValue)
            {
                dic["P_Relevant_Status"] = model.P_Relevant_Status;
            }
            
            {
                dic["P_Relevant_Seq"] = model.P_Relevant_Seq;
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
            if(model.Update_Time != null && model.Update_Time.HasValue)
            {
                dic["Update_Time"] = model.Update_Time;
            }
            if(model.Update_UserId != null)
            {
                dic["Update_UserId"] = model.Update_UserId;
            }
            if(model.Update_User != null)
            {
                dic["Update_User"] = model.Update_User;
            }
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_b_rel_product", dic) >0 ;
        }

        /// <summary>
        /// 修改
        /// <summary>
        public bool Update(b_rel_product_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.P_Relevant_ID != 0)
            {
                dic["P_Relevant_ID"] = model.P_Relevant_ID;
            }
            if(model.Source_Product_ID != 0)
            {
                dic["Source_Product_ID"] = model.Source_Product_ID;
            }
            if(model.Rel_Product_ID != 0)
            {
                dic["Rel_Product_ID"] = model.Rel_Product_ID;
            }
            if(model.P_Relevant_Status != null && model.P_Relevant_Status.HasValue)
            {
                dic["P_Relevant_Status"] = model.P_Relevant_Status;
            }
            
            {
                dic["P_Relevant_Seq"] = model.P_Relevant_Seq;
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
            if(model.Update_Time != null && model.Update_Time.HasValue)
            {
                dic["Update_Time"] = model.Update_Time;
            }
            if(model.Update_UserId != null)
            {
                dic["Update_UserId"] = model.Update_UserId;
            }
            if(model.Update_User != null)
            {
                dic["Update_User"] = model.Update_User;
            }
            return SQLHelperFactory.Instance.ExecuteNonQuery("Update_b_rel_product", dic) >0 ;
        }

        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(b_rel_product_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.P_Relevant_ID != 0)
            {
                dic["P_Relevant_ID"] = model.P_Relevant_ID;
            }
            if(model.Source_Product_ID != 0)
            {
                dic["Source_Product_ID"] = model.Source_Product_ID;
            }
            if(model.Rel_Product_ID != 0)
            {
                dic["Rel_Product_ID"] = model.Rel_Product_ID;
            }
            if(model.P_Relevant_Status != null && model.P_Relevant_Status.HasValue)
            {
                dic["P_Relevant_Status"] = model.P_Relevant_Status;
            }
            
            {
                dic["P_Relevant_Seq"] = model.P_Relevant_Seq;
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
            if(model.Update_Time != null && model.Update_Time.HasValue)
            {
                dic["Update_Time"] = model.Update_Time;
            }
            if(model.Update_UserId != null)
            {
                dic["Update_UserId"] = model.Update_UserId;
            }
            if(model.Update_User != null)
            {
                dic["Update_User"] = model.Update_User;
            }
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_b_rel_product", dic) >0 ;
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        public b_rel_product_Entity Get(b_rel_product_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.P_Relevant_ID != 0)
            {
                dic["P_Relevant_ID"] = model.P_Relevant_ID;
            }
            if(model.Source_Product_ID != 0)
            {
                dic["Source_Product_ID"] = model.Source_Product_ID;
            }
            if(model.Rel_Product_ID != 0)
            {
                dic["Rel_Product_ID"] = model.Rel_Product_ID;
            }
            if(model.P_Relevant_Status != null && model.P_Relevant_Status.HasValue)
            {
                dic["P_Relevant_Status"] = model.P_Relevant_Status;
            }
            
            {
                dic["P_Relevant_Seq"] = model.P_Relevant_Seq;
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
            if(model.Update_Time != null && model.Update_Time.HasValue)
            {
                dic["Update_Time"] = model.Update_Time;
            }
            if(model.Update_UserId != null)
            {
                dic["Update_UserId"] = model.Update_UserId;
            }
            if(model.Update_User != null)
            {
                dic["Update_User"] = model.Update_User;
            }
            return SQLHelperFactory.Instance.QueryForObjectByT<b_rel_product_Entity>("Select_b_rel_product", dic);
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<b_rel_product_Entity>,int) GetList(b_rel_product_Entity model,int pageindex,int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.P_Relevant_ID != 0)
            {
                dic["P_Relevant_ID"] = model.P_Relevant_ID;
            }
            if(model.Source_Product_ID != 0)
            {
                dic["Source_Product_ID"] = model.Source_Product_ID;
            }
            if(model.Rel_Product_ID != 0)
            {
                dic["Rel_Product_ID"] = model.Rel_Product_ID;
            }
            if(model.P_Relevant_Status != null && model.P_Relevant_Status.HasValue)
            {
                dic["P_Relevant_Status"] = model.P_Relevant_Status;
            }
            
            {
                dic["P_Relevant_Seq"] = model.P_Relevant_Seq;
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
            if(model.Update_Time != null && model.Update_Time.HasValue)
            {
                dic["Update_Time"] = model.Update_Time;
            }
            if(model.Update_UserId != null)
            {
                dic["Update_UserId"] = model.Update_UserId;
            }
            if(model.Update_User != null)
            {
                dic["Update_User"] = model.Update_User;
            }
            dic["StartIndex"] = pageindex == 1 ? 0 : (pageindex-1) * pagesize + 1;
            dic["SelectCount"] = pagesize;
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<b_rel_product_Entity>("Select_b_rel_product_List", dic,out int total);
            return (list,total);
        }

    }
}

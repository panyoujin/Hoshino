using System;
using System.Collections.Generic;
using DBHelper.SQLHelper;
using Hoshino.Entity;
using Hoshino.IRepository;

namespace Hoshino.Repository
{
    public class b_product_Repository : Ib_product_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        public bool Insert(b_product_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.Product_ID != 0)
            {
                dic["Product_ID"] = model.Product_ID;
            }
            if(model.Category_ID != 0)
            {
                dic["Category_ID"] = model.Category_ID;
            }
            if(model.Product_Name_CH != null)
            {
                dic["Product_Name_CH"] = model.Product_Name_CH;
            }
            if(model.Product_Name_HK != null)
            {
                dic["Product_Name_HK"] = model.Product_Name_HK;
            }
            if(model.Product_New != null && model.Product_New.HasValue)
            {
                dic["Product_New"] = model.Product_New;
            }
            if(model.Product_Hot != null && model.Product_Hot.HasValue)
            {
                dic["Product_Hot"] = model.Product_Hot;
            }
            if(model.Product_Recommend != null && model.Product_Recommend.HasValue)
            {
                dic["Product_Recommend"] = model.Product_Recommend;
            }
            if(model.Product_Status != null && model.Product_Status.HasValue)
            {
                dic["Product_Status"] = model.Product_Status;
            }
            
            {
                dic["Product_Seq"] = model.Product_Seq;
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
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_b_product", dic) >0 ;
        }

        /// <summary>
        /// 修改
        /// <summary>
        public bool Update(b_product_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.Product_ID != 0)
            {
                dic["Product_ID"] = model.Product_ID;
            }
            if(model.Category_ID != 0)
            {
                dic["Category_ID"] = model.Category_ID;
            }
            if(model.Product_Name_CH != null)
            {
                dic["Product_Name_CH"] = model.Product_Name_CH;
            }
            if(model.Product_Name_HK != null)
            {
                dic["Product_Name_HK"] = model.Product_Name_HK;
            }
            if(model.Product_New != null && model.Product_New.HasValue)
            {
                dic["Product_New"] = model.Product_New;
            }
            if(model.Product_Hot != null && model.Product_Hot.HasValue)
            {
                dic["Product_Hot"] = model.Product_Hot;
            }
            if(model.Product_Recommend != null && model.Product_Recommend.HasValue)
            {
                dic["Product_Recommend"] = model.Product_Recommend;
            }
            if(model.Product_Status != null && model.Product_Status.HasValue)
            {
                dic["Product_Status"] = model.Product_Status;
            }
            
            {
                dic["Product_Seq"] = model.Product_Seq;
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
            return SQLHelperFactory.Instance.ExecuteNonQuery("Update_b_product", dic) >0 ;
        }

        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(b_product_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.Product_ID != 0)
            {
                dic["Product_ID"] = model.Product_ID;
            }
            if(model.Category_ID != 0)
            {
                dic["Category_ID"] = model.Category_ID;
            }
            if(model.Product_Name_CH != null)
            {
                dic["Product_Name_CH"] = model.Product_Name_CH;
            }
            if(model.Product_Name_HK != null)
            {
                dic["Product_Name_HK"] = model.Product_Name_HK;
            }
            if(model.Product_New != null && model.Product_New.HasValue)
            {
                dic["Product_New"] = model.Product_New;
            }
            if(model.Product_Hot != null && model.Product_Hot.HasValue)
            {
                dic["Product_Hot"] = model.Product_Hot;
            }
            if(model.Product_Recommend != null && model.Product_Recommend.HasValue)
            {
                dic["Product_Recommend"] = model.Product_Recommend;
            }
            if(model.Product_Status != null && model.Product_Status.HasValue)
            {
                dic["Product_Status"] = model.Product_Status;
            }
            
            {
                dic["Product_Seq"] = model.Product_Seq;
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
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_b_product", dic) >0 ;
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        public b_product_Entity Get(b_product_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.Product_ID != 0)
            {
                dic["Product_ID"] = model.Product_ID;
            }
            if(model.Category_ID != 0)
            {
                dic["Category_ID"] = model.Category_ID;
            }
            if(model.Product_Name_CH != null)
            {
                dic["Product_Name_CH"] = model.Product_Name_CH;
            }
            if(model.Product_Name_HK != null)
            {
                dic["Product_Name_HK"] = model.Product_Name_HK;
            }
            if(model.Product_New != null && model.Product_New.HasValue)
            {
                dic["Product_New"] = model.Product_New;
            }
            if(model.Product_Hot != null && model.Product_Hot.HasValue)
            {
                dic["Product_Hot"] = model.Product_Hot;
            }
            if(model.Product_Recommend != null && model.Product_Recommend.HasValue)
            {
                dic["Product_Recommend"] = model.Product_Recommend;
            }
            if(model.Product_Status != null && model.Product_Status.HasValue)
            {
                dic["Product_Status"] = model.Product_Status;
            }
            
            {
                dic["Product_Seq"] = model.Product_Seq;
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
            return SQLHelperFactory.Instance.QueryForObjectByT<b_product_Entity>("Select_b_product", dic);
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<b_product_Entity>,int) GetList(b_product_Entity model,int pageindex,int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.Product_ID != 0)
            {
                dic["Product_ID"] = model.Product_ID;
            }
            if(model.Category_ID != 0)
            {
                dic["Category_ID"] = model.Category_ID;
            }
            if(model.Product_Name_CH != null)
            {
                dic["Product_Name_CH"] = model.Product_Name_CH;
            }
            if(model.Product_Name_HK != null)
            {
                dic["Product_Name_HK"] = model.Product_Name_HK;
            }
            if(model.Product_New != null && model.Product_New.HasValue)
            {
                dic["Product_New"] = model.Product_New;
            }
            if(model.Product_Hot != null && model.Product_Hot.HasValue)
            {
                dic["Product_Hot"] = model.Product_Hot;
            }
            if(model.Product_Recommend != null && model.Product_Recommend.HasValue)
            {
                dic["Product_Recommend"] = model.Product_Recommend;
            }
            if(model.Product_Status != null && model.Product_Status.HasValue)
            {
                dic["Product_Status"] = model.Product_Status;
            }
            
            {
                dic["Product_Seq"] = model.Product_Seq;
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
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<b_product_Entity>("Select_b_product_List", dic,out int total);
            return (list,total);
        }

        public (IEnumerable<T>, int) GetNewProductList<T>()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Product_New"] = 1;
            dic["StartIndex"] = 0;
            dic["SelectCount"] = 24;
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<T>("Select_b_product_List", dic, out int total);
            return (list, total);
        }

        public (IEnumerable<T>, int) GetHotProductList<T>()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Product_Hot"] = 1;
            dic["StartIndex"] = 0;
            dic["SelectCount"] = 24;
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<T>("Select_b_product_List", dic, out int total);
            return (list, total);
        }
    }
}

using System;
using System.Collections.Generic;
using DBHelper.SQLHelper;
using Hoshino.Entity;
using Hoshino.IRepository;

namespace Hoshino.Repository
{
    public class b_contact_Repository : Ib_contact_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        public bool Insert(b_contact_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.Contact_ID != 0)
            {
                dic["Contact_ID"] = model.Contact_ID;
            }
            if(model.Company != null)
            {
                dic["Company"] = model.Company;
            }
            if(model.Contacts != null)
            {
                dic["Contacts"] = model.Contacts;
            }
            if(model.Phone != null)
            {
                dic["Phone"] = model.Phone;
            }
            if(model.Email != null)
            {
                dic["Email"] = model.Email;
            }
            if(model.Matter != null)
            {
                dic["Matter"] = model.Matter;
            }
            if(model.Wechat != null)
            {
                dic["Wechat"] = model.Wechat;
            }
            if(model.WhatsApp != null)
            {
                dic["WhatsApp"] = model.WhatsApp;
            }
            if(model.Contact_Status != 0)
            {
                dic["Contact_Status"] = model.Contact_Status;
            }
            if(model.Processing_Result != null)
            {
                dic["Processing_Result"] = model.Processing_Result;
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
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_b_contact", dic) >0 ;
        }

        /// <summary>
        /// 修改
        /// <summary>
        public bool Update(int Contact_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Contact_ID"] = Contact_ID;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Update_b_contact", dic) >0 ;
        }

        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(int Contact_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Contact_ID"] = Contact_ID;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_b_contact", dic) >0 ;
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        public b_contact_Entity Get(int Contact_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Contact_ID"] = Contact_ID;
            return SQLHelperFactory.Instance.QueryForObjectByT<b_contact_Entity>("Select_b_contact", dic);
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<b_contact_Entity>,int) GetList(b_contact_Entity model,int pageindex,int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.Contact_ID != 0)
            {
                dic["Contact_ID"] = model.Contact_ID;
            }
            if(model.Company != null)
            {
                dic["Company"] = model.Company;
            }
            if(model.Contacts != null)
            {
                dic["Contacts"] = model.Contacts;
            }
            if(model.Phone != null)
            {
                dic["Phone"] = model.Phone;
            }
            if(model.Email != null)
            {
                dic["Email"] = model.Email;
            }
            if(model.Matter != null)
            {
                dic["Matter"] = model.Matter;
            }
            if(model.Wechat != null)
            {
                dic["Wechat"] = model.Wechat;
            }
            if(model.WhatsApp != null)
            {
                dic["WhatsApp"] = model.WhatsApp;
            }
            if(model.Contact_Status != 0)
            {
                dic["Contact_Status"] = model.Contact_Status;
            }
            if(model.Processing_Result != null)
            {
                dic["Processing_Result"] = model.Processing_Result;
            }
            if (pageindex >= 0)
            {
                dic["StartIndex"] = pageindex == 0 ? 0 : pageindex * pagesize + 1;
            }
            if (pagesize > 0)
            {
                dic["SelectCount"] = pagesize;
            }
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<b_contact_Entity>("Select_b_contact_List", dic,out int total);
            return (list,total);
        }

    }
}

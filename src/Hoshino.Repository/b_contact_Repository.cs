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
            dic["Contact_ID"] = model.Contact_ID;
            dic["Company"] = model.Company;
            dic["Contacts"] = model.Contacts;
            dic["Phone"] = model.Phone;
            dic["Email"] = model.Email;
            dic["Matter"] = model.Matter;
            dic["Wechat"] = model.Wechat;
            dic["WhatsApp"] = model.WhatsApp;
            dic["AC_Status"] = model.AC_Status;
            dic["Processing_Result"] = model.Processing_Result;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_b_contact", dic) >0 ;
        }

        /// <summary>
        /// 修改
        /// <summary>
        public bool Update(b_contact_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Contact_ID"] = model.Contact_ID;
            dic["Company"] = model.Company;
            dic["Contacts"] = model.Contacts;
            dic["Phone"] = model.Phone;
            dic["Email"] = model.Email;
            dic["Matter"] = model.Matter;
            dic["Wechat"] = model.Wechat;
            dic["WhatsApp"] = model.WhatsApp;
            dic["AC_Status"] = model.AC_Status;
            dic["Processing_Result"] = model.Processing_Result;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Update_b_contact", dic) >0 ;
        }

        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(b_contact_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Contact_ID"] = model.Contact_ID;
            dic["Company"] = model.Company;
            dic["Contacts"] = model.Contacts;
            dic["Phone"] = model.Phone;
            dic["Email"] = model.Email;
            dic["Matter"] = model.Matter;
            dic["Wechat"] = model.Wechat;
            dic["WhatsApp"] = model.WhatsApp;
            dic["AC_Status"] = model.AC_Status;
            dic["Processing_Result"] = model.Processing_Result;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_b_contact", dic) >0 ;
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        public b_contact_Entity Get(b_contact_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Contact_ID"] = model.Contact_ID;
            dic["Company"] = model.Company;
            dic["Contacts"] = model.Contacts;
            dic["Phone"] = model.Phone;
            dic["Email"] = model.Email;
            dic["Matter"] = model.Matter;
            dic["Wechat"] = model.Wechat;
            dic["WhatsApp"] = model.WhatsApp;
            dic["AC_Status"] = model.AC_Status;
            dic["Processing_Result"] = model.Processing_Result;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            return SQLHelperFactory.Instance.QueryForObjectByT<b_contact_Entity>("Select_b_contact", dic);
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<b_contact_Entity>,int) GetList(b_contact_Entity model,int pageindex,int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Contact_ID"] = model.Contact_ID;
            dic["Company"] = model.Company;
            dic["Contacts"] = model.Contacts;
            dic["Phone"] = model.Phone;
            dic["Email"] = model.Email;
            dic["Matter"] = model.Matter;
            dic["Wechat"] = model.Wechat;
            dic["WhatsApp"] = model.WhatsApp;
            dic["AC_Status"] = model.AC_Status;
            dic["Processing_Result"] = model.Processing_Result;
            dic["Create_Time"] = model.Create_Time;
            dic["Create_UserId"] = model.Create_UserId;
            dic["Create_User"] = model.Create_User;
            dic["Update_Time"] = model.Update_Time;
            dic["Update_UserId"] = model.Update_UserId;
            dic["Update_User"] = model.Update_User;
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<b_contact_Entity>("Select_b_contact_List", dic,out int total);
            return (list,total);
        }

    }
}

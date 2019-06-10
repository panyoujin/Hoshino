using System;
using System.Collections.Generic;
using DBHelper.SQLHelper;
using Hoshino.Entity;
using Hoshino.IRepository;

namespace Hoshino.Repository
{
    public class b_appointment_consultation_Repository : Ib_appointment_consultation_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        public bool Insert(b_appointment_consultation_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (model.Company != null)
            {
                dic["Company"] = model.Company;
            }
            if (model.Contacts != null)
            {
                dic["Contacts"] = model.Contacts;
            }
            if (model.Phone != null)
            {
                dic["Phone"] = model.Phone;
            }
            if (model.Email != null)
            {
                dic["Email"] = model.Email;
            }
            if (model.Matter != null)
            {
                dic["Matter"] = model.Matter;
            }
            if (model.Material != null)
            {
                dic["Material"] = model.Material;
            }
            dic["AC_Status"] = model.AC_Status;
            if (model.Processing_Result != null)
            {
                dic["Processing_Result"] = model.Processing_Result;
            }
            if (model.Create_UserId != null)
            {
                dic["Create_UserId"] = model.Create_UserId;
            }
            if (model.Create_User != null)
            {
                dic["Create_User"] = model.Create_User;
            }
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_b_appointment_consultation", dic) > 0;
        }

        /// <summary>
        /// 修改
        /// <summary>
        public bool Update(b_appointment_consultation_Entity model, int AC_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();

            dic["AC_ID"] = AC_ID;
            if (model.Company != null)
            {
                dic["Company"] = model.Company;
            }
            if (model.Contacts != null)
            {
                dic["Contacts"] = model.Contacts;
            }
            if (model.Phone != null)
            {
                dic["Phone"] = model.Phone;
            }
            if (model.Email != null)
            {
                dic["Email"] = model.Email;
            }
            if (model.Matter != null)
            {
                dic["Matter"] = model.Matter;
            }
            if (model.Material != null)
            {
                dic["Material"] = model.Material;
            }
            dic["AC_Status"] = model.AC_Status;
            if (model.Processing_Result != null)
            {
                dic["Processing_Result"] = model.Processing_Result;
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
            return SQLHelperFactory.Instance.ExecuteNonQuery("Update_b_appointment_consultation", dic) > 0;
        }

        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(int AC_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["AC_ID"] = AC_ID;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_b_appointment_consultation", dic) > 0;
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        public b_appointment_consultation_Entity Get(int AC_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["AC_ID"] = AC_ID;
            return SQLHelperFactory.Instance.QueryForObjectByT<b_appointment_consultation_Entity>("Select_b_appointment_consultation", dic);
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<b_appointment_consultation_Entity>, int) GetList(b_appointment_consultation_Entity model, int pageindex, int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (model.AC_ID != 0)
            {
                dic["AC_ID"] = model.AC_ID;
            }
            if (model.Company != null)
            {
                dic["Company"] = model.Company;
            }
            if (model.Contacts != null)
            {
                dic["Contacts"] = model.Contacts;
            }
            if (model.Phone != null)
            {
                dic["Phone"] = model.Phone;
            }
            if (model.Email != null)
            {
                dic["Email"] = model.Email;
            }
            if (model.Matter != null)
            {
                dic["Matter"] = model.Matter;
            }
            if (model.Material != null)
            {
                dic["Material"] = model.Material;
            }
            if (model.AC_Status >= 0)
            {
                dic["AC_Status"] = model.AC_Status;
            }
            if (model.Processing_Result != null)
            {
                dic["Processing_Result"] = model.Processing_Result;
            }
            if (pageindex >= 0)
            {
                dic["StartIndex"] = pageindex <= 1 ? 0 : (pageindex - 1) * pagesize ;
            }
            if (pagesize > 0)
            {
                dic["SelectCount"] = pagesize;
            }
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<b_appointment_consultation_Entity>("Select_b_appointment_consultation_List", dic, out int total);
            return (list, total);
        }

    }
}

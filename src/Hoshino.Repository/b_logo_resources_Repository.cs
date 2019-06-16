using System;
using System.Collections.Generic;
using DBHelper.SQLHelper;
using Hoshino.Entity;
using Hoshino.IRepository;

namespace Hoshino.Repository
{
    public class b_logo_resources_Repository : Ib_logo_resources_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        public bool Insert(b_logo_resources_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (!string.IsNullOrWhiteSpace(model.Logo_Name_CH))
            {
                dic["Logo_Name_CH"] = model.Logo_Name_CH;
            }
            if (!string.IsNullOrWhiteSpace(model.Logo_Name_HK))
            {
                dic["Logo_Name_HK"] = model.Logo_Name_HK;
            }
            if (!string.IsNullOrWhiteSpace(model.Logo_URL))
            {
                dic["Logo_URL"] = model.Logo_URL;
            }

            if (model.Logo_Seq >= 0)
            {
                dic["Logo_Seq"] = model.Logo_Seq;
            }
            if (model.Create_UserId != null)
            {
                dic["Create_UserId"] = model.Create_UserId;
            }
            if (model.Create_User != null)
            {
                dic["Create_User"] = model.Create_User;
            }
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_b_logo_resources", dic) > 0;
        }


        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(int Logo_ID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["Logo_ID"] = Logo_ID;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_b_logo_resources", dic) > 0;
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<b_logo_resources_Entity>, int) GetList(b_logo_resources_Entity model, int pageindex, int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (pageindex >= 0)
            {
                dic["StartIndex"] = pageindex <= 1 ? 0 : (pageindex - 1) * pagesize ;
            }
            if (pagesize > 0)
            {
                dic["SelectCount"] = pagesize;
            }
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<b_logo_resources_Entity>("Select_b_logo_resources_List", dic, out int total);
            return (list, total);
        }

    }
}

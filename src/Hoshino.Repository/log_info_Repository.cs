using System;
using System.Collections.Generic;
using DBHelper.SQLHelper;
using Hoshino.Entity;
using Hoshino.IRepository;

namespace Hoshino.Repository
{
    public class log_info_Repository : Ilog_info_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        public bool Insert(log_info_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.id != 0)
            {
                dic["id"] = model.id;
            }
            if(model.chain_id != null)
            {
                dic["chain_id"] = model.chain_id;
            }
            if(model.content != null)
            {
                dic["content"] = model.content;
            }
            if(model.interface_name != null)
            {
                dic["interface_name"] = model.interface_name;
            }
            if(model.type != null && model.type.HasValue)
            {
                dic["type"] = model.type;
            }
            if(model.creation_time != null && model.creation_time.HasValue)
            {
                dic["creation_time"] = model.creation_time;
            }
            if(model.ip != null)
            {
                dic["ip"] = model.ip;
            }
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_log_info", dic) >0 ;
        }

        /// <summary>
        /// 修改
        /// <summary>
        public bool Update(log_info_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.id != 0)
            {
                dic["id"] = model.id;
            }
            if(model.chain_id != null)
            {
                dic["chain_id"] = model.chain_id;
            }
            if(model.content != null)
            {
                dic["content"] = model.content;
            }
            if(model.interface_name != null)
            {
                dic["interface_name"] = model.interface_name;
            }
            if(model.type != null && model.type.HasValue)
            {
                dic["type"] = model.type;
            }
            if(model.creation_time != null && model.creation_time.HasValue)
            {
                dic["creation_time"] = model.creation_time;
            }
            if(model.ip != null)
            {
                dic["ip"] = model.ip;
            }
            return SQLHelperFactory.Instance.ExecuteNonQuery("Update_log_info", dic) >0 ;
        }

        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(log_info_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.id != 0)
            {
                dic["id"] = model.id;
            }
            if(model.chain_id != null)
            {
                dic["chain_id"] = model.chain_id;
            }
            if(model.content != null)
            {
                dic["content"] = model.content;
            }
            if(model.interface_name != null)
            {
                dic["interface_name"] = model.interface_name;
            }
            if(model.type != null && model.type.HasValue)
            {
                dic["type"] = model.type;
            }
            if(model.creation_time != null && model.creation_time.HasValue)
            {
                dic["creation_time"] = model.creation_time;
            }
            if(model.ip != null)
            {
                dic["ip"] = model.ip;
            }
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_log_info", dic) >0 ;
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        public log_info_Entity Get(log_info_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.id != 0)
            {
                dic["id"] = model.id;
            }
            if(model.chain_id != null)
            {
                dic["chain_id"] = model.chain_id;
            }
            if(model.content != null)
            {
                dic["content"] = model.content;
            }
            if(model.interface_name != null)
            {
                dic["interface_name"] = model.interface_name;
            }
            if(model.type != null && model.type.HasValue)
            {
                dic["type"] = model.type;
            }
            if(model.creation_time != null && model.creation_time.HasValue)
            {
                dic["creation_time"] = model.creation_time;
            }
            if(model.ip != null)
            {
                dic["ip"] = model.ip;
            }
            return SQLHelperFactory.Instance.QueryForObjectByT<log_info_Entity>("Select_log_info", dic);
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<log_info_Entity>,int) GetList(log_info_Entity model,int pageindex,int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if(model.id != 0)
            {
                dic["id"] = model.id;
            }
            if(model.chain_id != null)
            {
                dic["chain_id"] = model.chain_id;
            }
            if(model.content != null)
            {
                dic["content"] = model.content;
            }
            if(model.interface_name != null)
            {
                dic["interface_name"] = model.interface_name;
            }
            if(model.type != null && model.type.HasValue)
            {
                dic["type"] = model.type;
            }
            if(model.creation_time != null && model.creation_time.HasValue)
            {
                dic["creation_time"] = model.creation_time;
            }
            if(model.ip != null)
            {
                dic["ip"] = model.ip;
            }
            dic["StartIndex"] = pageindex == 1 ? 0 : (pageindex-1) * pagesize + 1;
            dic["SelectCount"] = pagesize;
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<log_info_Entity>("Select_log_info_List", dic,out int total);
            return (list,total);
        }

    }
}

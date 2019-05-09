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
            dic["id"] = model.id;
            dic["chain_id"] = model.chain_id;
            dic["content"] = model.content;
            dic["interface_name"] = model.interface_name;
            dic["type"] = model.type;
            dic["creation_time"] = model.creation_time;
            dic["ip"] = model.ip;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Insert_log_info", dic) >0 ;
        }

        /// <summary>
        /// 修改
        /// <summary>
        public bool Update(log_info_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["id"] = model.id;
            dic["chain_id"] = model.chain_id;
            dic["content"] = model.content;
            dic["interface_name"] = model.interface_name;
            dic["type"] = model.type;
            dic["creation_time"] = model.creation_time;
            dic["ip"] = model.ip;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Update_log_info", dic) >0 ;
        }

        /// <summary>
        /// 删除
        /// <summary>
        public bool Delete(log_info_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["id"] = model.id;
            dic["chain_id"] = model.chain_id;
            dic["content"] = model.content;
            dic["interface_name"] = model.interface_name;
            dic["type"] = model.type;
            dic["creation_time"] = model.creation_time;
            dic["ip"] = model.ip;
            return SQLHelperFactory.Instance.ExecuteNonQuery("Delete_log_info", dic) >0 ;
        }

        /// <summary>
        /// 获取单个
        /// <summary>
        public log_info_Entity Get(log_info_Entity model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["id"] = model.id;
            dic["chain_id"] = model.chain_id;
            dic["content"] = model.content;
            dic["interface_name"] = model.interface_name;
            dic["type"] = model.type;
            dic["creation_time"] = model.creation_time;
            dic["ip"] = model.ip;
            return SQLHelperFactory.Instance.QueryForObjectByT<log_info_Entity>("Select_log_info", dic);
        }

        /// <summary>
        /// 获取列表
        /// <summary>
        public (IEnumerable<log_info_Entity>,int) GetList(log_info_Entity model,int pageindex,int pagesize)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["id"] = model.id;
            dic["chain_id"] = model.chain_id;
            dic["content"] = model.content;
            dic["interface_name"] = model.interface_name;
            dic["type"] = model.type;
            dic["creation_time"] = model.creation_time;
            dic["ip"] = model.ip;
            var list = SQLHelperFactory.Instance.QueryMultipleByPage<log_info_Entity>("Select_log_info_List", dic,out int total);
            return (list,total);
        }

    }
}

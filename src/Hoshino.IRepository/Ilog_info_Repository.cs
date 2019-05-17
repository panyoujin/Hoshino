using System;
using System.Collections.Generic;
using Hoshino.Entity;

namespace Hoshino.IRepository
{
    public interface Ilog_info_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        bool Insert(log_info_Entity model);

        /// <summary>
        /// 修改
        /// <summary>
        bool Update(log_info_Entity model, int id);

        /// <summary>
        /// 删除
        /// <summary>
        bool Delete(int id);

        /// <summary>
        /// 获取单个
        /// <summary>
        log_info_Entity Get(int id);

        /// <summary>
        /// 获取列表
        /// <summary>
        (IEnumerable<log_info_Entity>,int) GetList(log_info_Entity model,int pageindex,int pagesize);

    }
}

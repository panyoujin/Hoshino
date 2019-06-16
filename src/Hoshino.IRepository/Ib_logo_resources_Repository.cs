using System;
using System.Collections.Generic;
using Hoshino.Entity;

namespace Hoshino.IRepository
{
    public interface Ib_logo_resources_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        bool Insert(b_logo_resources_Entity model);


        /// <summary>
        /// 删除
        /// <summary>
        bool Delete(int Logo_ID);


        /// <summary>
        /// 获取列表
        /// <summary>
        (IEnumerable<b_logo_resources_Entity>,int) GetList(b_logo_resources_Entity model,int pageindex,int pagesize);

    }
}

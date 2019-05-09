using System;
using System.Collections.Generic;
using Hoshino.Entity;

namespace Hoshino.IRepository
{
    public interface Isys_user_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        bool Insert(sys_user_Entity model);

        /// <summary>
        /// 修改
        /// <summary>
        bool Update(sys_user_Entity model);

        /// <summary>
        /// 删除
        /// <summary>
        bool Delete(sys_user_Entity model);

        /// <summary>
        /// 获取单个
        /// <summary>
        sys_user_Entity Get(sys_user_Entity model);

        /// <summary>
        /// 获取列表
        /// <summary>
        (IEnumerable<sys_user_Entity>,int) GetList(sys_user_Entity model,int pageindex,int pagesize);

    }
}

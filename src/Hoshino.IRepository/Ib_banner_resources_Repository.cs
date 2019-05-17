using System;
using System.Collections.Generic;
using Hoshino.Entity;

namespace Hoshino.IRepository
{
    public interface Ib_banner_resources_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        bool Insert(b_banner_resources_Entity model);

        /// <summary>
        /// 修改
        /// <summary>
        bool Update(b_banner_resources_Entity model, int Banner_ID);

        /// <summary>
        /// 删除
        /// <summary>
        bool Delete(int Banner_ID);

        /// <summary>
        /// 获取单个
        /// <summary>
        b_banner_resources_Entity Get(int Banner_ID);

        /// <summary>
        /// 获取列表
        /// <summary>
        (IEnumerable<b_banner_resources_Entity>,int) GetList(b_banner_resources_Entity model,int pageindex,int pagesize);

    }
}

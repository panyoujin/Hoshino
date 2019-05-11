using System;
using System.Collections.Generic;
using Hoshino.Entity;

namespace Hoshino.IRepository
{
    public interface Ib_product_resources_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        bool Insert(b_product_resources_Entity model);

        /// <summary>
        /// 修改
        /// <summary>
        bool Update(b_product_resources_Entity model);

        /// <summary>
        /// 删除
        /// <summary>
        bool Delete(int P_Resources_ID);

        /// <summary>
        /// 获取单个
        /// <summary>
        b_product_resources_Entity Get(int P_Resources_ID);

        /// <summary>
        /// 获取列表
        /// <summary>
        (IEnumerable<b_product_resources_Entity>,int) GetList(b_product_resources_Entity model,int pageindex,int pagesize);

    }
}

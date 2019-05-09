using System;
using System.Collections.Generic;
using Hoshino.Entity;

namespace Hoshino.IRepository
{
    public interface Ib_rel_product_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        bool Insert(b_rel_product_Entity model);

        /// <summary>
        /// 修改
        /// <summary>
        bool Update(b_rel_product_Entity model);

        /// <summary>
        /// 删除
        /// <summary>
        bool Delete(b_rel_product_Entity model);

        /// <summary>
        /// 获取单个
        /// <summary>
        b_rel_product_Entity Get(b_rel_product_Entity model);

        /// <summary>
        /// 获取列表
        /// <summary>
        (IEnumerable<b_rel_product_Entity>,int) GetList(b_rel_product_Entity model,int pageindex,int pagesize);

    }
}

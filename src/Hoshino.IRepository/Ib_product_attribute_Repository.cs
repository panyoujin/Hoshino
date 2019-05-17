using System;
using System.Collections.Generic;
using Hoshino.Entity;

namespace Hoshino.IRepository
{
    public interface Ib_product_attribute_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        bool Insert(b_product_attribute_Entity model);

        /// <summary>
        /// 修改
        /// <summary>
        bool Update(b_product_attribute_Entity model, int P_Attribute_ID);

        /// <summary>
        /// 删除
        /// <summary>
        bool Delete(int P_Attribute_ID);

        /// <summary>
        /// 获取单个
        /// <summary>
        b_product_attribute_Entity Get(int P_Attribute_ID);

        /// <summary>
        /// 获取列表
        /// <summary>
        (IEnumerable<b_product_attribute_Entity>,int) GetList(b_product_attribute_Entity model,int pageindex,int pagesize);

    }
}

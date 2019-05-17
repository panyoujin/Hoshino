using System;
using System.Collections.Generic;
using Hoshino.Entity;

namespace Hoshino.IRepository
{
    public interface Ib_category_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        bool Insert(b_category_Entity model);

        /// <summary>
        /// 修改
        /// <summary>
        bool Update(b_category_Entity model, int Category_ID);

        /// <summary>
        /// 删除
        /// <summary>
        bool Delete(int Category_ID);

        /// <summary>
        /// 获取单个
        /// <summary>
        b_category_Entity Get(int Category_ID);

        /// <summary>
        /// 获取列表
        /// <summary>
        (IEnumerable<b_category_Entity>,int) GetList(int pageindex,int pagesize);

    }
}

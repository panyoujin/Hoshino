using System;
using System.Collections.Generic;
using Hoshino.Entity;

namespace Hoshino.IRepository
{
    public interface Ib_product_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        bool Insert(b_product_Entity model);

        /// <summary>
        /// 修改
        /// <summary>
        bool Update(int Product_ID);

        /// <summary>
        /// 删除
        /// <summary>
        bool Delete(int Product_ID);

        /// <summary>
        /// 获取单个
        /// <summary>
        b_product_Entity Get(int Product_ID);

        /// <summary>
        /// 获取列表
        /// <summary>
        (IEnumerable<b_product_Entity>,int) GetList(b_product_Entity model,int pageindex,int pagesize);

        /// <summary>
        /// 获取最新产品列表
        /// <summary>
        (IEnumerable<T>, int) GetNewProductList<T>();


        /// <summary>
        /// 获取热门產品列表
        /// <summary>
        (IEnumerable<T>, int) GetHotProductList<T>();
		
    }
}

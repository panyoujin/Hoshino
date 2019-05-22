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
        bool Update(b_product_Entity model, int Product_ID);

        /// <summary>
        /// 删除
        /// <summary>
        bool Delete(int Product_ID);

        /// <summary>
        /// 获取单个
        /// <summary>
        (IEnumerable<b_product_Entity>, IEnumerable<b_product_resources_Entity>, IEnumerable<b_product_attribute_Entity>, IEnumerable<b_product_Entity>) Get(int Product_ID);

        /// <summary>
        /// 获取列表
        /// <summary>
        (IEnumerable<b_product_Entity>, int) GetList(b_product_Entity model, int pageindex, int pagesize);

        /// <summary>
        /// 获取最新产品列表
        /// <summary>
        (IEnumerable<T>, int) GetNewProductList<T>(int Category_ID, int pageindex, int pagesize);


        /// <summary>
        /// 获取热门产品列表
        /// <summary>
        (IEnumerable<T>, int) GetHotProductList<T>(int Category_ID, int pageindex, int pagesize);

        /// <summary>
        /// 获取推荐产品列表
        /// <summary>
        (IEnumerable<T>, int) GetRecommendProductList<T>(int Category_ID, int pageindex, int pagesize);

        /// <summary>
        /// 获取符合条件的产品id集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Category_ID"></param>
        /// <param name="name"></param>
        /// <param name="IsNew">-1</param>
        /// <param name="IsHot">-1</param>
        /// <param name="IsRecommend">-1</param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        (IEnumerable<T>, int) GetProductIDList<T>(int Category_ID, string name, int IsNew, int IsHot, int IsRecommend, int pageindex, int pagesize);


        /// <summary>
        /// 根据ids获取產品列表
        /// <summary>
        (IEnumerable<P>, IEnumerable<PR>) GetProductListByIDs<P, PR>(IEnumerable<int> ids);

    }
}

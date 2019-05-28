using System;
using System.Collections.Generic;
using Hoshino.Entity;

namespace Hoshino.IRepository
{
    public interface Ib_product_resources_Repository
    {
        /// <summary>
        /// 新增
        /// </summary>
        bool Insert(List<b_product_resources_Entity> list);

        /// <summary>
        /// 修改
        /// </summary>
        bool Update(List<b_product_resources_Entity> list);

        /// <summary>
        /// 删除
        /// </summary>
        bool Delete(List<int> idList);

        /// <summary>
        /// 获取单个
        /// </summary>
        b_product_resources_Entity Get(int P_Resources_ID);

        /// <summary>
        /// 获取列表
        /// </summary>
        (IEnumerable<b_product_resources_Entity>,int) GetList(int Product_ID, int pageindex,int pagesize);

    }
}

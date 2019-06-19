using System;
using System.Collections.Generic;
using Hoshino.Entity;

namespace Hoshino.IRepository
{
    public interface Ib_product_attribute_template_Repository
    {
        /// <summary>
        /// 新增
        /// </summary>
        bool Insert(List<b_product_attribute_template_Entity> list);

        /// <summary>
        /// 删除
        /// </summary>
        bool Delete();


        /// <summary>
        /// 获取列表
        /// </summary>
        List<T> GetList<T>();

    }
}

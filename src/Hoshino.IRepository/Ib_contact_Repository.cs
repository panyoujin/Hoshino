using System;
using System.Collections.Generic;
using Hoshino.Entity;

namespace Hoshino.IRepository
{
    public interface Ib_contact_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        bool Insert(b_contact_Entity model);

        /// <summary>
        /// 修改
        /// <summary>
        bool Update(b_contact_Entity model);

        /// <summary>
        /// 删除
        /// <summary>
        bool Delete(b_contact_Entity model);

        /// <summary>
        /// 获取单个
        /// <summary>
        b_contact_Entity Get(b_contact_Entity model);

        /// <summary>
        /// 获取列表
        /// <summary>
        (IEnumerable<b_contact_Entity>,int) GetList(b_contact_Entity model,int pageindex,int pagesize);

    }
}

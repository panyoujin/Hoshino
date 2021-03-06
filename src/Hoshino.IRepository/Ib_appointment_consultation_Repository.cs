﻿using System;
using System.Collections.Generic;
using Hoshino.Entity;

namespace Hoshino.IRepository
{
    public interface Ib_appointment_consultation_Repository
    {
        /// <summary>
        /// 新增
        /// <summary>
        bool Insert(b_appointment_consultation_Entity model);

        /// <summary>
        /// 修改
        /// <summary>
        bool Update(b_appointment_consultation_Entity model,int AC_ID);

        /// <summary>
        /// 删除
        /// <summary>
        bool Delete(int AC_ID);

        /// <summary>
        /// 获取单个
        /// <summary>
        b_appointment_consultation_Entity Get(int AC_ID);

        /// <summary>
        /// 获取列表
        /// <summary>
        (IEnumerable<b_appointment_consultation_Entity>,int) GetList(b_appointment_consultation_Entity model,int pageindex,int pagesize);

    }
}

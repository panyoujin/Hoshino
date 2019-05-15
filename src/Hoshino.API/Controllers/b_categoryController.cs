using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pan.Code;
using Pan.Code.Extentions;
using Hoshino.API.Filters;
using Hoshino.Entity;
using Hoshino.IRepository;
using Hoshino.API.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Hoshino.API.Controllers
{
    /// <summary>
    /// b_category
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class b_categoryController : ControllerBase
    {
        private readonly ILogger<b_categoryController> _logger;
        private readonly Ib_category_Repository _repository;
        /// <summary>
        /// 构造函数
        /// </summary>
        public b_categoryController(ILogger<b_categoryController> logger, Ib_category_Repository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }
        /// <summary>
        /// 新增
        /// </summary>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Post([FromBody]b_categoryVM model)
        {
            b_category_Entity entity = model.ConvertToT<b_category_Entity>();

            entity.Create_UserId = "1";
            entity.Create_User = "admin";
            return this._repository.Insert(entity).ResponseSuccess();
        }

        /// <summary>
        /// 修改
        /// </summary>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Update([FromBody]b_categoryVM model)
        {
            b_category_Entity entity = model.ConvertToT<b_category_Entity>();
            entity.Create_UserId = "1";
            entity.Create_User = "admin";
            return this._repository.Update(entity).ResponseSuccess();
        }

        /// <summary>
        /// 删除
        /// </summary>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]
        public ActionResult<object> Delete(int Category_ID)
        {
            return this._repository.Delete(Category_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<b_category_Entity>))]
        public ActionResult<object> Get(int Category_ID)
        {
            return this._repository.Get(Category_ID).ResponseSuccess();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<b_category_Entity>>))]
        public ActionResult<object> GetList(int pageindex, int pagesize)
        {
            var (list, total) = this._repository.GetList(pageindex, pagesize);
            return list.ResponseSuccess("", total);
        }

        /// <summary>
        /// 获取所有分类
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ApiResult<List<ALLCategoryVM>>))]
        public ActionResult<object> GetAllCategory()
        {
            var (list, total) = this._repository.GetList(-1, -1);
            List<ALLCategoryVM> categoryList = new List<ALLCategoryVM>();
            var firstID = list.Min(l => l.Parent_Category_ID);
            foreach (var item in list.Where(l => l.Parent_Category_ID == firstID))
            {
                var child = new ALLCategoryVM() { ID = item.Category_ID, Name = item.Category_Name_CH, Name_CN = item.Category_Name_CH, Name_HK = item.Category_Name_HK, Child = new List<ALLCategoryVM>() };
                foreach (var item2 in list.Where(l => l.Parent_Category_ID == child.ID))
                {
                    var child2 = new ALLCategoryVM() { ID = item2.Category_ID, Name = item2.Category_Name_CH, Name_CN = item2.Category_Name_CH, Name_HK = item2.Category_Name_HK, Child = new List<ALLCategoryVM>() };
                    foreach (var item3 in list.Where(l => l.Parent_Category_ID == child2.ID))
                    {
                        var child3 = new ALLCategoryVM() { ID = item3.Category_ID, Name = item3.Category_Name_CH, Name_CN = item3.Category_Name_CH, Name_HK = item3.Category_Name_HK, Child = new List<ALLCategoryVM>() };
                        child2.Child.Add(child3);
                    }
                    child.Child.Add(child2);
                }
                categoryList.Add(child);
            }
            return categoryList.ResponseSuccess("");
        }
    }
}

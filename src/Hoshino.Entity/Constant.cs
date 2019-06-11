namespace Hoshino.Entity
{
    public class Constant
    {
        public const string LoginToken_Key = "Authorization";
        public const string JwtTokenPrefix = "Bearer ";
        /// <summary>
        /// 验证码session名称
        /// </summary>
        public const string Session_CheckCode = "Session_CheckCode";

        /// <summary>
        /// 产品详情 id,Lang
        /// </summary>
        public const string Cache_Product_Prefix = "Cache_Product";

        /// <summary>
        /// 产品详情 id,Lang
        /// </summary>
        public const string Cache_Product = "Cache_Product_ID_{0}_Lang_{1}";

        /// <summary>
        /// 最新的产品列表 页码和页大小,Lang
        /// </summary>
        public const string Cache_ProductNewList = "Cache_Product_New_Page_{0}_Size_{1}_Lang_{2}";

        /// <summary>
        /// 最新的产品列表 页码和页大小,Lang
        /// </summary>
        public const string Cache_ProductNewListTotal = "Cache_Product_New_Total_Page_{0}_Size_{1}_Lang_{2}";

        /// <summary>
        /// 热门的产品列表 页码和页大小,Lang
        /// </summary>
        public const string Cache_ProductHotList = "Cache_Product_Hot_Page_{0}_Size_{1}_Lang_{2}";

        /// <summary>
        /// 热门的产品列表 页码和页大小,Lang
        /// </summary>
        public const string Cache_ProductHotListTotal = "Cache_Product_Hot_Total_Page_{0}_Size_{1}_Lang_{2}";

        /// <summary>
        /// 推荐的产品列表 页码和页大小,Lang
        /// </summary>
        public const string Cache_ProductRecommendList = "Cache_Product_Recommend_Page_{0}_Size_{1}_Lang_{2}";
        /// <summary>
        /// 推荐的产品列表 页码和页大小,Lang
        /// </summary>
        public const string Cache_ProductRecommendListTotal = "Cache_Product_Recommend_Total_Page_{0}_Size_{1}_Lang_{2}";


        /// <summary>
        /// 推荐的产品列表 分类，页码，页大小,Lang
        /// </summary>
        public const string Cache_ProductList = "Cache_Product_Category_{0}_Page_{1}_Size_{2}_Lang_{3}_Name_{4}";

        /// <summary>
        /// 推荐的产品列表 分类，页码，页大小,Lang
        /// </summary>
        public const string Cache_ProductListTotal = "Cache_Product_Total_Category{0}_Page_{1}_Size_{2}_Lang_{3}_Name_{4}";


        /// <summary>
        /// 分类
        /// </summary>
        public const string Cache_Category_Prefix = "Cache_Category";

        /// <summary>
        /// 分类 ,Lang
        /// </summary>
        public const string Cache_CategoryList = "Cache_Category_List_Lang_{0}";
    }
}

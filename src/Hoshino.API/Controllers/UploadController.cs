using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hoshino.API.ViewModels;
using Hoshino.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pan.Code;
using Pan.Code.Extentions;

namespace Hoshino.API.Controllers
{
    /// <summary>
    /// 附件上传接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly ILogger<UploadController> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// 
        /// </summary>
        public UploadController(ILogger<UploadController> logger, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// 附件上传接口
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(IFormCollection))]
        public ActionResult<object> Post([FromForm]IFormCollection formCollection, string picMode = "")
        {
            UploadVM upload = new UploadVM();
            try
            {
                string baseDirectory = AppContext.BaseDirectory;

                FormFileCollection filelist = (FormFileCollection)formCollection.Files;

                foreach (IFormFile file in filelist)
                {
                    String Tpath = Path.Combine("resources", DateTime.Now.ToString("yyyyMMddHH"));
                    string name = file.FileName;
                    //string FileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string FileName = Guid.NewGuid().ToString("N").ToLower();
                    string FilePath = Path.Combine(baseDirectory, Tpath);

                    string fileType = System.IO.Path.GetExtension(name);
                    DirectoryInfo di = new DirectoryInfo(FilePath);


                    if (!di.Exists) { di.Create(); }
                    string fullFile = Path.Combine(FilePath, FileName + fileType);

                    using (FileStream fs = System.IO.File.Create(fullFile))
                    {
                        // 复制文件
                        file.CopyTo(fs);
                        // 清空缓冲区数据
                        fs.Flush();
                    }

                    string newFullFile = "";
                    switch (picMode)
                    {
                        //缩略图
                        case "Thumbnail":
                            //FileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                            FileName = Guid.NewGuid().ToString("N").ToLower();
                            newFullFile = Path.Combine(FilePath, FileName + fileType);
                            Util.ImagePro.MakeThumNail(fullFile, newFullFile, 350, 350, "W");
                            break;
                        //详情图
                        case "Details":
                            FileName = Guid.NewGuid().ToString("N").ToLower();
                            //FileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                            newFullFile = Path.Combine(FilePath, FileName + fileType);
                            Util.ImagePro.MakeThumNail(fullFile, newFullFile, 800, 800, "W");
                            break;
                        //原图
                        case "OriginalGraph":
                        case "":
                            break;
                    }

                    upload.fileName = name;
                    upload.filePath = Path.Combine(Tpath, FileName + fileType);
                    upload.fileType = fileType;
                }
            }
            catch
            {

            }

            return upload.ResponseSuccess();
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ApiResult<UploadVM>))]
        public ActionResult<object> PostBase64([FromBody]ImageVM imageVM)
        {
            UploadVM upload = new UploadVM();
            try
            {

                string baseDirectory = AppContext.BaseDirectory;


                String Tpath = Path.Combine("resources", DateTime.Now.ToString("yyyyMMddHH"));
                string name = "picBase64.jpg";
                string FileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string FilePath = Path.Combine(baseDirectory, Tpath);

                string fileType = System.IO.Path.GetExtension(name);
                DirectoryInfo di = new DirectoryInfo(FilePath);


                if (!di.Exists) { di.Create(); }

                byte[] bit = Convert.FromBase64String(imageVM.ImgBase64);
                MemoryStream ms = new MemoryStream(bit);
                Bitmap bmp = new Bitmap(ms);

                bmp.Save(Path.Combine(FilePath, FileName + fileType), ImageFormat.Jpeg);


                upload.fileName = name;
                upload.filePath = Path.Combine(Tpath, FileName + fileType);
                upload.fileType = fileType;


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToJson());
                throw ex;
            }
            return upload.ResponseSuccess();
        }
    }


}
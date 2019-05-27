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
        public ActionResult<object> Post([FromForm] IFormCollection formCollection)
        {
            UploadVM upload = new UploadVM();
            try
            {
                string baseDirectory = AppContext.BaseDirectory;

                //string webRootPath = _hostingEnvironment.WebRootPath;
                //string contentRootPath = _hostingEnvironment.ContentRootPath;

                FormFileCollection filelist = (FormFileCollection)formCollection.Files;

                foreach (IFormFile file in filelist)
                {
                    String Tpath = Path.Combine("resources", DateTime.Now.ToString("yyyyMMddHH"));
                    string name = file.FileName;
                    string FileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string FilePath = Path.Combine(baseDirectory, Tpath);

                    string fileType = System.IO.Path.GetExtension(name);
                    DirectoryInfo di = new DirectoryInfo(FilePath);


                    if (!di.Exists) { di.Create(); }

                    using (FileStream fs = System.IO.File.Create(Path.Combine(FilePath, FileName + fileType)))
                    {
                        // 复制文件
                        file.CopyTo(fs);
                        // 清空缓冲区数据
                        fs.Flush();
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
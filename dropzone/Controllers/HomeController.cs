using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace dropzone.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpLoadProcess(HttpPostedFileBase imgFile)
        {
            Hashtable hash = new Hashtable();
            if (Request.Files.Count <= 0)
            {
                hash = new Hashtable();
                hash["success"] = false;
                hash["message"] = "Please select a file.";
                return Json(hash);
            }
            imgFile = Request.Files[0];
            string fileTypes = "gif,jpg,jpeg,png,bmp";
            string fileName = imgFile.FileName;
            string fileExt = Path.GetExtension(fileName).ToLower();

            if (string.IsNullOrEmpty(fileExt) || Array.IndexOf(fileTypes.Split(','), fileExt.Substring(1).ToLower()) == -1)
            {
                hash = new Hashtable();
                hash["success"] = false;
                hash["message"] = "Upload file extension is an extension that is not allowed.";
                return Json(hash);
            }

            string filePathName = string.Empty;
            string localPath = Path.Combine(HttpRuntime.AppDomainAppPath, "Resource");
            if (Request.Files.Count == 0)
            {
                return Json(new
                {
                    success = false,
                    message = "Faile"
                });
            }
            string ex = Path.GetExtension(imgFile.FileName);
            filePathName = Guid.NewGuid().ToString("N") + ex;
            if (!System.IO.Directory.Exists(localPath))
            {
                System.IO.Directory.CreateDirectory(localPath);
            }
            imgFile.SaveAs(Path.Combine(localPath, filePathName));
            return Json(new
            {
                success = true,
                message = "/Resource" + "/" + filePathName
            });

        }
        //[HttpPost]
        //public async Task<JsonResult> UploadFile(string defaultFileUploadTextInput)
        //{
        //    try
        //    {
        //        var file = this.Request.Files.First();

        //        //Check input
        //        if (file == null)
        //        {
        //            throw new UserFriendlyException("请选择一个文件!");
        //        }

        //        if (file.Length > 1048576) //1MB
        //        {
        //            throw new UserFriendlyException("文件太大!");
        //        }

        //        byte[] fileBytes;
        //        using (var stream = file.OpenReadStream())
        //        {
        //            fileBytes = stream.GetAllBytes();
        //        }

        //        var fileObject = new BinaryObject(fileBytes);
        //        await this._binaryObjectManager.SaveAsync(fileObject);

        //        return this.Json(new AjaxResponse(new
        //        {
        //            id = fileObject.Id,
        //            contentType = file.ContentType,
        //            defaultFileUploadTextInput = defaultFileUploadTextInput
        //        }));
        //    }
        //    catch (UserFriendlyException ex)
        //    {
        //        return this.Json(new AjaxResponse(new ErrorInfo(ex.Message)));
        //    }
        //}

        //public async Task<ActionResult> GetFile(Guid id, string contentType)
        //{
        //    var fileObject = await this._binaryObjectManager.GetOrNullAsync(id);
        //    if (fileObject == null)
        //    {
        //        return this.StatusCode((int)HttpStatusCode.NotFound);
        //    }

        //    return this.File(fileObject.Bytes, contentType);
        //}
        // }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
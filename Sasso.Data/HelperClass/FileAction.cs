using Microsoft.AspNetCore.Http;
using Sasso.Data.Data.Data;
using Sasso.Data.HelperClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sald.Data.HelperClass
{
    public static class FileAction
    {
        public static string GetImg(MyFile file)
        {
            if (file == null || string.IsNullOrEmpty(file.Path))
                return @"\img\noimg.jpg";
            return file.Path;
        }

        public static async Task<List<MyFile>> UploadFiles(IFormFile file)
        {
            IFormFile[] fileList = { file };
            return await UploadFiles(fileList);
        }

        public static async Task<List<MyFile>> UploadFiles(IFormFile[] files)
        {
            List<MyFile> listFile = new List<MyFile>();
            Random rand = new Random();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    //path
                    var filePath = Path.GetFileName(formFile.FileName);
                    //directory
                    if (!Directory.Exists(MyServer.MapPath("UploadFile")))
                    {
                        Directory.CreateDirectory(MyServer.MapPath("UploadFile"));
                    }

                    //file name + path
                    string pathToFile = MyServer.MapPath("UploadFile\\") + "_" + filePath;

                    while (System.IO.File.Exists(pathToFile))
                    {
                        pathToFile = MyServer.MapPath("UploadFile\\") + rand.Next() + "_" + filePath;
                    }

                    //save
                    using (var stream = File.Create(pathToFile))
                    {
                        //save file
                        await formFile.CopyToAsync(stream);
                        //save file name in db
                        //only name
                        //listFile.Add(new MyFile() { Path = pathToFile.Split("\\").Last() });
                        listFile.Add(new MyFile() { Path = pathToFile.Split("wwwroot").Last() });
                    }
                }
            }
            return listFile;
        }

        public static void RemoveFile(string path)
        {
            RemoveFile(new MyFile() { Path = path });
        }

        public static void RemoveFile(MyFile file)
        {
            if (file != null || !string.IsNullOrEmpty(file.Path))
            {
                if (File.Exists(MyServer.MapPath("") + file.Path))
                {
                    File.Delete(MyServer.MapPath("") + file.Path);
                }
            }
        }

        public static List<MyFile> ChangeFile(string path, IFormFile newFile)
        {
            RemoveFile(path);
            return UploadFiles(newFile).Result;
        }

        //[AllowAnonymous]
        //public async Task<IActionResult> DownloadFileJS(int id)
        //{
        //    var file = _context.Files.FirstOrDefault(f => f.FileID == id);

        //    if (file == null)
        //        return Content("filename not present");

        //    var path = MyServer.MapPath("UploadFile\\") + file.Path;
        //    var memory = new MemoryStream();
        //    using (var stream = new FileStream(path, FileMode.Open))
        //    {
        //        await stream.CopyToAsync(memory);
        //    }
        //    memory.Position = 0;

        //    return File(memory, GetContentType(path), Path.GetFileName(path));
        //}

        //public string GetContentType(string path)
        //{
        //    var types = GetMimeTypes();
        //    var ext = Path.GetExtension(path).ToLowerInvariant();
        //    return types[ext];
        //}

        //private Dictionary<string, string> GetMimeTypes()
        //{
        //    return new Dictionary<string, string>
        //    {
        //        {".txt", "text/plain"},
        //        {".pdf", "application/pdf"},
        //        {".doc", "application/vnd.ms-word"},
        //        {".docx", "application/vnd.ms-word"},
        //        {".xls", "application/vnd.ms-excel"},
        //        {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
        //        {".png", "image/png"},
        //        {".jpg", "image/jpeg"},
        //        {".jpeg", "image/jpeg"},
        //        {".gif", "image/gif"},
        //        {".csv", "text/csv"}
        //    };
        //}
    }
}

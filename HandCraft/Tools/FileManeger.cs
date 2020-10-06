using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HandCraft.Tools
{
    public static class FileManeger
    {
        //type = {
        //Image:1,
        //Video:2,
        //Other:3
        //}
        public class UploadFileStatus
        {
            public int Status { get; set; }
            public string Path { get; set; }
        }


        public static UploadFileStatus FileUploader(IFormFile file, short type, string FolderName)
        {
            UploadFileStatus _uploadFileStatus = new UploadFileStatus();

            if (type == 1)
            {
                if (IsImage(file))
                {
                    if (file.Length < ImageMinimumBytes || file.Length > ImageMaximumBytes)
                    {
                        _uploadFileStatus.Status = 500;
                        _uploadFileStatus.Path = "حجم فایل قابل قبول نیست !";
                    }
                    else
                    {

                        var ext = file.FileName.Split('.');
                        string fileNamee = Guid.NewGuid().ToString() + '.' + ext[(ext.Length) - 1];


                        var filePath = Path.Combine("wwwroot/Files/" + FolderName + "/", fileNamee);

                        if (!Directory.Exists("wwwroot/Files/" + FolderName))
                        {
                            Directory.CreateDirectory("wwwroot/Files/" + FolderName);
                        }

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        _uploadFileStatus.Status = 200;
                        _uploadFileStatus.Path = filePath.Replace("wwwroot", "");
                    }


                }
                else
                {
                    _uploadFileStatus.Status = 500;
                    _uploadFileStatus.Path = "فرمت فایل قابل قبول نیست !";


                }


            }
            else if (type == 2)
            {
                if (IsVideo(file))
                {
                    if (file.Length < VideoMinimumBytes || file.Length > VideoMaximumBytes)
                    {
                        _uploadFileStatus.Status = 500;
                        _uploadFileStatus.Path = "حجم فایل قابل قبول نیست !";
                    }
                    else
                    {

                        var ext = file.FileName.Split('.');
                        string fileNamee = Guid.NewGuid().ToString() + '.' + ext[(ext.Length) - 1];


                        var filePath = Path.Combine("wwwroot/Files/" + FolderName + "/", fileNamee);

                        if (!Directory.Exists("wwwroot/Files/" + FolderName))
                        {
                            Directory.CreateDirectory("wwwroot/Files/" + FolderName);
                        }

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        _uploadFileStatus.Status = 200;
                        _uploadFileStatus.Path = filePath.Replace("wwwroot", "");
                    }


                }
                else
                {
                    _uploadFileStatus.Status = 500;
                    _uploadFileStatus.Path = "فرمت فایل قابل قبول نیست !";


                }


            }
            else if (type == 3)
            {
                if (IsImage(file))
                {
                    if (file.Length < ImageMinimumBytes || file.Length > ImageMaximumBytes)
                    {
                        _uploadFileStatus.Status = 500;
                        _uploadFileStatus.Path = "حجم فایل قابل قبول نیست !";
                    }
                    else
                    {

                        var ext = file.FileName.Split('.');
                        string fileNamee = Guid.NewGuid().ToString() + '.' + ext[(ext.Length) - 1];


                        var filePath = Path.Combine("wwwroot/Files/" + FolderName + "/", fileNamee);

                        if (!Directory.Exists("wwwroot/Files/" + FolderName))
                        {
                            Directory.CreateDirectory("wwwroot/Files/" + FolderName);
                        }

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        _uploadFileStatus.Status = 200;
                        _uploadFileStatus.Path = filePath.Replace("wwwroot", "");
                    }


                }

                else if (IsVideo(file))
                {
                    if (file.Length < VideoMinimumBytes || file.Length > VideoMaximumBytes)
                    {
                        _uploadFileStatus.Status = 500;
                        _uploadFileStatus.Path = "حجم فایل قابل قبول نیست !";
                    }
                    else
                    {

                        var ext = file.FileName.Split('.');
                        string fileNamee = Guid.NewGuid().ToString() + '.' + ext[(ext.Length) - 1];


                        var filePath = Path.Combine("wwwroot/Files/" + FolderName + "/", fileNamee);

                        if (!Directory.Exists("wwwroot/Files/" + FolderName))
                        {
                            Directory.CreateDirectory("wwwroot/Files/" + FolderName);
                        }

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        _uploadFileStatus.Status = 200;
                        _uploadFileStatus.Path = filePath.Replace("wwwroot", "");
                    }


                }

                else if (IsValid(file))
                {
                    if (file.Length < ValidMinimumBytes || file.Length > ValidMaximumBytes)
                    {
                        _uploadFileStatus.Status = 500;
                        _uploadFileStatus.Path = "حجم فایل قابل قبول نیست !";
                    }
                    else
                    {

                        var ext = file.FileName.Split('.');
                        string fileNamee = Guid.NewGuid().ToString() + '.' + ext[(ext.Length) - 1];


                        var filePath = Path.Combine("wwwroot/Files/" + FolderName + "/", fileNamee);

                        if (!Directory.Exists("wwwroot/Files/" + FolderName))
                        {
                            Directory.CreateDirectory("wwwroot/Files/" + FolderName);
                        }

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        _uploadFileStatus.Status = 200;
                        _uploadFileStatus.Path = filePath.Replace("wwwroot", "");
                    }


                }

                else
                {
                    _uploadFileStatus.Status = 500;
                    _uploadFileStatus.Path = "فرمت فایل قابل قبول نیست !";


                }


            }
            return (_uploadFileStatus);
        }


        public const int ImageMinimumBytes = 5 * 1024;
        public const int ImageMaximumBytes = 5 * 1024 * 1024;
        static bool IsImage(IFormFile postedFile)
        {
            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            if (!string.Equals(postedFile.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/pjpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/gif", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/x-png", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/bmp", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/png", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            var postedFileExtension = Path.GetExtension(postedFile.FileName);
            if (!string.Equals(postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".gif", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".bmp", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }




            return true;
        }

        public const int VideoMinimumBytes = 5 * 1024;
        public const int VideoMaximumBytes = 100 * 1024 * 1024;

        static bool IsVideo(IFormFile postedFile)
        {



            //-------------------------------------------
            //  Check the Video mime types
            //-------------------------------------------
            if (!string.Equals(postedFile.ContentType, "video/mp4", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "video/mpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "video/ogg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "video/quicktime", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "video/webm", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "video/x-msvideo", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "video/x-ms-wmv", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            //-------------------------------------------
            //  Check the Video extension
            //-------------------------------------------
            var postedFileExtension = Path.GetExtension(postedFile.FileName);
            if (!string.Equals(postedFileExtension, ".mp4", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".mpeg", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".ogg", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".mov", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".avi", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".wmv", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }




            return true;
        }

        public const int ValidMinimumBytes = 1 * 1024;
        public const int ValidMaximumBytes = 100 * 1024 * 1024;

        static bool IsValid(IFormFile postedFile)
        {



            //-------------------------------------------
            //  Check the  mime types
            //-------------------------------------------
            if (!string.Equals(postedFile.ContentType, "audio/aac", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "application/msword", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "audio/mpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "audio/ogg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "application/pdf", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "application/vnd.ms-powerpoint", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "application/vnd.openxmlformats-officedocument.presentationml.presentation", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "application/vnd.rar", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "application/rtf", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "application/x-shockwave-flash", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "text/plain", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "application/vnd.ms-excel", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "application/zip", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            //-------------------------------------------
            //  Check the  extension
            //-------------------------------------------
            var postedFileExtension = Path.GetExtension(postedFile.FileName);
            if (!string.Equals(postedFileExtension, ".aac", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".doc", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".docx", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".mp3", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".oga", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".pdf", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".ppt", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".pptx", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".rar", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".rtf", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".swf", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".txt", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".xls", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".xlsx", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".zip", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }




            return true;
        }

        public static void FileRemover(List<string> FileAddress)
        {

            foreach (string item in FileAddress)
            {

                var filepath = Directory.GetCurrentDirectory() + (@"\wwwroot\" + item.Replace("/", @"\"));
                try
                {
                    File.Delete(filepath);
                }
                catch (Exception e)
                {

                }

            }

        }
    }


}


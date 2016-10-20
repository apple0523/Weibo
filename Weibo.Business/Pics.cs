using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using Weibo.Entity;
using Weibo.Data;
using Weibo.Common;
using Weibo.Config;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Weibo.Business
{
    public class Pics
    {
        public static bool DelPic(long id)
        {
            try
            {
                if (id > 0)
                {
                    return Data.Pics.DelPic(id);
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
        }

        public static Pic GetPicByID(long id)
        {
            try
            {
                if (id > 0)
                {
                    return Data.Pics.GetPicByID(id);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return null;
            }
        }

        public static Pic UploadImg(User user, ref int error, ref string fileName)
        {
            return UploadImg(user,ref  error,ref  fileName, true);
        }

        public static Pic UploadImg(User user,ref int error,ref string fileName,bool isWaterMark)
        {
            try
            {
                if (user != null)
                {
                    UserConfig uc = Users.GetUserConfigByID(user.ID);
                    if (uc != null)
                    {
                        HttpPostedFile file = HttpContext.Current.Request.Files[0];
                        string filename = Path.GetFileName(file.FileName);
                        string fileextname = Path.GetExtension(filename).ToLower();
                        fileName = filename;
                        if (file.ContentLength > BaseConfigs.GetImgUploadSize)
                        {
                            error = -2;
                            return null;
                        }
                        else if (Utils.InArray(fileextname, ".jpg,.jpeg,.gif,.png") && ValidateImage(file.InputStream))
                        {
                            Image image = Image.FromStream(file.InputStream);
                            string dateNow=Utils.GetDate();
                            string backupPath=BaseConfigs.GetImageUploadPath+"Backup/"+dateNow+"/";
                            Utils.CreateDir(backupPath);
                            string thumPath = BaseConfigs.GetImageUploadPath + "Thum/" + dateNow + "/";
                            Utils.CreateDir(thumPath);
                            string smallPath=BaseConfigs.GetImageUploadPath+"Small/"+dateNow+"/";
                             Utils.CreateDir(smallPath);
                            string largePath=BaseConfigs.GetImageUploadPath+"Large/"+dateNow+"/";
                             Utils.CreateDir(largePath);
                            string middlePath=BaseConfigs.GetImageUploadPath+"Middle/"+dateNow+"/";
                             Utils.CreateDir(middlePath);
                            string guid=Guid.NewGuid().ToString();
                            string newFileName=guid+fileextname;
                            file.SaveAs(Utils.GetMapPath(backupPath+newFileName));
                            if (uc.WaterMarkStyle.Trim() != "0|0" && isWaterMark)
                            {
                                string waterMarkText = string.Empty;
                                if (uc.WaterMarkStyle.Trim() == "1|1")
                                {
                                    waterMarkText = user.NickName + "\n" + BaseConfigs.GetWebDomain + "/" + (string.IsNullOrEmpty(user.CustomSite)?user.ID.ToString() : user.CustomSite);
                                }
                                else if (uc.WaterMarkStyle.Trim() == "1|0")
                                {
                                    waterMarkText = user.NickName;
                                }
                                else
                                {
                                    waterMarkText = BaseConfigs.GetWebDomain + "/" + (string.IsNullOrEmpty(user.CustomSite)? user.ID.ToString() : user.CustomSite);
                                }
                                if (fileextname != ".gif")
                                {
                                    AddImageSignText(image, Utils.GetMapPath(largePath + newFileName), waterMarkText, uc.WaterMarkPosition);
                                }
                                else
                                {
                                    image.Save(Utils.GetMapPath(largePath + newFileName));
                                    image.Dispose();
                                }
                            }
                            else
                            {
                                image.Save(Utils.GetMapPath(largePath + newFileName));
                                image.Dispose();
                            }
                            image = Image.FromFile(Utils.GetMapPath(largePath + newFileName));
                            int imageWidth = image.Width;
                            int imageHeight = image.Height;
                            bool isConvert = true;
                            Size newSize = GetThumbnailSize(imageWidth, imageHeight, 200, 200,ref isConvert);
                            if (isConvert)
                            {
                                MakeReSizeImage(image, Utils.GetMapPath(smallPath + newFileName), newSize);
                            }
                            else
                            {
                                image.Save(Utils.GetMapPath(smallPath + newFileName));
                            }

                            newSize = GetThumbnailSize(imageWidth, imageHeight, 120, 120, ref isConvert);
                            if (isConvert)
                            {
                                MakeReSizeImage(image, Utils.GetMapPath(thumPath + newFileName), newSize);
                            }
                            else
                            {
                                image.Save(Utils.GetMapPath(thumPath + newFileName));
                            }
                            newSize = GetMiddleSize(imageWidth, imageHeight, 440, ref isConvert);
                            if (isConvert)
                            {
                                MakeReSizeImage(image, Utils.GetMapPath(middlePath + newFileName), newSize);
                            }
                            else
                            {
                                image.Save(Utils.GetMapPath(middlePath + newFileName));
                            }
                            image.Dispose();

                            Pic pic=new Pic();
                            pic.SmallPicUrl = smallPath + newFileName;
                            pic.MidPicUrl = middlePath + newFileName;
                            pic.OriginalPicUrl = largePath + newFileName;
                            pic.ThumPicUrl = thumPath + newFileName;
                            pic.ID = Data.Pics.CreatePic(pic);
                            if (pic.ID > 0)
                                return pic;
                            else
                                throw new Exception();
                        }
                        throw new Exception();
                    }
                }
                throw new Exception();
            }
            catch (Exception ex)
            {
                error = -1;
                Logs.WriteErrorLog(ex);
                return null;
            }
            
        }

        private static bool ValidateImage(Stream inputStream)
        {
            if (inputStream.Length == 0)
                return false;
            try
            {
                Image image = Image.FromStream(inputStream);
                image.Dispose();
            }
            catch(Exception ex)
            {
                Logs.WriteErrorLog(ex);
                return false;
            }
            return true;
        }


        private static void AddImageSignText(Image img, string filename, string watermarkText, int watermarkPosition)
        {
            Graphics g = Graphics.FromImage(img);
            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Font drawFont = new Font("Tahoma", ((float)img.Width * (float).03), FontStyle.Regular, GraphicsUnit.Pixel);
            SizeF crSize;
            crSize = g.MeasureString(watermarkText, drawFont);

            float xpos = 0;
            float ypos = 0;

            switch (watermarkPosition)
            {
                case 3:
                    xpos = ((float)img.Width * (float).50) - (crSize.Width / 2);
                    ypos = ((float)img.Height * (float).50) - (crSize.Height / 2);
                    break;
                case 2:
                    xpos = ((float)img.Width * (float).50) - (crSize.Width / 2);
                    ypos = (float)img.Height  - crSize.Height;
                    break;
                case 1:
                    xpos = ((float)img.Width * (float).99) - crSize.Width;
                    ypos = (float)img.Height  - crSize.Height;
                    break;
            }

            g.DrawString(watermarkText, drawFont, new SolidBrush(Color.White), xpos + 1, ypos + 1);
            g.DrawString(watermarkText, drawFont, new SolidBrush(Color.Black), xpos, ypos);

  
           img.Save(filename);

            g.Dispose();
            img.Dispose();
        }

        /// <summary>
        /// 得到图片格式
        /// </summary>
        /// <param name="name">文件名称</param>
        /// <returns></returns>
        private static ImageFormat GetFormat(string name)
        {
            string ext = name.Substring(name.LastIndexOf(".") + 1);
            switch (ext.ToLower())
            {
                case "jpg":
                case "jpeg":
                    return ImageFormat.Jpeg;
                case "bmp":
                    return ImageFormat.Bmp;
                case "png":
                    return ImageFormat.Png;
                case "gif":
                    return ImageFormat.Gif;
                default:
                    return ImageFormat.Jpeg;
            }
        }

        /// <summary>
        /// 计算缩略图大小
        /// </summary>
        /// <param name="width">原始宽度</param>
        /// <param name="height">原始高度</param>
        /// <param name="maxWidth">最大新宽度</param>
        /// <param name="maxHeight">最大新高度</param>
        /// <returns></returns>
        private static Size GetThumbnailSize(int width, int height, int maxWidth, int maxHeight,ref bool isConvert)
        {
            decimal MAX_WIDTH = (decimal)maxWidth;
            decimal MAX_HEIGHT = (decimal)maxHeight;
            decimal ASPECT_RATIO = MAX_WIDTH / MAX_HEIGHT;

            int newWidth, newHeight;
            decimal originalWidth = (decimal)width;
            decimal originalHeight = (decimal)height;

            if (originalWidth > MAX_WIDTH || originalHeight > MAX_HEIGHT)
            {
                decimal factor;
                // determine the largest factor 
                if (originalWidth / originalHeight > ASPECT_RATIO)
                {
                    factor = originalWidth / MAX_WIDTH;
                    newWidth = Convert.ToInt32(originalWidth / factor);
                    newHeight = Convert.ToInt32(originalHeight / factor);
                }
                else
                {
                    factor = originalHeight / MAX_HEIGHT;
                    newWidth = Convert.ToInt32(originalWidth / factor);
                    newHeight = Convert.ToInt32(originalHeight / factor);
                }
            }
            else
            {
                newWidth = width;
                newHeight = height;
                isConvert = false;
            }
            return new Size(newWidth, newHeight);
        }


        /// <summary>
        /// 计算中图大小
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <returns></returns>
        private static Size GetMiddleSize(int width, int height, int maxWidth, ref bool isConvert)
        {
            decimal MAX_WIDTH = (decimal)maxWidth;

            int newWidth, newHeight;
            decimal originalWidth = (decimal)width;
            decimal originalHeight = (decimal)height;

            if (maxWidth < originalWidth)
            {
                newWidth = maxWidth;
                newHeight = Convert.ToInt32(originalHeight / (originalWidth / MAX_WIDTH));
            }
            else
            {
                newWidth = width;
                newHeight = height;
                isConvert = false;
            }
            return new Size(newWidth, newHeight);
        }

        private static void MakeReSizeImage(Image original, string newFileName, Size _newSize)
       {
           //新建一个bmp图片 
           System.Drawing.Image bitmap = new System.Drawing.Bitmap(_newSize.Width, _newSize.Height);

           Graphics g = System.Drawing.Graphics.FromImage(bitmap);

           //设置高质量插值法 
           g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

           //设置高质量,低速度呈现平滑程度 
           g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

           //清空画布并以透明背景色填充 
           g.Clear(Color.Transparent);

           //在指定位置并且按指定大小绘制原图片的指定部分 
           g.DrawImage(original, 0, 0, _newSize.Width, _newSize.Height);

           try
           {
               if (GetFormat(newFileName) == ImageFormat.Gif)
                   bitmap.Save(newFileName, ImageFormat.Jpeg);
               else
               {
                   bitmap.Save(newFileName, GetFormat(newFileName));
               }
           }
           catch (System.Exception e)
           {
               Logs.WriteErrorLog(e);
           }
           finally
           {
               bitmap.Dispose();
               g.Dispose();
           } 
       }
    }
}

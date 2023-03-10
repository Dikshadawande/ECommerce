using ECommerce.Core.Contract;
using ECommerce.Core.Domain.RequestModel;
using ECommerce.Infra.Contract;
using ECommerce.Infra.Domain.Entities;
using ECommerceContextt.Infra.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Web.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services
{
    public class ImageServices : IImageService
    {
        private readonly IImage _image;
        public static IWebHostEnvironment _webHostEnvironment;

        public ImageServices(IImage image, IWebHostEnvironment webHostEnvironment)
        {
            _image = image;
            _webHostEnvironment = webHostEnvironment;
        }

        public string Addimage([FromForm] Infra.Domain.Entities.FileUpload image)
        {
           
                if(image.files.Length >0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\Uploads\\";
                    if(!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (FileStream fileStream = System.IO.File.Create(path + image.files.FileName))
                    {
                        image.files.CopyTo(fileStream);
                        fileStream.Flush();
                        var path2 = path + image.files.FileName;

                        Images img = new Images();
                        img.Id = img.Id;
                        img.ProductId = image.ProductId;
                        img.Name = image.files.FileName;
                        img.Url = path2;

                       var img1 = _image.Add(img);
                       
                        Console.WriteLine(path);
                        var str = "Uploaded";
                    //return img.Id.ToString();
                    return str;
                    }

                
                }
                else
                {
                    return "Not Added";
                }
        }
           
        }
    }
    

        
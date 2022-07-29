using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StaticFile.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IHostingEnvironment _environment;

        public ImagesController(IHostingEnvironment hostingEnvironment)
        {
            _environment = hostingEnvironment;
        }

        public IActionResult Post(string apiKey)
        {
            if (apiKey != "mysecretkey")
            {
                return BadRequest();
            }

            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (files != null)
                {
                    //upload
                    return Ok(UploadFile(files));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error");
                throw new Exception("upload image error", ex);
            }
        }

    private UploadDto UploadFile(IFormFileCollection files)
    {
            string newName = Guid.NewGuid().ToString();
            var date = DateTime.Now;
            string folder = $@"Resources\images\{date.Year}\{date.Year}-{date.Month}\";
            var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
            if (!Directory.Exists(uploadsRootFolder))
            {
                Directory.CreateDirectory(uploadsRootFolder);
            }
            List<string> address = new List<string>();
            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    string fileName = newName + file.FileName;
                    var filePath = Path.Combine(uploadsRootFolder, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    address.Add(folder + fileName);
                }
            }
            return new UploadDto()
            {
                FileNameAddress = address,
                Status = true,
            };

        }
        }
    public class UploadDto
    {
        public bool Status { get; set; }
        public List<string> FileNameAddress { get; set; }
    }
}

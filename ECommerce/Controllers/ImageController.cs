using ECommerce.Core.Contract;
using ECommerce.Infra.Domain.Entities;
using ECommerceContextt.Infra.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }


        [HttpPost("Images")]
        //public  async string AddImage([FromForm] Infra.Domain.Entities.FileUpload image)
        public async Task<IActionResult> Add([FromForm] FileUpload image)
        {
          return Ok( _imageService.Addimage(image));
           
            
        
        }
            
     }
}

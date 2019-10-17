using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AngularCoreApp.DIPCore;
using AngularCoreApp.Mapping.Resources;
using AngularCoreApp.Models;
using AngularCoreApp.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace AngularCoreApp.Controllers
{
    [Route("/api/vehicles/{vehicleId}/photos")]
    public class PhotosController : Controller
    {
        private readonly IHostEnvironment _host;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PhotoSettings _photoSettings;

        public PhotosController(
            IHostEnvironment host, 
            IVehicleRepository vehicleRepository, 
            IPhotoRepository photoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IOptionsSnapshot<PhotoSettings> photoSettings)
        {
            _host = host;
            _vehicleRepository = vehicleRepository;
            _photoRepository = photoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _photoSettings = photoSettings.Value;
        }
        
        [HttpPost]
        public async Task<IActionResult> Upload(int vehicleId, IFormFile file)
        {
            if (file == null)
                return BadRequest("Not a file");

            if (file.Length > _photoSettings.MaxBytes)
                return BadRequest("Over of maximum file size");

            if (!_photoSettings.IsSupported(file.FileName))
                return BadRequest("Invalid file type");
            
            var vehicle = await _vehicleRepository.GetVehicle(vehicleId, false);
            
            if (vehicle == null)
                return NotFound();
            
            var uploadFolderPath = Path.Combine(_host.ContentRootPath + "\\wwwroot\\", "uploads");

            if (!Directory.Exists(uploadFolderPath))
                Directory.CreateDirectory(uploadFolderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var photo = new Photo { FileName = fileName };
            vehicle.Photos.Add(photo);
            await _unitOfWork.CompleteAsync();

            return Ok(_mapper.Map<Photo, PhotoResource>(photo));
        }

        [HttpGet]
        public async Task<IEnumerable<PhotoResource>> GetPhotos(int vehicleId)
        {
            var photos = await _photoRepository.GetPhotos(vehicleId);

            return _mapper.Map<IEnumerable<Photo>, IEnumerable<PhotoResource>>(photos);
        }
    }
}
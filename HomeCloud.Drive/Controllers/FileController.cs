using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HomeCloud.Drive.Services;
using HomeCloud.Drive.Services.Models;
using HomeCloud.Drive.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeCloud.Drive.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("{directoryDescriptorId?}")]
        public IActionResult GetAll(int? directoryDescriptorId)
        {
            if (directoryDescriptorId.HasValue && directoryDescriptorId <= 0)
            {
                return NoContent();
            }

            return Ok(_fileService.GetFileDescryptors(directoryDescriptorId).Select(x => new FileDescryptorViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                DirectoryDescryptorId = x.DirectoryDescriptorId
            }));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int fileDescryptorId)
        {
            if (fileDescryptorId <= 0)
            {
                return BadRequest();
            }

            await _fileService.DeleteFile(fileDescryptorId);
            return NoContent();
        }

        [HttpGet("{fileDescriptorId}/download")]
        public async Task<IActionResult> Download(int fileDescriptorId)
        {
            if (fileDescriptorId <= 0)
            {
                return NotFound();
            }

            var fileWithData = await _fileService.GetFileAsync(fileDescriptorId);
            return File(fileWithData.Stream, fileWithData.ContentType, fileWithData.FileName);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm][Required] FileViewModel viewModel)
        {
            var fileDescryptor = await _fileService.AddFile(new FileWithDataModel(viewModel.File.FileName, viewModel.DirectoryDescryptorId,
                viewModel.File.OpenReadStream(), viewModel.File.ContentType));
            return Ok(fileDescryptor);
        }
    }
}
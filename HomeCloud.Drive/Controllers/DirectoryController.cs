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
    [Route("api/directories")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        private readonly IDirectoryService _directoryService;

        public DirectoryController(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
        }

        [HttpGet("{parentDirectoryDescryptorId?}")]
        public IActionResult GetAll(int? parentDirectoryDescryptorId)
        {
            if (parentDirectoryDescryptorId.HasValue && parentDirectoryDescryptorId <= 0)
            {
                return BadRequest();
            }

            return Ok(_directoryService.GetDirectories(parentDirectoryDescryptorId).Select(x => new DirectoryDescryptorViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                ParentDirectoryDescryptorId = x.ParentDirectoryDescryptorId
            }));
        }

        [HttpPost]
        public async Task<IActionResult> Save([Required] DirectoryDescryptorViewModel viewModel)
        {
            var directoryDescryptor = await _directoryService
                .AddDirectory(new DirectoryModel(viewModel.Name, viewModel.ParentDirectoryDescryptorId));
            return Ok(directoryDescryptor);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int directoryDescryptorId)
        {
            if (directoryDescryptorId <= 0)
            {
                return BadRequest();
            }

            await _directoryService.DeleteDirectory(directoryDescryptorId);
            return NoContent();
        }
    }
}
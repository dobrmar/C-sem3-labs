using Microsoft.AspNetCore.Mvc;
using Lab4.Services;
using System;
using System.Threading.Tasks;
using Lab4.Models;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace Lab4.Controllers
{
    [ApiController]
    [Route("api/compositions")]
    public class CompositionController : ControllerBase
    {
        private readonly ICompService _compService;

        public CompositionController(ICompService compService)
        {
            _compService = compService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddComposition([Required] string AuthorName, [Required] string Name)
        {
            try
            {
                bool success = await _compService.AddComposition(new Composition(AuthorName, Name));

                if (success)
                {
                    return Ok($"Composition {AuthorName} - {Name} has been added successfully.");
                }
                else
                {
                    return Ok($"Composition {AuthorName} - {Name} is already in the list.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding composition: {ex.Message}");
            }
        }

        [HttpGet("show-list")]
        public async Task<IActionResult> ShowList()
        {
            try
            {
                var comps = await _compService.ShowList();
                if (comps != null && comps.Any())
                {
                    return Ok(comps);
                }
                else return Ok("No compositions in the list.");
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Error showing list: {ex.Message}");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult> SearchComposition([Required] string str)
        {
            try
            {
                var comps = await _compService.SearchComposition(str);

                if (comps != null && comps.Any())
                {
                    return Ok(comps);
                }
                else
                {
                    return NotFound($"No compositions found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error finding compositions: {ex.Message}");
            }
        }

        [HttpDelete("remove")]
        public async Task<ActionResult> RemoveComposition([Required] string AuthorName, [Required] string Name)
        {
            try
            {
                bool success = await _compService.RemoveComposition(new Composition(AuthorName, Name));

                if (success)
                {
                    return Ok($"Composition {AuthorName} - {Name} has been removed successfully.");
                }
                else
                {
                    return NotFound($"Composition {AuthorName} - {Name} not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error removing composition: {ex.Message}");
            }
        }
    }

}
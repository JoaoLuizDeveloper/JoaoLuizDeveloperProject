using JoaoLuizDeveloper.Application.Application;
using JoaoLuizDeveloper.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/aboutUs")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private readonly IAboutUsApplication _aboutUs;        
        public AboutUsController(IAboutUsApplication aboutUs)
        {
            _aboutUs = aboutUs;
        }

        /// <summary>
        /// Get All AboutUs
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AboutUs>))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _aboutUs.GetAll().ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get One AboutUs
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("Get/{id:int}", Name = "GetAboutUs")]
        [ProducesResponseType(200, Type = typeof(AboutUs))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _aboutUs.GetOne(id).ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Create AboutUs
        /// </summary>
        /// <param name="aboutUs"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("Create")]
        [ProducesResponseType(201, Type = typeof(AboutUs))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] AboutUs aboutUs)
        {
            try
            {
                return Ok(await _aboutUs.Create(aboutUs).ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Update AboutUs
        /// </summary>
        /// <param name="aboutUs"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPatch("Update")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] AboutUs aboutUs)
        {
            try
            {
                return Ok(await _aboutUs.Update(aboutUs).ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Delete AboutUs
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpDelete("Remove/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                return Ok(await _aboutUs.Remove(id).ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
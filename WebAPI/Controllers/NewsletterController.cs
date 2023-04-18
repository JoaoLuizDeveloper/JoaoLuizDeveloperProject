using JoaoLuizDeveloper.Application.Application;
using JoaoLuizDeveloper.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/newsletter")]
    [ApiController]
    public class NewsletterController : ControllerBase
    {
        private readonly INewsLetterApplication _newsletter;

        public NewsletterController(INewsLetterApplication newsletter)
        {
            _newsletter = newsletter;
        }

        /// <summary>
        /// Get All NewsLetter
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NewsLetter>))]
        public async Task<IActionResult> GetAll()
        {
            try 
            {
                return Ok(await _newsletter.GetAll().ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get One NewsLetter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("Get/{id:int}", Name = "GetOneNewsLetter")]
        [ProducesResponseType(200, Type = typeof(NewsLetter))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _newsletter.GetOne(id).ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Create NewsLetter
        /// </summary>
        /// <param name="newsletter"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("Create")]
        [ProducesResponseType(201, Type = typeof(NewsLetter))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] NewsLetter newsletter)
        {
            try
            {
                return Ok(await _newsletter.Create(newsletter).ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Update NewsLetter
        /// </summary>
        /// <param name="newsletter"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPatch("Update")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] NewsLetter newsletter)
        {
            try
            {
                return Ok(await _newsletter.Update(newsletter).ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete NewsLetter
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
                return Ok(await _newsletter.Remove(id).ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
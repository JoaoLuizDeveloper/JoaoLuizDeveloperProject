using JoaoLuizDeveloper.Application.Application;
using JoaoLuizDeveloper.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/contactUs")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsApplication _contactUs;

        public ContactUsController(IContactUsApplication contactUs)
        {
            _contactUs = contactUs;
        }

        /// <summary>
        /// Get All ContactUs
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ContactUs>))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _contactUs.GetAll().ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get One ContactUs
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("Get/{id:int}", Name = "GetOneContactUs")]
        [ProducesResponseType(200, Type = typeof(ContactUs))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _contactUs.GetOne(id).ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Create ContactUs
        /// </summary>
        /// <param name="contactUs"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("Create")]
        [ProducesResponseType(201, Type = typeof(ContactUs))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ContactUs contactUs)
        {
            try
            {
                return Ok(await _contactUs.Create(contactUs).ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Update ContactUs
        /// </summary>
        /// <param name="contactUs"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPatch("Update")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] ContactUs contactUs)
        {
            try
            {
                return Ok(await _contactUs.Update(contactUs).ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Delete ContactUs
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
                return Ok(await _contactUs.Remove(id).ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
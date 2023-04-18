using JoaoLuizDeveloper.Application.Application;
using JoaoLuizDeveloper.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/resume")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeApplication _resume;

        public ResumeController(IResumeApplication resume)
        {
            _resume = resume;
        }

        /// <summary>
        /// Get All Resume
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Resume>))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _resume.GetAll().ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get One Resume
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("Get/{id:int}", Name = "GetOneResume")]
        [ProducesResponseType(200, Type = typeof(Resume))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _resume.GetOne(id).ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Create Resume
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("Create")]
        [ProducesResponseType(201, Type = typeof(Resume))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] Resume resume)
        {
            try
            {
                return Ok(await _resume.Create(resume).ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Update Resume
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPatch("Update")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] Resume resume)
        {
            try
            {
                return Ok(await _resume.Update(resume).ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete Resume
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
                return Ok(await _resume.Remove(id).ConfigureAwait(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
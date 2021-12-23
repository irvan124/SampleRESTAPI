using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleRESTAPI.Data;
using SampleRESTAPI.Dtos;
using SampleRESTAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private ICourse _course;
        private IMapper _mapper;

        public CoursesController(ICourse course, IMapper mapper)

        {
            _course = course;
            _mapper = mapper;
        }

        // GET: api/<CoursesController>
        [HttpGet]
        //Tipe pengembalian nya Task
        public async Task<ActionResult<IEnumerable<CourseDto>>> Get()
        {
            var courses = await _course.GetAll();
            var dtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
            return Ok(dtos);
            
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> Get(int id)
        {
            var result = await _course.GetById(id.ToString());
            if(result == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CourseDto>(result));
        }

        // POST api/<CoursesController>
        [HttpPost]
        //Kalau mau mengembalikan status, gunakan IAction Result
        // Kalau sudah tau kembalian nya gunakan Action Result
        public async Task<ActionResult<CourseDto>> Post([FromBody] CourseForCreateDto courseForCreateDto)
        {
            try
            {
                // Di Map dari Model Coruse, Tapi hanya tampilkan Field sesuai parameter (courseForCreateDto)
                var course = _mapper.Map <Models.Course>(courseForCreateDto);

                // Field yang sudah di Map di tambahin ke database
                var result = await _course.Insert(course);

                //Mengembalikan data Insert nya
                var courseReturn = _mapper.Map<Dtos.CourseDto>(result);
                return Ok(courseReturn);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDto>> Put(int id, [FromBody] CourseForCreateDto courseForCreateDto)
        {
            try
            {
                var course = _mapper.Map<Models.Course>(courseForCreateDto);
                // Semua data yang akan di gunakan harus di convert menjadi String dahulu
                var result =  await _course.Update(id.ToString(), course);
                var courseReturn = _mapper.Map<Dtos.CourseDto>(result);
                return Ok(courseReturn);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _course.Delete(id.ToString());
                return Ok($"Delete data id {id} berhasil");
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("bytitle")]
        public async Task<IEnumerable<Course>> GetByTitle(string title)
        {
            var results = await _course.GetByTitle(title);
            return results;
        }
    }
}

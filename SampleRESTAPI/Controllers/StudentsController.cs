using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleRESTAPI.Data;
using SampleRESTAPI.Dtos;
using SampleRESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // return "Hello Student";
        /* private List<Student> lstStudent = new List<Student>
         {
          new Student { ID=1, FirstName="Agus", LastName="Kurniawan", EnrollmentDate=DateTime.Now},
          new Student { ID=2, FirstName="Erick", LastName="Kurniawan", EnrollmentDate=DateTime.Now},
          new Student { ID=3, FirstName="Leo", LastName="Giant", EnrollmentDate=DateTime.Now}
          }; */

        private IStudent _student;
        private IMapper _mapper;

        public StudentsController(IStudent student, IMapper mapper)
        {
            _student = student ?? throw new ArgumentException(nameof(student));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }


        [HttpGet]
         public async Task<ActionResult<IEnumerable<StudentDto>>> Get()
        {
            var students = await _student.GetAll();
            /* 

             List<StudentDto> lstStudentDto = new List<StudentDto>();

             foreach (var student in students)
             {
                 lstStudentDto.Add(new StudentDto
                 {
                     ID = student.ID,
                     Name = $"{student.FirstName} {student.LastName}",
                     EnrollmentDate = student.EnrollmentDate,
                 });

             }
             return lstStudentDto;
            */

            // Map With Auto Mapper
            var dtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            return Ok(dtos);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> Get(int id)
        {
            // Processing the student data get By desired ID
            var result = await _student.GetById(id.ToString());
            if(result == null)
            {
                return  NotFound();
            }
            // return mapper of Student Dto
            return Ok(_mapper.Map<StudentDto>(result));
        }
        


           // [HttpGet("{id}")]
           /* public Student Get(int id)
            {
                // Menggunakan Lambda
               // var result = lstStudent.Where(s => s.ID == id).SingleOrDefault();

                // Menggunakan LinQ
                var result = (from s in lstStudent select s).SingleOrDefault();

                if(result != null)
                {
                    return result;
                }
                else
                {
                    return new Student { };
                }
            }

            //Custom Route = ControllerName/byname/params

            [HttpGet("byname")]
            public List<Student> Get(string firstname="", string lastname="")
            {
            //Menggunakan Lambda
            var results = lstStudent.Where(s => s.FirstName.ToLower().StartsWith(firstname.ToLower()) && s.LastName.ToLower().StartsWith(lastname.ToLower())).ToList();

           // var results = (from s in lstStudent where s.FirstName.Contains(firstname) select s).ToList();

            return results;

            }
           */
           [HttpPost]
          public async Task<ActionResult<StudentDto>> Post([FromBody]StudentForCreateDto studentForCreateDto)
            {
            try
            {
                // Masukin dari StudentForDto berdasarkan model Student
                var student = _mapper.Map<Models.Student>(studentForCreateDto);
                // Proses Inseert
                var result = await _student.Insert(student);

                //Mengembalikan data Insert nya
                var studentReturn = _mapper.Map<Dtos.StudentDto>(result);
                return Ok(studentReturn);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            }


           [HttpPut("{id}")]
           public async Task<ActionResult<StudentDto>> Put(int id,[FromBody] StudentForCreateDto studentForCreateDto)
        {
            try
            {
                var student = _mapper.Map<Models.Student>(studentForCreateDto);
                var result = await _student.Update(id.ToString(), student);
                var studentReturn = _mapper.Map<Dtos.StudentDto>(result);
                return Ok(studentReturn);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>  Delete(int id)
        {
            try
            {
                await _student.Delete(id.ToString());
                return Ok($"Data Student {id} Berhasil di delete");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    
       }
    }


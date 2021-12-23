using Microsoft.EntityFrameworkCore;
using SampleRESTAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleRESTAPI.Data
{
    public class EnrollmentDAL : IEnrollment
    {
        private ApplicationDbContext _db;

        // Contructor untuk menginjek Service
        // ApplicationDbContext db >> Connect in ke Database
        public EnrollmentDAL(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        //Joining Table
        // With Include
        public async Task<IEnumerable<Enrollment>> GetAll()
        {
           //With Lambda? = Enrolments Join Students Tables
           // Joining Table Students and Course into the based on Enrollment Table
           var result = await _db.Enrollments.Include(e => e.Student).Include(e => e.Course).AsNoTracking().ToListAsync();
           return result;
        }

        public Task<Enrollment> GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Enrollment> Insert(Enrollment obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<Enrollment> Update(string id, Enrollment obj)
        {
            throw new System.NotImplementedException();
        }
    }
}

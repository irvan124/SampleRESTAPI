using Microsoft.EntityFrameworkCore;
using SampleRESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleRESTAPI.Data
{
    public class CourseDAL : ICourse
    {
        private ApplicationDbContext _db;

        public CourseDAL(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Delete(string id)
        {
            try
            {
                var result = await GetById(id);
                if (result == null) throw new Exception($"Data couse ID {id} tidak ditemukan");

                //Deleting the data desired
                _db.Courses.Remove(result);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException DbEx)
            {

                throw new Exception(DbEx.Message);
            }
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            // Select just want data to be read, so to get optimal performance use As No Tracking
            // With Lambda
            //var result = await _db.Courses.OrderBy(c => c.Title).AsNoTracking().ToListAsync();

            var result = await (from c in _db.Courses 
                                //orderby c.Title ascending 
                                select c).AsNoTracking().ToListAsync();
            return result;  
        }

       /* public async Task<IEnumerable<Course>> GetStudentByCourseName(string title)
        {
            try
            {
                var results1 = await GetByTitle(title);
                if (results1 == null) throw new Exception($"Data Course name {title} tidak ditemukan");
                var result2 = await _db.Enrollments
            }
            catch (Exception)
            {

                throw;
            }
       


        }
       */
       

        public async Task<Course> GetById(string id)
        {
            // Karena return nya 1 objek saja, maka digunakan SIngleorDefaultAsync()
            // Proses2 read biasanya memakai AS no tracking untuk mempertahankan performace dari server
            // AsNoTracking not allwed, because this query is use for other update methods, so the id wont recorded
            var result = await (from c in _db.Courses where c.CourseID == Convert.ToInt32(id) select c).SingleOrDefaultAsync();
            if (result == null) throw new Exception($"Data Id {id} Tidak ditemukan");

            return result;
            
        }

    
        public async Task<IEnumerable<Course>> GetByTitle(string title)
        {
           var results = await (from c in _db.Courses where c.Title.Contains(title.ToLower()) 
                                select c).AsNoTracking().ToListAsync();

            if (results == null) throw new Exception($"{title} Tidak ditemukan");

            return results;
        }

        public async Task<Course> Insert(Course obj)
        {
            try
            {
                //Masukkan objek baru ke dalam list object database
                _db.Courses.Add(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            catch (DbUpdateException dbEx)
            {

                throw new Exception(dbEx.Message);
            }
        }

        public async Task<Course> Update(string id, Course obj)
        {
            try
            {
                // Mencari iD nya dulu di database
                var result = await GetById(id);
                // Jika id tidak di temukan akan ending di sini
                if (result == null) throw new Exception($"Data Course ID {id} tidak ditemukan");
                
                // Menambahkan ke object data jika ketemu id nya
                result.Title = obj.Title;
                result.Credits = obj.Credits;

                // Saving to the database
                await _db.SaveChangesAsync();

                return result;
            }
            catch (DbUpdateException DbEx)
            {

                throw new Exception(DbEx.Message);
            }
        }
    }
}

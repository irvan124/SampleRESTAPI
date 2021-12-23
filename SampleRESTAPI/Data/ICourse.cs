using SampleRESTAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleRESTAPI.Data
{
    public interface ICourse : ICrud<Course>
    {
        //Additional Bussiness Logic
        Task<IEnumerable<Course>> GetByTitle(string title);
       // Task<IEnumerable<Course>> GetStudentByCourseName(string title);
    }
}

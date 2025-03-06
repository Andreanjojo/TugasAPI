using System;
using SimpleRESTApi.Models;
namespace SimpleRESTApi.Data
{
    public interface IInstructor
    {
        //crud
        IEnumerable<Instructor> GetInstructors();
        Instructor GetInstructorById(int InstructorID);
        Instructor addInstructor(Instructor Instructor);
        Instructor updateInstructor(Instructor Instructor);
        void deleteInstructor(int InstructorID);
    }
}
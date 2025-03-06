using System;
using SimpleRESTApi.Models;
namespace SimpleRESTApi.Data;
public class InstructorDal : IInstructor
{
    private List<Instructor> _instructor = new List<Instructor>();
    public InstructorDal()
    {
        _instructor = new List<Instructor>
        {
            new Instructor { InstructorID = 1, InstructorName = "John Doe", InstructorEmail = "john@gmail.com", InstructorPhone = "1234567890", InstructorAddress = "1234 Main St", InstructorCity = "Anytown" },
        };
    }

        public Instructor addInstructor(Instructor Instructor)
        {
            _instructor.Add(Instructor);
            return Instructor;
        }

        public void deleteInstructor(int InstructorID)
        {
            var Instructor = GetInstructorById(InstructorID);
            if (Instructor != null)
            {
                _instructor.Remove(Instructor);
            }
            else
            {
                throw new Exception("Instructor not found");
            }
        }

        public Instructor GetInstructorById(int InstructorID)
        {
            var Instructor = _instructor.FirstOrDefault(c => c.InstructorID == InstructorID);
            if (Instructor == null)
            {
                throw new Exception("Instructor not found");
            }
            return Instructor;
        }

        public IEnumerable<Instructor> GetInstructors()
        {
            return _instructor;
        }

        public Instructor updateInstructor(Instructor Instructor)
        {
            var existingInstructor = GetInstructorById(Instructor.InstructorID);
            if (existingInstructor != null)
            {
                existingInstructor.InstructorName = Instructor.InstructorName;
                existingInstructor.InstructorEmail = Instructor.InstructorEmail;
                existingInstructor.InstructorPhone = Instructor.InstructorPhone;
                existingInstructor.InstructorAddress = Instructor.InstructorAddress;
                existingInstructor.InstructorCity = Instructor.InstructorCity;
            }
            else
            {
                throw new Exception("Instructor not found");
            }
            return Instructor;
        }
    }
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class StudentService
{
    private readonly StudentDbContext _context;

    public StudentService()
    {
        var optionsBuilder = new DbContextOptionsBuilder<StudentDbContext>();
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Student_DB;Trusted_Connection=True;");
        _context = new StudentDbContext(optionsBuilder.Options);
    }

    // CREATE
    public void AddStudent(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
    }

    // READ ALL
    public List<Student> GetAllStudents()
    {
        return _context.Students.ToList();
    }

    // READ BY ID
    public Student GetStudentById(int id)
    {
        return _context.Students.FirstOrDefault(s => s.Id == id);
    }

    // UPDATE
    public void UpdateStudent(Student student)
    {
        _context.Students.Update(student);
        _context.SaveChanges();
    }

    // DELETE
    public void DeleteStudent(int id)
    {
        var student = _context.Students.Find(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }

    // DISPLAY
    public void Display(Student student)
    {
        Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
    }
}

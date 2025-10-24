public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age {  get; set; }
    public string Grade {  get; set; }

    public Student(string name,int age,string grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }
}
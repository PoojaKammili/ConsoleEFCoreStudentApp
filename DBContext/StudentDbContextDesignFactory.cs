using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

public class StudentDbContextDesignFactory : IDesignTimeDbContextFactory<StudentDbContext>
{
    public StudentDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appSettings.json", optional: false, reloadOnChange: true).Build();
        var optionbuilder = new DbContextOptionsBuilder<StudentDbContext>();
        optionbuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;DataBase=Student_DB;Trusted_Connection=true;");
        return new StudentDbContext(optionbuilder.Options);
    }
}
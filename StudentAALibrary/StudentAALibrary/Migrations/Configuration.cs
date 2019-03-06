namespace StudentAALibrary.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentAAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StudentAALibrary.StudentAAContext context)
        {
            Lecturer lecturer = new Lecturer() { FName = "L FirstName", LName = "L Last Name" };
            Student student = new Student() { FName = "S FirstName", LName = "S Last Name" };
            Module module = new Module() { ModuleName = "Module1" };
            Lecturer lecturer1 = new Lecturer() { FName = "L FirstName2", LName = "L Last Name2" };
            Assessment assessment = new Assessment() { AssessmentName = "A1" };
                

            context.Lecturers.Add(lecturer);
            context.Lecturers.Add(lecturer1);
            context.Students.Add(student);
            context.Modules.Add(module);
            

            context.SaveChanges();
          
        }
    }
}

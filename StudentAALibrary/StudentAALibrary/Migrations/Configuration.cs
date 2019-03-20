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
            Lecturer lecturer = new Lecturer() { FName = "James", LName = "Durning" };
            Lecturer lecturer2 = new Lecturer() { FName = "Jack", LName = "Adding" };
            Lecturer lecturer3 = new Lecturer() { FName = "Peter", LName = "Last" };
            Lecturer lecturer4 = new Lecturer() { FName = "Luke", LName = "Skywalker" };
            Student student = new Student() { FName = "Pierre", LName = "Jacob" };
            Student student2 = new Student() { FName = "Stephen", LName = "Langly" };
            Student student3 = new Student() { FName = "Paul", LName = "Neills" };
            Student student4 = new Student() { FName = "Jake", LName = "Stephenson" };
            Module module = new Module() { ModuleName = "Maths" };
            Module module2 = new Module() { ModuleName = "English" };
            Module module3 = new Module() { ModuleName = "French" };
            Module module4 = new Module() { ModuleName = "Geography" };
            // Lecturer lecturer1 = new Lecturer() { FName = "L FirstName2", LName = "L Last Name2" };
            Assessment assessment = new Assessment() { AssessmentName = "A1" };
            Assessment assessment2 = new Assessment() { AssessmentName = "A2" };
            Assessment assessment3 = new Assessment() { AssessmentName = "B1" };
            Assessment assessment4 = new Assessment() { AssessmentName = "B2" };
            Assessment assessment5 = new Assessment() { AssessmentName = "B3" };
            Assessment assessment6 = new Assessment() { AssessmentName = "C1" };
            Assessment assessment7 = new Assessment() { AssessmentName = "C2" };
            Assessment assessment8 = new Assessment() { AssessmentName = "C3" };
            Assessment assessment9 = new Assessment() { AssessmentName = "D1" };
            Assessment assessment10 = new Assessment() { AssessmentName = "D2" };
            Assessment assessment11 = new Assessment() { AssessmentName = "D3" };
            Assessment assessment12 = new Assessment() { AssessmentName = "E" };
            Assessment assessment13 = new Assessment() { AssessmentName = "F" };

            context.Lecturers.Add(lecturer);
            context.Lecturers.Add(lecturer2);
            context.Lecturers.Add(lecturer3);
            context.Students.Add(student);
            context.Modules.Add(module);


            context.SaveChanges();

        }
    }
}

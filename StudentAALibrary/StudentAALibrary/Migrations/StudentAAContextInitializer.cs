namespace StudentAALibrary.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class StudentAAContextInitializer : DropCreateDatabaseAlways<StudentAAContext>
    {
        public StudentAAContextInitializer()
        {
          
        }

        protected override void Seed(StudentAALibrary.StudentAAContext context)
        {
            Lecturer lecturer = new Lecturer() { FirstName = "James", LastName = "Durning" };
            Lecturer lecturer2 = new Lecturer() { FirstName = "Jack", LastName = "Adding" };
            Lecturer lecturer3 = new Lecturer() { FirstName = "Peter", LastName = "Last" };
            Lecturer lecturer4 = new Lecturer() { FirstName = "Luke", LastName = "Skywalker" };
            Student student = new Student() { FirstName = "Pierre", LastName = "Jacob" };
            Student student2 = new Student() { FirstName = "Stephen", LastName = "Langly" };
            Student student3 = new Student() { FirstName = "Paul", LastName = "Neills" };
            Student student4 = new Student() { FirstName = "Jake", LastName = "Stephenson" };
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
            context.Lecturers.Add(lecturer4);
            context.Students.Add(student);
            context.Students.Add(student2);
            context.Students.Add(student3);
            context.Students.Add(student4);
            context.Modules.Add(module);
            context.Modules.Add(module2);
            context.Modules.Add(module3);
            context.Modules.Add(module4);
            //context.Assessments.Add(assessment);


            context.SaveChanges();
            base.Seed(context);
        }
    }
}

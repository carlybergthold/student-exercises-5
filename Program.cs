﻿using System;
using StudentExercises5.Data;
using System.Collections.Generic;
using System.Linq;
using StudentExercises5.Models;

namespace StudentExercises5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Repository repository = new Repository();

            //get list of exercises from the database and prints it to the console
            List<Exercise> exercises = repository.GetExercises();
            repository.PrintExercises(exercises);

            Pause();

            // print exercises that use JS
            var JSExercises = exercises.Where(ex => ex.Language == "JavaScript").ToList();
            repository.PrintExercises(JSExercises);

            Pause();

            //add local instance of an exercise
            Exercise DoAllThings = new Exercise() { ExerciseName = "Do all the things", Language = "JavaScript" };
            //add that instance to the database
            repository.AddExerciseToDB(DoAllThings);

            exercises = repository.GetExercises();
            Console.Write("exercises after adding new");
            repository.PrintExercises(exercises);

            Pause();

            //get all instructors from database and print to console
            List<Instructor> instructors = repository.GetAllInstructorsWithCohorts();
            repository.PrintInstructors(instructors);

            Pause();

            //creating a new cohort, then a new instructor with that cohort included. adding to DB and printing to console
            Cohort Cohort32 = new Cohort() { Id = 3, CohortName = "Cohort 32"};
            Instructor instructor = new Instructor() {FirstName = "New", LastName = "Person", SlackHandle = "slackkk", Specialty = "none", Cohort = Cohort32 };
            repository.AddInstructorToDB(instructor);
            instructors = repository.GetAllInstructorsWithCohorts();
            Console.Write("instructors after adding");
            repository.PrintInstructors(instructors);

            Pause();

            // get list of students from database and prints to console
            var students = repository.GetStudents();
            repository.PrintStudentsWithExercises(students);

            Pause();

            //add existing exercise to an existing student
            var carly = students.Find(stud => stud.FirstName == "Carly");
            var exer = exercises.Find(foo => foo.ExerciseName == "Nutshell");
            repository.AssignExercise(exer, carly);
            repository.PrintStudentsWithExercises(students);

            Pause();

        }
        public static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}

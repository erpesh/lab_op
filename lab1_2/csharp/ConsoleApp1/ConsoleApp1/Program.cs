using System;
using System.IO;

namespace ConsoleApp1
{
    struct Faculty
    {
        public string facultie_name;
        public int num_of_students;
    };

    struct University
    {
        public string name;
        public string city;
        public int acr_lvl;
        public int num_of_faculties;
        public Faculty[] faculties;
    };

    internal class Program
    {
        static void createFile1(string path)
        {
            Console.WriteLine("Enter 'a' if you want to append to file and 'w' if you want rewrite: ");
            string answer = Console.ReadLine();
            FileMode fileMode;
            if (answer == "a")
            {
                fileMode = FileMode.Append;
            }else if (answer == "w")
            {
                fileMode = FileMode.Create;
            }
            else
            {
                Console.WriteLine("Wrong answer");
                createFile1(path);
                return;
            }
            BinaryWriter file = new BinaryWriter(File.Open(path, fileMode, FileAccess.Write));
            Console.WriteLine("Input number of universities:");
            int n = int.Parse(Console.ReadLine());
            var univs = new University[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"University number {i + 1}:");
                univs[i] = new University();
                Console.WriteLine("Set name:");
                univs[i].name = Console.ReadLine();
                Console.WriteLine("Set city:");
                univs[i].city = Console.ReadLine();
                Console.WriteLine("Set accreditation level: ");
                univs[i].acr_lvl = int.Parse(Console.ReadLine());
                Console.WriteLine("Set number of faculties: ");
                univs[i].num_of_faculties = int.Parse(Console.ReadLine());
                univs[i].faculties = new Faculty[univs[i].num_of_faculties];
                for (int j = 0; j < univs[i].num_of_faculties; j++)
                {
                    Console.WriteLine("Set faculty name:");
                    univs[i].faculties[j].facultie_name = Console.ReadLine();
                    Console.WriteLine("Set number of students:");
                    univs[i].faculties[j].num_of_students = int.Parse(Console.ReadLine());
                }
            }

            foreach (var univ in univs)
            {
                file.Write(univ.name);
                file.Write(univ.city);
                file.Write(univ.acr_lvl);
                file.Write(univ.num_of_faculties);
                foreach (var faculty in univ.faculties)
                {
                    file.Write(faculty.facultie_name);
                    file.Write(faculty.num_of_students);
                }
            }

            file.Close();
        }

        static void createFile2(string path1, string path2)
        {
            BinaryReader file1 = new BinaryReader(File.Open(path1, FileMode.Open, FileAccess.Read));
            BinaryWriter file2 = new BinaryWriter(File.Open(path2, FileMode.Create, FileAccess.Write));
            while (file1.PeekChar() != -1)
            {
                var univ = new University();
                univ.name = file1.ReadString();
                univ.city = file1.ReadString();
                univ.acr_lvl = file1.ReadInt32();
                univ.num_of_faculties = file1.ReadInt32();
                univ.faculties = new Faculty[univ.num_of_faculties];
                for (int i = 0; i < univ.num_of_faculties; i++)
                {
                    univ.faculties[i].facultie_name = file1.ReadString();
                    univ.faculties[i].num_of_students = file1.ReadInt32();
                }

                if (univ.acr_lvl == 3 || univ.acr_lvl == 4)
                {
                    file2.Write(univ.name);
                    file2.Write(univ.city);
                    file2.Write(univ.acr_lvl);
                }
            }

            file1.Close();
            file2.Close();
        }

        static void outputFile1(string path)
        {
            Console.WriteLine('\n' + path + ':');
            BinaryReader file = new BinaryReader(File.Open(path, FileMode.Open, FileAccess.Read));
            while (file.PeekChar() != -1)
            {
                Console.WriteLine("University: " + file.ReadString());
                Console.WriteLine("City: " + file.ReadString());
                Console.WriteLine("Accreditation level: " + file.ReadInt32());
                var numberOfFaculties = file.ReadInt32();
                Console.WriteLine("Number of faculties: " + numberOfFaculties);
                Console.WriteLine();
                for (int i = 0; i < numberOfFaculties; i++)
                {
                    Console.WriteLine("Faculty name: " + file.ReadString());
                    Console.WriteLine("Number of students: " + file.ReadInt32());
                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            file.Close();
        }

        static void outputFile2(string path)
        {
            Console.WriteLine(path + ':');
            BinaryReader file = new BinaryReader(File.Open(path, FileMode.Open, FileAccess.Read));
            while (file.PeekChar() != -1)
            {
                Console.WriteLine("University: " + file.ReadString());
                Console.WriteLine("City: " + file.ReadString());
                Console.WriteLine("Accreditation level: " + file.ReadInt32());
                Console.WriteLine();
            }

            file.Close();
        }

        private static Faculty findMaxFacultyInUniversity(University university)
        {
            var maxFaculty = new Faculty();
            var i = 0;
            foreach (var faculty in university.faculties)
            {
                if (i == 0 || faculty.num_of_students > maxFaculty.num_of_students)
                {
                    maxFaculty = faculty;
                }

                i++;
            }

            return maxFaculty;
        }

        static void findMaxFaculty(string path)
        {
            BinaryReader file = new BinaryReader(File.Open(path, FileMode.Open, FileAccess.Read));
            int counter = 0;
            var univWithMaxNumberOfStudents = new University();
            var univNumber = 0;
            Console.WriteLine("Enter city where you want to find the biggest faculty");
            string city = Console.ReadLine();
            Console.WriteLine();
            while (file.PeekChar() != -1)
            {
                var univ = new University();
                univ.name = file.ReadString();
                univ.city = file.ReadString();
                univ.acr_lvl = file.ReadInt32();
                univ.num_of_faculties = file.ReadInt32();
                univ.faculties = new Faculty[univ.num_of_faculties];
                for (int i = 0; i < univ.num_of_faculties; i++)
                {
                    univ.faculties[i].facultie_name = file.ReadString();
                    univ.faculties[i].num_of_students = file.ReadInt32();
                }

                var maxFacul = findMaxFacultyInUniversity(univ);
                if (univNumber == 0 ||
                    (findMaxFacultyInUniversity(univWithMaxNumberOfStudents).num_of_students < maxFacul.num_of_students
                     && univ.city == city))
                {
                    univWithMaxNumberOfStudents = univ;
                }

                univNumber++;
            }

            var maxFaculty = findMaxFacultyInUniversity(univWithMaxNumberOfStudents);
            Console.WriteLine(
                $"{maxFaculty.num_of_students} students in {maxFaculty.facultie_name} faculty in" +
                $" {univWithMaxNumberOfStudents.name} university");
            file.Close();
        }

        static void Main(string[] args)
        {
            string path1 = "firstFile.txt", path2 = "secondFile.txt";
            createFile1(path1);
            createFile2(path1, path2);
            findMaxFaculty(path1);
            outputFile1(path1);
            outputFile2(path2);
        }
    }
}
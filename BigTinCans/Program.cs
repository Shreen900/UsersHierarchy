using System;
using BigTinCans.Queries;
using BigTinCans.Commands;
using BigTinCans.Models;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace BigTinCans
{
    class Program
    {
        static void Main(string[] args)
        {
            //default input file is D:\input.txt + an option to change it once
            string inputFilePath = @"D:\input.txt";
            Console.Write("Defualt input file path is: " + inputFilePath + "... Would you like to change it? (y/n): ");
            if (Console.ReadLine().Equals("y"))
            {
                Console.Write("Please enter the new path: ");
                string newFile = Console.ReadLine();
                if (File.Exists(newFile))
                    inputFilePath = newFile;
                else Console.WriteLine("Failed to change default path");
            }

            if (File.Exists(inputFilePath))
            {
                bool moreRounds = true;
                while (moreRounds)
                {
                    Group group = new Group(inputFilePath);
                    Console.Write("Enter User Id: ");
                    if (int.TryParse(Console.ReadLine(), out int userNum))
                    {
                        Subordinates subordinates = new Subordinates(userNum, group.Roles, group.Users);
                        Console.WriteLine(JsonSerializer.Serialize(subordinates.getSubordinates(), new JsonSerializerOptions { WriteIndented = true }));
                        //File.WriteAllText(@"D:\UsersOutput.txt", JsonSerializer.Serialize(subordinates.getSubordinates(), new JsonSerializerOptions { WriteIndented = true }));    
                    }
                    else
                        Console.WriteLine("Invalid User Id");

                    Console.Write("One more go? (y/n): ");
                    moreRounds = Console.ReadLine().ToLower().Equals("y");
                }
            }
            else
            {
                Console.WriteLine("Input file does not exist!");
                Console.ReadLine();
            }

        }
    }
}

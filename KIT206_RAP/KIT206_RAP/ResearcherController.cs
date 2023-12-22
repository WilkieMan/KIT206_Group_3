﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    internal class ResearcherController
    {
        private static List<Researcher> MasterList = DBAdapter.FetchBasicResearcher();
        private List<Researcher> ModifiedList = MasterList;
        // private List<Researcher> tempList = new List<Researcher>();

        public void DisplayCurrentList()
        {
            foreach (Researcher researcher in ModifiedList)
            {
                Console.WriteLine(researcher.ToBasicName());
            }

            Console.WriteLine();
        }

        public void DisplayList(List<Researcher> list)
        {
            foreach (Researcher researcher in list)
            {
                Console.WriteLine(researcher.ToBasicName());
            }

            Console.WriteLine();
        }

        public void LoadResearchers()
        {
            
        }

        public List<Researcher> FilterByJobTitle(Position employmentLevel)
        {
            var temp = from Researcher r in MasterList
                       where r.EmploymentLevel == employmentLevel
                       select r;

            return new List<Researcher>(temp);
        }

        public List<Researcher> FilterByName()
        {

            Console.Write("Enter search text: ");
            string searchText = Console.ReadLine().ToLower();

            var searchResults = from Researcher r in MasterList
                                where r.GivenName.ToLower().Contains(searchText) || r.FamilyName.ToLower().Contains(searchText)
                                select r;

            return new List<Researcher>(searchResults);
        }

        public static List<Student> getSupervisions(int id)
        {
            var supervisions =  from Student s in MasterList
                                where s.SupervisorID == id
                                select s;

            return new List<Student>(supervisions);
        }

        public void getCummulativeCount()
        {

        }

    }

}
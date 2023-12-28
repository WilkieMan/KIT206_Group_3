﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    internal class DBAdapter
    {
        static string db = "kit206", server = "alacritas.cis.utas.edu.au", user = "kit206", pass = "kit206";
        static MySqlConnection conn;

        public DBAdapter()
        {
            conn = GetConnection(conn);
        }

        private static MySqlConnection GetConnection(MySqlConnection conn)
        {
            if (conn == null)
            {
                string connectionString = string.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }

            return conn;
        }

        public static Researcher FetchAllDetail(Researcher researcher)
        {
            conn = GetConnection(conn);
            MySqlDataReader rdr = null;
            int id = researcher.ID;
            string selection = "unit, campus, email, photo, utas_start, current_start ";

            try
            {
                conn.Open();

                if (researcher.EmploymentLevel == Position.EmploymentLevel.Student)
                {
                    researcher = researcher as Student;
                    selection = selection = "degree, supervisor_id ";
                }
                else
                {
                    researcher = researcher as Staff;
                    selection = "";
                }

                MySqlCommand cmd = new MySqlCommand("select " + selection + "from researcher where id=" + id.ToString(), conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //researcher.CampusName = rdr.GetString(1);
                    if (researcher is Student)
                    {

                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Conn failure.");
                System.Console.WriteLine(e.Message);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }
            }

            return researcher;
        }

        public static List<Researcher> FetchBasicResearcher()
        {
            conn = GetConnection(conn);
            List<Researcher> researchers = new List<Researcher>();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select title, given_name, family_name, level, id from researcher", conn);
                // MySqlCommand cmd = new MySqlCommand("select title, given_name, family_name from researcher", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    researchers.Add(new Researcher(MakeTitle(rdr.GetString(0)), rdr.GetString(1), rdr.GetString(2), MakeEmploymentLevel(rdr[3].ToString()), rdr.GetInt32(4)));
                    // System.Console.WriteLine(rdr.GetString(0) + " " + rdr.GetString(1) + " " + rdr.GetString(2));
                }
            }
            catch (Exception e) 
            {
                System.Console.WriteLine("Conn failure.");
                System.Console.WriteLine(e.Message);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }
            }

            return researchers;
        }

        private static Position.EmploymentLevel MakeEmploymentLevel(string employmentLevel)
        {
            switch (employmentLevel.ToLower())
            {
                case "a":
                    return Position.EmploymentLevel.A;

                case "b":
                    return Position.EmploymentLevel.B;

                case "c":
                    return Position.EmploymentLevel.C;

                case "d":
                    return Position.EmploymentLevel.D;

                case "e":
                    return Position.EmploymentLevel.E;

                default:
                    return Position.EmploymentLevel.Student;
            }

        }

        private static Researcher.Title MakeTitle(string title)
        {
            switch (title.ToLower())
            {
                case "dr":
                    return Researcher.Title.Dr;

                case "mr":
                    return Researcher.Title.Mr;

                case "ms":
                    return Researcher.Title.Ms;

                case "mrs":
                    return Researcher.Title.Mrs;

                case "prof":
                    return Researcher.Title.Prof;

                case "rev":
                    return Researcher.Title.Rev;

                default:
                    return Researcher.Title.Dr;
            }

        }

        private static Researcher.Campus MakeCampus(string campus)
        {
            switch (campus.ToLower())
            {
                case "cradle coast":
                    return Researcher.Campus.CradleCoast;

                case "launceston":
                    return Researcher.Campus.Launceston;

                default:
                    return Researcher.Campus.Hobart;
            }
        }
    }
}
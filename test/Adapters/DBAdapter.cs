using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;


namespace test
{
    internal class DBAdapter
    {
        static string db = "kit206", server = "alacritas.cis.utas.edu.au", user = "kit206", pass = "kit206"; // Information to connect to the MySQL database
        static MySqlConnection conn; // The connection to the database

        /// <summary>
        /// Creates the database adapter.
        /// </summary>
        public DBAdapter()
        {
            conn = GetConnection(conn);
        }

        /// <summary>
        /// Connects the MySQL connection to the database.
        /// </summary>
        /// <param name="conn">The connection to connect</param>
        /// <returns>
        /// The connection.
        /// </returns>
        private static MySqlConnection GetConnection(MySqlConnection conn)
        {
            if (conn == null)
            {
                string connectionString = string.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }

            return conn;
        }

        /// <summary>
        /// Gets all the detail available for a given researcher.
        /// </summary>
        /// <param name="researcher">The researcher that needs information filling out.</param>
        public static void FetchAllDetail(Researcher researcher)
        {
            conn = GetConnection(conn); // The connection
            MySqlDataReader rdr = null; // The database reader
            int id = researcher.ID; // The id of the researcher
            string selection = "unit, campus, email, photo, utas_start, current_start ";
            // Researcher researcher = new Researcher(oldResearcher.ID, oldResearcher.GivenName, oldResearcher.FamilyName, oldResearcher.NameTitle, oldResearcher.CampusName);

            try
            {
                conn.Open();

                // Changes the SQL call based on the type of information that is required and turns the
                // researcher object into either a Student or Staff object
                if (researcher.EmploymentLevel == Position.EmploymentLevel.Student)
                {
                    selection += "degree, supervisor_id ";
                }
                else
                {
                    selection += "";
                }

                // System.Console.WriteLine("select " + selection + "from researcher where id = " + id);
                MySqlCommand cmd = new MySqlCommand("select " + selection + "from researcher where id = " + id, conn); // A command to get the basic information from the database

                rdr = cmd.ExecuteReader();
                // System.Console.WriteLine("Reader is reading.");

                while (rdr.Read())
                {
                    // Takes the information from the database and assigns it to the individual parameters
                    // System.Console.WriteLine("Basic information read starting.");
                    researcher.Unit = rdr.GetString(0);
                    // System.Console.WriteLine("1");
                    researcher.CampusName = MakeCampus(rdr.GetString(1));
                    researcher.Email = rdr.GetString(2);
                    researcher.Photo = rdr.GetString(3);
                    researcher.InstitutionStart = DateTime.Parse(rdr.GetString(4));
                    researcher.CurrentStart = DateTime.Parse(rdr.GetString(5));
                    // System.Console.WriteLine("Basic information read.");

                    // If the researcher is a student it gets the Degree that they are doing and
                    // there supervisors ID and assigns them to the researcher
                    if (researcher is Student)
                    {
                        // System.Console.WriteLine("Researcher is student.");
                        Student student = researcher as Student;
                        student.Degree = rdr.GetString(6);
                        student.SupervisorID = rdr.GetInt32(7);
                    }
                    else
                    {
                        // System.Console.WriteLine("Researcher is staff.");
                        // List<Position> pastJob = new List<Position>();
                        Staff staff = researcher as Staff;
                        MySqlCommand positionCmd = new MySqlCommand("select level, start, end from position where id=" + id, conn); // A command to get all previous position for a researcher

                        rdr.Close();
                        rdr = positionCmd.ExecuteReader();

                        // System.Console.WriteLine("Making past positions.");
                        while (rdr.Read())
                        {
                            // System.Console.WriteLine(rdr.GetString(1));
                            DateTime dateTime = DateTime.Now;

                            // System.Console.WriteLine(rdr[2]);
                            if (rdr[2].ToString().Length > 0)
                            {
                                // System.Console.WriteLine("In if loop.");
                                dateTime = DateTime.Parse(rdr.GetString(2));
                            }
                            // System.Console.WriteLine("DateTime made.");
                            researcher.AddPosition(new Position(id, MakeEmploymentLevel(rdr.GetString(0)), DateTime.Parse(rdr.GetString(1)), dateTime));
                            // System.Console.WriteLine("Made position.");
                        }
                    }
                }

                rdr.Close();

                cmd = new MySqlCommand("select doi from researcher_publication where researcher_id=" + id, conn); // A command to get the unique dois to query against.
                // System.Console.WriteLine("Reading publications.");

                rdr = cmd.ExecuteReader();
                List<String> publications = new List<string>();
                List<Publication> curPublications = new List<Publication>();

                while (rdr.Read())
                {
                    // System.Console.WriteLine(rdr.GetString(0));
                    publications.Add(rdr.GetString(0));
                }

                // System.Console.WriteLine("Read publications.");
                rdr.Close();

                foreach (String p in publications)
                {
                    cmd = new MySqlCommand("select doi, title, ranking, authors, year, type, cite_as, available from publication where doi like '" + p + "'", conn); // Gets the information about the publications using the doi as the identifying aspect
                    // System.Console.WriteLine("select doi, title, ranking, authors, year, type, cite_as, available from publication where doi like '" + p + "'");

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        // System.Console.WriteLine("While.");
                        // System.Console.WriteLine(rdr.GetString(1));
                        // System.Console.WriteLine("Read data.");
                        researcher.AddPublication(new Publication(rdr.GetString(1), rdr.GetString(0), MakeType(rdr.GetString(5)), rdr.GetInt32(4), DateTime.Parse(rdr.GetString(7)), MakeRanking(rdr.GetString(2)), new List<String>(rdr.GetString(3).Split(',')), rdr.GetString(6)));
                    }

                    rdr.Close();
                }
                // System.Console.WriteLine("Finished fetching publications.\n" + curPublications.Count());
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
                // System.Console.WriteLine("Finished finalisation.");
            }
            // System.Console.WriteLine(researcher.ID + " " + researcher.GivenName + " " + researcher.FamilyName);
            // return researcher;
        }

        /// <summary>
        /// Gets the basic information of all the researchers 
        /// </summary>
        /// <returns>
        /// A list of all the researches in the database.
        /// </returns>
        public static List<Researcher> FetchBasicResearcher()
        {
            conn = GetConnection(conn);
            List<Researcher> researchers = new List<Researcher>();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select title, given_name, family_name, level, id from researcher", conn); // A command to get the query-able information for a researcher
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

        /// <summary>
        /// Turns a string into an enumerated employment level.
        /// </summary>
        /// <param name="employmentLevel">The string version of the employment level.</param>
        /// <returns>
        /// The enumerated employment level.
        /// </returns>
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

        /// <summary>
        /// Turns a string into an enumerated honorific.
        /// </summary>
        /// <param name="title">The string honorific.</param>
        /// <returns>
        /// The enumerated honorific
        /// </returns>
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

        /// <summary>
        /// Turns a string campus location into an enumerated campus location.
        /// </summary>
        /// <param name="campus">The string campus location.</param>
        /// <returns>
        /// The enumerated campus location.
        /// </returns>
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

        /// <summary>
        /// Turns a string publication type into an enumerated publication type.
        /// </summary>
        /// <param name="type">The string publication type.</param>
        /// <returns>
        /// The enumerated publication type.
        /// </returns>
        private static Publication.OutputType MakeType(string type)
        {
            switch (type.ToLower())
            {
                case "conference":
                    return Publication.OutputType.Conference;

                case "journal":
                    return Publication.OutputType.Journal;

                default:
                    return Publication.OutputType.Other;
            }
        }

        /// <summary>
        /// Turns a string journal ranking into an enumerated journal ranking.
        /// </summary>
        /// <param name="ranking">The string journal ranking.</param>
        /// <returns>
        /// The enumerated journal ranking.
        /// </returns>
        private static Publication.JournalRanking MakeRanking(string ranking)
        {
            switch (ranking.ToLower())
            {
                case "q1":
                    return Publication.JournalRanking.Q1;

                case "q2":
                    return Publication.JournalRanking.Q2;

                case "q3":
                    return Publication.JournalRanking.Q3;

                default:
                    return Publication.JournalRanking.Q4;
            }
        }
    }
}

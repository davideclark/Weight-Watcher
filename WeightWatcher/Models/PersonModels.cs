using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Mvc;
using System.Web.Security;
namespace MvcApplication1.Models
{
    /// <summary>
    /// Used to maintain a persons details such as height, sex, target weight target BMI etc
    /// </summary>
    public class PersonModel
    {
                public void Details(string userID)
                {
                    //List<Person> 
                   // return null;
                }
                public void UpdatePerson(string userId)
                {
                }
        
        }

    class Person
    {
        public bool metric;
        public double targetweightKg;
        public double heightCm;
        public bool male;
        public int weightPerPage;
    }
}
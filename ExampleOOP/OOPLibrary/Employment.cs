using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLibrary
{
    //Access Modifier - Internal, Public, Private
    // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
    public class Employment
    {
        #region Data Members
        //fields, attributes, what holds the data
        //data is valuable, so we restrict access to our data
        //access modifier (private)
        private string _title = string.Empty;
        private double _years;
        private SupervisoryLevel _supervisoryLevel;
        #endregion

        #region Properties
        //portal to the data
        //where we have our public data access
        //Each property is associated with one piece of data
        //written like methods, but has no parameters

        //Two main parameter types are auto-implemented and Fully Implemented 
        //Auto-Implemented: Has no data member and just has get and set, no business rules
        //Fully Implemented: Have a explicit get and set can contain Business Rules to check the data before storing it. 
        public string Title
        {
            get { return _title; }
            set
            {
                //Business Rule: Title cannot be empty
                    //Validate the incoming coming
                //All properties have one "paramter" called value that is the data the program is trying to set for the property.

                // Empty = ""
                // Whitespace = "               "
                // Null = null
                if(string.IsNullOrWhiteSpace(value))
                {
                    //We won't write any data to our data member, we will throw an error
                    throw new ArgumentNullException("Title must be provided.");
                }

                _title = value.Trim();
            }
        }

        public double Years
        {
            get { return _years; }
            set
            {
                //Business Rule: Must be a positive number
                if(value < 0.0)
                {
                    throw new ArgumentException($"Years {value} is less than 0. Years must be positive.");
                }
                _years = value;
            }
        }

        
        //Can change to a private set which restricts changes to the property to methods or constructors within this class.
        public SupervisoryLevel Level
        {
            get { return _supervisoryLevel; }
            private set
            {
                //Validate that an enum value is an acceptable integer value.
                    // syntax: Enum.IsDefined(typeof(xxxx), value)
                    // xxxx = EnumType
                if(!Enum.IsDefined(typeof(SupervisoryLevel), value))
                {
                    throw new ArgumentException($"Supervisory level {value} is invalid.");
                }
                _supervisoryLevel = value;
            }
        }

        //auto-implemented
            //Only the property, just get and set, no additional values needed!
            //Do not make a data member for an auto-implemented property!**
        public DateTime StartDate { get; set; }
        #endregion

        #region Constructors
        // greedy constructor
        // greedy is a constructor that accepts a parameter list of value
        //if you want to default a value you must put the parameter at the end. You can have more than one parameter with a default value!
            //Default allows the users to provide a value or not. If the user does not provide a value, then the default value is used.
        public Employment(string title, SupervisoryLevel level, DateTime startDate, double years = 0.0)
        {
            //We always set to the Properties, do not set ever directly to a data member (never ever ever)
            //We wrote business logic, don't ignore it by not using the property, that makes kitten's cry.
            Title = title;
            Level = level;
            if(startDate > DateTime.Today)
            {
                throw new ArgumentException($"The start date {startDate} is in the future.");
            }
            StartDate = startDate;
            

            //if the user does not provide a year, and it gets the default 0.0, then we want to calculate the years of employment.
            if(years == 0.0)
            {
                TimeSpan days = DateTime.Today - startDate;
                Years = Math.Round((days.Days / 365.25), 1);
                
            }
            else
            {
                Years = years;
            }
        }
        //Default Constructor, no parameters. We are just setting the values to default values of our choice.
        public Employment()
        {
            Title = "unknown";
            Level = SupervisoryLevel.TeamMember;
            StartDate = DateTime.Today;
            Years = 0.0;
        }
        #endregion

        #region Methods
        //Methods can change our properties as well, again do not assign data from a method to a data member
        public void SetEmploymentResponsibilityLevel(SupervisoryLevel level)
        {
            Level = level;
        }

        public void CorrectStartDate(DateTime startDate)
        {
            //Since StartDate is Auto-Implemented we need to have a method to check the value before setting it.
            //Without this we can't throw any exceptions and any value accepted by C# is valid.
            if(startDate > DateTime.Today)
            {
                throw new ArgumentException($"The start date {startDate} is in the future.");
            }
            StartDate = startDate;
            TimeSpan span = DateTime.Today - startDate;
            Years = Math.Round((span.Days / 365.25), 1);
        }
        #endregion
    }
}

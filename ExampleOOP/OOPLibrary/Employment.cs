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

        //auto-implemented
            //Only the property, just get and set, no additional values needed!
            //Do not make a data member for an auto-implemented property!**
        public SupervisoryLevel Level { get; set; }

        //Will fix later - fully implement
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
            Years = years;
            Level = level;
            StartDate = startDate;
        }

        public Employment()
        {

        }
        #endregion

        #region Methods
        #endregion
    }
}

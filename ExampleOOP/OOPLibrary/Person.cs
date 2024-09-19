namespace OOPLibrary
{
    public class Person
    {
        #region Data Members
        private string _firstName;
        private string _lastName;
        #endregion

        #region Properties

        //Fully Implemented Properties
        public string FirstName 
        { 
            get { return _firstName; } 
            set { _firstName = value; } 
        }
        public string LastName 
        { 
            get { return _lastName; } 
            set { _lastName = value; } 
        }

        //Auto-Implemented Properties
        //Collection of Instance of the Employment Class
        //Set the lists to a default empty list in order to avoid null reference errors.
        public List<Employment> Employments { get; set; } = []; //[] = new List<Employment>()

        //single reference to the ResidentAddress class
        public ResidentAddress ResidentAddress { get; set; }

        //Read-Only Property
        public string FullName => $"{FirstName} {LastName}";

        #endregion

        #region Constructor
        //Default Constructor
        public Person()
        {
            FirstName = "Unknown";
            LastName = "Unknown";
        }
        #endregion
    }
}

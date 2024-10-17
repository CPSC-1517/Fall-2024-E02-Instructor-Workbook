using OOPLibrary;

namespace OOPWebApp.Components.Pages.Examples
{

    public partial class DataEntry
    {
        private string feedback = string.Empty;

        //Creating variables to store the form information
        //Match what is in the class for datatypes
        private string empTitle = string.Empty;
        private DateTime empStartDate = DateTime.Today;
        private SupervisoryLevel empLevel;
        private double empYears = 0.0;
    }
}

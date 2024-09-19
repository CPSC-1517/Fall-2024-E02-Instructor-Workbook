using FluentAssertions;
using OOPLibrary;

namespace UnitTestingForSystem
{
    public class Person_Should
    {
        #region Valid Data Tests
        //Fact: one test, test body (what makes up the test) contains all the setup,
        //execution and evaluation of the excution in a single test, Fact Tests run only ONCE
        //Theory: allow for multiple executions of the same test.
        //Takes in different inputs 
        // To specify our input the Test must have parameters and the data supplied to the parameters through 
        //[InlineData(...)]

        //Test our Constructor(s)
        [Fact]
        public void Create_Instance_Using_Default_Constructor()
        {
            //Exceptions
            string expectedFirstName = "Unknown";
            string expectedLastName = "Unknown";

            //Action
            //sut - Subject Under Test
            Person sut = new(); //new() = new Person()

            //Assertions (evaluation of the result of the action)
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.ResidentAddress.Should().BeNull();
            sut.Employments.Count.Should().Be(0);
            sut.FullName.Should().Be($"{expectedFirstName} {expectedLastName}");
        }
        #endregion

        #region Invalid Data Test
        #endregion
    }
}

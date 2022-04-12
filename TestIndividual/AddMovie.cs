using Xunit;
using IndividualSeeSharpers.Areas.Identity;
using IndividualSeeSharpers.Data;
using IndividualSeeSharpers.Models;
using Moq;


namespace TestIndividual
{
    public class MovieTest
    {
        [Fact]
        public void Add_NewMovie()
        {
            // Arrange
            var movie = new Movie();

            // Act
            movie.Title = "Harry Snotter";

            // Assert
            Assert.Equal("Harry Snotter", movie.Title);

           
        }

    }
}
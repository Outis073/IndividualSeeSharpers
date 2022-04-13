using IndividualSeeSharpers.Controllers;
using IndividualSeeSharpers.Models;
using IndividualSeeSharpers.Services;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace TestIndividual;

public class MailTest 
{

        private readonly Mock<IMailService> _mockMailService = new Mock<IMailService>();
        private readonly Mock<SeeSharpersContext> _mockContext = new Mock<SeeSharpersContext>();

        [Fact]
        public void TestMethod1()
        {
            // arrange
            var mailController = new MailController(_mockMailService.Object, _mockContext.Object);
            var mailRequest = new MailRequest();

            // act
            mailController.MailNewsletter(mailRequest);

            // assert    
        
            _mockMailService.Verify(v => v.SendEmailAsync(mailRequest), Times.AtLeastOnce);

        }
    
}
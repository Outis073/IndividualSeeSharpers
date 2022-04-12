using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IndividualSeeSharpers.Areas.Identity.Pages.Account;
using IndividualSeeSharpers.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Org.BouncyCastle.Security;
using Xunit;

namespace TestIndividual
{
    public class AddUserTest
    {

        [Fact]
        public void Add_NewUser()
        {
            //Arrange

            var user = new ApplicationUser();

            //Act

            user.FirstName = "Jan";
            user.LastName = "Jansen";

            //Assert

            Assert.Equal("Jan", user.FirstName);
            Assert.Equal("Jansen", user.LastName);
        }
    }
}
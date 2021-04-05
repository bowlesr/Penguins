using Xunit;
using Penguins_Front_End.Models.Entities;
using System.Collections.Generic;

namespace PenguinsTest
{
    public class ApplicationUserTest
    {
        //ACT
        ApplicationUser user = new ApplicationUser();
        
        [Fact]
        public void UserNameTest()
        {
            //ARRANGE

            string fName = "Zachary";
            string lName = "Carrier";

            user.FirstName = fName;
            user.LastName = lName;

            string name1 = user.FirstName;
            string name2 = user.LastName;

            //ASSERT

            Assert.Equal(fName, name1);
            Assert.Equal(lName, name2);
        }

        [Fact]
        public void CollectionTest()
        {
            //ARRANGE

            List<string> list = new List<string>();
            list = (List<string>)user.Roles;
            list.Add("Admin");
            list.Add("User");

            //ASSERT
           
            Assert.Contains("Admin", list);
            Assert.Contains("User", list);

        }

        [Fact]
        public void RoleTest()
        {
            List<string> list = new List<string>();
            list = (List<string>)user.Roles;
            
            Assert.NotNull(list);

        }
    }
}
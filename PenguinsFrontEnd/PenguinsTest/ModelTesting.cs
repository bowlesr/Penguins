using System;
using Xunit;
using Penguins_Front_End.Models.Entities;
using System.Collections.Generic;

namespace PenguinsTest
{
    ///  This class has the tests for the Application User Entity
    ///  Using Xunit 
    ///  Author: Zachary Carrier
    public class ApplicationUserTest
    {
        //ACT
        ApplicationUser user = new ApplicationUser();  //Create an object to access the class

        /// Test that ensure the variable of first and last names are working
        /// 
        /// Author: Zachary Carrier
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

        /// Test that ensures the list will hold the roles
        /// 
        /// Author: Zachary Carrier
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

        /// Test that checks to see if the list of user roles is not null
        /// 
        /// Author: Zachary Carrier
        [Fact]
        public void RoleTest()
        {
            List<string> list = new List<string>();
            list = (List<string>)user.Roles;

            Assert.NotNull(list);

        }
    }
}
using System;
using Xunit;
using Penguins_Front_End.Models.Entities;
using System.Collections.Generic;

namespace PenguinsTest
{
    /// Class that holds the tests for the Application User Entity
    /// Using Xunit
    /// Author: Zachary Carrier
    public class ApplicationUserTest
    {
        //ACT
        ApplicationUser user = new ApplicationUser();   //Creates an object of Application User to
                                                        //access the class

        /// <summary>
        /// 
        /// Test to ensure the first and last name is holding data and matches what is stored
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// Test to ensure the list will hold the types of roles
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// Test to check if the list of user roles is null
        /// 
        /// </summary>
        [Fact]
        public void RoleTest()
        {
            List<string> list = new List<string>();
            list = (List<string>)user.Roles;

            Assert.NotNull(list);

        }
    }
}
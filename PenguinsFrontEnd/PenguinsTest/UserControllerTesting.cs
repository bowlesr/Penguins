using Xunit;
using Penguins_Front_End.Controllers;

namespace PenguinsTest
{
    ///  This class has the tests for the User Controller
    ///  Using Xunit 
    ///  Author: Zachary Carrier
    public class UserControllerTest
    {
        /// Test to check if Chart Data is null
        /// 
        /// Author: Zachary Carrier
        [Fact]
        public void IsChartDataNull()
        {
            //ARRANGE
            var controller = new UserController();

            //ACT
            var result = controller.ChartData();

            //ASSERT
            Assert.NotNull(result);
        }

        /// Test to check if User List is null
        /// 
        /// Author: Zachary Carrier
        [Fact]
        public void IsUserListNull()
        {
            //ARRANGE
            var controller = new UserController();

            //ACT
            var result = controller.UserList();

            //ASSERT
            Assert.NotNull(result);
        }

        /// Test to check if Assign Role is null
        /// 
        /// Author: Zachary Carrier
        [Fact]
        public void IsAssignRoleNull()
        {
            //ARRANGE
            var controller = new UserController();

            //ACT
            var result = controller.AssignRoles();

            //ASSERT
            Assert.NotNull(result);
        }
    }
}
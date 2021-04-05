using Xunit;
using Penguins_Front_End.Controllers;

namespace PenguinsTest
{
    public class UserControllerTest
    {

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
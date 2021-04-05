using Xunit;
using Penguins_Front_End.Controllers;

namespace PenguinsTest
{
    public class UserControllerTest
    {
        [Fact]
        public void IsIndexNull()
        {
            //ARRANGE
            var controller = new UserController();

            //ACT
            var result = controller.Index();

            //ASSERT
            Assert.NotNull(result);

        }

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
        public void IsCreateNull()
        {
            //ARRANGE
            var controller = new UserController();

            //ACT
            var result = controller.Create();

            //ASSERT
            Assert.NotNull(result);
        }

        [Fact]
        public void IsDeleteNull()
        {
            //ARRANGE
            var controller = new UserController();

            //ACT
            var result = controller.Delete(1);

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
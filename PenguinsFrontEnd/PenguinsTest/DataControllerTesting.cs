using Xunit;
using Penguins_Front_End.Controllers;

namespace PenguinsTest
{
    public class DataControllerTest
    {
        [Fact]
        public void IsIndexNull()
        {
            //ARRANGE

            var controller = new DataController();

            //ACT

            var result = controller.Index();

            //ASSERT

            Assert.NotNull(result);

        }

        [Fact]
        public void IsCreateNull()
        {
            //ARRANGE

            var controller = new DataController();

            //ACT

            var result = controller.Create();

            //ASSERT

            Assert.NotNull(result);
        }

        [Fact]
        public void IsDeleteNull()
        {
            //ARRANGE

            var controller = new DataController();

            //ACT

            var result = controller.Delete(1);

            //ASSERT

            Assert.NotNull(result);
        }

       
    }
}
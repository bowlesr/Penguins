using Xunit;
using Penguins_Front_End.Controllers;

namespace PenguinsTest
{
    /// Class that holds the tests for the Data Controller
    /// Using Xunit
    /// Author: Zachary Carrier
    public class DataControllerTest
    {
        /// <summary>
        /// 
        /// Test to check if Index view is null
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// Test to check if Create view is null
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// Test to check if Delete view is null
        /// 
        /// </summary>
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
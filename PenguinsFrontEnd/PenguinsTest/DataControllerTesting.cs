using Xunit;
using Penguins_Front_End.Controllers;

namespace PenguinsTest
{
    ///  This class has the tests for the Data Controller
    ///  Using Xunit 
    ///  Author: Zachary Carrier
    public class DataControllerTest
    {
        /// Test that checks to see if Index view is null
        /// 
        /// Author: Zachary Carrier
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

        /// Test that checks to see if Create view is null
        /// 
        /// Author: Zachary Carrier
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

        /// Test that checks to see if Delete view is null
        /// 
        /// Author: Zachary Carrier
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
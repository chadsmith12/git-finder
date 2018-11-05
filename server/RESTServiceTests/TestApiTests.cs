using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using RESTServiceTests.TestApi;

namespace RESTServiceTests
{
    [TestClass]
    public class TestApiTests
    {
        [TestMethod]
        public async Task GetTodoItemTest()
        {
            var testApiService = new TestApiService();
            var todoItem = await testApiService.GetTodo();

            Assert.IsNotNull(todoItem.Result);
        }
    }
}

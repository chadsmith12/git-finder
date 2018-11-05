using System;
using System.Threading.Tasks;
using RESTService;
using RESTService.ResponseModels;

namespace RESTServiceTests.TestApi
{
    public class TestApiService : BaseHttpService
    {
        public async Task<Response<TestTodoItem>> GetTodo()
        {
            var uri = new Uri("https://jsonplaceholder.typicode.com/todos/1");

            return await SendRequestAsync<TestTodoItem, TestTodoItem>(uri);
        }
    }
}

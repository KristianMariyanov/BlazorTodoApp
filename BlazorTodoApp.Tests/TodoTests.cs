using Bunit;
using Xunit;
using BlazorTodoApp.Shared;
using BlazorTodoApp.Models;
using System.Collections.Generic;

namespace BlazorTodoApp.Tests
{
    public class TodoTests
    {
        [Fact]
        public void TodoListComponentWithTodosParameter_ShouldRenderCorrectHTML()
        {
            // Arrange
            using var ctx = new TestContext();

            // Act
            var cut = ctx.RenderComponent<TodoList>(
                ComponentParameter.CreateParameter("Todos", new List<TodoItem>() { new TodoItem { Title = "Todo1" } }));

            // Assert
            cut.MarkupMatches(@"<ul class=""list-unstyled"">
                  <li>
 <input id=""todo-0"" type=""checkbox"" >
        <label  for=""todo-0"" style=""font-size: 20px"">Todo1</label>
                    <button class=""btn btn-sm btn-link"">Edit</button>
                  </li>
                </ul>");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace todo_rest_api.Controllers.List
{
    [Route("list")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private TodoItemService todoItemsService;
        public TodoItemController(TodoItemService service)
        {
            this.todoItemsService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetTodoItems()
        {
            return todoItemsService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoItem(int id)
        {
            return todoItemsService.GetById(id);
        }

        [HttpPost]
        public ActionResult<TodoItem> CreateTodoItem(TodoItem task)
        {
            TodoItem createdItem = todoItemsService.Create(task);
            return Created($"task{createdItem.Id}", createdItem);
        }

        [HttpPut("{id}")]
        public ActionResult PutTodoTask(int id, TodoItem task)
        {
            return todoItemsService.PutTask(id, task) ? StatusCode(204) : StatusCode(404);
        }

        [HttpPatch("{id}")]
        public ActionResult PatchTodoTask(int id, TodoItem task)
        {
            return todoItemsService.PatchTask(id, task) ? StatusCode(204) : StatusCode(404);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTodoTask(int id)
        {
            return todoItemsService.Delete(id) ? StatusCode(204) : StatusCode(404);
        }

        // [Http]
        // [HttpPat]
        // [HttpPatch("{id1}/tmp/{id2}")]
    }
}
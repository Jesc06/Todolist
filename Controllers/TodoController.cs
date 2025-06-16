using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo_List_App._DbContext;
using Todo_List_App.Models;

namespace Todo_List_App.Controllers
{
    public class TodoController : Controller
    {
        public TodoTable _TodoTable;

        public TodoController(TodoTable todoTable)
        {
            _TodoTable = todoTable;
        } 


        public IActionResult TodoList()
        {
            TodoNewModel DataTable = new TodoNewModel
            {
                listTodoModel = _TodoTable.TodoData.ToList()
            };
            return View(DataTable);
        }


        public IActionResult Edit(int GetId )
        {
            TodoNewModel model = new TodoNewModel
            {
                listTodoModel = _TodoTable.TodoData.ToList()
            };
            model.TodoModel = _TodoTable.TodoData.Find(GetId);
            return View("TodoList", model);
        }
   

        [HttpPost]
        public ActionResult InsertTask(TodoNewModel table)
        {

            if(table.TodoModel.Id == 0)
            {
                _TodoTable.TodoData.Add(table.TodoModel);
            }
            else
            {
                //update if have id select or clicked the edit from table
                Todo update = _TodoTable.TodoData.Find(table.TodoModel.Id);
                if(update != null)
                {
                    update.Task = table.TodoModel.Task;
                }
            }
            _TodoTable.SaveChanges();
            return RedirectToAction("TodoList");
        }



        [HttpPost]
        public IActionResult Delete(int id)
        {
            var data = _TodoTable.TodoData.Find(id);
            if(data == null)
            {
                return NotFound();
            }
          
            _TodoTable.TodoData.Remove(data);
            _TodoTable.SaveChanges();
            return RedirectToAction("TodoList");
        }



    }
}

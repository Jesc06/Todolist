namespace Todo_List_App.Models
{
    public class TodoNewModel
    {
        public Todo? TodoModel { get; set; } = new Todo();
        public  List<Todo> listTodoModel { get; set; } = new List<Todo>();
    }
}

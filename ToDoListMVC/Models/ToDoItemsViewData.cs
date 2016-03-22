using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListMVC.Models
{
    public class ToDoItemsViewData
    {
        public IEnumerable<ToDoItem> ToDoItems { get; set; }

        public ToDoItem ToDoItem()
        {
            return new ToDoItem();
        }


    }
}

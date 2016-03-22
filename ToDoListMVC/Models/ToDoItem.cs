using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ToDoListMVC.Models
{
    public class ToDoItem
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter a thing to do...")]
        public string TaskDescription { get; set; }

        public bool Checked { get; set; }  
        public JsonResult UpdateCheckBox(JsonResult data)
        {
            return data;
        }   

        public IList<ToDoItem> ToDoItems { get; set; }
    }
}

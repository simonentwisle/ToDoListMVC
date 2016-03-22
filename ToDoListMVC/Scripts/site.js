$(document).ready(function() {
    //change task tick box
    $("#tasklist :checkbox").click(function () {
        var toDoItem = {
            ID: this.id,
            TaskDescription: this.getAttribute("taskDescription"),
            Checked: this.checked
        }; 

        $.ajax({
            url: "/Home/UpdateCheckBox",
            content: "application/json; charset=utf-8",
            dataType: "json",
            data: toDoItem,
            type: "POST"
        });
      
    });

});
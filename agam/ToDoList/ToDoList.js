let ToDoInput = document.getElementById("ToDoInput");
let AddToDoButton = document.getElementById("AddToDo");
let ToDoList = document.getElementById("ToDoList");


ToDoList.addEventListener("click",deleteToDo);


//add a todo by perssing enter
ToDoInput.addEventListener("keydown",(e)=>
{
    if(e.code === "Enter" && checkInputValidation())
    {
        addNewToDo()
    }

});

function checkInputValidation()
{

    if(ToDoInput.value.length == 0)
    {
        alert("Invalid Input!")
        return false
    }
    return true
}

function addToDoClick()
{
    if(checkInputValidation())
    {
        addNewToDo()
    }
}

function addNewToDo()
{
    //create todo div
    var newToDodiv = document.createElement('div');
    newToDodiv.classList.add("todo");
    
    //create check box for the to do
    var newCheckBox = document.createElement("input");
    newCheckBox.type = "checkbox";
    newCheckBox.classList = "toDoCheckBox";
    newCheckBox.id = "ToDocheckBox";
    newCheckBox.addEventListener('change', ToDoChecked)
    newToDodiv.appendChild(newCheckBox);
  
    //create the to do item
    var newToDo = document.createElement("input");
    newToDo.classList.add("ToDo-input");
    newToDo.value = ToDoInput.value;
    //newToDo.readOnly  = true;
    //newToDo.addEventListener("click",editToDo);
    newToDodiv.appendChild(newToDo);
      
    //add delete button
    var newDeleteButton = document.createElement("button");
    newDeleteButton.innerText = "Delete";
    newDeleteButton.classList.add("delete-btn");
    newToDodiv.appendChild(newDeleteButton)

    // add the new todo div
    ToDoList.appendChild(newToDodiv);
    
    //clear text input
    ToDoInput.value = "";
    
}

//edit to do when clicked
function editToDo(e)
{
    console.log("here")
    console.log(e.target)
    




}





//delete the to do
function deleteToDo(elementToDelete)
{
    const item = elementToDelete.target;
    if(item.classList[0] === "delete-btn") //make sure they press on the right button
    {
        var ToDoDelete = item.parentElement; //delete the div we created
        ToDoDelete.remove();
    }
    
}


function ToDoChecked(checkedElement)
{
    const item = checkedElement.target
    if(item.classList[0] === "toDoCheckBox" && item.checked) //check if the item is checkbox and it is checked
    {
        // the created element is always at the bottom so i delete and create a new one to make at the bottom.
        var TempToDoDiv = item.parentElement;
        item.parentElement.remove();
        ToDoList.appendChild(TempToDoDiv);
    }

}


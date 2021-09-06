const uri = '/api/task';
let tasks = [];
var selectStatus = document.getElementById("status");
var arrayStatus = ["","Создана","В работе","Завершена"]
for (var i = 1; i < arrayStatus.length; i++) {
    var option = document.createElement("option");
    option.setAttribute("value", i);
    option.text = arrayStatus[i];
    selectStatus.appendChild(option);
}

function getItems() {
    var getI = uri+'/getall';
    fetch(getI)
        .then(response => response.json())
        .then(data => _displayItems(data["tasks"]))
        .catch(error => console.error('Unable to get items.', error));
}



function addItem() {
    const addNameTextbox = document.getElementById('add-name');
    const addDescriptionTextbox = document.getElementById('add-description');
    const addStatusOption= document.getElementById('status');
    if(addDescriptionTextbox===undefined || addDescriptionTextbox===null||addNameTextbox===undefined||addNameTextbox===null) {
        helpadd();
        addItem();
    }
    const item = {
        "Name":addNameTextbox.value,
        "Description":addDescriptionTextbox.value.trim(),
        "Status":addStatusOption.value
    
    };
    
    var  addI = uri + '/create';
    fetch(addI, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            getItems();
            addNameTextbox.value = '';
            addDescriptionTextbox.value='';
        })
        .catch(error => console.error('Unable to add item.', error));
}
function checkbutton(){
    var inp = document.getElementsByName('radioButton');
    for (var i = 0; i < inp.length; i++) {
        if (inp[i].type == "radio" && inp[i].checked) {
            return inp[i].value;
        }
    }
}
function deleteItem() {
    var deleteI = uri+"/delete";
    id = checkbutton();
    while(id == undefined){
        help()
        deleteItem()
    }
    fetch(`${deleteI}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id) {
    var number = checkArray(id)
    document.getElementById('add-name').value = tasks[number].name;
    document.getElementById('add-description').value = tasks[number].description;
}
function checkArray(id){
    for (i=0;i<tasks.length;i++){
        if(tasks[i].id==id){
            return i;
        }
    }
}
function updateItem() {
    var id = checkbutton();
    while(id == undefined){
        help()
        updateItem()
    }
    document.getElementById('header').innerText = `Edit`;
    displayEditForm(id)
    
    
}
function saveItem(){
    const addNameTextbox = document.getElementById('add-name');
    const addDescriptionTextbox = document.getElementById('add-description');
    const addStatusOption= document.getElementById('status');
    const id =checkbutton()
    const item = {
        "id":id,
        "Name":addNameTextbox.value,
        "Description":addDescriptionTextbox.value,
        "StatusId":addStatusOption.value

    };
    var uriUpdate = uri+"/update";
    fetch(uriUpdate, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(() => {
            getItems(); 
            addNameTextbox.value = '';
            addDescriptionTextbox.value='';
            document.getElementById('header').innerText = `Add`;
        })
        .catch(error => console.error('Unable to update item.', error));
    
    closeInput();
    

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'now task' : 'now tasks';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}
function help(){
    document.getElementById('help').innerText = `выберите radioButton`;
}
function helpadd(){
    document.getElementById('help').innerText = `заполните поля`;
}

function _displayItems(data) {
    const tBody = document.getElementById('tasks');
    tBody.innerHTML = '';
    const edit = document.getElementById("edit");
    edit.innerHTML='';
    _displayCount(data.length);
    
    const button = document.createElement('button');
   
    let deleteEButton = button.cloneNode(false);
    deleteEButton.innerText = 'Delete';
    deleteEButton.setAttribute('onclick', `deleteItem()`);

    let editEButton = button.cloneNode(false);
    editEButton.innerText = 'Edit';
    editEButton.setAttribute('onclick', `updateItem()`);
    
    let saveEButton = button.cloneNode(false);
    saveEButton.innerText = 'Save';
    saveEButton.setAttribute('onclick', `saveItem()`);
    
    let tr1 = edit.insertRow();
    
    let td1 = tr1.insertCell(0);
    td1.appendChild(deleteEButton);
    
    let td2 = tr1.insertCell(1);
    td2.appendChild(editEButton);
    
    let td3 = tr1.insertCell(2);
    td3.appendChild(saveEButton);
    
    Object.keys(data).forEach(item => {
        let Checkbox = document.createElement('input');
        Checkbox.type = 'radio';
        Checkbox.disabled = false;
        Checkbox.name="radioButton"
        Checkbox.value = data[item].id;
        
        let tr = tBody.insertRow();
        tr.id =data[item].id;
        let td2 = tr.insertCell(0);
        let textNodeid = document.createTextNode(data[item].id);
        td2.appendChild(textNodeid);

        let td3 = tr.insertCell(1);
        let textNodename = document.createTextNode(data[item].name);
        td3.appendChild(textNodename);

        let td4 = tr.insertCell(2);
        let textNodedes = document.createTextNode(data[item].description);
        td4.appendChild(textNodedes);

        let td5 = tr.insertCell(3);
        let textNodestat = document.createTextNode(data[item].status);
        td5.appendChild(textNodestat);

        let td1 = tr.insertCell(4);
        td1.appendChild(Checkbox);
    });
    var row = document.getElementsByTagName('tasks');

    [].forEach.call(row, function(elem){
        elem.addEventListener('click', function (el) {
            alert(this.children[0].innerHTML);
        })
    });
    tasks = data;
}
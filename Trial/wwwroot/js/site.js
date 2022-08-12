// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#myTable').DataTable({
        "pageLength": 12,
        processing: true,
        ordering: false,
        paging: true,
        searching: true,
        "lengthChange": false,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        },

    });
});

$(document).ready(function () {
    $('#classSchedule').DataTable({
        "pageLength": 12,
        processing: true,
        ordering: false,
        paging: true,
        searching: true,
        "lengthChange": false,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        },

    });
});

function butonFunction() {
    const checkBox = document.getElementsByClassName("filledBox");
    for (var i = 0; i < checkBox.length; i++) {
        if (!(checkBox[i].hasAttribute("checked"))) {
            checkBox[i].setAttribute("checked", "true");
            
        } else {
            checkBox[i].removeAttribute("checked");
        }
    }

}

//Yeni Slot Sayfası
function btnFunction(){

}

var slotResult = document.getElementById("slotResult");
var checkedList = [];

//Aktif Etmek
var elements = document.getElementsByClassName("availableBox");
for (var i = 0; i < elements.length; i++) {
    elements[i].addEventListener('click', function (e) {
        console.log(e.target);
        e.target.getAttribute("class");
        if (e.target.getAttribute("class") === "btn btn-success availableBox") {
            e.target.setAttribute("class",  "btn btn-danger busyBox");
        } else {
            e.target.setAttribute("class", "btn btn-success availableBox");
        }

        
        var id = e.target.getAttribute("for");
        if (checkedList.includes(id)) {
            var index = checkedList.indexOf(id, 0);
            checkedList.splice(index, 1);
        }
        else {
            checkedList.push(id);
        }
        console.log(checkedList);
        var checkListString = "";

        for (var i = 0; i < checkedList.length; i++) {
            checkListString += checkedList[i] + " ";
        }

        slotResult.setAttribute("value", checkListString);
    });
};
document.getElementById("allAvailable").addEventListener('click', function (e) {
    var slots = document.getElementsByClassName("busyBox");
    console.log(slots.length);
    var itemIds=[];
    for (var i = 0; i < slots.length; i++) {
        itemIds.push(slots[i].getAttribute("for"));
    }
    console.log(itemIds.length)
    for (var i = 0; i < itemIds.length; i++) {
        document.getElementById(itemIds[i]).setAttribute("class", "btn btn-success availableBox");
        checkedList.pop();
    }
    console.log(checkedList);
});
document.getElementById("allBusy").addEventListener('click', function (e) {
    var slots = document.getElementsByClassName("availableBox");
    console.log(slots.length);
    var itemIds = [];
    for (var i = 0; i < slots.length; i++) {
        itemIds.push(slots[i].getAttribute("for"));
    }
    console.log(itemIds.length)
    for (var i = 0; i < itemIds.length; i++) {
        document.getElementById(itemIds[i]).setAttribute("class", "btn btn-danger busyBox");
        checkedList.push(itemIds[i]);
    }
    console.log(checkedList);
});
//Modal1
var myModal = document.getElementById('myModal')
var myInput = document.getElementById('myInput')
myModal.addEventListener('shown.bs.modal', function () {
    myInput.focus()
});

//Modal2
var pageModal = document.getElementById('pageModal')
var pageInput = document.getElementById('pageInput')

myModal.addEventListener('shown.bs.modal', function () {
    myInput.focus()
});

var myCarousel = document.getElementById('#myCarousel')
var carousel = new bootstrap.Carousel(myCarousel, {
    interval: false,
    wrap: false
});

function theoreticalFunction(val) {
    document.getElementById('theoreticalHourLabel').innerHTML = 'Teorik Saat: ' + val;

}
function praticalFunction(val) {
    document.getElementById('praticalHourLabel').innerHTML = 'Pratik Saat: ' + val;

}
function creditFunction(val) {
    document.getElementById('creditLabel').innerHTML = 'Ders Kredisi: ' + val;

}
function ectsFunction(val) {
    document.getElementById('ectsLabel').innerHTML = 'ECTS: ' + val;

}
function semesterFunction(val) {
    document.getElementById('semesterLabel').innerHTML = 'Semester: ' + val + ". Semester";

} 
function studentCountFunction(val) {
    document.getElementById('studentCountLabel').innerHTML = 'Kapasite: ' + val;

}

function inputModalFunction(val) {
    var academician = {
        Id : 0,
        FirstName :"Undefined",
        LastName: "Undefined",
        IsAssistant: "Undefined",
        Email: "Undefined",
        Title: "Undefined"
    }
    

    const myArray = val.split("-");
    academician.Id = myArray[0];
    academician.FirstName = myArray[1];
    academician.LastName = myArray[2];
    academician.Email = myArray[3];
    academician.IsAssistant = myArray[4];
    if (myArray.length > 5) {
        academician.Title = myArray[5];
    }
    var isAssistant = "Asistan Değil"
    if (academician.IsAssistant == "true") {
        isAssistant = "Asistan"
    }
    document.getElementById("modalNameTitle").innerHTML = academician.Title + " " + academician.FirstName + " " + academician.LastName;
    document.getElementById("modalEmailAdress").innerHTML = academician.Email;
    document.getElementById("modalIsAssistant").innerHTML = isAssistant;
    document.getElementById("modalIsAssistant").setAttribute("class", "bg-warning rounded-pill p-2 px-sm-5 text-white");

    document.getElementById("profileSlotSelection").val = academician.Id;
    console.log(document.getElementById("profileSlotSelection").val);
    document.getElementById("profileSlotSelection").setAttribute("value", academician.Id);

    var constraintsGroups = document.getElementById("constraints").getAttribute("value");
    var constraintsList = constraintsGroups.split("-");
    var constraintsListFixed = [];
    for (var i = 0; i < constraintsList.length; i++) {
        var temp = constraintsList[i].split("_");
        console.log(temp);
        var constraint = {
            academicianId: "null",
            timeSlot: "null"
        };
        constraint.academicianId = temp[0];
        constraint.timeSlot = temp[1];
        constraintsListFixed.push(constraint);
    }
    var academicianScheduleListString = document.getElementById("academicianSchedule").getAttribute("value");
    var academicianScheduleList = academicianScheduleListString.split(",");
    var academicianScheduleListFixed = [];
    for (var i = 1; i < academicianScheduleList.length; i++) {
        var temp = academicianScheduleList[i].split("_");
        var academicianSchedule = {
            academicianId: 1,
            timeSlotId: 1,
            courseName: "",
            classroomCode: "",
            courseCode: "",
        }
        console.log(temp);
        console.log(temp[4]);
        academicianSchedule.academicianId = temp[0];
        academicianSchedule.courseName = temp[3];
        academicianSchedule.classroomCode = temp[1];
        academicianSchedule.courseCode = temp[2];
        academicianSchedule.timeSlotId = temp[4];
        academicianScheduleListFixed.push(academicianSchedule);
    }
    console.log(academicianScheduleListFixed);

    var courseCodeNameBox = document.getElementById("courseCodeNameContainer");
    while (courseCodeNameBox.hasChildNodes()) {
        courseCodeNameBox.removeChild(courseCodeNameBox.firstChild);
    }

    var resetSlots = document.getElementsByClassName("scheduleCell");
    for (var i = 0; i < resetSlots.length; i++) {
        resetSlots[i].setAttribute("class", "d-block scheduleCell");
        resetSlots[i].innerHTML = "";
        resetSlots[i].parentElement.setAttribute("class", "pb-2 align-bottom");
    }
    for (var i = 1; i < constraintsListFixed.length; i++) {
        timeSlot = constraintsListFixed[i].timeSlot;
        timeSlotString = timeSlot+"Slot";
        var slotNumber = document.getElementById(timeSlotString);
        if (constraintsListFixed[i].academicianId == academician.Id) {
            slotNumber.setAttribute("class", "d-block badge bg-dark scheduleCell");
            slotNumber.parentElement.setAttribute("class", "pb-2 align-bottom bg-dark bg-gradient");
            slotNumber.innerHTML = "Not Available";
        }
    }
    for (var i = 0; i < academicianScheduleListFixed.length; i++) {
        if (academician.Id == academicianScheduleListFixed[i].academicianId) {
            if (academicianScheduleListFixed[i].timeSlotId == "") {
                continue;
            }
            var classGrid = document.getElementById(academicianScheduleListFixed[i].timeSlotId + "Slot");
            console.log(classGrid);
            //classGrid.setAttribute("class", "py-5 bg-info bg-gradient bg-opacity-75");
            /*if (classGrid.innerHTML == "") {
                classGrid.innerHTML = academicianScheduleListFixed[i].courseCode;
            } else {
                classGrid.innerHTML = classGrid.innerHTML + academicianScheduleListFixed[i].courseCode;         
            }*/
            var paragraph = document.createElement("p");
            paragraph.appendChild(document.createTextNode(academicianScheduleListFixed[i].courseCode));
            addClass(paragraph, "d-block");
            classGrid.appendChild(paragraph);
            /*
            var courseCodeNameContainer = getElementById("courseCodeNameContainer");
            var lecCode = document.createElement("strong");
            lecCode.appendChild(document.createTextNode(academicianScheduleListFixed[i].courseCode + "  -"));
            courseCodeNameContainer.appendChild(lecCode);
            var lecName = document.createElement("span");
            paragraph.appendChild(document.createTextNode(academicianScheduleListFixed[i].courseName));
            courseCodeNameContainer.appendChild(lecName);*/
        }
    }

    console.log(constraintsListFixed);
    
}
function facultyNameFunction(id) {
    var allDepartments = document.getElementsByClassName("departmentCard");
    for (var i = 0; i < allDepartments.length; i++) {
        addClass(allDepartments[i], "visually-hidden");
    }
    var hiddens = document.getElementsByClassName(id);
    var fnames = document.getElementsByClassName("faculty-card-fname");
    console.log(hiddens);
    for (var i = 0; i < fnames.length; i++) {
        fnames[i].innerHTML = "Fakülte Kodu: " + id;
    }
    for (var i = 0; i < hiddens.length; i++) {
        removeClass(hiddens[i], "visually-hidden");
    }
    document.getElementById("facultyId").setAttribute("value", id);
}

function hasClass(el, className) {
    if (el.classList)
        return el.classList.contains(className);
    return !!el.className.match(new RegExp('(\\s|^)' + className + '(\\s|$)'));
}

function addClass(el, className) {
    if (el.classList)
        el.classList.add(className)
    else if (!hasClass(el, className))
        el.className += " " + className;
}

function removeClass(el, className) {
    if (el.classList)
        el.classList.remove(className)
    else if (hasClass(el, className)) {
        var reg = new RegExp('(\\s|^)' + className + '(\\s|$)');
        el.className = el.className.replace(reg, ' ');
    }
}
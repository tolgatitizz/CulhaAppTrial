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

var myModal = document.getElementById('myModal')
var myInput = document.getElementById('myInput')

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
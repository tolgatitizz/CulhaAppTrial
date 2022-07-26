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
var elements = document.getElementsByClassName("filledBox");
for (var i = 0; i < elements.length; i++) {
    elements[i].addEventListener('click', function (e) {
        console.log(e.target);
        if (checkedList.includes(e.target.getAttribute("for"))) {
            e.target.setAttribute("class", "btn btn-outline-dark");
        }
        e.target.setAttribute("class", "btn btn-secondary");
        var id = e.target.getAttribute("for");
        console.log(id);
        if (checkedList.includes(id)) {
            checkedList.pop(id);
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

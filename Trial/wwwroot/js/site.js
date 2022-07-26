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

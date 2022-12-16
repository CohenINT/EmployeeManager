// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
///<reference path="../lib/jquery/dist/jquery.js" />


function redirectToView(controller, view, uniqueId) {

    location.href = `${controller}/${view}?id=${uniqueId}`;
}


function EnbleAddressEdit(e) {
    let target = e.target || e.srcElement;
    target.parentElement.parentElement.children[0].childNodes[0].disabled = false;
    target.parentElement.parentElement.children[1].childNodes[0].disabled = false;
}

function SaveAddressChanges(e) {
    let target = e.target || e.srcElement;
    let city = target.parentElement.parentElement.children[0].childNodes[0].value;
    let street = target.parentElement.parentElement.children[1].childNodes[0].value;
    let Id = target.getAttribute("id");
    
    $.ajax({
        type: "POST",
        url: `https://${location.host}/api/Address/UpdateAddress`,
        contentType: "application/json",
        dataType:"json",
        data:JSON.stringify({
            Id:Id,
            City: city,
            Street: street
        }),
        success: function (data) {
            console.log(data);
        },
        error: function (a, b, c) {
            console.error(a);
            console.error(b);
            console.error(c);
            debugger;
        }

    });


}
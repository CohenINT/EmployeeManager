// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.



// Write your JavaScript code.
///<reference path="../lib/jquery/dist/jquery.js" />


function redirectToView(controller, view, uniqueId) {

    location.href = `${controller}/${view}?id=${uniqueId}`;
}


function EnbleAddressEdit(uniqueId) {
    document.getElementById(`city_${uniqueId}`).disabled = false;
    document.getElementById(`street_${uniqueId}`).disabled = false;
}

function DeleteAddress(uniqueId) {
   

    $.ajax({
        type: "POST",
        url: `https://${location.host}/api/Address/Delete`,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({
            Id: uniqueId
        }),
        success: function (data) {
            console.log(data);
        },
        error: function (a, b, c) {
            console.error(a);
            console.log(b);
            console.log(c);
            debugger;
        }
    });
}
function SaveAddressChanges(uniqueId) {
  
    let city = document.getElementById(`city_${uniqueId}`).value;
    let street = document.getElementById(`street_${uniqueId}`).value;
    debugger;
    $.ajax({
        type: "POST",
        url: `https://${location.host}/api/Address/UpdateAddress`,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({
            Id: uniqueId,
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

function EnbleContactEdit(uniqueId) {
  
   document.getElementById(`fullname_${uniqueId}`).disabled= false;
   document.getElementById(`officenumber_${uniqueId}`).disabled = false;
   document.getElementById(`email_${uniqueId}`).disabled = false;

}
function IsValidCustomerNumber(customerNumber) {
    if (customerNumber != "" && customerNumber.length == 9) {
        for (let i = 0; i < customerNumber.length; i++) {
            if (!(customerNumber[i] >= '0' && customerNumber[i] <= '9'))
                return false
        }
        return true;
    }
    return false;
    
}
function SaveContactChanges(uniqueId) {
    let fullname = document.getElementById(`fullname_${uniqueId}`).value;
    let officenumber = document.getElementById(`officenumber_${uniqueId}`).value;
    let email = document.getElementById(`email_${uniqueId}`).value;

    debugger;
    $.ajax({
        type: "POST",
        url: `https://${location.host}/api/Contact/UpdateContact`,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({
            Id: uniqueId,
            FullName: fullname,
            Email: email,
            OfficeNumber:officenumber
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
function CreateCustomer() {
    let name = document.getElementById("newCustomer_name").value;
    let customerNumber = document.getElementById("newCustomer_customerNumber").value;
    let city = document.getElementById("newCustomer_city").value;
    let street = document.getElementById("newCustomer_street").value;
    let addresses = [ {City:city,Street:street}];
    let contact_name = document.getElementById("newCustomer_contact_fullname").value;
    let contact_officenumber = document.getElementById("newCustomer_contact_officenumber").value;
    let contact_email = document.getElementById("newCustomer_contact_email").value;
    let contacts = [ { FullName: contact_name, OfficeNumber: contact_officenumber, Email: contact_email }];
    $.ajax({
        type: "POST",
        url: `https://${location.host}/api/Customer/CreateCustomer`,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({
           
            Name: name,
            CustomerNumber: customerNumber,
            Addresses: addresses,
            Contacts: contacts
           
        }),
        success: function (data) {
            console.log(data);
            location.reload();
        },
        error: function (a, b, c) {
            console.error(a);
            console.error(b);
            console.error(c);
            debugger;
        }

    });
}
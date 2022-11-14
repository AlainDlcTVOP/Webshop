// Define Javascript functions to call and fetch information from methods in Controllers > OrdersController.cs

function ViewAllOrders() {

    $.ajax({
        type: 'GET',
        url: "/Orders/GetAllOrders",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            let result = document.getElementById("result");
            result.innerHTML = response;
        },
        error: function (error) {
            //console.log(error);
        }
    });
}

function ViewOrder(orderID) {

    $.ajax({
        type: 'GET',
        url: `/Orders/GetOrder?id=${orderID}`,
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            let result = document.getElementById("result");
            result.innerHTML = response;
        },
        error: function (error) {
            //console.log(error);
        }
    });
}

function ViewCurrentUserOrders() {

    $.ajax({
        type: 'GET',
        url: "/Orders/GetCurrentUserOrders",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            let result = document.getElementById("result");
            result.innerHTML = response;
        },
        error: function (error) {
            //console.log(error);
        }
    });
}

function UpdateOrder(orderID) {

    $.ajax({
        type: 'GET',
        url: `/Orders/UpdateOrder?orderID=${orderID}`,
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            let result = document.getElementById("result");
            result.innerHTML = response;
        },
        error: function (error) {
            //console.log(error);
        }
    });
}

function UpdateOrderPut() {

    let data = $("#updateOrderForm").serializeArray();

    let orderID = "";

    for (let i = 0; i < data.length; i++) {
        if (data[i].name === "Id") {
            orderID = data[i].value;
        }
    }

    $.ajax({
        type: 'PUT',
        url: `/Orders/UpdateOrder`,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (response) {
            ViewOrder(orderID);
        },
        error: function (error) {
            //console.log(error);
        }
    });
}

function DeleteOrder(orderID) {

    $.ajax({
        type: 'DELETE',
        url: `/Orders/DeleteOrder?id=${orderID}`,
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            //console.log(response);
            ViewAllOrders();
        },
        error: function (error) {
            //console.log(error);
        }
    });
}
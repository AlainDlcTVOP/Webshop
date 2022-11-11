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
            console.log(error);
        }
    });
}
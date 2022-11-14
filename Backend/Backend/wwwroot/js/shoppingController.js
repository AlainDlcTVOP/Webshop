// Define Javascript functions to call and fetch information from methods in Controllers > ShoppingController.cs


function ViewShoppingCart() {

    $.ajax({
        type: 'GET',
        url: "/Basket/GetShoppingCart",
        success: function (response) {
            let result = document.getElementById("result");
            result.innerHTML = response;
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function AddToCart(productID) {

    $.ajax({
        type: "POST",
        url: "/Basket/AddItemToCart?productId=" + productID + "&quantity=1",
        success: function () {
            let notification = document.getElementById("notification");
            notification.innerHTML = "Tillagd i varukorg!",
                notification.classList.remove("hidden");
        }



    });
    setTimeout(function () {
        let notification = document.getElementById("notification");
        notification.innerHTML = "",
            notification.classList.add("hidden");
    }, 2000);

}



function UpdateQuantity(productID) {

    const id = new String(productID);
    let quantity = $("#" + id).val();

    $.ajax({
        type: "PUT",
        url: "/Basket/UpdateQuantity?productId=" + productID + "&quantity=" + quantity,
        success: function (response) {
            let result = document.getElementById("result");
            result.innerHTML = response;
        },
    });
}

function RemoveItemFromCart(productID) {

    $.ajax({
        type: "DELETE",
        url: "/Basket/RemoveCartItem?productId=" + productID,
        success: function (response) {
            let result = document.getElementById("result");
            result.innerHTML = response;
        },
    });
}

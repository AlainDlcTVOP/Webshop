// Define Javascript functions to call and fetch information from methods in Controllers > ShoppingController.cs

function AddToCart(productID) {

    console.log("AddToCart");
    console.log(productID);

    $.ajax({
        type: 'GET',
        url: `/Shopping/AddToCart?Id=${productID}&Quantity=1`,
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            console.log(response);
            //let result = document.getElementById("result");
            //result.innerHTML = response;
        },
        error: function (error) {
            console.log(error);
        }
    });
}

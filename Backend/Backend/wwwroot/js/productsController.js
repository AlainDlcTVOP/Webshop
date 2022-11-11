// Define Javascript functions to call and fetch information from methods in Controllers > ProductsController.cs

function ViewAllProducts() {

    $.ajax({
        type: 'GET',
        url: "/Products/GetAllProducts",
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

function ViewProduct(productID) {

    $.ajax({
        type: 'GET',
        url: `/Products/GetProduct?id=${productID}`,
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

function CreateProduct() {

    $.ajax({
        type: 'GET',
        url: "/Products/CreateProduct",
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

function CreateProductPost() {

    let data = $("#createProductForm").serializeArray();

    $.ajax({
        type: 'POST',
        url: "/Products/CreateProduct",
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (response) {
            //console.log(response);
            let productID = response.id;
            ViewProduct(productID);
        },
        error: function (error) {
            //console.log(error);
        }
    });
}

function UpdateProduct(productID) {

    $.ajax({
        type: 'GET',
        url: `/Products/UpdateProduct?id=${productID}`,
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

function UpdateProductPut() {

    let data = $("#updateProductForm").serializeArray();

    let productID = "";

    for (let i = 0; i < data.length; i++)
    {
        if (data[i].name === "Id")
        {
            productID = data[i].value;
        }
    }

    $.ajax({
        type: 'PUT',
        url: `/Products/UpdateProduct`,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (response) {
            //console.log(response);
            ViewProduct(productID);
        },
        error: function (error) {
            //console.log(error);
        }
    });
}

function DeleteProduct(productID) {

    $.ajax({
        type: 'DELETE',
        url: `/Products/DeleteProduct?id=${productID}`,
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            //console.log(response);
            ViewAllProducts();
        },
        error: function (error) {
            //console.log(error);
        }
    });
}

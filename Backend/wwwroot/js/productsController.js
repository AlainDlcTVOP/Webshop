// Define Javascript functions to call and fetch information from methods in Controllers > ProductsController.cs

function ViewAllProducts() {

    console.log("GetAllProducts");

    let url = "/Products/GetAllProducts";

    $.ajax({
        type: 'GET',
        url: url,
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            let result = document.getElementById("result");
            result.innerHTML = response;
        },
        error: function (error) {
            // This part will not trigger unless response status code is set to anything other than 2**
        }
    });
}

function ViewProduct(productID) {

    console.log("ViewProductPage");
    console.log(productID);

    let url = `/Products/GetProduct?id=${productID}`;

    $.ajax({
        type: 'GET',
        url: url,
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            let result = document.getElementById("result");
            result.innerHTML = response;
        },
        error: function (error) {
            // This part will not trigger unless response status code is set to anything other than 2**
        }
    });
}

function CreateProduct() {

    console.log("CreateProduct");

    let url = "/Products/CreateProduct";

    $.ajax({
        type: 'GET',
        url: url,
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            let result = document.getElementById("result");
            result.innerHTML = response;
        },
        error: function (error) {
            // This part will not trigger unless response status code is set to anything other than 2**
        }
    });
}

function CreateProductPost() {

    console.log("CreateProductPost");

    var data = new FormData();

    var fileupload = $("#images").get(0);
    var files = fileupload.files;
    for (let i = 0; i < files.length; i++) {
        data.append(files[i].name, files[i]);
    }

    let model = {
        Name: $("#name").name,
        NameVal: $("#name").val(),
        Description: $("#description").name,
        DescriptionVal: $("#description").val(),
        Price: $("#price").name,
        PriceVal: $("#price").val(),
        InStock: $("#instock").name,
        InStockVal: $("#instock").val()
    }

    data.append(model.Name, model.NameVal);
    data.append(model.Description, model.DescriptionVal);
    data.append(model.Price, model.PriceVal);
    data.append(model.Price, model.PriceVal);

    //console.table(data);

    let url = "/Products/CreateProduct";

    $.ajax({
        type: 'POST',
        url: url,
        contentType: false,
        processData: false,
        data: data,
        success: function (response) {
            console.log(response);
        },
        error: function (error) {
            // This part will not trigger unless response status code is set to anything other than 2**
            console.log(error);
        }
    });
}

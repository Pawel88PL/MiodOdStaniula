
$(document).ready(function () {
    $.ajax({
        url: getCartItemCountUrl,
        type: 'GET',
        success: function (data) {
            $('#cartCount').text(data);
        }
    });
});



function showCartModal(product) {

    document.getElementById('productName').textContent = product.name;
    document.getElementById('productImage').src = product.image;
    document.getElementById('productPrice').textContent = product.price + ",00 PLN";
    document.getElementById('productWeight').textContent = product.weight + " G";

    var cartModal = new bootstrap.Modal(document.getElementById('cartModal'));
    cartModal.show();
    updateCartItemCount();
}

function updateCartItemCount() {
    $.ajax({
        url: getCartItemCountUrl,
        type: 'GET',
        success: function (data) {
            $('#cartCount').text(data);
        }
    });
}

$(document).ready(function () {
    $(".addToCartButton").click(function (e) {
        console.log('addToCartButton was clicked');
        e.preventDefault();
        var productId = $(this).siblings('.product-id').val();
        console.log('Sending AJAX request, productId:', productId);
        $.ajax({
            url: '/Cart/AddItemToCart',
            type: 'POST',
            data: {
                productId: productId,
                quantity: 1
            },
            success: function (response) {
                console.log('AJAX request successful, response:', response);
                if (response.success) {
                    var product = response.product;
                    showCartModal(product);
                } else {
                    // Handle error
                }
            },
            error: function (error) {
                console.log('AJAX request failed, error:', error);
            }
        });
    });
});


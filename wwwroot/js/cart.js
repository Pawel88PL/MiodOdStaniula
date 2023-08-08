function showCartModal(product) {

    document.getElementById('productName').textContent = product.name;
    document.getElementById('productImage').src = product.image;
    document.getElementById('productPrice').textContent = product.price;
    document.getElementById('productWeight').textContent = product.weight + " G";

    var cartModalElement = document.getElementById('cartModal');
    var cartModal = new bootstrap.Modal(cartModalElement);
    cartModal.show();
    updateCartItemCount();
    
    setTimeout(function() {
        $(cartModalElement).addClass('slide-out');
        setTimeout(function() {
            cartModal.hide();
        }, 300);
    }, 3000);
}

function updateCartItemCount() {
    $.ajax({
        url: '/Cart/GetCartItemCount',
        type: 'GET',
        success: function (data) {
            $('#cartCount').text(data);
        }
    });
}

$(document).ready(function () {
    
    updateCartItemCount();

    $('#cartModal').on('hidePrevented.bs.modal', function(event) {
        var cartModal = new bootstrap.Modal(this);
        $(this).addClass('slide-out');
        setTimeout(function() {
            cartModal.hide();
        }, 300);
    });

    $('#cartModal').on('hide.bs.modal', function(event) {
        if ($(this).hasClass('slide-out')) {
            $(this).removeClass('slide-out');
        } else {
            return false;
        }
    });

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
                alert('Wystąpił problem podczas dodawania produktu do koszyka.\nSpróbuj ponownie.');
            }
        });
    });
});
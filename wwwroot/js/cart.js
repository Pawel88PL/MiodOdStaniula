$(document).ready(function () {
    $.ajax({
        url: getCartItemCountUrl,
        type: 'GET',
        success: function (data) {
            $('#cartCount').text(data);
        }
    });
});

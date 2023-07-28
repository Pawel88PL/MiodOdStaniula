$(function () {
    $(".filter-link, .sort-link").click(function (event) {
        event.preventDefault();

        var url = $(this).attr("href");
        $("#products-container").load(url);
    });

    $(document).ready(function () {
        // Set initial availability
        $('.variant-select').each(function () {
            var initialAvailability = $(this).find('option:first').data('availability');
            var productId = $(this).data('product-id');

            // Update availability
            updateAvailability(initialAvailability, productId);
        });

        // Handle change event
        $('.variant-select').change(function () {
            // Handle image change
            var newImageUrl = $(this).val();
            var imagePath = '/img/' + newImageUrl;
            $(this).closest('.card').find('.bg-image img').attr('src', imagePath);

            // Handle availability change
            var availability = $(this).find('option:selected').data('availability');
            var productId = $(this).data('product-id');

            // Update availability
            updateAvailability(availability, productId);
        });
    });

    // Function to update availability
    function updateAvailability(availability, productId) {
        if (availability == 0) {
            $('#outOfOrder-' + productId).show();
            $('#smallAmount-' + productId).hide();
            $('#available-' + productId).hide();
        } else if (availability > 0 && availability < 10) {
            $('#outOfOrder-' + productId).hide();
            $('#smallAmount-' + productId).show();
            $('#available-' + productId).hide();
        } else if (availability >= 10) {
            $('#outOfOrder-' + productId).hide();
            $('#smallAmount-' + productId).hide();
            $('#available-' + productId).show();
        }
    }
});

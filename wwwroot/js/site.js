$(document).ready(function () {
    $(".filter-link").click(function (e) {
        e.preventDefault();
        var url = $(this).attr('href');
        $.ajax({
            url: url,
            type: 'get',
            success: function (data) {
                // Zaktualizuj stronę z nowymi danymi
                $("#products-container").html(data);
            }
        });
    });
});

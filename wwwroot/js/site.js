

$(function () {
    $(".filter-link, .sort-link").click(function (event) {
        event.preventDefault();

        var url = $(this).attr("href");
        $("#products-container").load(url);
    });
});

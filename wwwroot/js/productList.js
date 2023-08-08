$(function () {
    $(".filter-link, .sort-link").click(function (event) {
        event.preventDefault();

        var url = $(this).attr("href");
        var filterCondition = $(this).text().trim();

        $("#categories").text(filterCondition);

        $("#products-container").load(url);
    });
});

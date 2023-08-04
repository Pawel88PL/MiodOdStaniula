$(function () {
    $(".filter-link, .sort-link").click(function (event) {
        event.preventDefault();

        var url = $(this).attr("href");
        var filterCondition = $(this).text().trim();

        // update the h1 text
        $("h1").text(filterCondition);

        $("#products-container").load(url);
    });
});

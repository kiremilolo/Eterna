$(document).ready(function () {
    $(document).on("click", ".portfolio-detail-open", function(e) {
        e.preventDefault();

        var url = $(this).attr("href")

        fetch(url)
            .then((response) => response.text())
            .then(htmlDetail =>
                $("#portfolio-details .detail-info").html(htmlDetail)
            )

    
})
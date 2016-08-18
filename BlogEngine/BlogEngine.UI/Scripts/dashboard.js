$(function () {
    $('.clickable-row').click(function () {
        var dataType = $(this).data("type");
        window.location.href = "/Home/Edit" + dataType + "/" + $(this).data("id");
    })
    .hover(function () {
        $(this).toggleClass(" bg-primary");
    });

})
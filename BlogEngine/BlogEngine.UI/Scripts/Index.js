$(function()
{ 
    $(".place").click(function() {
        var dataType = $(this).data();
        window.location.href = "/Home/IndividualPost/" + $(this).data();
    })
    .hover(function() {
        $(this).toggleClass("bg-green");
    });

})
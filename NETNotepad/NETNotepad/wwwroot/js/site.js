$("#exampleFormControlTextarea5").keyup(function () {
    $("#count").text("Characters left: " + (1000 - $(this).val().length));
});

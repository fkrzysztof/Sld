$("body").on("click", ".removeButtonBackground", function (event) {
    event.preventDefault();
    let toHide = $(this).closest(".hide-show-background");
    let send = $(this).data("id");
    $.post("/Settings/DeleteBackgroundJS", { id: send }, function (data) {
        if (data == true) {
            toHide.fadeOut();
        }
        else {
            alert("Wystąpił problem..");
        }
    });
});
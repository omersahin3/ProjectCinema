
$(function () {

    $(".chairButton").click(function () {

        const id = $(this).val();
        const button = $(this);
        $.ajax({
            method: "GET",
            url: "/changestatus_chair/" + id,
            success: function (response) {
                $(".response").html(response);
                if (button.hasClass("tChair")) {
                    button.removeClass("tChair").addClass("fChair");
                    $(button).children('img').remove();
                    $(button).html("<img src='/Images/off.png' /> ");
                }
                else {
                    button.removeClass("fChair").addClass("tChair");
                    $(button).children('img').remove();
                    $(button).html("<img src='/Images/on.png' /> ");
                }
            }
        });
    })
})

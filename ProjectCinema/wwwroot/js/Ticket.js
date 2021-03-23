var id;
var button;
var copy = false;
$(function () {
    

    $(".chairButton2").click(function () {

        id = $(this).val();
        button = $(this);
        $.ajax({
            method: "GET",
            url: "/ticketstatus_chair/" + id,
            success: function (response) {
                $(".response").html(response);
                if (button.hasClass("tChair")) {
                    button.removeClass("tChair").addClass("fChair");
                    $(button).children('img').remove();
                    $(button).html("<img src='/Images/off.png' /> ");
                    copy = true;
                }
                else {
                    copy = false;
                }
            }
        });
    })

    $(".chairButton2").click(function (e) {
        //alert($("#Test").attr("class"));
        var SessionID = $("#Test").attr("class");
        $.ajax({
            type: "POST",
            url: "/AddTickettt/" + SessionID + "/" + id,
            success: function (result) {
                if (copy == true) {
                    alert('Koltuk Satın Alındı');
                }
                else {
                    alert('Koltuk Dolu');
                }
                
            },
            error: function (result) {
                alert('error');
            }
        });
    });
});


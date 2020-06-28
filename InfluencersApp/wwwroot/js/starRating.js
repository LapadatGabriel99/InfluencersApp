$(document).ready(() => {
    $('#s1').click(() => {
        $('.fa-star').css("color", "azure");
        $('#s1').css("color", "yellow");
    });
    $('#s2').click(() => {
        $('.fa-star').css("color", "azure");
        $('#s1, #s2').css("color", "yellow");
    });
    $('#s3').click(() => {
        $('.fa-star').css("color", "azure");
        $('#s1, #s2, #s3').css("color", "yellow");
    });
    $('#s4').click(() => {
        $('.fa-star').css("color", "azure");
        $('#s1, #s2, #s3, #s4').css("color", "yellow");
    });
    $('#s5').click(() => {
        $('.fa-star').css("color", "azure");
        $('.fa-star').css("color", "yellow");
    });
})
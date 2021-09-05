
function clearDate(v, t) {
    $("#" + v).val("");
    $("#" + t).val("");
}

$('.remove-enter1').on("input", function () {
    var value = $(this).val();
    if (value.indexOf('\n') != -1) {
        $(this).val(value.replace(/\n/g, " <br> "));
    }
    var currentLength = $(this).val().length;
    $('.remove-enter11').children('span').html(currentLength + "/4000");
});

$('.remove-enter2').on("input", function () {
    var value = $(this).val();
    if (value.indexOf('\n') != -1) {
        $(this).val(value.replace(/\n/g, " <br> "));
    }
    var currentLength = $(this).val().length;
    $('.remove-enter12').children('span').html(currentLength + "/4000");
});

$("#openDes").on("click", function () {
    $(".completeDes").toggleClass("d-none");
    $(".hostDes").toggleClass("d-none");
});

$("#openWeb").on("click", function () {
    $(".completeWeb").toggleClass("d-none");
    $(".hostWeb").toggleClass("d-none");
});
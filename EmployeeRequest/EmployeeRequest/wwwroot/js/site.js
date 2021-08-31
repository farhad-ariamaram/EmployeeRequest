
function clearDate(v,t) {
    $("#" + v).val("");
    $("#" + t).val("");
}

$(".remove-enter").on("keyup", function (event) {
    var value = $(this).val();
    if (value.indexOf('\n') != -1) {
        $(this).val(value.replace(/\n/g, ""));
    }
    $(this).children('div').html($(".areainputs").val().length + "/4000");
});
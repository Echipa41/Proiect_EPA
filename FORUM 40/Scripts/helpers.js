function HtmlEncode(value) {
    value = value.replace(/</g, "&lt;");
    value = value.replace(/>/g, "&gt;");
    return value;
}

function Encode(tb) {
    tb.value = HtmlEncode(tb.value);
    return (tb.value != "");
}

function CheckNotNull(tb) {
    return (tb.value != "");
}

function ShowEdit(divToShowID, editID, ID ,editTB_ID, text, divToHideID) {

    $('#' + editID).val(ID);
    $('#' + editTB_ID).val(text);
    $('#' + divToShowID).show();
    $('#' + divToHideID).hide();

    return false;   
}

function CancelEdit(divToHideID, divToShowID) {
    $('#' + divToHideID).hide();
    $('#' + divToShowID).show();
    return false;
}


$(document).ready(function () {

    $('.emoticon').click(function () {
        var textarea = $(this).parent().find('textarea');
        var len = textarea.val().length;
        var start = textarea[0].selectionStart;
        var end = textarea[0].selectionEnd;
        var selected = textarea.val().substring(start, end);
        var replace = $(this).attr('code');
        var content = textarea.val().substring(0, start) + replace + textarea.val().substring(end, len);
        textarea.val(content);
    });

    $('.format-text').click(function () {
        var textarea = $(this).parent().find('textarea');
        var len = textarea.val().length;
        var start = textarea[0].selectionStart;
        var end = textarea[0].selectionEnd;
        var selected = textarea.val().substring(start, end);
        var replace = $(this).attr('start-tag') + selected + $(this).attr('end-tag');
        var content = textarea.val().substring(0, start) + replace + textarea.val().substring(end, len);
        textarea.val(content);
    });

    $('.carousel').carousel();
});
$('#login-button').click(function () {
    login();
});

function login() {

    $('#msgPanel').css('display', 'none');
    $('#msgText').html('');

    if (IsNullOrEmpty($('#username').val())) {
        $('#msgPanel').css('display', 'block');
        $('#msgText').html('Username is Required.');
        return;
    }

    if (IsNullOrEmpty($('#password').val())) {
        $('#msgPanel').css('display', 'block');
        $('#msgText').html('Password is Required.');
        return;
    }

    $.ajax({
        url: '/Account/Login',
        data: {
            username: $("#username").val(),
            password: $("#password").val()
        },
        type: 'POST',
        cache: false,
        beforeSend: function () { $('#login-button').hide(); },
        //complete: function () { $('#loading').hide(); },
        success: function (result) {
            
            console.log(result);

            if (result == false || result == null) {
                $('#msgPanel').css('display', 'block');
                $('#msgText').html('Invalid Credentials.');
                
                $('#loading').hide();
                $('#login-button').show();
                return;
            }

            window.location.href = '/Home';
        },
        error: function (x, e) {
            if (x.status == 0) {
                alert('You are offline!!\n Please Check Your Network.');
            } else if (x.status == 404) {
                alert('Requested URL not found.');
            } else if (x.status == 500) {
                alert('Internal Server Error.');
            } else if (e == 'parsererror') {
                alert('Error.\nParsing JSON Request failed.');
            } else if (e == 'timeout') {
                alert('Request Time out.');
            } else {
                alert('Unknown Error.\n' + x.responseText);
            }

            $('#loading').hide();
            $('#login-button').show();
        }
    });

}
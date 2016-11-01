var Script = function () {

    $.validator.setDefaults({
        submitHandler: function () {
          
            $.ajax("/Users/CreateOrEdit", {
                data: {
                    id: $('#id').val(),
                    username: $('#username').val(),
                    password: $('#password').val(),
                    displayname: $('#displayname').val(),
                    email: $('#email').val()
                },
                cache: false,
                type: 'POST',
                success: function (json) {
                    console.log(json);
                    if (json) {
                        window.location.replace('/Users');
                    } else {
                        alert('Ha ocurrido un error intentando procesar los datos.');
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    console.log("Error", xhr);
                }
            });

        }
    });

    $().ready(function () {
        // validate signup form on keyup and submit
        $("#form-create").validate({
            rules: {
                username: {
                    required: true
                },
                password: {
                    required: true,
                    minlength: 4,
                    maxlength: 50
                },
                password2: {
                    equalTo: "#password"
                }
            },
            messages: {
                username: {
                    required: "Por Favor Digite el Usuario."
                },
                password: {
                    required: "Por Favor Digite su Contraseña.",
                    minlength: "Minimo de Caracteres 4.",
                    maxlength: "Maximo de Caracteres 16."
                },
                password2: {
                    equalTo: "Las Contraseñas deben ser iguales."
                }
            }
        });
    });

}();
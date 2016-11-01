function formatCedula(p) {
    if (p.length == 11) {
        return p.toString().substring(0, 3) + '-' + p.toString().substring(3, 10) + '-' + p.toString().substring(10, 11);
    }
    return p;
}

function formatCreditCard1(p) {
    if (p.length == 16) {
        debugger;
        return p.toString().substring(0, 4) + '-' + p.toString().substring(3, 10) + '-' + p.toString().substring(10, 11);
    }
    return p;
}

function formatPhone(phonenum) {
    var regexObj = /^(?:\+?1[-. ]?)?(?:\(?([0-9]{3})\)?[-. ]?)?([0-9]{3})[-. ]?([0-9]{4})$/;
    if (regexObj.test(phonenum)) {
        var parts = phonenum.match(regexObj);
        var phone = "";
        if (parts[1]) { phone += "+1 (" + parts[1] + ") "; }
        phone += parts[2] + "-" + parts[3];
        return phone;
    }
    else {
        return phonenum;
    }
}

function formatCurrency(number, decimals, dec_point, thousands_sep) {
    decimals = 2;
    dec_point = '.';
    thousands_sep = ',';

    var n = !isFinite(+number) ? 0 : +number,
        prec = !isFinite(+decimals) ? 0 : Math.abs(decimals),
        sep = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep,
        dec = (typeof dec_point === 'undefined') ? '.' : dec_point,
        toFixedFix = function (n, prec) {
            // Fix for IE parseFloat(0.55).toFixed(0) = 0;
            var k = Math.pow(10, prec);
            return Math.round(n * k) / k;
        },
        s = (prec ? toFixedFix(n, prec) : Math.round(n)).toString().split('.');
    if (s[0].length > 3) {
        s[0] = s[0].replace(/\B(?=(?:\d{3})+(?!\d))/g, sep);
    }
    if ((s[1] || '').length < prec) {
        s[1] = s[1] || '';
        s[1] += new Array(prec - s[1].length + 1).join('0');
    }

    var result = s.join(dec);

    if (result.indexOf("-") >= 0) {
        result = "<span style='color:red'>" + s.join(dec) + "</span>";
    }

    return result;
}

function formatCreditCard(number) {
    return number.replace(/\d(?=\d{4})/g, "*");
}

function getToday() {
    var meses = new Array("Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre");
    var f = new Date();

    return f.getDate() + " de " + meses[f.getMonth()] + " de " + f.getFullYear();
}

function IsNullOrEmpty(p) {
    switch (p) {
        case "":
        case 0:
        case "0":
        case '':
        case null:
        case false:
        case typeof this == "undefined":
            return true;
        default:
            return false;
    }
}

function formatDate(date) {
    if (IsNullOrEmpty(date)) {
        return 'Formato no valido.';
    }

    var d = date.toString().substring(6, 8);
    var m = date.toString().substring(4, 6);
    var y = date.toString().substring(0, 4);

    return d + '/' + m + '/' + y;
}

function ConvertJsonDateString(jsonDate) {
    var shortDate = null;
    if (jsonDate) {
        var regex = /-?\d+/;
        var matches = regex.exec(jsonDate);
        var dt = new Date(parseInt(matches[0]));
        var month = dt.getMonth() + 1;
        var monthString = month > 9 ? month : '0' + month;
        var day = dt.getDate();
        var dayString = day > 9 ? day : '0' + day;
        var year = dt.getFullYear();
        shortDate = monthString + '/' + dayString + '/' + year;
    }
    return shortDate;
};

function getGuid() {
    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000)
          .toString(16)
          .substring(1);
    }
    return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
      s4() + '-' + s4() + s4() + s4();
}
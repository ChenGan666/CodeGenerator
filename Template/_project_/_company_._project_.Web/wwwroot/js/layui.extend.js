var form = layui.form;

form.verify({
    phoneN: [/(^$)|^1\d{10}$/, '请输入正确的手机号'],
    emailN: [/(^$)|^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/, '邮箱格式不正确'],
    line: [/^(\d3,4|\d{3,4}-)?\d{7,8}$/, '请输入正确的电话号'],
    lineN: [/(^$)|^(\d3,4|\d{3,4}-)?\d{7,8}$/, '请输入正确的电话号'],
    telphone: [/^1\d{10}$|^(\d3,4|\d{3,4}-)?\d{7,8}$/, '请输入正确的电话号'],
    telphoneN: [/(^$)|^1\d{10}$|^(\d3,4|\d{3,4}-)?\d{7,8}$/, '请输入正确的电话号'],
    length50: function (value, item) {
        return lengthLimit(value, 50);
    },
    length200: function (value, item) {
        return lengthLimit(value, 200);
    },
    length500: function (value, item) {
        return lengthLimit(value, 500);
    },
    length1024: function (value, item) {
        return lengthLimit(value, 1024);
    },
    password: function (value, item) {
        var l = value.length;
        if (l < 6)
            return "密码不能小于6位";
    },
    repassword: function (value) {
        if ($('#password').val() !== $('#repassword').val()) {
            return '两次密码不一致';
        }
    }
});

function lengthLimit(value, limit) {
    var l = value.length;
    if (l > limit)
        return "长度不能超过" + limit + "字符,您已超过" + (l-limit)+ "字符";
}
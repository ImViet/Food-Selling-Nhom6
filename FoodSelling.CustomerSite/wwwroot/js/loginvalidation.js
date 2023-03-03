$(document).ready(function () {
    $("#login").validate({
        rules: {
            UserName: {
                required: true
            },
            Password: {
                required: true,
                minlength: 6
            }
        },
        messages: {
            UserName: {
                required: "Nhập tài khoản"
            },
            Password: {
                required: "Nhập mật khẩu",
                minlength: "Mật khẩu ít nhất 6 ký tự"
            }
        },
    });
});
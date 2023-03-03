$(document).ready(function () {
    $("#register").validate({
        rules: {
            UserName: {
                required: true
            },
            Email: {
                required: true,
                email: true
            },
            FirstName: {
                required: true
            },
            LastName: {
                required: true
            },
            IdentityCard: {
                required: true,
                number: true
            },
            PhoneNumber: {
                required: true,
                number: true
            },
            Address: {
                required: true
            },
            Password: {
                required: true,
                minlength: 6
            },
            ConfirmPassword: {
                required: true,
                minlength: 6,
                equalTo: "#password"
            }
        },
        messages: {
            UserName: {
                required: "Nhập tài khoản"
            },
            Email: {
                required: "Nhập email",
                email: "Không phải định dạng email"
            },
            FirstName: {
                required: "Nhập họ"
            },
            LastName: {
                required: "Nhập tên"
            },
            IdentityCard: {
                required: "Nhập CCCD",
                number: "Không phải định dạng số"
            },
            PhoneNumber: {
                required: "Nhập số điện thoại",
                number: "Không phải định dạng số"
            },
            Address: {
                required: "Nhập địa chỉ"
            },
            Password: {
                required: "Nhập mật khẩu",
                minlength: "Mật khẩu tối thiếu 6 ký tự"
            },
            ConfirmPassword: {
                required: "Xác nhận mật khẩu",
                minlength: "Mật khẩu tối thiểu 6 ký tự",
                equalTo: "Không trùng khớp với mật khẩu"
            }
        },
    });
});
$(document).ready(function () {
    $("#register").validate({
        rules: {
            UserName: {
                required: true,
                remote: {
                    url: "https://localhost:7059/Auth/CheckUserAvailable",
                    type: 'POST',
                    data:{
                        userName: function(){ return $("#userName").val()}
                    },
                }
            },
            Email: {
                required: true,
                email: true
            },
            FirstName: {
                required: true,
                regex: "^[a-zA-Z]+$"
            },
            LastName: {
                required: true,
                regex: "^[a-zA-Z]+$"
            },
            IdentityCard: {
                required: true,
                number: true,
                maxlength: 12,
                minlength: 12
            },
            PhoneNumber: {
                required: true,
                number: true,
                maxlength: 10,
                minlength: 10,
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
                required: "Nhập tài khoản",
                remote: "Tên đăng nhập đã được sử dụng"
            },
            Email: {
                required: "Nhập email",
                email: "Không phải định dạng email"
            },
            FirstName: {
                required: "Nhập họ",
                text: "Không phải địng dạng chữ"
            },
            LastName: {
                required: "Nhập tên"
            },
            IdentityCard: {
                required: "Nhập CCCD",
                number: "Không phải định dạng số",
                maxlength: "CCCD gồm 12 chữ số",
                minlength: "CCCD gồm 12 chữ số"
            },
            PhoneNumber: {
                required: "Nhập số điện thoại",
                number: "Không phải định dạng số",
                maxlength: "SĐT gồm 10 chữ số",
                minlength: "SĐT gồm 10 chữ số"
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
//Custom validate text input
$.validator.addMethod("regex", function(value, element) 
{
return this.optional(element) || /^[a-z àáãạảăắằẳẵặâấầẩẫậèéẹẻẽêềếểễệđìíĩỉịòóõọỏôốồổỗộơớờởỡợùúũụủưứừửữựỳỵỷỹýÀÁÃẠẢĂẮẰẲẴẶÂẤẦẨẪẬÈÉẸẺẼÊỀẾỂỄỆĐÌÍĨỈỊÒÓÕỌỎÔỐỒỔỖỘƠỚỜỞỠỢÙÚŨỤỦƯỨỪỬỮỰỲỴỶỸÝ]+$/i.test(value);
}, "Không được chứa số hoặc ký tự đặc biệt"); 

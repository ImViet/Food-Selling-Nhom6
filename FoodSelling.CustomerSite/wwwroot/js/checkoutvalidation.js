$(document).ready(function(){
    $("#checkout").validate({
        rules: {
            email: {
                required: true,
                email: true
            },
            name: {
                required: true,
                regex: "^[a-zA-Z]+$"
            },
            phonenumber: {
                required: true,
                number: true,
                maxlength: 10,
                minlength: 10
            },
            address: {
                required: true,
            },
        },
        messages: {
            email: {
                required: "Nhập email",
                email: "Không phải định dạng email"
            },
            name: {
                required: "Nhập họ và tên",
            },
            phonenumber: {
                required: "Nhập số điện thoại",
                number: "Không phải định dạng số",
                maxlength: "SĐT gồm 10 chữ số",
                minlength: "SĐT gồm 10 chữ số"
            },
            address: {
                required: "Nhập địa chỉ nhận hàng",
            },
        },
    });
});
//Custom validate text input
$.validator.addMethod("regex", function(value, element) 
{
return this.optional(element) || /^[a-z àáãạảăắằẳẵặâấầẩẫậèéẹẻẽêềếểễệđìíĩỉịòóõọỏôốồổỗộơớờởỡợùúũụủưứừửữựỳỵỷỹýÀÁÃẠẢĂẮẰẲẴẶÂẤẦẨẪẬÈÉẸẺẼÊỀẾỂỄỆĐÌÍĨỈỊÒÓÕỌỎÔỐỒỔỖỘƠỚỜỞỠỢÙÚŨỤỦƯỨỪỬỮỰỲỴỶỸÝ]+$/i.test(value);
}, "Không được chứa số hoặc ký tự đặc biệt"); 
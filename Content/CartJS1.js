
var select = document.getElementById("list-color");
// Add an onclick event to the select element
select.onclick = function () {
    // Get the currently selected option
    var selectedOption = select.options[select.selectedIndex];

    // Access the value and text of the selected option
    var optionValue = selectedOption.value;
    var optionText = selectedOption.text;
    if (optionValue == "den") {
        document.getElementById("anh").setAttribute("src", "https://ict-cms-prod.s3-sgn09.fptcloud.com/products/2022/11/30/00832906_638054218956629637_ip_14_pro_max_den_1_47d56728f2.jpg");
    }
    else if (optionValue == "bac") {
        document.getElementById("anh").setAttribute("src", "https://ict-cms-prod.s3-sgn09.fptcloud.com/products/2022/11/30/00832907_638054217303176240_ip_14_pro_max_bac_1_989d9f40b7.jpg");

    }
    else if (optionValue == "vang") {
        document.getElementById("anh").setAttribute("src", "https://ict-cms-prod.s3-sgn09.fptcloud.com/products/2022/11/30/00832908_638054222139728415_ip_14_pro_max_vang_1_769511bcae.jpg");

    }
    else if (optionValue == "tim") {
        document.getElementById("anh").setAttribute("src", "https://ict-cms-prod.s3-sgn09.fptcloud.com/products/2022/11/30/00832909_638054220350691584_ip_14_pro_max_tim_1_2826acf702.jpg");

    }
};
//===========================================

//TongTien
var oldPrice = parseFloat(document.getElementById("oldPrice").innerHTML);
var newPrice = oldPrice - 3;

window.onload = function () {
    document.getElementById("newPrice").innerHTML = (newPrice * 1000000).toLocaleString().replace(/,/g, '.') + "đ";
    document.getElementById("newPricePayProduct").innerHTML = (newPrice * 1000000).toLocaleString().replace(/,/g, '.') + "đ";
}



var voucher1 = true, voucherpay1 = false; //voucher lam thay doi price
var voucherpay3 = false, voucherpay2 = false; //voucher khong lam thay doi price

var soLuong = 1, soluongcu = 1;
document.getElementById("soluong").onchange = function () {
    var soluong = parseFloat(this.value);
    soLuong = soluong; //lay soluong ra ngoai function sau khi da nhan nut

    newPrice = (newPrice / soluongcu) * soluong;
    oldPrice = (oldPrice / soluongcu) * soluong;

    soluongcu = soluong;
    document.getElementById("newPrice").innerHTML = (newPrice * 1000000).toLocaleString().replace(/,/g, '.') + "đ";
    if (document.getElementById("oldPrice").innerHTML.length > 0) {
        document.getElementById("oldPrice").innerHTML = (oldPrice * 1000000).toLocaleString().replace(/,/g, '.') + "đ";
    }
    document.getElementById("total-price").innerHTML = (oldPrice * 1000000).toLocaleString().replace(/,/g, '.') + "đ";
}


document.getElementById("voucher1").onclick = function () {
    if (voucher1) {
        voucher1 = false; this.checked = false;
        newPrice = newPrice + 3 * soLuong;
    }
    else {
        voucher1 = true; this.checked = true;
        newPrice = newPrice - 3 * soLuong;
    }

    NPandOP();
}

function NPandOP() {
    if (newPrice == oldPrice) {
        document.getElementById("oldPrice").innerHTML = null;
    }
    else if (newPrice != oldPrice && document.getElementById("oldPrice").innerHTML.length == 0) {
        document.getElementById("oldPrice").innerHTML = (oldPrice * 1000000).toLocaleString().replace(/,/g, '.') + "đ";
    }
    document.getElementById("newPrice").innerHTML = (newPrice * 1000000).toLocaleString().replace(/,/g, '.') + "đ";
}


document.getElementById("voucher-pay-1").onclick = function () {
    if (voucherpay1) {
        voucherpay1 = false; this.checked = false;
        newPrice = newPrice + 1 * soLuong;
        document.getElementById("voucher-pay-2").toggleAttribute("disabled");
        document.getElementById("voucher-pay-3").toggleAttribute("disabled");
    }
    else {
        voucherpay1 = true; this.checked = true;
        newPrice = newPrice - 1 * soLuong;
        document.getElementById("voucher-pay-2").toggleAttribute("disabled");
        document.getElementById("voucher-pay-3").toggleAttribute("disabled");
    }

    NPandOP();
}
document.getElementById("voucher-pay-2").onclick = function () {
    if (voucherpay2) {
        voucherpay2 = false; this.checked = false;
        document.getElementById("voucher-pay-3").toggleAttribute("disabled");
        document.getElementById("voucher-pay-1").toggleAttribute("disabled");
    }
    else {
        voucherpay2 = true; this.checked = true;
        document.getElementById("voucher-pay-3").toggleAttribute("disabled");
        document.getElementById("voucher-pay-1").toggleAttribute("disabled");
    }
}
document.getElementById("voucher-pay-3").onclick = function () {
    if (voucherpay3) {
        voucherpay3 = false; this.checked = false;
        document.getElementById("voucher-pay-2").toggleAttribute("disabled");
        document.getElementById("voucher-pay-1").toggleAttribute("disabled");
    }
    else {
        voucherpay3 = true; this.checked = true;
        document.getElementById("voucher-pay-2").toggleAttribute("disabled");
        document.getElementById("voucher-pay-1").toggleAttribute("disabled");
    }
}


//=====================================
document.getElementById("GHTN").onclick = function () {
    document.getElementById("form-customer").innerHTML = "<div class=\"customer-info-hd\"><p id=\"thong-tin-nhan-hang\">Thông tin khách hàng</p> <span> <a href=\"#\">Thay đổi</a> </span></div> <div class=\"customer-info-body\"><div id=\"nguoi-dat-hang\"><div>Người đặt hàng</div><div class=\"name-phoneNumber\"><p style=\"margin-bottom:5px;\">Anh Đoàn Tấn Lộc</p>0911949133</div></div></div><div class=\"customer-info-ft\"><div id=\"nguoinhan\"><div>Người nhận</div><div class=\"name-phoneNumber\"><p style=\"margin-bottom:5px;\">Anh Đoàn Tấn Lộc</p>0911949133</div></div></div>"
    document.getElementById("form").innerHTML = "<p id=\"form-title\">Địa chỉ nhận hàng</p> <div class=\"row\" ><div class=\"col-sm-4\"><input type=\"text\" style=\"width: 240px; height: 56px;\" placeholder=\"Nhập Tỉnh/Thành Phố\" /></div><div class=\"col-sm-4\"><input type=\"text\" style=\"width:240px;height:56px;\" placeholder=\"Nhập Quận/Huyện\" /></div><div class=\"col-sm-4\"><input type=\"text\" style=\"width:240px;height:56px;\" placeholder=\"Nhập Phường/Xã\" /></div></div ><div style=\"margin-top:15px;\" class=\"row\"><div class=\"col-sm-12\"><input type=\"text\" style=\"width:740px;height:56px;\" placeholder=\"Nhập địa chỉ, tên đường\" /></div></div><div class=\"time\"><div class=\"row\"><div class=\"col-sm-4\"><p id=\"time-text\">Thời gian giao hàng</p></div><div class=\"col-sm-8\"><select><option value=\"value\">Chỉ giao hàng giờ hành chính</option><option value=\"value\">Tất cả ngày trong tuần</option></select></div>   </div></div>";
}
document.getElementById("NTCH").onclick = function () {
    document.getElementById("form-customer").innerHTML = "<div class=\"customer-info-hd\"><p id =\"thong-tin-nhan-hang\"> Thông tin khách hàng</p ><span><a href=\"#\">Thay đổi</a></span></div ><div class=\"customer-info-body\"><div id=\"nguoi-dat-hang\"><div>Người đặt hàng</div><div class=\"name-phoneNumber\"><p style=\"margin-bottom:5px;\">Anh Đoàn Tấn Lộc</p>0911949133</div></div></div>";
    document.getElementById("form").innerHTML = "<p id=\"form-title\">Chọn cửa hàng nhận sản phẩm</p> <div class=\"row\"><div class=\"col-sm-6\"><input type=\"text\" style=\"width: 360px; height: 56px;\" placeholder=\"Nhập Tỉnh/Thành Phố\" /></div><div class=\"col-sm-6\"><input type=\"text\" style=\"width:360px;height:56px;\" placeholder=\"Nhập Quận/Huyện\" /></div></div > ";
}

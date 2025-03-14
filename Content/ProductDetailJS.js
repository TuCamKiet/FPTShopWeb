
var ListImg = document.querySelector('.ListImgTitanXanh');
var maxImg = document.querySelectorAll('.Img_OfBoxTitanXanh').length - 1;
var btnBottom = document.querySelectorAll('.btnBottom_bg');
var fuk = 0;
btnBottom[fuk].classList.add('activeSlideMain');
checkStatus_btnBorrom = false;
var index;

function SlidePre() {
    for (var i = 0; i < btnBottom.length; i++) {
        btnBottom[i].classList.remove('activeSlideMain');
    }
    if (checkStatus_btnBorrom === false) {
        fuk = fuk - 1;
        if (fuk < 0) {
            fuk = 0;
        }
        let gocluat = -585 * fuk;
        ListImg.style.left = gocluat + 'px';
        btnBottom[fuk].classList.add('activeSlideMain');
    }
    else {
        index--;
        if (index < 0) { index = 0 }
        let soon = -585 * index;
        ListImg.style.left = soon + 'px';
        btnBottom[index].classList.add('activeSlideMain');
    }
}

function SlideNext() {
    for (var i = 0; i < btnBottom.length; i++) {
        btnBottom[i].classList.remove('activeSlideMain');
    }
    if (checkStatus_btnBorrom === false) {
        fuk = fuk + 1;
        if (fuk > maxImg) {
            fuk = maxImg;
        }
        let g = -585 * fuk;
        ListImg.style.left = g + 'px';
        btnBottom[fuk].classList.add('activeSlideMain');
    }
    else {
        index++;
        if (index > maxImg) { index = maxImg; }
        let seen = -585 * index;
        ListImg.style.left = seen + 'px';
        btnBottom[index].classList.add('activeSlideMain');
    }
}
for (var i = 0; i < btnBottom.length; i++) {
    btnBottom[i].addEventListener('click', function () {
        for (var j = 0; j < btnBottom.length; j++) {
            btnBottom[j].classList.remove('activeSlideMain');
        }
        index = parseInt(this.getAttribute('data-index'));
        this.classList.add('activeSlideMain');
        let t = -585 * index;
        ListImg.style.left = t + 'px';
        checkStatus_btnBorrom = true;
    });
}



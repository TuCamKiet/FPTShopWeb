/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */
function name0() {
SlidePre()
}
/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */
function name1() {
SlideNext()
}
/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

                                        document.addEventListener('DOMContentLoaded', function () {
                                            var frameS = document.querySelector('.FrameSildeMain');
                                            var cliclo = document.querySelectorAll('.img_titanXanh img');
                                            var imgs = document.querySelectorAll('.Img_OfBoxTitanXanh img');
                                            var cl = document.querySelector('.ListImgTitanXanh');
                                            for (var cc = 0; cc < @color.Count; cc++) {
                                                (function (hax) {
                                                    cliclo[cc].addEventListener('click', function () {
                                                        var conc = -585 * hax;
                                                        ListImg.style.left = conc + 'px';
                                                        for (var cail = 0; cail < btnBottom.length; cail++) {
                                                            btnBottom[cail].classList.remove('activeSlideMain');
                                                        }
                                                        btnBottom[hax].classList.add('activeSlideMain');
                                                });
                                                    })(cc)
                                            }

                                        })
                                    
/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

                                        var click = document.querySelectorAll('.tickThis');
                                        var conformClick = document.querySelectorAll('.conformThis');
                                        let exams = false;
                                        document.addEventListener('DOMContentLoaded', function () {
                                            for (var i = 0; i < click.length; i++) {
                                                (function (index) {
                                                    click[index].addEventListener('click', function () {
                                                        conformClick[index].style.display = 'block';
                                                        click[index].style.display = 'none';
                                                        conformClick[1].style.display = 'none';
                                                        click[1].style.display = 'block';
                                                        if (index === 1) {
                                                            console.log(index);
                                                            conformClick[index].style.display = 'block';
                                                            click[index].style.display = 'none';
                                                            conformClick[0].style.display = 'none';
                                                            click[0].style.display = 'block';
                                                        }
                                                    });
                                                })(i);
                                            }
                                            for (var i = 0; i < conformClick.length; i++) {
                                                (function (index) {
                                                    conformClick[index].addEventListener('click', function () {
                                                        conformClick[index].style.display = 'none';
                                                        click[index].style.display = 'block';
                                                    });
                                                })(i);
                                            }
                                        });
                                    
/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

                            var P_Special = document.querySelector('#Price_Special');
                            var P_Standart = document.querySelector('#Price_Standart')
                            var Content_PStandart = document.querySelector('#content_Price_Standart');
                            var Content_PSpecial = document.querySelector('#content_Price_Special');
                            var addClassLeft = document.querySelector('.left_price_product_iPhone15_ProMax');
                            var addClassRight = document.querySelector('.right_price_product_iPhone15_ProMax');
                            addClassLeft.classList.add('kiki');
                            addClassLeft.classList.add('koko');
                            document.addEventListener('DOMContentLoaded', function () {

                                P_Standart.addEventListener('click', function () {
                                    Content_PStandart.style.display = 'block';
                                    Content_PSpecial.style.display = 'none';
                                    P_Special.style.backgroundColor = '#f8f9fa';
                                    P_Standart.style.backgroundColor = 'white';
                                    P_Standart.style.border = '2px solid #e55055';
                                    P_Standart.style.borderBottom = 'none';
                                    P_Special.style.border = 'none';
                                    P_Special.style.borderBottom = '2px solid #e55055';
                                    addClassLeft.classList.add('kiki');
                                    addClassRight.classList.remove('kiki');
                                    addClassLeft.classList.add('koko');
                                    addClassRight.classList.remove('koko');
                                })
                                P_Special.addEventListener('click', function () {
                                    Content_PStandart.style.display = 'none';
                                    Content_PSpecial.style.display = 'block';
                                    P_Special.style.backgroundColor = 'white';
                                    P_Standart.style.backgroundColor = '#f8f9fa';
                                    P_Special.style.border = '2px solid #e55055';
                                    P_Special.style.borderBottom = 'none';
                                    P_Standart.style.border = 'none';
                                    P_Standart.style.borderBottom = '2px solid #e55055';
                                    addClassLeft.classList.remove('kiki');
                                    addClassRight.classList.add('kiki');
                                    addClassLeft.classList.remove('koko');
                                    addClassRight.classList.add('koko');
                                });
                            });

                            var checkClick = [];
                            var BxT_MF_list = document.querySelectorAll('.boxText_modrenFour');
                            var BxT_CT_list = document.querySelectorAll('.boxText_creative');
                            var BxT_SP_list = document.querySelectorAll('.boxText_superProduct');
                            var BxT_MT = document.querySelector('.boxText_modrenThree');

                            var tab_MF_list = document.querySelectorAll('.Tab_modrenFour');
                            var tab_C_list = document.querySelectorAll('.Tab_Creative');
                            var tab_SP_list = document.querySelectorAll('.Tab_superProduct');
                            var tab_MT = document.querySelector('.Tab_modrenThree');

                            for (let i = 0; i < tab_MF_list.length; i++) {
                                tab_MF_list[i].addEventListener('click', function () {
                                    if (checkClick[i] === true) {
                                        tab_MF_list[i].style.backgroundColor = 'white';
                                        tab_MF_list[i].style.borderTop = '3px solid #cb1c22';
                                        BxT_MF_list[i].style.display = 'block';
                                        tab_C_list[i].style.backgroundColor = '';
                                        tab_C_list[i].style.borderTop = '';
                                        BxT_CT_list[i].style.display = 'none';
                                        BxT_SP_list[i].style.display = 'none';
                                        tab_SP_list[i].style.backgroundColor = '';
                                        tab_SP_list[i].style.borderTop = '';
                                        tab_MT.style.backgroundColor = '';
                                        tab_MT.style.borderTop = '';
                                        BxT_MT.style.display = 'none';
                                    }
                                    checkClick[i] = true;
                                });
                            }
                            for (let i = 0; i < tab_C_list.length; i++) {
                                tab_C_list[i].addEventListener('click', function () {
                                    tab_C_list[i].style.backgroundColor = 'white';
                                    tab_C_list[i].style.borderTop = '3px solid #cb1c22';
                                    tab_MF_list[i].style.borderTop = '';
                                    tab_MF_list[i].style.backgroundColor = '';
                                    BxT_MF_list[i].style.display = 'none';
                                    BxT_CT_list[i].style.display = 'block';
                                    if (checkClick[i] === true) {
                                        tab_SP_list[i].style.backgroundColor = '';
                                        tab_SP_list[i].style.borderTop = '';
                                        BxT_SP_list[i].style.display = 'none';
                                        tab_MT.style.backgroundColor = '';
                                        tab_MT.style.borderTop = '';
                                        BxT_MT.style.display = 'none';
                                    }
                                    checkClick[i] = true;
                                });
                            }
                            for (let i = 0; i < tab_SP_list.length; i++) {
                                tab_SP_list[i].addEventListener('click', function () {
                                    tab_SP_list[i].style.backgroundColor = 'white';
                                    tab_SP_list[i].style.borderTop = '3px solid #cb1c22';
                                    BxT_SP_list[i].style.display = 'block';
                                    BxT_MF_list[i].style.display = 'none';
                                    tab_MF_list[i].style.backgroundColor = '';
                                    tab_MF_list[i].style.borderTop = '';
                                    if (checkClick[i] === true) {
                                        tab_C_list[i].style.backgroundColor = '';
                                        tab_C_list[i].style.borderTop = '';
                                        BxT_CT_list[i].style.display = 'none';
                                        tab_MT.style.backgroundColor = '';
                                        tab_MT.style.borderTop = '';
                                        BxT_MT.style.display = 'none';
                                    }
                                    checkClick[i] = true;
                                });
                            }
                            tab_MT.addEventListener('click', function () {
                                tab_MT.style.backgroundColor = 'white';
                                tab_MT.style.borderTop = '3px solid #cb1c22';
                                BxT_MT.style.display = 'block';
                                for (let i = 0; i < tab_MF_list.length; i++) {
                                    BxT_MF_list[i].style.display = 'none';
                                    tab_MF_list[i].style.backgroundColor = '';
                                    tab_MF_list[i].style.borderTop = '';
                                    if (checkClick[i] === true) {
                                        tab_C_list[i].style.backgroundColor = '';
                                        tab_C_list[i].style.borderTop = '';
                                        BxT_CT_list[i].style.display = 'none';
                                        tab_SP_list[i].style.backgroundColor = '';
                                        tab_SP_list[i].style.borderTop = '';
                                        BxT_SP_list[i].style.display = 'none';
                                    }
                                    checkClick[i] = true;
                                }
                            });
                        
/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

                            var IndexImg = 0;
                            var List_Img = document.querySelectorAll('.ImgCP');
                            var Btn_Control = document.querySelectorAll('.btn_controlImg');
                            var CheckStatus = true;
                            carousel_left_characteristic();
                            function carousel_left_characteristic() {
                                if (CheckStatus) {
                                    for (var i = 0; i < List_Img.length; i++) {
                                        List_Img[i].classList.remove('active');
                                        Btn_Control[i].classList.remove('bg');
                                    }
                                    IndexImg++;
                                    if (IndexImg > List_Img.length) { IndexImg = 1 }
                                    List_Img[IndexImg - 1].classList.add('active');
                                    Btn_Control[IndexImg - 1].classList.add('bg');
                                    setTimeout(carousel_left_characteristic, 2500);
                                }
                            }
                            for (var i = 0; i < Btn_Control.length; i++) {
                                (function (index) {
                                    Btn_Control[index].addEventListener('click', function () {
                                        CheckStatus = false;
                                        for (var j = 0; j < List_Img.length; j++) {
                                            List_Img[j].classList.remove('active');
                                            Btn_Control[j].classList.remove('bg');
                                        }
                                        List_Img[index].classList.add('active');
                                        Btn_Control[index].classList.add('bg');
                                    });
                                })(i);
                            }
                        
/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

                    var btn_view = document.getElementById('btn_view');
                    btn_view.addEventListener("click", function () {
                        document.querySelector('.box_left_characteristic_product_iP15_ProMax').style.overflow = 'initial';
                        document.querySelector('.box_header_product_iP15_ProMax').setAttribute('style', 'height:fit-content');
                        document.querySelector('.box_left_characteristic_product_iP15_ProMax').setAttribute('style', 'height:fit-content')
                        document.querySelector('.btn_view_all_content_boxLeft').remove();
                    });
                
/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

            var switch_cash_list = document.querySelectorAll('.switch_cash');
            var hidden_more_info_list = document.querySelectorAll('.hidden_more_info');
            var background_hidden_content_list = document.querySelectorAll('.manager_questions_product_iP15_ProMax');
            let Check_Bool = [];
            for (let i = 0; i < switch_cash_list.length; i++) {
                switch_cash_list[i].addEventListener("click", function () {
                    if (Check_Bool[i]) {
                        switch_cash_list[i].textContent = '+';
                        hidden_more_info_list[i].style.display = 'none';
                        background_hidden_content_list[i].style.backgroundColor = '';
                    }
                    else {
                        switch_cash_list[i].textContent = '-';
                        hidden_more_info_list[i].style.display = 'block';
                        background_hidden_content_list[i].style.backgroundColor = '#f8f9fa';
                    }
                    Check_Bool[i] = !Check_Bool[i];
                });
            }
        
/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */

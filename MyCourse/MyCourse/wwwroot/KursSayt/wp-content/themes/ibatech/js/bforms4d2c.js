//CHECKBOX FOR BUTTON
$(document).ready(function () {
//    $('.btn-extra').prop("disabled", true);
    $('#personalData').change(function () {
        if (this.checked) {
            $('.btn-extra').prop("disabled", false);
        } else {
            $('.btn-extra').prop("disabled", true);
        }
    });
});
//contact forms
$(document).ready(function () {
    //contactform
    if (document.querySelector('#wpcf7-f54-o1') || document.querySelector('#wpcf7-f56-o1') || document.querySelector('#wpcf7-f57-o1')) {

        if (document.querySelector('#wpcf7-f54-o1')) {
            var contactform = document.querySelector('#wpcf7-f54-o1');
        } else if (document.querySelector('#wpcf7-f56-o1')) {
            var contactform = document.querySelector('#wpcf7-f56-o1');
        } else if (document.querySelector('#wpcf7-f57-o1')) {
            var contactform = document.querySelector('#wpcf7-f57-o1');
        } else {
            var contactform = "";
        }


        contactform.addEventListener('wpcf7mailsent', function (event) {
            $('.app-modal').css('display', 'flex');
        }, false);
        $('.btn-extra').click(function () {
            $('.app-modal').css('display', 'none');
        });
    }
});

//required fields
$(document).ready(function () {
    var form = $('.app-form');
    var formName = form.find('#formName');
    var formAge = form.find('#formAge');
    var zipCode = form.find('#zipCode');
    var formMail = form.find('#formMail');
    var formProgram = form.find('#formProgram');
    var formSchedule = form.find('#formSchedule');
    var formLetter = form.find('#formLetter');
    var btn_extra = form.find('.btn-extra');

    btn_extra.click(function () {
        var formNameval = formName.val();
        var formAgeval = formAge.val();
        var zipCodeval = zipCode.val();
        var formMailval = formMail.val();
        var formProgramval = formProgram.val();
        var formScheduleval = formSchedule.val();
        var formLetterval = formLetter.val();

        function formscrol(input) { // аргументы: from, text
            $('html, body').animate({
                scrollTop: (input.offset().top - 100)
            }, 800);
        }

        if (formNameval.length == 0) {
            formName.css('border', '2px solid #ff0000');
            //$('<div class="vac_errors">Это обязательное поле</div>').insertAfter(formName.parent());
            formscrol(formName);
            return false;
        } else {
            formName.css('border', '1px solid #f7f7f7');
            //$('.vac_errors').html('');
        }
        if (formAgeval.length == 0) {
            formAge.css('border', '2px solid #ff0000');
            //$('<div class="vac_errors">Это обязательное поле</div>').insertAfter(formAge.parent());
            formscrol(formName);
            return false;
        } else {
            formAge.css('border', '1px solid #f7f7f7');
            //$('.vac_errors').html('');
        }
        if (zipCodeval.length == 0) {
            zipCode.css('border', '2px solid #ff0000');
            //$('<div class="vac_errors">Это обязательное поле</div>').insertAfter(zipCode.parent());
            formscrol(formName);
            return false;
        } else {
            zipCode.css('border', '1px solid #f7f7f7');
            //$('.vac_errors').html('');
        }
        if (formMailval.length == 0) {
            formMail.css('border', '2px solid #ff0000');
            //$('<div class="vac_errors">Это обязательное поле</div>').insertAfter(formMail.parent());
            formscrol(formName);
            return false;
        } else {
            formMail.css('border', '1px solid #f7f7f7');
            //$('.vac_errors').html('');
        }
        if (formProgramval.length == 0) {
            formProgram.css('border', '2px solid #ff0000');
            //$('<div class="vac_errors">Это обязательное поле</div>').insertAfter(formProgram.parent());
            formscrol(formName);
            return false;
        } else {
            formProgram.css('border', '1px solid #f7f7f7');
            //$('.vac_errors').html('');
        }
        if (formScheduleval.length == 0) {
            formSchedule.css('border', '2px solid #ff0000');
            //$('<div class="vac_errors">Это обязательное поле</div>').insertAfter(formSchedule.parent());
            formscrol(formName);
            return false;
        } else {
            formSchedule.css('border', '1px solid #f7f7f7');
            //$('.vac_errors').html('');
        }
        if (formLetterval.length == 0) {
            formLetter.css('border', '2px solid #ff0000');
            //$('<div class="vac_errors">Это обязательное поле</div>').insertAfter(formLetter.parent());
            formscrol(formName);
            return false;
        } else {
            formLetter.css('border', '1px solid #f7f7f7');
            //$('.vac_errors').html('');
        }
    });
});

$(document).ready(function () {
    $('.navbar__menu #lang_choice_1').addClass("navbar__lang-list").css({'text-transform': 'capitalize'});
});

wow = new WOW({
    boxClass: 'wow', // default
    animateClass: 'animated', // default
    offset: 0, // default
    mobile: true, // default
    live: true        // default
});
wow.init();


$(document).ready(function () {
    var mySwiper = new Swiper('.swiper-container', {
        // Optional parameters
        direction: 'horizontal',
        loop: true,
        autoplay: {
            delay: 6000,
        },
        slidesPerView: 1,
        spaceBetween: 30,
        breakpoints: {
        1200: {
          slidesPerView: 2,
          spaceBetween: 20,
        },

        },
        // If we need pagination
//    pagination: {
//      el: '.swiper-pagination',
//    },

        // Navigation arrows
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },

        // And if we need scrollbar
//    scrollbar: { 
//      el: '.swiper-scrollbar', 
//    }, 
    });
});
"use strict";

//function slowScroll(triggerSymbol, headerClassName) {
//  var allLinks = document.querySelectorAll('a');
//  allLinks.forEach(function (link) {
//    if (link.hash[0] === triggerSymbol) {
//      link.onclick = function (e) {
//        e.preventDefault();
//        slowScrolling(e);
//      };
//    }
//  });
//
//  function slowScrolling(event) {
//    var id = event.target.hash,
//        to = document.querySelector(id).offsetTop - document.querySelector(".".concat(headerClassName)).clientHeight - 10;
//    window.scroll({
//      top: to,
//      left: 0,
//      behavior: 'smooth'
//    });
//  }
//}

// function manageNavLinks() {
  // if (document.location.pathname !== '/' || document.location.pathname !== '/index.html') {
    // var nav = document.querySelector('.navbar__menu-wrapper');

    // var navHandle = function navHandle(e) {
      // e.preventDefault();
      // debugger;

      // if (e.target.hash === '#programs' || e.target.hash === '#stages' || e.target.hash === '#about') {
        // var language = localStorage.getItem('lang') || 'az';

        // switch (localStorage.getItem('lang')) {
          // case 'az':
            // window.location.assign("".concat(document.location.origin, "/").concat(e.target.hash));
            // break;

          // case "en":
            // window.location.assign("".concat(document.location.origin, "/en/").concat(e.target.hash));
            // break;

          // case 'ru':
            // window.location.assign("".concat(document.location.origin, "/ru/").concat(e.target.hash));
            // break;

          // default:
            // localStorage.setItem('lang', 'az');
            // window.location.assign("".concat(document.location.origin, "/").concat(e.target.hash));
            // break;
        // }
      // } else if (e.target.parentElement.tagName === 'LI') {
        // window.location.assign(e.target.href);
      // } else {
        // window.scroll({
          // top: document.querySelector(e.target.hash).offsetTop,
          // left: 0,
          // behavior: 'smooth'
        // });
      // }
    // };

    // nav.addEventListener('click', navHandle);
    // nav.addEventListener('touchstart', navHandle);
    // nav.addEventListener('mousedown', navHandle);
  // }
// }

// (function () {
  // if (!localStorage.getItem('lang')) {
    // localStorage.setItem('lang', "az");
  // }
// })();

// manageNavLinks();
//slowScroll('#', 'navbar'); // // ************************************************************************
// //  about
// // ************************************************************************
//
// const sponsor1 = document.querySelector('.about-sponsors__sponsor-1');
// const sponsor2 = document.querySelector('.about-sponsors__sponsor-2');
//
// if(sponsor1) {
//     sponsor1.addEventListener('click', () => {
//         const modalWindowBank = document.getElementById('modal-bank');
//         modalWindowBank.style.visibility = 'visible';
//     });
// }
// if(sponsor2) {
//     sponsor2.addEventListener('click', () => {
//         const modalWindowDanit = document.getElementById('modal-danit');
//         modalWindowDanit.style.visibility = 'visible';
//     });
// }
// // hide any of show modal window
// document.querySelectorAll('.modal-window__box .modal-btn-close').forEach((btn) => {
//     btn.addEventListener('click', (e) => {
//         e.currentTarget.parentNode.parentNode.style.visibility = 'hidden';
//     });
// });
//
// // click on underlay closing itself
// document.querySelectorAll('.modal-window__underlay').forEach((btn) => {
//     btn.addEventListener('click', (e) => {
//         if (e.target.classList.contains('modal-window__underlay')) {
//             e.currentTarget.style.visibility = 'hidden';
//         }
//     });
// });

function mask(inputName, mask, evt) {
  try {
    var text = document.getElementById(inputName);
    var value = text.value;

    try {
      var e = evt.which ? evt.which : event.keyCode;

      if (e == 46 || e == 8) {
        text.value = "";
        return;
      }
    } catch (e1) {}

    var literalPattern = /[0\*]/;
    var numberPattern = /[0-9]/;
    var newValue = "";

    for (var vId = 0, mId = 0; mId < mask.length;) {
      if (mId >= value.length) break; // Number expected but got a different value, store only the valid portion

      if (mask[mId] == '0' && value[vId].match(numberPattern) == null) {
        break;
      } // Found a literal


      while (mask[mId].match(literalPattern) == null) {
        if (value[vId] == mask[mId]) break;
        newValue += mask[mId++];
      }

      newValue += value[vId++];
      mId++;
    }

    text.value = newValue;
  } catch (e) {}
}

//var form = document.querySelector('#appForm');
//form.addEventListener('submit', function (e) {
//  e.preventDefault();
//  var name = document.querySelector('#formName').value;
//  var age = document.querySelector('#formAge').value;
//  var tel = document.querySelector('#zipCode').value;
//  var email = document.querySelector('#formMail').value;
//  var program = document.querySelector('#formProgram').value;
//  var schedule = document.querySelector('#formSchedule').value;
//  var letter = document.querySelector('#formLetter').value;
//  var url = new URL('https://script.google.com/macros/s/AKfycbzKBJ4yX6b8mwtzJmaPtGew0wOCthTeceoXNAidAJE53y_vsA/exec');
//  url.searchParams.append('name', name);
//  url.searchParams.append('age', age);
//  url.searchParams.append('tel', tel);
//  url.searchParams.append('mail', email);
//  url.searchParams.append('program', program);
//  url.searchParams.append('schedule', schedule);
//  url.searchParams.append('letter', letter);
//  document.querySelector('#formName').value = '';
//  document.querySelector('#formAge').value = '';
//  document.querySelector('#zipCode').value = '';
//  document.querySelector('#formMail').value = '';
//  document.querySelector('#formLetter').value = '';
//  document.querySelector('.app-form > .btn-extra').disabled = true;
//  fetch(url).then(function () {
//    var responseMessages = {
//      az: "Qeydiyyat \xFC\xE7\xFCn t\u0259\u015F\u0259kk\xFCr\xFCm\xFCz\xFC bildiririk. Sizin \u0259riz\u0259niz q\u0259bul olunmu\u015F v\u0259 bax\u0131lmaq \xFC\xE7\xFCn t\u0259qdim edilmi\u015Fdir. Yax\u0131n zamanlarda \u0259m\u0259kda\u015Flar\u0131m\u0131z sizinl\u0259 \u0259laq\u0259 saxlayacaqlar.\n\nH\u0259r hans\u0131 suallar\u0131n\u0131zla ba\u011Fl\u0131 +994(12)937 n\xF6mr\u0259li M\u0259lumat M\u0259rk\u0259zin\u0259 z\u0259ng ed\u0259 bil\u0259rsiniz.\n\nH\xF6rm\u0259tl\u0259, IBA Tech komandas\u0131",
//      en: "Thank you for registration. Your application has been accepted and sent for processing.\nOur manager will contact you shortly.\n\nIf you have any questions, please call + 994 (12) 937.\n\nWith kind regards,\nThe IBA Tech Academy Team",
//      ru: "\u0421\u043F\u0430\u0441\u0438\u0431\u043E \u0437\u0430 \u0440\u0435\u0433\u0438\u0441\u0442\u0440\u0430\u0446\u0438\u044E. \u0412\u0430\u0448\u0430 \u0437\u0430\u044F\u0432\u043A\u0430 \u043F\u043E\u043B\u0443\u0447\u0435\u043D\u0430 \u0438 \u043E\u0442\u043F\u0440\u0430\u0432\u043B\u0435\u043D\u0430 \u043D\u0430 \u043E\u0431\u0440\u0430\u0431\u043E\u0442\u043A\u0443.\n\u0412 \u0431\u043B\u0438\u0436\u0430\u0439\u0448\u0435\u0435 \u0432\u0440\u0435\u043C\u044F \u0441 \u0432\u0430\u043C\u0438 \u0441\u0432\u044F\u0436\u0435\u0442\u0441\u044F \u043D\u0430\u0448 \u043C\u0435\u043D\u0435\u0434\u0436\u0435\u0440.\n\n\u0415\u0441\u043B\u0438 \u0443 \u0432\u0430\u0441 \u0432\u043E\u0437\u043D\u0438\u043A\u043B\u0438 \u0432\u043E\u043F\u0440\u043E\u0441\u044B, \u0442\u0440\u0435\u0431\u0443\u044E\u0449\u0438\u0435 \u0441\u0440\u043E\u0447\u043D\u043E\u0433\u043E \u043E\u0442\u0432\u0435\u0442\u0430, \u0432\u044B \u043C\u043E\u0436\u0435\u0442\u0435 \u043F\u043E\u0437\u0432\u043E\u043D\u0438\u0442\u044C \u043F\u043E \u0442\u0435\u043B\u0435\u0444\u043E\u043D\u0443 + 994 (12) 937.\n\n\u0421 \u0443\u0432\u0430\u0436\u0435\u043D\u0438\u0435\u043C, \n\u043A\u043E\u043C\u0430\u043D\u0434\u0430 IBA Tech Academy"
//    };
//    var message = responseMessages.az;
//    var applicationCopy = "name: ".concat(name, ";\n    email: ").concat(email, ";\n    age: ").concat(age, ";\n    tel: ").concat(tel, ";\n    program: ").concat(program, ";\n    schedule: ").concat(schedule, ";\n    motivation letter: ").concat(letter, ";");
//
//    switch (true) {
//      case window.location.pathname.includes('az'):
//        message = responseMessages.az;
//        break;
//
//      case window.location.pathname.includes('en'):
//        message = responseMessages.en;
//        break;
//
//      case window.location.pathname.includes('ru'):
//        message = responseMessages.ru;
//        break;
//
//      default:
//        message = responseMessages.az;
//    }
//
//    fetch("/email", {
//      method: 'POST',
//      headers: {
//        "Content-type": "application/x-www-form-urlencoded; charset=UTF-8"
//      },
//      body: "sendTo=".concat(email, "&message=").concat(message)
//    }).then(function (res) {
//      fetch("/email", {
//        method: 'POST',
//        headers: {
//          "Content-type": "application/x-www-form-urlencoded; charset=UTF-8"
//        },
//        body: "sendTo=apply@ibatech.az&message=".concat(applicationCopy)
//      });
//    }).then(function (res) {
//      var modal = document.querySelector('.app-modal');
//      modal.style.display = 'flex';
//
//      document.querySelector('.app-modal__msg > .btn-extra').onclick = function (e) {
//        document.querySelector('.app-modal').style.display = 'none';
//      };
//    }, function (error) {
//      console.dir(error);
//    });
//  });
//}); 
//
// ************************************************************************

var accordion = function (element) {
  var _getItem = function _getItem(elements, className) {
    var element = undefined;
    elements.forEach(function (item) {
      if (item.classList.contains(className)) {
        element = item;
      }
    });
    return element;
  };

  return function () {
    var _mainElement = {},
        _items = {},
        _contents = {};

    var _actionClick = function _actionClick(e) {
      if (!e.target.classList.contains('accordion-item-header')) {
        return;
      }

      e.preventDefault();

      var header = e.target,
          item = header.parentElement,
          itemActive = _getItem(_items, 'show');

      if (itemActive === undefined) {
        item.classList.add('show');
      } else {
        itemActive.classList.remove('show');

        if (itemActive !== item) {
          item.classList.add('show');
        }
      }
    },
        _setupListeners = function _setupListeners() {
      _mainElement.addEventListener('click', _actionClick);
    };

    return {
      init: function init() {
        var element = arguments.length > 0 && arguments[0] !== undefined ? arguments[0] : {};

        try {
          _mainElement = typeof element === 'string' ? document.querySelector(element) : element;
          _items = _mainElement.querySelectorAll('.accordion-item');

          _setupListeners();
        } catch (e) {}
      }
    };
  };
}();

var accordion1 = accordion();
accordion1.init('#accordion'); // ************************************************************************
// Handle Change Languages

//УДАЛИЛ
//var langList = document.getElementById('navbar__lang-list');
//var langStorage = localStorage.getItem('lang');
//langList.addEventListener('change', function () {
//  function redirectURL(toFolder) {
//    var resURL = '';
//
//    if (window.location.pathname.includes('frontend')) {
//      resURL = window.location.origin.concat(toFolder).concat('frontend');
//    } else if (window.location.pathname.includes('backend')) {
//      resURL = window.location.origin.concat(toFolder).concat('backend');
//    } else {
//      resURL = window.location.origin.concat(toFolder);
//    }
//
//    return resURL;
//  }
//
//  switch (langList.value) {
//    case 'az':
//      localStorage.setItem('lang', 'az');
//      window.location.assign(redirectURL('/'));
//      break;
//
//    case 'en':
//      localStorage.setItem('lang', 'en');
//      window.location.assign(redirectURL('/en/'));
//      break;
//
//    case 'ru':
//      localStorage.setItem('lang', 'ru');
//      window.location.assign(redirectURL('/ru/'));
//      break;
//
//    default:
//      console.log('Unknown language!');
//  }
//}); // ************************************************************************
// Handle burger menu

function uncheckBurgerMenu() {
  document.getElementById('navbar__checkbox').checked = false;
}

function hideMenu(e) {
  if (e.target.closest('A')) {
    uncheckBurgerMenu();
  }
}

document.querySelector('.navbar__menu-wrapper').addEventListener('click', function (e) {
  if (document.body.clientWidth < 981) {
    hideMenu(e);
  }
});
window.addEventListener('resize', function () {
  if (document.body.clientWidth > 979) {
    uncheckBurgerMenu();
  }
});

function toggleFullProgram() {
  document.querySelectorAll('.program__module').forEach(function (module, ind) {
    if (ind > 1) {
      module.hidden = !module.hidden;
    }
  });
}

(function () {
  var showMoreBtn = document.querySelector('.program__show-more-btn') || document.createElement('div');
  var showMore = document.querySelector('.program__show-more') || document.createElement('div');
  toggleFullProgram();

  var expandMoreHandler = function expandMoreHandler(e) {
    e.preventDefault();
    window.scroll({
      top: document.querySelectorAll('.program__module')[0].offsetTop - 80,
      left: 0,
      behavior: 'smooth'
    });
    toggleFullProgram();
    showMoreBtn.classList.toggle('program__show-more-btn--activated');
  };

  showMore.addEventListener('mousedown', expandMoreHandler);
  showMore.addEventListener('touchstart', expandMoreHandler);
})();
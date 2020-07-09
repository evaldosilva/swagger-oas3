(function () {
    window.addEventListener("load", function () {
        setTimeout(function () {
            var logo = document.getElementsByClassName('link');
            logo[0].children[0].alt = "Red Ribbon Logo";
            logo[0].children[0].src = "../swagger/ui/640px-Red_Ribbon_Army_Logo.png";
        });
    });
})();
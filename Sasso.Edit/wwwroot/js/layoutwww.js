$(document).ready(function () {

    //rodo
    const xButton = document.getElementById("rodoc");
    const rodoToHide = document.getElementById("rodo");
    if (sessionStorage.getItem("rodo") == "ok") {
        rodoToHide.style.display = "none";
    }


    xButton.addEventListener("click", function (e) {
        e.preventDefault();
        rodoToHide.style.display = "none";
        sessionStorage.setItem("rodo", "ok");
    });


    //share

    function copyToClipboard(text) {
        var $temp = $("<input>");
        $("body").append($temp);
        $temp.val(text).select();
        document.execCommand("copy");
        $temp.remove();
    }

    let btn = document.getElementById('share');
    btn.addEventListener("click", function (e) {
        e.preventDefault();
        let infoDiv = $("#copy-info");
        copyToClipboard("http://sald.com.pl");
        infoDiv.fadeToggle();
        infoDiv.delay(600).fadeToggle();
    });

});
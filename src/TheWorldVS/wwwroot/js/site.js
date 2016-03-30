// site.js
(function () {
    //var main = $("#main");
    
    //main.on("mouseenter", function () {
    //    main.css("background-color", "#888");
    //});
    
    //main.on("mouseleave", function () {
    //    main.css("background-color", "#eee");
    //});

    //var menuItems = $("#ul.menu li a");
    //menuItems.click(function () {
    //    var me = $(this);
    //    me.text = "Hi";
    //    alert(me.text());
    //});

    var sidebarAndWrapper = $("#sidebar,#wrapper");
    var $icon = $("#sidebarToggle i.fa");
    $("#sidebarToggle").click(function () {
        sidebarAndWrapper.toggleClass("hide-sidebar");
        if (sidebarAndWrapper.hasClass("hide-sidebar")) {
            $icon.removeClass("fa-angle-left");
            $icon.addClass("fa-angle-right");
        } else {
            $icon.removeClass("fa-angle-right");
            $icon.addClass("fa-angle-left");
        }
    });
    
}());
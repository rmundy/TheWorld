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
    $("#sidebarToggle").click(function () {
        sidebarAndWrapper.toggleClass("hide-sidebar");
        if (sidebarAndWrapper.hasClass("hide-sidebar")) {
            $(this).text("Show Sidebar");
        } else {
            $(this).text("Hide Sidebar");
        }
    });
    
}());
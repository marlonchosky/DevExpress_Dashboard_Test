window.onload = function () {
    DevExpress.Dashboard.ResourceManager.embedBundledResources();
    var dashboardControl = new DevExpress.Dashboard.DashboardControl(document.getElementById("web-dashboard"), {
        endpoint: "/api/dashboardControl"
    });
    dashboardControl.render();
    dashboardControl.loadDashboard('1');
};

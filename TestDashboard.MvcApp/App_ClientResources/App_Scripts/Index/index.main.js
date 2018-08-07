
'use strict';
var dashboardControl;
var btnCargar;
var dashboard = dashboard;
var dashboard_onBeforeRender = function (sender) {
    dashboardControl = sender.GetDashboardControl();
};

var fn_loaddashboard_done = function () {
    console.log(dashboardControl);
    console.log('Done loading dashboard...');
};
var btnCargar_onclick = function () {
    debugger;
    //var parameters = dashboard.GetParameters();
    //var parTipoInd = parameters.GetParameterByName('TipoIndicador');
    //dashboard.BeginUpdateParameters();
    //parTipoInd.SetValue('U');

    //dashboard.EndUpdateParameters();

    dashboardControl.loadDashboard('1')
        .done(fn_loaddashboard_done);
};

var init = function () {
    btnCargar = $('#btnCargar');
    btnCargar.click(btnCargar_onclick);
};

    //return {
    //    dashboard_onBeforeRender: dashboard_onBeforeRender,
    //    init: init,
    //    dashboardControl: dashboardControl
    //};

$(document).ready(() => {
    //index_module.init();
    init();

    
});

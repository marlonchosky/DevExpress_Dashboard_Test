
'use strict';
var dashboardControl;
var btnCargar;
var dashboard = dashboard;
var idIndicador = null;
var tipo = null;
var fechaInicio = null;
var fechaFin = null;
var idPlataforma = null;
var dashboard_onBeforeSend = function (jqXHR) {
    idIndicador = $('#txtIdIndicador').val();
    tipo = $('#cboTipo').val();
    fechaInicio = $('#txtFechaInicio').val();
    fechaFin = $('#txtFechaFin').val();

    jqXHR.setRequestHeader('filtro_id', idIndicador);
    jqXHR.setRequestHeader('filtro_tipo_indicador', tipo);
    jqXHR.setRequestHeader('filtro_fecha_inicio', fechaInicio);
    jqXHR.setRequestHeader('filtro_fecha_fin', fechaFin);
    jqXHR.setRequestHeader('filtro_id_plataforma', idPlataforma);
};
var dashboard_onBeforeRender = function (sender) {
    dashboardControl = sender.GetDashboardControl();
    dashboardControl.remoteService.beforeSend = dashboard_onBeforeSend;
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

    tipo = 'U';
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


'use strict';
var dashboardControl;
var btnCargar;
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

    jqXHR.setRequestHeader('filtro_id_indicador', idIndicador);
    jqXHR.setRequestHeader('filtro_tipo_indicador', tipo);
    jqXHR.setRequestHeader('filtro_fecha_inicio', fechaInicio);
    jqXHR.setRequestHeader('filtro_fecha_fin', fechaFin);
    jqXHR.setRequestHeader('filtro_id_plataforma', idPlataforma);
};
var fn_loaddashboard_done = function () {
    console.log(dashboardControl);
    console.log('Done loading dashboard...');
};
var btnCargar_onclick = function () {
    dashboardControl.loadDashboard('1')
        .done(fn_loaddashboard_done);
};

var init = function () {
    btnCargar = $('#btnCargar');
    btnCargar.click(btnCargar_onclick);

    dashboardControl = new DevExpress.Dashboard.DashboardControl(document.getElementById('web-dashboard'), {
        endpoint: '/api/dashboardControl'
    });
    dashboardControl.remoteService.beforeSend = dashboard_onBeforeSend;
    dashboardControl.render();
};

$(document).ready(() => {
    //index_module.init();
    init();

    
});

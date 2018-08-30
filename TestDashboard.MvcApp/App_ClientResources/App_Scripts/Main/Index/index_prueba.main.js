'use strict';

var now = new Date();
var fechaInicio = $('#cboFechaInicio');
var plataforma = $('#cboPlataforma');

fechaInicio.dxDateBox({
    type: 'date'
});
plataforma.dxSelectBox({
    
});

DevExpress.Dashboard.ResourceManager.embedBundledResources();
var dashboardControl = new DevExpress.Dashboard.DashboardControl(document.getElementById('web-dashboard'), {
    endpoint: '/api/dashboardControl'
});
dashboardControl.render();



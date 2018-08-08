'use strict';

var app_infrastructure = app_infrastructure || {};
app_infrastructure.routes = app_infrastructure.routes || {};
app_infrastructure.routes.base = app_infrastructure.routes.base || {};
app_infrastructure.routes.clientresources = {
    base: `${app_infrastructure.routes.base}App_ClientResources`,
    app_scripts: `${app_infrastructure.routes.base}App_Scripts`,
    libraries: `${app_infrastructure.routes.base}Libraries`
};

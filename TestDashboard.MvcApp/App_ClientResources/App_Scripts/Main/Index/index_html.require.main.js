/// <reference path="../../Infrastructure/app.infrastructure.routes.__noumd.js" />
/// <reference path="../../../Libraries/requirejs/require.js" />

'use strict';
(function (require, window) {
    require.config({
        baseUrl: window.app_infrastructure.routes.clientresources.base,
        paths: {
            'jquery': 'Libraries/jquery/jquery',
            'jquery.ui': 'Libraries/jquery-ui/jquery-ui',
            'knockout': 'Libraries/knockout/knockout',
            'cldr': 'Libraries/cldrjs/cldr',
            'cldr/event': 'Libraries/cldrjs/cldr/event',
            'cldr/supplemental': 'Libraries/cldrjs/cldr/supplemental',
            'globalize': 'Libraries/globalize',
            
            //'globalize/globalize': 'Libraries/globalize/globalize',
            //'globalize/globalize/message': 'Libraries/globalize/globalize/message',
            //'globalize/globalize/number': 'Libraries/globalize/globalize/number',
            //'globalize/globalize/currency': 'Libraries/globalize/globalize/currency',
            //'globalize/globalize/date': 'Libraries/globalize/globalize/date',
            
            'dx.all': 'Libraries/DevExtreme/js/dx.all',
            'dx.dashboard.control.bundle': 'Libraries/DevExpress/Dashboard/dx.dashboard-control.bundle'
        },
        shim: {
            'dx.all': {
                deps: ['jquery', 'jquery.ui', 'knockout', 'cldr', 'cldr/event', 'cldr/supplemental'
                      , 'globalize/globalize', 'globalize/globalize/message', 'globalize/globalize/number', 'globalize/globalize/currency', 'globalize/globalize/date'],
                exports: 'dx_all'
            },
            'dx.dashboard.control.bundle': {
                deps: ['jquery', 'jquery.ui', 'knockout', 'cldr', 'cldr/event', 'cldr/supplemental'
                      , 'globalize/globalize', 'globalize/globalize/message', 'globalize/globalize/number', 'globalize/globalize/currency', 'globalize/globalize/date'],
                exports: 'dx_dashboard_bundle'
            }
            //'globalize/globalize': {
            //    deps: ['cldr'],
            //    exports: 'globalize'
            //},
            //'globalize/globalize/message': {
            //    deps: ['globalize/globalize'],
            //    exports: 'globalize_message'
            //},
            //'globalize/globalize/number': {
            //    deps: ['globalize/globalize'],
            //    exports: 'globalize_number'
            //},
            //'globalize/globalize/currency': {
            //    deps: ['globalize/globalize'],
            //    exports: 'globalize_currency'
            //},
            //'globalize/globalize/date': {
            //    deps: ['globalize/globalize'],
            //    exports: 'globalize_date'
            //}
        }
    });

    require([
        'jquery', 'jquery.ui', 'knockout',
        'cldr', 'cldr/event', 'cldr/supplemental',
        'globalize/globalize', 'globalize/globalize/message', 'globalize/globalize/number', 'globalize/globalize/currency', 'globalize/globalize/date',
        //'dx.all', 'dx.dashboard.control.bundle',
        'dx.dashboard.control.bundle',
        'App_Scripts/Main/Index/index_html.main'],
        ($, jquery_ui, ko,
         cldr, cldr_event, cldr_supplemental,
         globalize, globalize_message, globalize_number, globalize_currency, globalize_date,
         //dx_all, dx_dashboard_bundle,
         dx_dashboard_bundle,
         main) => {
            main.fn_start();
            //console.log(globalize);
            //console.log(dx_dashboard_bundle);
        }
    );
}(require, window));

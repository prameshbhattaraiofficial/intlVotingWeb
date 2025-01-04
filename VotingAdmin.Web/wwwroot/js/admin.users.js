﻿
var FormHandler = {
    settings: {
        method: 'POST',
        actionUrl: undefined,
        selector: undefined,
        containerSelector: undefined
    },

    init: function (settings, successCallback) {
        if (!settings)
            throw new Error('parameter settings is requeired!');

        if (!settings.selector)
            throw new Error('selector is not defined in settings');

        if (!settings.actionUrl)
            throw new Error('actionUrl is not defined in settings');

        if (!settings.containerSelector)
            throw new Error('containerSelector is not defined in settings');

        var formSettings = $.extend({}, this.settings, settings);
        var $formEl = $(formSettings.selector);

        $.validator.unobtrusive.parse($formEl);

        $formEl.on('submit', function (e) {
            e.preventDefault();

            if (!$(this).valid()) {
                return false;
            }

            $.ajax({
                cache: false,
                url: formSettings.actionUrl,
                type: 'POST',
                data: new FormData(this),
                contentType: false,
                processData: false,
                success: function (res) {
             
                    if (successCallback && typeof successCallback === 'function') {
                        successCallback();
                    }
                },
                beforeSend: function () {
                
                    $('.loader').show();
                },
                error: function (err) {
                  
                    switch (err.status) {
                        case 400:
                            $(formSettings.containerSelector).html(err.responseText);
                            // Reattach handlers
                            //FormHandler.init(formSettings);
                            break;
                        case 403:
                            $(formSettings.containerSelector).html("<h1>You dont have access to view this page</h1>");
                            // Reattach handlers
                            //FormHandler.init(formSettings);
                            break;
                        case 404:
                            new PNotify({
                                title: 'Error notice',
                                text: 'There was some Issue.',
                                type: 'error',
                                animation: {
                                    effect_in: 'fade',
                                    effect_out: 'slide'
                                }

                            });
                            console.log("Not Found!");
                            break;
                        default:
                            console.log(err.responseText);
                        // handle default
                    }
                },
                complete: function () {
                    $('.loader').hide();
                }
            });
        });
    }
}
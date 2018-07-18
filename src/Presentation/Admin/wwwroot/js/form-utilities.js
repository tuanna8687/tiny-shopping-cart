// https://vykantor.com/2014/04/25/clear-reset-form-unobtrusive-jquery-validation/

(function ($) {

    $.fn.clearForm = function (options) {

        // This is the easiest way to have default options.
        var settings = $.extend({
            // These are the defaults.

            formId: this.closest('form')

        }, options);

        var $form = $(settings.formId);

        //reset jQuery Validate's internals
        $form.validate().resetForm();

        //reset unobtrusive validation summary, if it exists
        $form.find("[data-valmsg-summary=true]")
            .removeClass("validation-summary-errors")
            .addClass("validation-summary-valid")
            .find("ul").empty();

        //reset unobtrusive field level, if it exists
        $form.find("[data-valmsg-replace]")
            .removeClass("field-validation-error")
            .addClass("field-validation-valid")
            .empty();

        return $form;
    };

}(jQuery));
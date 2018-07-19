(function ($) {
    var defaultOptions = {
        validClass: 'is-valid',
        errorClass: 'is-invalid',
        // highlight: function (element, errorClass, validClass) {
        //     $(element).closest(".form-group")
        //         .removeClass(validClass)
        //         .addClass(errorClass);

        //     $(element).siblings("span[class*='form-control-feedback']")
        //         .removeClass("glyphicon-ok")
        //         .addClass("glyphicon-remove");
        // },
        // unhighlight: function (element, errorClass, validClass) {
        //     $(element).closest(".form-group")
        //         .removeClass(errorClass)
        //         .addClass(validClass);

        //     $(element).siblings("span[class*='form-control-feedback']")
        //         .removeClass("glyphicon-remove")
        //         .addClass("glyphicon-ok");
        // }
    };

    $.validator.setDefaults(defaultOptions);

    $.validator.unobtrusive.options = {
        errorClass: defaultOptions.errorClass,
        validClass: defaultOptions.validClass,
    };
})(jQuery);
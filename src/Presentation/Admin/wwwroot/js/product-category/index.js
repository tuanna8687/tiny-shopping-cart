;
(function(global, $) {
    'use strict';
    ////////////////////////////////////////////////////////////////
    // Configuration
    ////////////////////////////////////////////////////////////////
    var _elementIds = {
        mainForm: {
            productCategoriesTreeContainer: "divTree",
            contextMenu: "divMenu",
        },

        creatingWindow: {
            id: "creatingWindow",
            creatingForm: "editingForm",
        },

        editingWindow: {
            id: "editingWindow",
            editingForm: "editingForm",
        },
    };


    //////////////////////////////////////////////////////////////////
    // Creating Windows
    //////////////////////////////////////////////////////////////////
    function _registerEventHandlersForContextMenu() {
        var viewProductCategory = global.tinyShoppingCart.viewProductCategory;

        viewProductCategory.registerAddEventHandlerForContextMenu(_openCreatingWindow);
        viewProductCategory.registerEditEventHandlerForContextMenu(_openEditingWindow);
        viewProductCategory.registerRemoveEventHandlerForContextMenu(_removeCategory);
    }

    function _openCreatingWindow(eventArgs) {
        var selectedItem = eventArgs.selectedItemOnTree;
        var getCreatingFormUrl = eventArgs.getUrl;

        if (selectedItem && getCreatingFormUrl) {

            // Send a AJAX request to server to get content of creating windows
            $.ajax({
                url: getCreatingFormUrl,
                method: 'POST',
                data: {
                    parentId: selectedItem.value
                }
            }).then(function(data) {
                var $creatingWindow = $("#" + _elementIds.creatingWindow.id);
                $creatingWindow.jqxWindow({ content: data });

                // Register jquery validation unobtrusive for dynamic form
                var $creatingForm = $("#" + _elementIds.creatingWindow.creatingForm);
                $.validator.unobtrusive.parse($creatingForm);
                _registerSubmitEvenHandlerForCreatingForm($creatingWindow, $creatingForm, eventArgs.updateUrl);
                
                $creatingWindow.jqxWindow('open');
            });
            
        }
    }

    function _registerSubmitEvenHandlerForCreatingForm($creatingWindow, $creatingForm, updateUrl) {
        $creatingForm.data("validator").settings.submitHandler = function (form) { 
            var formElement = $(form);

            $.ajax({
                url: updateUrl,
                method: 'POST',
                data: formElement.serialize()
            }).done(function(data) {
                $creatingWindow.jqxWindow('close');

                // Reload product category tree
                $("#" + _elementIds.mainForm.productCategoriesTreeContainer).html(data);
                _registerEventHandlersForContextMenu();
            });

            return false;
        };
    }

    function _registerCloseEventHandlerForWindow($window)
    {
        $window.on('close', function(event) {
            $(this).jqxWindow({ content: ''});
        });
    }

    ////////////////////////////////////////////////////////////////////
    // Editing Window
    ////////////////////////////////////////////////////////////////////
    function _openEditingWindow(eventArgs) {
        var selectedItem = eventArgs.selectedItemOnTree;
        var getUrl = eventArgs.getUrl;

        if (selectedItem && getUrl) {

            // Send a AJAX request to server to get content of creating windows
            $.ajax({
                url: getUrl,
                method: 'POST',
                data: {
                    id: selectedItem.value
                }
            }).then(function(data) {
                var $editingWindow = $("#" + _elementIds.editingWindow.id);
                $editingWindow.jqxWindow({ content: data });

                // Register jquery validation unobtrusive for dynamic form
                var $editingForm = $("#" + _elementIds.editingWindow.editingForm);
                $.validator.unobtrusive.parse($editingForm);
                _registerSubmitEvenHandlerForEditingForm($editingWindow, $editingForm, eventArgs.updateUrl);
                
                $editingWindow.jqxWindow('open');
            });
            
        }
    }

    function _registerSubmitEvenHandlerForEditingForm($editingWindow, $editingForm, updateUrl) {
        $editingForm.data("validator").settings.submitHandler = function (form) { 
            var formElement = $(form);

            // Submit data to server to update category to database
            $.ajax({
                url: updateUrl,
                method: 'POST',
                data: formElement.serialize()
            }).done(function(data) {
                $editingWindow.jqxWindow('close');

                // Reload product category tree
                $("#" + _elementIds.mainForm.productCategoriesTreeContainer).html(data);
                _registerEventHandlersForContextMenu();
            });

            return false;
        };
    }

    function _removeCategory(eventArgs) {
        if(!confirm("Are you sure?")) {
            return;
        }

        var selectedItem = eventArgs.selectedItemOnTree;
        var deleteUrl = eventArgs.updateUrl;

        if (selectedItem != null && deleteUrl) {
            $.ajax({
                url: deleteUrl,
                method: 'POST',
                data: {
                    id: selectedItem.value
                } 
            }).done(function() {
                global.tinyShoppingCart.viewProductCategory.removeSelectedElement();
            });
        }
    }

    $(document).ready(function() {
        _registerEventHandlersForContextMenu();
        
        var $creatingWindow = $("#" + _elementIds.creatingWindow.id);
        var $editingWindow = $("#" + _elementIds.editingWindow.id);

        _registerCloseEventHandlerForWindow($creatingWindow);
        _registerCloseEventHandlerForWindow($editingWindow);
    });

})(window, jQuery);
;
(function(global, $) {
    'use strict';
    ////////////////////////////////////////////////////////////////
    // Configuration
    ////////////////////////////////////////////////////////////////
    var _elementIds = {
        mainForm: {
            productCategoriesTreeContainer: "divTree",
            productCategoriesTree: "productCategoriesTree",
            contextMenu: "divMenu",
            searchText: "searchText",
            searchButton: "searchButton",
            expandCollapseAllButton: "expandCollapseAllButton"
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
    var _isTreeCollapsed = true;


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
        $window.off("close")
        $window.on("close", function(event) {
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

    function _registerClickEventHandlerForSearchButton($searchButton, $searchText) {
        $searchButton.off("click");
        $searchButton.on("click", function() {
            var searchText = $.trim($searchText.val());
            if(searchText) {
                var $jqxTree = $("#" + _elementIds.mainForm.productCategoriesTree);
                var result = global.tinyShoppingCart.utilities.jqxTree.setFirstSelectedElementByText($jqxTree, searchText);
                if(!result) {
                    alert("Don't have any categories matches with '" + searchText + "'");
                }
            }
        });
    }

    function _registerClickEventHandlerForExpandCollapseAllButton($button) {
        _refreshTextOfExpandCollapseButton($button);

        $button.off("click");
        $button.on("click", function() {
            var $jqxTree = $("#" + _elementIds.mainForm.productCategoriesTree);

            if(_isTreeCollapsed) {
                $jqxTree.jqxTree("expandAll");
            } else {
                $jqxTree.jqxTree("collapseAll");
            }

            _isTreeCollapsed = !_isTreeCollapsed;
            _refreshTextOfExpandCollapseButton($button);
        });
    }

    function _refreshTextOfExpandCollapseButton($button) {
        if(_isTreeCollapsed) {
            $button.text("Expand All");
        } else {
            $button.text("Collapse All");
        }
    }



    $(document).ready(function() {
        _registerEventHandlersForContextMenu();
        
        var $creatingWindow = $("#" + _elementIds.creatingWindow.id);
        var $editingWindow = $("#" + _elementIds.editingWindow.id);

        _registerCloseEventHandlerForWindow($creatingWindow);
        _registerCloseEventHandlerForWindow($editingWindow);

        var $searchButton = $("#" + _elementIds.mainForm.searchButton);
        var $searchText = $("#" + _elementIds.mainForm.searchText);

        _registerClickEventHandlerForSearchButton($searchButton, $searchText);

        var $expandCollapseAllButton = $("#" + _elementIds.mainForm.expandCollapseAllButton);
        _registerClickEventHandlerForExpandCollapseAllButton($expandCollapseAllButton);
    });

})(window, jQuery);
;
(function(global, $) {
    'use strict';

    var jqxTreeUtilities = {
        getSelectedItem: function($jqxTree) {
            var selectedItem = $jqxTree.jqxTree('selectedItem');
            return selectedItem;
        },

        getElementByValue: function($jqxTree, value) {
            var elements = $jqxTree.jqxTree("getItems");
            for(var i = 0; i < elements.length; i++) {
                var element = elements[i];
                if(element.value === value) {
                    return element;
                }
            }

            return null;
        },

        setSelectedElementByValue: function($jqxTree, value) {
            var element = this.getElementByValue($jqxTree, value);
            if(element) {
                $jqxTree.jqxTree("selectItem", element);
                $jqxTree.jqxTree("expandItem", element);
            }
        },

        getFirstElementByText: function($jqxTree, text) {
            var elements = $jqxTree.jqxTree("getItems");
            for(var i = 0; i < elements.length; i++) {
                var element = elements[i];
                if(element.label.toLowerCase().indexOf(text.toLowerCase()) !== -1) {
                    return element;
                }
            }

            return null;
        },

        setFirstSelectedElementByText: function($jqxTree, text) {
            var firstElement = this.getFirstElementByText($jqxTree, text);
            if(firstElement) {
                $jqxTree.jqxTree("selectItem", firstElement);
                $jqxTree.jqxTree("expandItem", firstElement);

                return true;
            }

            return false;
        }
    };

    var tinyShoppingCart = window.tinyShoppingCart || {};
    var utilities = tinyShoppingCart.utilities || {};
    utilities.jqxTree = jqxTreeUtilities;

    tinyShoppingCart.utilities = utilities;
    global.tinyShoppingCart = tinyShoppingCart;
    
})(window, jQuery);
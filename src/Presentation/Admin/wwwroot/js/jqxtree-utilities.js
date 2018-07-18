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
            if(element != null) {
                $jqxTree.jqxTree("selectItem", element);
                $jqxTree.jqxTree("expandItem", element)
            }
        }
    };

    var tinyShoppingCart = window.tinyShoppingCart || {};
    var utilities = tinyShoppingCart.utilities || {};
    utilities.jqxTree = jqxTreeUtilities;

    tinyShoppingCart.utilities = utilities;
    global.tinyShoppingCart = tinyShoppingCart;
    
})(window, jQuery);
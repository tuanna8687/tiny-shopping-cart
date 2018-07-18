;
(function(global) {
    "use strict";

    function EventEmitter() {
        this.events = {};
    }

    EventEmitter.prototype.on = function(event, listener) {
        this.events[event] = this.events[event] || [];
        this.events[event].push(listener);
    }

    EventEmitter.prototype.emit = function(event, eventAgrs) {
        if(this.events[event]) {
            this.events[event].forEach(function(listener) {
                listener(eventAgrs);
            });
        }
    }

    global.tinyShoppingCart = global.tinyShoppingCart || {};
    global.tinyShoppingCart.EventEmitter = EventEmitter;
})(window);
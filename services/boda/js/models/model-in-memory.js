directory.Invitation = Backbone.Model.extend({

    initialize: function () { },

    sync: function (method, model, options) {
        if (method === "read") {
            directory.store.findByIdAndPin(this.id, this.attributes.pin, function (data) {
                options.success(data);
            });
        }
    }

});



directory.Home = Backbone.Model.extend({

    initialize: function () { },

    sync: function (method, model, options) {
        if (method === "read") {
            directory.store.findContent(function (data) {
                options.success(data);
            });
        }
    }

});




directory.MemoryStore = function (successCallback, errorCallback) {
    this.findByIdAndPin = function (id, pin, callback) {
        var invitations = this.invitations;
        var invitation = null;
        var l = invitations.length;
        for (var i = 0; i < l; i++) {
            if (invitations[i].id.toLowerCase() === id.toLowerCase() && invitations[i].pin.toLowerCase() === pin.toLowerCase()) {
                invitation = invitations[i];
                break;
            }
        }
        callLater(callback, invitation);
    };

    this.findContent = function (callback) {
        var content = this.contentHome;
        callLater(callback, content);
    };

    // Used to simulate async calls. This is done to provide a consistent interface with stores that use async data access APIs
    var callLater = function (callback, data) {
        if (callback) {
            setTimeout(function () {
                callback(data);
            });
        }
    };

    this.invitations = [{
        "id": "Carlos+David",
        "title": "Carlos y David",
        "pin": "45a67r",
        "content": "",
        "attendants": [{
            "name": "Carlos",
            "corfirmed": "false"
        }, {
            "name": "David",
            "corfirmed": "false"
        }]
    }, {
        "id": "David+Maria",
        "title": "David y Maria",
        "pin": "12f44w",
        "content": "",
        "attendants": [{
            "name": "David",
            "corfirmed": "false"
        }, {
            "name": "Maria",
            "corfirmed": "false"
        }, {
            "name": "Ana",
            "corfirmed": "false"
        }, {
            "name": "Carlos",
            "corfirmed": "false"
        }, {
            "name": "David (hijo)",
            "corfirmed": "false"
        }]
    }];

    this.contentHome = {
        mainImages: [{
            image: '0.jpg'
        }, {
            image: '2.jpg'
        }, {
            image: '5.jpg'
        }, {
            image: '6.jpg'
        }, {
            image: '7.jpg'
        }, {
            image: '8.jpg'
        }, {
            image: '9.jpg'
        }, {
            image: '10.jpg'
        }, {
            image: '11.jpg'
        }, {
            image: '12.jpg'
        }, {
            image: '13.jpg'
        }, {
            image: '14.jpg'
        }, {
            image: '15.jpg'
        }, {
            image: '16.jpg'
        }, {
            image: '17.jpg'
        }, {
            image: '18.jpg'
        }, {
            image: '19.jpg'
        }, {
            image: '20.jpg'
        }, {
            image: '21.jpg'
        }, {
            image: '22.jpg'
        }, {
            image: '23.jpg'
        }, {
            image: '24.jpg'
        }, {
            image: '27.jpg'
        }, {
            image: '28.jpg'
        }, {
            image: '29.jpg'
        }, {
            image: '30.jpg'
        }, {
            image: '31.jpg'
        }, {
            image: '32.jpg'
        }, {
            image: '33.jpg'
        }, {
            image: '34.jpg'
        }

        ],
        posts: [{
            "title": "Entrada 1",
            "Content": "Esto es el contenido 1"
        }, {
            "title": "Entrada 2",
            "Content": "Esto es el contenido 2"
        }, {
            "title": "Entrada 3",
            "Content": "Esto es el contenido 3"
        }]
    };

    callLater(successCallback);

};

directory.store = new directory.MemoryStore();
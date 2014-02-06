directory.Invitation = Backbone.Model.extend({

    initialize: function () {},

    sync: function (method, model, options) {
        if (method === "read") {
            directory.store.findByIdAndPin(this.id, this.attributes.pin, function (data) {
                options.success(data);
            });
        }
    }

});

directory.InvitationCollection = Backbone.Collection.extend({

    model: directory.Invitation,

    sync: function (method, model, options) {
        if (method === "read") {
            directory.store.findByName(options.data.name, function (data) {
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

    this.content = [{
        "title": "Entrada 1",
        "Content": "Esto es el contenido 1"
    }, {
        "title": "Entrada 2",
        "Content": "Esto es el contenido 2"
    }, {
        "title": "Entrada 3",
        "Content": "Esto es el contenido 3"
    }];

    callLater(successCallback);

};

directory.store = new directory.MemoryStore();
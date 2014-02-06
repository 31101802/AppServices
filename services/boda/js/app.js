var directory = {

    views: {},

    models: {},

    loadTemplates: function (views, callback) {

        var deferreds = [];

        $.each(views, function (index, view) {
            if (directory[view]) {
                deferreds.push($.get('tpl/' + view + '.html', function (data) {
                    directory[view].prototype.template = _.template(data);
                }, 'html'));
            } else {
                alert(view + " not found");
            }
        });

        $.when.apply(null, deferreds).done(callback);
    }

};

$.strPad = function (i, l, s) {
    var o = i.toString();
    if (!s) {
        s = '0';
    }
    while (o.length < l) {
        o = s + o;
    }
    return o;
};

directory.Router = Backbone.Router.extend({

    routes: {
        "": "home",
        "contact": "contact",
        "invitacion/:id/:pin": "invitationDetail"
    },

    initialize: function () {
        directory.shellView = new directory.ShellView();
        $('body').html(directory.shellView.render().el);
        // Close the search dropdown on click anywhere in the UI
        $('body').click(function () {
            $('.dropdown').removeClass("open");
        });
        this.$content = $("#content");
    },

    home: function () {
        // Since the home view never changes, we instantiate it and render it only once
        if (!directory.homelView) {
            directory.homelView = new directory.HomeView();
            directory.homelView.render();
        } else {
            console.log('reusing home view');
            directory.homelView.delegateEvents(); // delegate events when the view is recycled
        }
        this.$content.html(directory.homelView.el);
        directory.shellView.selectMenuItem('home-menu');
    },

    contact: function () {
        if (!directory.contactView) {
            directory.contactView = new directory.ContactView();
            directory.contactView.render();
        }
        this.$content.html(directory.contactView.el);
        directory.shellView.selectMenuItem('contact-menu');
    },

    invitationDetail: function (id, pin) {
        var invitation = new directory.Invitation({
            id: id,
            pin: pin
        });
        var self = this;
        invitation.fetch({
            success: function (data) {
                console.log(data);
                // Note that we could also 'recycle' the same instance of EmployeeFullView
                // instead of creating new instances
                self.$content.html(new directory.InvitationView({
                    model: data
                }).render().el);
            }
        });
        //directory.shellView.selectMenuItem();
    }

});

$(document).on("ready", function () {
    directory.loadTemplates(["HomeView", "ShellView", "InvitationView"],
        function () {
            directory.router = new directory.Router();
            Backbone.history.start();
        });
});
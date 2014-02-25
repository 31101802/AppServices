directory.HomeView = Backbone.View.extend({

    events: {
        "click #showMeBtn": "showMeBtnClick"
    },

    render: function () {
        this.$el.html(this.template(this.model.attributes));

        this.startCountDownTimer(new Date(2014, 6 - 1, 7, 12, 30, 0));

        return this;
    },
    startCountDownTimer: function (end) {

        var _second = 1000;
        var _minute = _second * 60;
        var _hour = _minute * 60;
        var _day = _hour * 24;
        var timer;

        function showRemaining() {
            var now = new Date();
            var distance = end - now;
            if (distance < 0) {

                clearInterval(timer);

                return;
            }
            var days = Math.floor(distance / _day);
            var hours = Math.floor((distance % _day) / _hour);
            var minutes = Math.floor((distance % _hour) / _minute);
            var seconds = Math.floor((distance % _minute) / _second);


            $('#cutdownDay1').attr("src", 'img/' + $.strPad(days, 3)[0] + '.png');
            $('#cutdownDay2').attr("src", 'img/' + $.strPad(days, 3)[1] + '.png');
            $('#cutdownDay3').attr("src", 'img/' + $.strPad(days, 3)[2] + '.png');

            $('#cutdownHour1').attr("src", 'img/' + $.strPad(hours, 2)[0] + '.png');
            $('#cutdownHour2').attr("src", 'img/' + $.strPad(hours, 2)[1] + '.png');



            $('#cutdownMinute1').attr("src", 'img/' + $.strPad(minutes, 2)[0] + '.png');
            $('#cutdownMinute2').attr("src", 'img/' + $.strPad(minutes, 2)[1] + '.png');

            $('#cutdownSecond1').attr("src", 'img/' + $.strPad(seconds, 2)[0] + '.png');
            $('#cutdownSecond2').attr("src", 'img/' + $.strPad(seconds, 2)[1] + '.png');


        }



        setTimeout(function () {
            showRemaining();
        });


        timer = setInterval(showRemaining, 1000);
    },

    showMeBtnClick: function () {
        console.log("showme");
        directory.shellView.search();
    }

});
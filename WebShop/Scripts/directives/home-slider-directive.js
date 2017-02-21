
app.directive('homeSlider', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
           // debugger;
            // $(element).toolbar(scope.$eval(attrs.toolbarTip));
            if (element.length) {
                console.log(element)
                $(element).after('<div class="landing"><div class="spinner"><div class="bounce1"></div><div class="bounce2"></div><div class="bounce3"></div></div></div>');
                $(element).addClass(function () {
                    return $(element).find('.item').length > 1 ? "big-slider" : "";
                });
                $(element).waitForImages({
                    finished: function () {
                        $('.landing').remove();
                        if ($(element).hasClass('big-slider')) {
                            var autoplay = $(element).data('autoplay'),
                                navigation = $(element).data('navigation'),
                                dots = $(element).data('dots'),
                                transition = $(element).data('transition');

                                $(element).owlCarousel({
                                items: 1,
                                loop: true,
                                autoplayTimeout: autoplay || false,
                                dots: dots || false,
                                nav: navigation || false,
                                navText: ['<i class="icon-arrow-left"></i>', '<i class="icon-arrow-right"></i>'],
                                autoplay: true,
                                animateOut: transition || false
                            });
                        }
                    },
                    waitForAll: true
                });
            }
        }
    };
});
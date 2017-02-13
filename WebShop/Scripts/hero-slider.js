/*===================================
=            Hero slider            =
===================================*/

$(document).ready(function() {

	var win = $(window),
		pxWrapper = $('#hero'),
		pxContainer = $('#hero-slider');
		loaderIntro = '<div class="landing"><div class="spinner"><div class="bounce1"></div><div class="bounce2"></div><div class="bounce3"></div></div></div>';

	/* Initialize Intro */
	function initIntro() {
		var $this = pxContainer;
		$this.after(loaderIntro);
		$this.addClass(function () {
			return $this.find('.item').length > 1 ? "big-slider" : "";
		});

		$this.waitForImages({
			finished: function () {
				$('.landing').remove();
				if ($this.hasClass('big-slider')) {
					var autoplay = $this.data('autoplay'),
						navigation = $this.data('navigation'),
						dots = $this.data('dots'),
						transition = $this.data('transition');

					$this.owlCarousel({
					   items : 1, 
						loop: true,
						autoplayTimeout: autoplay || false,
						dots: dots || false,
						nav: navigation || false,
						navText: ['<i class="icon-arrow-left"></i>','<i class="icon-arrow-right"></i>'],
					    autoplay: true,
						animateOut: transition || false
					});
				}
			},
			waitForAll: true
		});

	}
	if (pxContainer.length) {
		initIntro();
	}
});

/*-----  End of Hero slider  ------*/
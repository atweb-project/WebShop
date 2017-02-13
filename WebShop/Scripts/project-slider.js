/*===================================
=            Project slider            =
===================================*/

$(document).ready(function() {

	var win = $(window),
		pxContainer = $('#project-slider');
		loaderIntro = '<div class="landing"><div class="spinner"><div class="bounce1"></div><div class="bounce2"></div><div class="bounce3"></div></div></div>';

	/* Initialize Intro */
	function initSlider() {
		var $this = pxContainer;
		$this.after(loaderIntro);
		$this.addClass(function () {
			return $this.find('.item').length > 1 ? "big-slider" : "";
		});

		$this.waitForImages({
			waitForAll: true,
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
					    autoplay: false,
						animateOut: transition || false
					});
				}
			}
		});

	}

	/* Project Preview	==============================================*/
	$('.img-box').click(function(e) {
		//e.preventDefault();
		var elem = $(this).parent(),
			title = elem.find('.project-title').text(),
			price = elem.find('.project-price').text(),
			descr = elem.find('.project-description').html(),
			slidesHtml = '';
			elemDataCont = elem.find('.project-description');
			slides = elem.find('.project-description').data('images').split(',');
		for (var i = 0; i < slides.length; ++i) {
			slidesHtml = slidesHtml + '<div class="item" style="background-image: url(' + slides[i] + ');"></div>';

		}
		$('#project-modal').on('show.bs.modal', function() {
			$(this).find('#sdbr-title').text(title);
			$(this).find('#sdbr-price').text(price);
			$(this).find('#project-content').html(descr).append('<a id="btn-order" class="btn btn-store btn-right"  href="#">Order now</a>');
			$(this).find('#project-slider').html(slidesHtml);
			if (elemDataCont.data('oldprice')) {
				$(this).find('#sdbr-oldprice').show().text(elemDataCont.data('oldprice'))
			} else {
				$(this).find('#sdbr-oldprice').hide();
			}
			if (elemDataCont.data('descr')) {
				$(this).find('#sdbr-descr').show().text(elemDataCont.data('descr'))
			} else {
				$(this).find('#sdbr-descr').hide();
			}
		}).modal();

		initSlider();
	});

	$('#project-modal').on('hidden.bs.modal', function() {
		$('#project-slider').removeClass('big-slider');
		//$('#project-slider').trigger('remove.owl.carousel');
		$('#project-slider').trigger('destroy.owl.carousel');
	});

	$('#project-modal').on( 'click', '#btn-order',function () {
		$('#project-modal').modal('hide');
		$('#project-slider').trigger('destroy.owl.carousel');
		var aTag = $("section[id='orderform']");
		$('html,body').animate({scrollTop: aTag.offset().top - 60},'slow');
		return false;
	});

});		
/*-----  End of Project slider  ------*/
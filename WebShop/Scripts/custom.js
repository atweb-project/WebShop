$(document).ready(function() {
	
	/* waypoint ======================================= */

   var waypoints = $('.anima').waypoint(function(direction) {
        if(direction == 'down'){
                $(this.element).addClass('in');    
           } else {
             //  $(this.element).removeClass('animate');
           }
        }, {
          offset: '80%'
   });


	/* Hero slider ======================================= */

	// $('#hero-slides').superslides({
	// 	play: 4000,
	// 	animation: 'fade'
	// });
		// full-height 
	function heroHeight() {
		var $this = $('#hero'),
		win = $(window),
		dataHeight = $this.data('height');

		if ($this.hasClass('full-height')) {
			$this.css({
				'height': (win.height())
			});
		} else {
			$this.css({
				'height': dataHeight + 'px'
			});
		}
	};
	// Start 
	heroHeight();
	$(window).resize(heroHeight);

	/* Navbar colapse ======================================= */
	$(document).on('click.nav','.navbar-collapse.in',function(e) {
		if( $(e.target).is('a') || $(e.target).is('button')) {
			$(this).collapse('hide');
		}
	});

	/* show about more  ======================================= */
	$("#show-btn").click(function() {
		$('#showme').slideDown("slow");
		$(this).hide();
		return false;
	});

	/* testimonial ======================================= */
	$('.carousel').carousel();
	
	/* One Page Navigation Setup ======================================= */
	$('#main-nav').singlePageNav({
		offset: $('.navbar').height(),
		speed: 750,
		currentClass: 'active',
		filter: ':not(.external)',
		beforeStart: function() {},
		onComplete: function() {}
	});
	
	/* Bootstrap Affix ======================================= */		
	$('#modal-bar').affix({
		offset: {
			top: 10,
		}
	});


	/* countdown ======================================= */	
	var days = 3;
	var date = new Date();
	var res = date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
	
	$('#countdown').countdown(res, function(event) {
	  $(this).text(
		event.strftime('%-d days %H:%M:%S')
	  );
	});

	/* Smooth Hash Link Scroll ======================================= */	
	$('.smooth-scroll').click(function() {
		if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
			var target = $(this.hash);
			target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
			if (target.length) {
				// console.log(offset());
				$('html,body').animate({
						scrollTop: target.offset().top - 60
				}, 1000);
				return false;
			}
		}
	});
		



	/* style switch	==============================================*/
	$('#style-switcher h2 a').click(function(){
		$('#style-switcher').toggleClass('open');
		return false;
	});

	$('#style-switcher li').click(function(e){
		e.preventDefault();
		var m = $(this);
		$('.colors').attr('href', 'css/' + m.attr('id') + '.css');
		$('#logo').attr('src', 'img/logo-' + m.attr('id') + '.png');
		$('#navlogo').attr('src', 'img/navlogo-' + m.attr('id') + '.png');
		$('#style-switcher').removeClass('open');
		return false; 
	});	


});
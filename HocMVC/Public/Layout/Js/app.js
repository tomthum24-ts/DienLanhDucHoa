function openMenu() {
  let w = window.innerWidth;
  document.body.style.backgroundColor = "rgba(0,0,0,0.5)";
  if (w > 450) {
    document.getElementById("myMenu").style.width = "450px";
  } else {
    document.getElementById("myMenu").style.width = "100%";
  }
}

function closeMenu() {
  document.getElementById("myMenu").style.width = "0";
  document.body.style.backgroundColor = "white";
}

// <!-- Hide modal --->
$(".close").click(() => {
  $(".modal").css("display", "none");
  $(".modal").css("transition", "0.7s ease");
});
$(".modal")
  .on("show", function () {
    $("body").addClass("modal-open");
  })
  .on("hidden", function () {
    $("body").removeClass("modal-open");
  });
// <!-- Start of Tawk.to Script-->

var Tawk_API = Tawk_API || {},
  Tawk_LoadStart = new Date();
(function () {
  var s1 = document.createElement("script"),
    s0 = document.getElementsByTagName("script")[0];
  s1.async = true;
  s1.src = "https://embed.tawk.to/6327f72037898912e969f3bf/1gda1qm4d";
  s1.charset = "UTF-8";
  s1.setAttribute("crossorigin", "*");
  s0.parentNode.insertBefore(s1, s0);
})();
// <!--End of Tawk.to Script-->

$(".perspective-img").owlCarousel({
  loop: true,
  dotsEach: 3,
  nav: true,
  center: true,
  margin: 10,
  dots: true,
  autoplayTimeout: 8500,
  smartSpeed: 450,
  responsive: {
    0: {
      items: 1,
    },
    768: {
      items: 2,
    },
    1170: {
      items: 3,
    },
  },
});
$(".overviews-history_box").owlCarousel({
  nav: true,
  margin: 20,
  autoplayTimeout: 2000,
  responsive: {
    0: {
      items: 1,
    },
    400: {
      items: 1,
    },
    600: {
      items: 1,
    },
    1000: {
      items: 3,
    },
  },
});
$(".overviews-background").owlCarousel({
  dotsEach: 6,
  nav: true,
  loop: true,
  margin: 20,
  autoplayTimeout: 2000,
  responsive: {
    0: {
      items: 1,
    },
    400: {
      items: 1,
    },
    600: {
      items: 1,
    },
    1000: {
      items: 1,
    },
  },
});
$(".recruit--image").owlCarousel({
  nav: true,
  dotsEach: 1,
  nav: true,
  loop: true,
  margin: 20,
  autoplayTimeout: 2000,
  responsive: {
    0: {
      items: 1,
    },
    400: {
      items: 1,
    },
    600: {
      items: 1,
    },
    1000: {
      items: 1,
    },
  },
});

$(".details--news").owlCarousel({
  dotsEach: 6,
  nav: true,
  loop: true,
  margin: 20,
  autoplayTimeout: 2000,
  responsive: {
    0: {
      items: 1,
    },
    400: {
      items: 1,
    },
    600: {
      items: 1,
    },
    1000: {
      items: 3,
    },
  },
});
//section2
$(".service").owlCarousel({
  dotsEach: 1,
  loop: true,
  margin: 20,
  autoplayTimeout: 3000,
  responsive: {
    0: {
      items: 1,
    },
    400: {
      items: 1,
    },
    600: {
      items: 1,
    },
    1000: {
      items: 3,
    },
  },
});

var Scrollbar = window.Scrollbar;
options = {
  damping: 0.1,
};
let scrollbar = Scrollbar.init(
  document.querySelector("#my-scrollbar"),
  options
);
function toOverview(params) {
  scrollbar.scrollTo(
    0,
    document.getElementById("overview").offsetTop - 150,
    1000
  );
}
function toLocation(params) {
  scrollbar.scrollTo(
    0,
    document.getElementById("location").offsetTop - 130,
    1000
  );
}
function toUtilities(params) {
  scrollbar.scrollTo(
    0,
    document.getElementById("utilities").offsetTop - 130,
    1000
  );
}

function toPerspective(params) {
  scrollbar.scrollTo(
    0,
    document.getElementById("perspective").offsetTop - 130,
    1000
  );
}

function toContact(params) {
  scrollbar.scrollTo(0, document.getElementById("contact").offsetTop, 1000);
}

scrollbar.setPosition(0, 0);
scrollbar.track.xAxis.element.remove();
const header_setTop = $(".header-setTop").offset().top -100; // distance top


function listener(status) {
  let scroll = scrollbar.offset.y;
  let width = window.innerWidth;
  if (width > 1200) {
    if (scroll <= 200) {
      $("header").css("backgroundColor", "transparent");
      $("header").css("width", "99.5%");
      $(".navbar-nav-tool a").css("color", "white");
      $(".nav-item a").css("color", "white");
      $(".dropdown-item").css("color", "black");
    } else {
      $("header").css("backgroundColor", "white");
      $("header").css("width", "100%");
      $(".navbar-nav-tool a").css("color", "orange");
      $(".nav-item a").css("color", "orange");
      $(".dropdown-item").css("color", "black");
    }
    if (scroll <= header_setTop) {
      $(".project--nav__off").css("visibility", "visible");
      $(".header-show").removeClass("hide");
    } else {
      $(".header-show").addClass("hide");
      $(".project--nav__off").css("visibility", "hidden");
    }
  } else {
    $("header").css("backgroundColor", "white");
  }
  if ($("#detailsNews").attr("id")) {
    const overview = document.getElementById("overview").offsetTop - 200;
    const locations = document.getElementById("location").offsetTop - 200;
    const utilities = document.getElementById("utilities").offsetTop - 200;
    const perspective = document.getElementById("perspective").offsetTop - 200;
    const contact = document.getElementById("contact").offsetTop - 200;
    if (scroll >= overview && scroll < locations) {
      $(".btn_overview").addClass("active");
    } else {
      $(".btn_overview").removeClass("active");
    }
    if (scroll >= locations && scroll < utilities) {
      $(".btn_location").addClass("active");
    } else {
      $(".btn_location").removeClass("active");
    }
    if (scroll >= utilities && scroll < perspective) {
      $(".btn_utilities").addClass("active");
    } else {
      $(".btn_utilities").removeClass("active");
    }
    if (scroll >= perspective && scroll < contact) {
      $(".btn_perspective").addClass("active");
    } else {
      $(".btn_perspective").removeClass("active");
    }
    if (scroll > contact) {
      $(".btn_contact").addClass("active");
    } else {
      $(".btn_contact").removeClass("active");
    }
  }
}
scrollbar.addListener(listener);

//Handle offset Scroll
AOS.init({
  delay: 500,
});
[].forEach.call(document.querySelectorAll("[data-aos]"), (el) => {
  scrollbar.addListener(() => {
    if (scrollbar.isVisible(el)) {
      el.classList.add("aos-animate");
    }
  });
});

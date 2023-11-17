const header = document.querySelector(".header");
const nav_links = header.querySelectorAll(".nav-link");
let width = screen.width;
const changeColorHeader = (e) => {
  if (e.includes("introPage")) {
    header.style.backgroundColor = "transparent";
    nav_links.forEach((nav_link) => {
      nav_link.style.color = "white";
    });
    header.style.transition = "all 0.5";
  } else {
    header.style.backgroundColor = "#fff";
    nav_links.forEach((nav_link) => {
      nav_link.style.color = "orange";
    });
  }
};
new fullpage("#myContainer", {
  navigation: true,
  autoScrolling: true,
  onLeave: (origin, destination, direction) => {
    const section = destination.item;
    changeColorHeader(section.className.split(" "));
    if (destination.index === 2) {
      //hover section2
      const cards = document.querySelectorAll(".resort_item");
      let check = false;
      const defaultbox = () => {
        if (!check) {
          //false
          cards[1].classList.add("move");
        } else {
          cards[1].classList.remove("move");
        }
      };
      defaultbox();
      for (let i = 0; i < cards.length; i++) {
        const element = cards[i];
        element.addEventListener("mouseover", () => {
          if (element.className.split(" ").includes("move")) {
            return;
          } else {
            element.classList.add("move");
            check = true;
            defaultbox();
          }
        });
      }
      for (let i = 0; i < cards.length; i++) {
        const element = cards[i];
        element.addEventListener("mouseout", () => {
          element.classList.remove("move");
          check = false;
          defaultbox();
        });
      }
    }
    if (destination.index === 3 || destination.index === 5  ) {
      header.style.backgroundColor = "transparent";
      nav_links.forEach((nav_link) => {
        nav_link.style.color = "white";
      });
      header.style.transition = "all 0.5";
      return;
    }
    if (destination.index === 3 && width <= 968) {
      let nextSlideIndex = origin.index + 1; // convert from index to slide nr.
      let nextSibling = destination.item;
      let skipped = false; // avoid if($(destination.item).is(':hidden'))

      while ($(nextSibling).is(":hidden")) {
        if (direction === "down") {
          // misusing skipped to find out if this is the first round.
          // in the first round we need +2, in all others +1 (-2, -1 when going upwards)
          if (!skipped) {
            nextSlideIndex++;
          }
          nextSlideIndex++;
          nextSibling = nextSibling.nextElementSibling;
        } else {
          if (!skipped) {
            nextSlideIndex--;
          }
          nextSlideIndex--;
          nextSibling = nextSibling.previousElementSibling;
        }

        skipped = true;
      }

      if (skipped) {
        fullpage_api.moveTo(nextSlideIndex);
        return false; // cancel slide that triggered this onLeave
      }
    }
    jQuery(".section [data-aos]").removeClass("aos-animate");
  },

  onSlideLeave: function () {
    jQuery(".slide [data-aos]").removeClass("aos-animate");
  },
  afterSlideLoad: function () {
    jQuery(".slide.active [data-aos]").addClass("aos-animate");
  },
  afterLoad: function () {
    jQuery(".section.active [data-aos]").addClass("aos-animate");
    //jQuery('.fp-table.active .aos-init').addClass('aos-animate');
  },
  sectionsColor: ["#fff", "#fff", "#fff", "#fff", "#fff"],
  menu: "#menu",
  slidesNavigation: true,
  dropEffect: true,
  //In addition to the extension license you'll
  //need to acquire a fullPage.js license from https://goo.gl/5x9a22
  licenseKey: "8E7D7A7A-25144A1B-AF10A926-C239A4DE",
  responsiveWidth: 1024,
  responsiveSlides: true,
  responsiveSlidesKey: "INSERT YOUR EXTENSION KEY HERE", //see https://goo.gl/xkUmHS
  dropEffect: true,
  dropEffectKey: "aG9hbmdnaWFncm91cC5ncm91cF9TR25aSEp2Y0VWbVptVmpkQT09eDR0", //see https://goo.gl/xkUmHS
  dropEffectOptions: {
    speed: 2000,
    color: "#ffc507",
    zIndex: 999999,
    opacity: 0.5,
  },
  resetSliders: true,
  resetSlidersKey: "INSERT YOUR EXTENSION KEY HERE", //see https://goo.gl/xkUmHS
  esponsiveSlidesKey: "INSERT YOUR EXTENSION KEY HERE", //see https://goo.gl/xkUmHS
});

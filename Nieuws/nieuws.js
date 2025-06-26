const nieuwsItems = [
      {
        titel: "Klimaatbeleid in de schijnwerpers",
        tekst: "De discussie over klimaatverandering blijft centraal staan.",
        afbeelding: "https://www.oxfamnovib.nl/redactie/Images/Algemeen/Nieuws/2015/Nieuws_klimaatparade_670x352.jpg?hid=img;mxw=800;"
      },
      {
        titel: "Economische groei op lange termijn",
        tekst: "VVD benadrukt het belang van marktliberalisme.",
        afbeelding: "https://www.wyniasweek.nl/wp-content/uploads/2024/01/ww2401.png"
      },
      {
        titel: "Betaalbaar wonen in steden",
        tekst: "SP wil meer regelgeving om woningnood aan te pakken.",
        afbeelding: "https://sp-media.imgix.net/2025/01/Wonen.png?auto=compress%2Cformat&crop=faces%2Centropy&q=80&fit=crop&w=1024&h=575"
      },
      {
        titel: "Migratiebeleid in focus",
        tekst: "FvD roept op tot strengere controlemaatregelen.",
        afbeelding: "https://image.parool.nl/244226556/feature-crop/1200/900/tweede-kamerlid-gideon-van-meijeren-van-forum-voor-democratie"
      },
      {
        titel: "Innovatie in Onderwijs",
        tekst: "D66 investeert in moderne leeromgevingen.",
        afbeelding: "https://i.ytimg.com/vi/YaAfOwfVCgk/maxresdefault.jpg"
      },
      {
        titel: "Sociale zekerheid en gelijke kansen",
        tekst: "PvdA wil eerlijke kansengelijkheid voor iedereen.",
        afbeelding: "https://amsterdam.pvda.nl/wp-content/uploads/sites/460/2021/06/Ontwerp-zonder-titel.png"
      },
      {
        titel: "Duurzaamheid als prioriteit",
        tekst: "GroenLinks pleit voor duurzame transitie.",
        afbeelding: "https://groenlinkspvda.nl/wp-content/uploads/2024/02/Suzanne-Kroger-Habtamu-de-Hoop-Klimaatmars-600x400.jpg"
      }
    ];

    const carousel = document.getElementById("carousel");
    const dotsContainer = document.getElementById("dots");

    let currentIndex = 0;
    const itemsPerSlide = 3;

    function renderCarousel() {
      carousel.innerHTML = "";
      const visibleItems = [];

      for (let i = 0; i < itemsPerSlide; i++) {
        const index = (currentIndex + i) % nieuwsItems.length;
        visibleItems.push(nieuwsItems[index]);
      }

      visibleItems.forEach(item => {
        const card = document.createElement("div");
        card.className = "news-card";
        card.innerHTML = `
          <img src="${item.afbeelding}" alt="${item.titel}">
          <div class="content">
            <h3>${item.titel}</h3>
            <p>${item.tekst}</p>
          </div>
        `;
        carousel.appendChild(card);
      });

      updateDots();
    }

    function nextSlide() {
      currentIndex = (currentIndex + itemsPerSlide) % nieuwsItems.length;
      renderCarousel();
    }

    function prevSlide() {
      currentIndex = (currentIndex - itemsPerSlide + nieuwsItems.length) % nieuwsItems.length;
      renderCarousel();
    }

    function updateDots() {
      dotsContainer.innerHTML = "";
      const totalSlides = Math.ceil(nieuwsItems.length / itemsPerSlide);

      for (let i = 0; i < totalSlides; i++) {
        const dot = document.createElement("div");
        dot.className = "dot" + (i === getCurrentDotIndex() ? " active" : "");
        dot.onclick = () => {
          currentIndex = i * itemsPerSlide;
          renderCarousel();
        };
        dotsContainer.appendChild(dot);
      }
    }

    function getCurrentDotIndex() {
      return Math.floor(currentIndex / itemsPerSlide);
    }

    setInterval(nextSlide, 5000);

    document.addEventListener('DOMContentLoaded', () => {
      renderCarousel();  

      const menuToggle = document.getElementById('menu-toggle');
      const mainNav    = document.getElementById('main-nav');

      menuToggle.addEventListener('click', e => {
        e.stopPropagation();
        mainNav.classList.toggle('active');
      });

      document.addEventListener('click', e => {
        if (window.innerWidth <= 960
            && !mainNav.contains(e.target)
            && !menuToggle.contains(e.target)) {
          mainNav.classList.remove('active');
        }
      });

      window.addEventListener('resize', () => {
        if (window.innerWidth > 960) {
          mainNav.classList.remove('active');
        }
      });
    });
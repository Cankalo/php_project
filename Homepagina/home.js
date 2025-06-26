document.addEventListener('DOMContentLoaded', () => {
  const menuToggle = document.getElementById('menu-toggle');
  const mainNav    = document.getElementById('main-nav');

  // MENU TOGGLE
  menuToggle.addEventListener('click', e => {
    e.stopPropagation();
    mainNav.classList.toggle('active');
  });

  // KLIK BUITEN MENU SLUIT HET OP MOBIEL
  document.addEventListener('click', e => {
    const isMobile = window.innerWidth <= 960;
    if (isMobile && !mainNav.contains(e.target) && !menuToggle.contains(e.target)) {
      mainNav.classList.remove('active');
    }
  });

  // RESET MENU BIJ DESKTOP-RESIZE
  window.addEventListener('resize', () => {
    if (window.innerWidth > 960) {
      mainNav.classList.remove('active');
    }
  });
});

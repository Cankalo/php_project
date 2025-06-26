document.addEventListener('DOMContentLoaded', () => {
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
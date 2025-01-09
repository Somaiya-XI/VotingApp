document.addEventListener('DOMContentLoaded', () => {
  const menuArrow = document.getElementById('menu-arrow');
  const adminLink = document.getElementById('admin-nav');

  if (menuArrow && adminLink) {
    menuArrow.addEventListener('mousedown', () => {
      menuArrow.classList.toggle('-translate-x-[3.56rem]');

      setTimeout(() => {
        menuArrow.classList.toggle('duration-300');
        menuArrow.classList.toggle('rotate-180');

        setTimeout(() => {
          menuArrow.classList.toggle('duration-300');
        }, 100);
      }, 350);

      setTimeout(() => {
        adminLink.classList.toggle('-translate-x-[3.56rem]');
      }, 100);
    });
  }

  const userMenuArrow = document.getElementById('user-menu-arrow');
  const userLink = document.getElementById('user-nav');

  if (userMenuArrow && userLink) {
    userMenuArrow.addEventListener('mousedown', () => {
      userMenuArrow.classList.toggle('-translate-x-[2.5rem]');

      setTimeout(() => {
        userMenuArrow.classList.toggle('duration-300');
        userMenuArrow.classList.toggle('rotate-180');

        setTimeout(() => {
          userMenuArrow.classList.toggle('duration-300');
        }, 100);
      }, 350);

      setTimeout(() => {
        userLink.classList.toggle('-translate-x-[3rem]');
      }, 100);
    });
  }
});

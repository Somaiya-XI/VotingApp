/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./Pages/**/*.cshtml', './Views/**/*.cshtml', './Areas/****/***/**/*.cshtml'],
  theme: {
    screens: {
      sm: '640px',
      md: '768px',
      lg: '1024px',
      xl: '1440px',
    },
    extend: {
      colors: {
        'c-primary': '#f5f5f5',
      },
    },
  },
  plugins: [],
};

module.exports = {
  purge: ['./src/**/*.{vue,js,ts,jsx,tsx}'],
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {
      colors: {
        'primary': {
          '50': '#787878',
          '100': '#696969',
          '200': '#525752',
          '300': '#344B33',
          '400': '#1E421E',
          '500': '#003806',
          '600': '#002C00',
          '700': '#001C00',
          '800': '#010700',
          '900': '#000',
        }
      }
    },
  },
  variants: {
    extend: {
      backgroundColor: ['odd']
    },
  },
  plugins: [
    require('tailwindcss-bg-patterns'),
  ],
}

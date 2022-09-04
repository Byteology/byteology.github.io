let plugin = require('tailwindcss/plugin')

module.exports = {
    content: ["../**/*.{razor,html,cshtml}"],

    theme: {
        screens: {
            'sm': '25rem',
            'md': '40rem',
            'lg': '64rem',
            'xl': '80rem',
            '2xl': '96rem',
        },

        fontFamily: {
            'sans': ['Archivo', 'sans-serif'],
        },

        colors: {
            'transparent': 'transparent',
            'current': 'currentColor',

            primary: {
                100: "#aa99ff",
                300: "#7f67f4",
                DEFAULT: "#573ce2",
                700: "#4935ac",
                900: "#36297a"
            },
            accent: {
                100: "#ade9ff",
                300: "#96def8",
                DEFAULT: "#61c9ef",
                700: "#38b0dc",
                900: "#1b98c5"
            },
            dark: {
                100: "#122759",
                300: "#0e214e",
                DEFAULT: "#0a1b42",
                700: "#041334",
                900: "#030d26"
            },
            light: {
                100: "#ffffff",
                300: "#f9f8fc",
                DEFAULT: "#f2f1f9",
                700: "#e3e1ef",
                900: "#cfcbe1"
            },
            neutral: {
                100: "#ffffff",
                200: "#d4d3d9",
                300: "#b1afbb",
                400: "#9491a1",
                DEFAULT: "#7b7887",
                600: "#6a6779",
                700: "#595766",
                800: "#3f3d48",
                900: "#131316"
            },
            error: "#e23c3c"
        },
    },

    plugins: [
        plugin(function ({ addVariant }) {
            addVariant('hocus', ['&:hover', '&:focus', '&:focus-within']);
        }),
    ],
}
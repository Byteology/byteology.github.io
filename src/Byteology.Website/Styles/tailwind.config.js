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

            'touch': { "raw": "(hover: none)" },
            'cursor': { "raw": "(hover: hover)" }
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
                100: "#1e1259",
                300: "#180e4e",
                DEFAULT: "#130a43",
                700: "#0c0434",
                900: "#090326"
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

        extend: {
            keyframes: {
                fade: {
                    '0%': { opacity: 1 },
                    '100%': { opacity: 0 },
                },
                fadeAlt: {
                    '0%': { opacity: 1 },
                    '100%': { opacity: 0 },
                }
            },
            animation: {
                'fade-in-fast': 'fade 0.25s ease-out 0s reverse forwards',
                'fade-in-fast-alt': 'fadeAlt 0.25s ease-out 0s reverse forwards',
                'blink': 'fade 1.5s linear 0s infinite alternate-reverse',
            }
        },
    },

    plugins: [
        plugin(function ({ addVariant }) {
            addVariant('active', '&.active');
            addVariant('checkbox-checked', [
                'input[type=checkbox]:checked + label > &',
                'input[type=checkbox]:checked + label + &',
                'input[type=checkbox]:checked + label + * > &',
                'input[type=checkbox]:checked + &',
                'input[type=checkbox]:checked + * > &',
            ]);
            addVariant('hocus', ['&:hover', '&:focus', '&:focus-within']);
        }),
    ],
}

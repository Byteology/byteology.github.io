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
                'blink': 'fade 1s linear 0s infinite alternate',
            }
        },
    },

    plugins: [
        plugin(function ({ addVariant, addBase, addComponents, addUtilities, theme }) {
            addVariant('active', '&.active');
            addVariant('checkbox-checked', [
                'input[type=checkbox]:checked + label > &',
                'input[type=checkbox]:checked + label + &',
                'input[type=checkbox]:checked + label + * > &',
                'input[type=checkbox]:checked + &',
                'input[type=checkbox]:checked + * > &',
            ]);
            addVariant('hocus', ['&:hover', '&:focus', '&:focus-within']);

            addBase({
                ".uppercase": {
                    "letter-spacing": "0.15em"
                }
            });

            addComponents(getLinkComponent(theme));
            addComponents(getButtonComponent(theme));

            addUtilities(getScrollBarUtilities(theme));
            addUtilities(getTransitionUtilities(theme));
            addUtilities(getSafeCenterUtilities(theme));
        }),
    ],
}

function getLinkComponent(theme)
{
    return {
        ".link": {
            "text-decoration-line": "underline",
            "text-underline-offset": "2px",
            "text-decoration-thickness": "2px",
            "text-decoration-color": theme("colors.primary.DEFAULT"),
            "transition-property": "all",
            "transition-timing-function": theme("transitionTimingFunction.ease-out"),
            "transition-duration": "0.2s",
        },
        ".link:focus, .link:focus-within, .link:hover": {
            "text-decoration-color": theme("colors.primary.300"),
            "color": theme("colors.primary.300")
        }
    }
}

function getButtonComponent(theme)
{
    return {
        ".button": {
            "font-weight": theme("fontWeight.bold"),
            "letter-spacing": ".15em",
            "text-transform": "uppercase",
            "text-align": "center",
            "color": theme("colors.neutral.100"),
            "background-color": theme("colors.primary.DEFAULT"),
            "transition-property": "all",
            "transition-timing-function": theme("transitionTimingFunction.ease-out"),
            "transition-duration": "0.5s",
        },
        ".button:focus, .button:focus-within, .button:hover": {
            "background-color": theme("colors.primary.300"),
        }
    }
}

function getScrollBarUtilities(theme)
{
    return {
        ".no-scrollbar": {
            "-ms-overflow-style": "none",
            "scrollbar-width": "none"
        },
        ".no-scrollbar::-webkit-scrollbar": {
            "display": "none",
            "width": 0,
            "height": 0
        },
        ".styled-scrollbar::-webkit-scrollbar": {
            "width": "16px",
            "height": "16px",
            "background-color": theme("colors.dark.900"),
            "--tw-shadow-color": theme("colors.dark.100"),
            "box-shadow": "inset 0 0 0 2px var(--tw-shadow-color)"
        },
        ".styled-scrollbar::-webkit-scrollbar-thumb": {
            "--tw-gradient-from": theme("colors.dark.DEFAULT"),
            "--tw-gradient-to": theme("colors.primary.900"),
            "--tw-gradient-stops": "var(--tw-gradient-from) 25%, var(--tw-gradient-to) 50%, var(--tw-gradient-from) 75%",
            "background-image": "linear-gradient(to bottom, var(--tw-gradient-stops))",
            "--tw-shadow-color": theme("colors.dark.100"),
            "box-shadow": "inset 0 0 0 2px var(--tw-shadow-color)",
        }
    }
}

function getTransitionUtilities(theme)
{
    return {
        ".transition-slow": {
            "transition-property": "all",
            "transition-timing-function": theme("transitionTimingFunction.ease-out"),
            "transition-duration": "1s",
        },
        ".transition-normal": {
            "transition-property": "all",
            "transition-timing-function": theme("transitionTimingFunction.ease-out"),
            "transition-duration": "0.5s",
        },
        ".transition-fast": {
            "transition-property": "all",
            "transition-timing-function": theme("transitionTimingFunction.ease-out"),
            "transition-duration": "0.2s",
        },
    }
}

function getSafeCenterUtilities()
{
    return {
        ".justify-safe-center": {
            "justify-content": "space-between"
        },
        ".justify-safe-center:after, .justify-safe-center:before":{
            "content": "var(--tw-content)",
            "max-height": "0",
        }
    }
}

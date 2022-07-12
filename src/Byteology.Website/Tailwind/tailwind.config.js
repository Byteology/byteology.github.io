let plugin = require('tailwindcss/plugin')

module.exports = {
    content: ["../**/*.{razor,html,cshtml}"],

    theme: {
        screens: {
            tablet: '688px',
            laptop: '992px',
            desktop: '1360px',
        },
        colors: {
            transparent: 'transparent',
            current: 'currentColor',
            dark: '#030e28',
            light: '#ffffff',
            accent: {
                DEFAULT: '#583be2',
                dark: '#352fd3',
                light: '#9177ec',
            },
            secondary: {
                DEFAULT: '#60caef',
                dark: '#2ab1ed',
                light: '#b7e8f8',
            },
            grey: {
                DEFAULT: '#d9d9d9',
                dark: '#959595',
                light: '#f2f2f2'
            }
        },
        fontSize: {
            h1:     ['2.5rem', { letterSpacing: '0.05em', lineHeight: '1.1'} ],
            h2:     ['2rem', { letterSpacing: '0.05em', lineHeight: '1.1'} ],
            h3:     ['1.5rem', { letterSpacing: '0.05em', lineHeight: '1.1'} ],
            body:   ['1rem', { letterSpacing: '0.05em', lineHeight: '1.5'} ],
            detail: ['0.875rem', { letterSpacing: '0.05em', lineHeight: '1.5'} ],
        },
        extend: {
            fontFamily: {
                'sans': ['Archivo', 'sans-serif'],
            },
            keyframes: {
                flash: {
                    '0%,66%': { opacity: 1 },
                    '33%,100%': { opacity: 0 },
                },
                fade: {
                    '0%': { opacity: 1 },
                    '100%': { opacity: 0 },
                }
            },
            animation: {
                'flash-out': 'flash 1s ease-out 0.2s forwards',
                'flash-in': 'flash 1s ease-out 0.2s reverse forwards',
            }
        },
    },

    corePlugins: {
        container: false
    },

    plugins: [
        plugin(function ({ addVariant }) {
            addVariant('enter', '&.entered-screen');
            addVariant('parent-enter', '.entered-screen > &')
        }),
    ],
}
let plugin = require('tailwindcss/plugin')

module.exports = {
    content: ["../**/*.{razor,html,cshtml}"],

    theme: {
        screens: {
            tablet: '26rem',
            laptop: '48rem',
            desktop: '80rem',
        },

        colors: {
            'transparent':          'transparent',
            'current':              'currentColor',
            'accent':               'rgb(var(--clr-accent) / <alpha-value>)',
            'accent-alt':           'rgb(var(--clr-accent-alt) / <alpha-value>)',
            'accent-fg':            'rgb(var(--clr-accent-fg) / <alpha-value>)',
            'secondary':            'rgb(var(--clr-secondary) / <alpha-value>)',
            'secondary-fg':         'rgb(var(--clr-secondary-fg) / <alpha-value>)',
            'emph':                 'rgb(var(--clr-emph) / <alpha-value>)',
            'bg':                   'rgb(var(--clr-bg) / <alpha-value>)',
            'fg':                   'rgb(var(--clr-fg) / <alpha-value>)',
            'fg-inactive':          'rgb(var(--clr-fg-inactive) / <alpha-value>)',
            'error':                'rgb(var(--clr-error) / <alpha-value>)',
        },

        fontSize: {
            h1:     ['2.5rem', { letterSpacing: '0.10rem', lineHeight: '1.1'} ],
            h2:     ['2rem', { letterSpacing: '0.10rem', lineHeight: '1.1'} ],
            h3:     ['1.5rem', { letterSpacing: '0.10rem', lineHeight: '1.1'} ],
            body:   ['1rem', { letterSpacing: '0.10rem', lineHeight: '1.5'} ],
            detail: ['0.875rem', { letterSpacing: '0.10rem', lineHeight: '1.5' }],
            footnote: ['0.75rem', { letterSpacing: '0.10rem', lineHeight: '1.5' }],
        },

        extend: {
            fontFamily: {
                'sans': ['Archivo', 'sans-serif'],
            },

            keyframes: {
                fade: {
                    '0%': { opacity: 1 },
                    '100%': { opacity: 0 },
                }
            },
        },
    },

    plugins: [
        plugin(function ({ addVariant }) {
            addVariant('hocus', ['&:hover', '&:focus', '&:focus-within']);
        }),
    ],
}
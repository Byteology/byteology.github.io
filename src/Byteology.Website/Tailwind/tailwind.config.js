let plugin = require('tailwindcss/plugin')

module.exports = {
    content: ["../**/*.{razor,html,cshtml}"],

    theme: {
        screens: {
            tablet: '30rem',
            laptop: '48rem',
            desktop: '80rem',
        },

        colors: {
            'transparent':          'transparent',
            'current':              'currentColor',
            'active':               'rgb(var(--clr-active) / <alpha-value>)',
            'active-hover':         'rgb(var(--clr-active-hover) / <alpha-value>)',
            'active-fg':            'rgb(var(--clr-active-fg) / <alpha-value>)',
            'passive':              'rgb(var(--clr-passive) / <alpha-value>)',
            'passive-hover':        'rgb(var(--clr-passive-hover) / <alpha-value>)',
            'passive-fg':           'rgb(var(--clr-passive-fg) / <alpha-value>)',
            'backdrop':             'rgb(var(--clr-backdrop) / <alpha-value>)',
            'backdrop-fg':          'rgb(var(--clr-backdrop-fg) / <alpha-value>)',
            'backdrop-fg-inactive': 'rgb(var(--clr-backdrop-fg-inactive) / <alpha-value>)',
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
            addVariant('invalid', '&.invalid')
        }),
    ],
}
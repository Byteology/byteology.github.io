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
            'primary': {
                light: 'hsl(var(--clr-primary-light) / <alpha-value>)',
                DEFAULT: 'hsl(var(--clr-primary) / <alpha-value>)',
                dark: 'hsl(var(--clr-primary-dark) / <alpha-value>)',
                contrast: 'hsl(var(--clr-primary-contrast) / <alpha-value>)'
            },
            'accent': {
                light: 'hsl(var(--clr-accent-light) / <alpha-value>)',
                DEFAULT: 'hsl(var(--clr-accent) / <alpha-value>)',
                dark: 'hsl(var(--clr-accent-dark) / <alpha-value>)',
            },
            'fg': {
                DEFAULT: 'hsl(var(--clr-foreground-1) / <alpha-value>)',
                2: 'hsl(var(--clr-foreground-2) / <alpha-value>)',
                3: 'hsl(var(--clr-foreground-3) / <alpha-value>)',
                4: 'hsl(var(--clr-foreground-4) / <alpha-value>)',
                5: 'hsl(var(--clr-foreground-5) / <alpha-value>)'
            },
            'bg': {
                DEFAULT: 'hsl(var(--clr-background-1) / <alpha-value>)',
                2: 'hsl(var(--clr-background-2) / <alpha-value>)',
                3: 'hsl(var(--clr-background-3) / <alpha-value>)',
                4: 'hsl(var(--clr-background-4) / <alpha-value>)',
                5: 'hsl(var(--clr-background-5) / <alpha-value>)'
            },
            'error': 'hsl(var(--clr-error) / <alpha-value>)',
        },

        extend: {
            keyframes: {
                fade: {
                    '0%': { opacity: 1 },
                    '100%': { opacity: 0 },
                }
            },
            animation: {
                'fade-in-fast': 'fade 0.25s ease-out 0s reverse forwards',
            }
        },
    },

    plugins: [
        plugin(function ({ addVariant }) {
            addVariant('hocus', ['&:hover', '&:focus', '&:focus-within']);
        }),
    ],
}
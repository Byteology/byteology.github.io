window.initCalendly = (link) => {
	Calendly.initInlineWidget({
		url: "https://calendly.com/tsvetan-igov/" + link + "?background_color=090326&text_color=ffffff&primary_color=573ce2",
		parentElement: document.getElementById('calendly-embed')
	});
}
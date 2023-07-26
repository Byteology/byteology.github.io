window.initIndex = (ids) => {
	ids.forEach(id => {
		var indexLink = document.querySelector("[b-target=" + id + "]");
		if (indexLink) 
			indexLink.addEventListener("click", (event) => {
				var link = event.target;
				var targetName = link.getAttribute("b-target");
				var targetElement = document.getElementsByName(targetName)[0];

				var viewport = document.getElementsByTagName("b-viewport")[0];
				var headerOffset = 64;
				var elementPosition = targetElement.getBoundingClientRect().top;
				var offsetPosition = elementPosition + viewport.scrollTop - headerOffset;

				viewport.scrollTo({
					top: offsetPosition,
					behavior: "smooth"
				});
			});
	});
}
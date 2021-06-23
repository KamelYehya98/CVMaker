var fonts = ["Sans-Serif", "Verdana", "Courier New", "monospace", "Montez", "Lobster", "Josefin Sans", "Shadows Into Light", "Pacifico", "Amatic SC", "Orbitron", "Rokkitt", "Righteous", "Dancing Script", "Bangers", "Chewy", "Sigmar One", "Architects Daughter", "Abril Fatface", "Covered By Your Grace", "Kaushan Script", "Gloria Hallelujah", "Satisfy", "Lobster Two", "Comfortaa", "Cinzel", "Courgette"];
var string = "";
setTimeout(createFontFamilySelector, 3000);
setTimeout(createFontSizeSelector, 3000);

function createFontFamilySelector() {
	var select = document.getElementById("selecth1FontFamily");
	for (var a = 0; a < fonts.length; a++) {
		var opt = document.createElement('option');
		opt.value = opt.innerHTML = fonts[a];
		opt.style.fontFamily = fonts[a];
		select.add(opt);
	}
}

function createFontSizeSelector() {
	var select = document.getElementById("selecth1FontSize");
	for (var a = 10; a <= 32 ; a+=2) {
		var opt = document.createElement('option');
		if (a == 14)
			opt.selected = true;
		opt.value = opt.innerHTML = a;
		opt.style.fontSize = a;
		select.add(opt);
	}
}

function updateh1family() {

	var select = document.getElementById("selecth1FontFamily");
	var h1 = document.getElementById('div_to_print');
	h1.style.fontFamily = select.value;
}

function updateFontSize() {

	var select = document.getElementById("selecth1FontSize");
	var fonts = document.getElementsByClassName("font-resizable");
	for (let i = 0; i < fonts.length; i++) {
		fonts[i].style.fontSize = select.value + "px";
		console.log(fonts[i].style.fontSize);
    }
		
}

function updateStyle() {
	let div = document.getElementById("div_to_print");
	let select = document.getElementById("selectStyle");
	if (select.value == "bg-primary") {
		div.classList.remove("dark");
		div.classList.add("primary");
	} else {
		div.classList.remove("primary");
		div.classList.add("dark");
    }
}

function updateImageStyle() {
	let div = document.getElementById("profile_img");
	let select = document.getElementById("imageStyle");
	if (select.value == "circle") {
		div.classList.remove("square-image");
		div.classList.add("round-image");
	} else {
		div.classList.remove("round-image");
		div.classList.add("square-image");
	}
}

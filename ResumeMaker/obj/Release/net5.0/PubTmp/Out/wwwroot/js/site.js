function showNav() {
    console.log("LAKKKKKKKKKKKKKKKKKKKKKKK EHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
    document.getElementsByTagName("nav")[0].setAttribute("class", "nav-shown");
    document.querySelector('nav').addEventListener('click', hideNav);
}

function hideNav() {
    const nav = document.querySelector("nav");
    nav.classList.remove('nav-shown');
    document.querySelector('nav').removeEventListener('click', hideNav);
}

function hideShowOptions() {
    if (window.innerWidth > 1000) {
        var e = document.querySelector(".account-options");
        if (e.style.display) {
            if (e.style.display != 'none') {
                e.style.display = 'none';
            }
            else {
                e.style.display = 'block';
                showAccountOptions();
            }
            //e.style.display = ((e.style.display!='none') ? 'none' : 'block');
        }
        else {
            e.style.display = 'block';
        }
    }
}


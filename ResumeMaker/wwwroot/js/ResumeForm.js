let LangCounter = 0;
let SkillCounter = 0;
let ExpCounter = 0;

function addLanguage(name, prof) {

    LangCounter++;
    let table = document.getElementById("languages_table");
    let row = document.createElement("tr");

    let col = document.createElement("td");
    col.setAttribute("class", "d-flex flex-md-row flex-column justify-content-around align-items-center mb-4");
    row.appendChild(col);

    let div1 = document.createElement("div");
    div1.setAttribute("class", "m-2");
    let span1 = document.createElement("span");
    span1.setAttribute("class", "text-light");
    span1.innerHTML = "Language: ";
    let input1 = document.createElement("input");
    input1.value = name;
    input1.setAttribute("class", "form-control-sm text-dark");
    input1.setAttribute("type", "text"); input1.setAttribute("name", "LanguageName");
    div1.appendChild(span1); div1.appendChild(input1);
    col.appendChild(div1);

    let div2 = document.createElement("div");
    div2.setAttribute("class", "m-2");
    var str = ["Beginner", "Intermediate", "Advanced"];

    for (var i = 1; i <= 3; i++) {
        let div = document.createElement("div");
        div.setAttribute("class", "form-check form-check-inline");
        let input = document.createElement("input");
        input.setAttribute("class", "form-check-input text-dark"); input.setAttribute("type", "radio"); input.setAttribute("name", "LanguageValue" + LangCounter);
        input.setAttribute("id", "inlineRadio" + i); input.setAttribute("value", i);
        let label = document.createElement("label");
        label.setAttribute("class", "form-check-label text-light"); label.setAttribute("for", "inlineRadio" + i);
        label.innerHTML = "" + str[i - 1].toString() + "";
        if (i == prof) {
            input.setAttribute("checked", true);
        }
        div.appendChild(input); div.appendChild(label);
        div2.appendChild(div);
    }

    let btn = document.createElement("button");
    btn.addEventListener("click", function () { row.remove();});
    btn.innerHTML = "X";
    btn.setAttribute("class", "btn btn-danger d-block");
    col.appendChild(div2);
    col.appendChild(btn);
    table.appendChild(row);

}

function addSkills(name, prof) {
    SkillCounter++;
    let table = document.getElementById("skills_table");
    let row = document.createElement("tr");

    let col = document.createElement("td");
    col.setAttribute("class", "d-flex flex-md-row flex-column justify-content-around align-items-center mb-4");
    row.appendChild(col);

    let div1 = document.createElement("div");
    div1.setAttribute("class", "m-2");
    let span1 = document.createElement("span");
    span1.innerHTML = "Skill: ";
    span1.setAttribute("class", "text-light");
    let input1 = document.createElement("input");
    input1.value = name;
    input1.setAttribute("class", "form-control-sm text-dark");
    input1.setAttribute("type", "text"); input1.setAttribute("name", "SkillName");
    div1.appendChild(span1); div1.appendChild(input1);
    col.appendChild(div1);

    let div2 = document.createElement("div");
    div2.setAttribute("class", "m-2");
    var str = ["Beginner", "Intermediate", "Advanced"];


    for (var i = 1; i <= 3; i++) {
        let div = document.createElement("div");
        div.setAttribute("class", "form-check form-check-inline");
        let input = document.createElement("input");
        input.setAttribute("class", "form-check-input text-light"); input.setAttribute("type", "radio"); input.setAttribute("name", "SkillValue" + SkillCounter);
        input.setAttribute("id", "inlineRadio" + i); input.setAttribute("value", i);
        let label = document.createElement("label");
        label.setAttribute("class", "form-check-label text-light"); label.setAttribute("for", "inlineRadio" + i);
        label.innerHTML = "" + str[i - 1].toString() + "";
        if (i == prof) {
            input.setAttribute("checked", true);
        }
        div.appendChild(input); div.appendChild(label);
        div2.appendChild(div);
    }

    let btn = document.createElement("button");
    btn.addEventListener("click", function () { row.remove();});
    btn.innerHTML = "X";
    btn.setAttribute("class", "btn btn-danger d-block");
    col.appendChild(div2);
    col.appendChild(btn);
    table.appendChild(row);
}

function addExperiences(title, text) {
    let div = document.getElementById("experience_div");
    let divtotal = document.createElement("div");
    divtotal.setAttribute("class", "card bg-transparent border-white m-3");
    let cardheader = document.createElement("div");
    cardheader.setAttribute("class", "card-header d-flex flex-row justify-content-between align-items-center");
    let titleinput = document.createElement("input");
    titleinput.setAttribute("type", "title"); titleinput.setAttribute("class", "experience_header card-title w-75"); titleinput.setAttribute("placeholder", "Title");
    titleinput.setAttribute("name", "ExperienceTitle");
    titleinput.value = title;
    cardheader.appendChild(titleinput);
    let button = document.createElement("button");
    button.addEventListener("click", function () { divtotal.remove();});
    button.innerHTML = "X";
    button.setAttribute("class", "btn btn-danger align-start");
    cardheader.appendChild(button);
    let bodydiv = document.createElement("div");
    bodydiv.setAttribute("class", "card-body");
    let textarea = document.createElement("textarea");
    textarea.setAttribute("name", "ExperienceText");
    textarea.setAttribute("placeholder", "Tell us more about it...");
    textarea.setAttribute("class", "form-control experience_text");
    textarea.setAttribute("rows", "8");
    textarea.value = text;
    bodydiv.appendChild(textarea);

    divtotal.appendChild(cardheader);
    divtotal.appendChild(bodydiv);

    div.appendChild(divtotal);
}


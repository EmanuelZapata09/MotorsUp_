// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var sideMenu = document.querySelector("#sideMenu");
var selectMenuView = "";

const abrirMenu = () => {
    if (sideMenu.classList.contains("menu_lateral_comprimido")) {
        sideMenu.classList.remove("menu_lateral_comprimido");
        sideMenu.classList.add("menu_lateral_expander");
        document.querySelector('.btn_menu').classList.add("close");
    } else {
        sideMenu.classList.remove("menu_lateral_expander");
        sideMenu.classList.add("menu_lateral_comprimido");
        document.querySelector('.btn_menu').classList.remove("close");
    }

    if (selectMenuView == "menuView") cerrarOpciones();
}

document.querySelector('.btn_menu').addEventListener("click", () => {
    abrirMenu();
})

//menubar
const itemsPrincipales = document.querySelectorAll('.aControll');

for (let i = 0; i < itemsPrincipales.length; i++) {
    itemsPrincipales[i].addEventListener('click', () => {
        var padreItem = itemsPrincipales[i].parentNode;
        if (sideMenu.classList.contains("menu_lateral_comprimido")) {
            abrirMenu();
        }

        if (padreItem.classList.contains("menuViewNo")) {
            cerrarOpciones();
            padreItem.classList.remove("menuViewNo");
            padreItem.classList.add("menuView");
            selectMenuView = "menuView"
        }
        else {
            padreItem.classList.add("menuViewNo");
            padreItem.classList.remove("menuView");
            selectMenuView = "menuViewNo";
        }
    });
}

function cerrarOpciones() {
    const openMenu = document.querySelectorAll('.menuView');

    for (let i = 0; i < openMenu.length; i++) {
        openMenu[i].classList.remove('menuView');
        openMenu[i].classList.add('menuViewNo');
    }
}
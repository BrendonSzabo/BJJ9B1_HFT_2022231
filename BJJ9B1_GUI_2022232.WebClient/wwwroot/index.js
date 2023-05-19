const menu = document.getElementById("menu");

Array.from(document.getElementsByClassName("menu-item"))
    .forEach((item, index) => {
        item.onmouseover = () => {
            menu.dataset.activeIndex = index;
        }
    });

function linker(id) {
    switch (true) {
        case id == 'drivers':
            window.location.href = "./drivers.html";
            break;
        case id == 'teams':
            window.location.href = "./teams.html";
            break;
        case id == 'principals':
            window.location.href = "./principals.html";
            break;
        case id == 'stats':
            window.location.href = "./stats.html";
            break;
        case id == 'home':
            window.location.href = "./index.html";
            break;
        default:
            break;
    }
}
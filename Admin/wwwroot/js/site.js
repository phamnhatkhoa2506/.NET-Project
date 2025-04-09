// Đặt localStorage cho ngôn ngữ được chọn và load lại trang để commit
window.updateUI = async (lang) => {
    localStorage.setItem("currentLanguage", lang);
    location.reload();
};


// Kiểm tra chế độ và load khi tải trang
window.onload = function () {
    const theme = localStorage.getItem("theme");
    const systemPreferDark = window.matchMedia("(prefers-color-scheme: dark)").matches;

    if (theme) {
        document.body.classList.remove("dark-mode", "special-mode", "light-mode");
        if (theme !== "light") {
            document.body.classList.add(`${theme}-mode`);
        }
    } else if (systemPreferDark) {
        document.body.classList.add("dark-mode");
    }
};


// Cuộn dropdown mode xuống
function toggleModeDropdown() {
    document.getElementById("dropdown-menu-mode").classList.toggle("show-mode");
}

// Chọn 1 option trong dropdown mode
function selectModeOption(mode, text, path) {
    document.getElementById("selected-text-mode").innerText = text;
    document.getElementById("selected-path-mode").d = path;

    localStorage.setItem("theme", mode);

    // Xoá tất cả class liên quan đến mode trước đó
    document.body.classList.remove("dark-mode", "special-mode", "light-mode");

    // Nếu không phải light mode, thêm class mode tương ứng
    if (mode !== "light") {
        document.body.classList.add(`${mode}-mode`);
    }

    toggleModeDropdown();
}


// Ẩn dropdown khi nhấn ra ngoài dropdown mode
document.addEventListener("click", function(event) {
    if (!event.target.closest(".dropdown-mode")) {
        document.getElementById("dropdown-menu-mode").classList.remove("show-mode");
    }
});



// Cuộn dropdown language xuống
function toggleLanguageDropdown() {
    document.getElementById("dropdown-menu-lang").classList.toggle("show-lang");
}

// Chọn 1 option trong dropdown language
function selectLanguageOption(text, imgSrc) {
    document.getElementById("selected-text-lang").innerText = text;
    document.getElementById("selected-img-lang").src = imgSrc;
    toggleLanguageDropdown();
}

// Ẩn dropdown khi nhấn ra ngoài dropdown language
document.addEventListener("click", function(event) {
    if (!event.target.closest(".dropdown-lang")) {
        document.getElementById("dropdown-menu-lang").classList.remove("show-lang");
    }
});
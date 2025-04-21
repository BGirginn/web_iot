document.addEventListener("DOMContentLoaded", () => {
    const buttons = document.querySelectorAll(".switch-btn");

    buttons.forEach(btn => {
        btn.addEventListener("click", () => {
            buttons.forEach(b => b.classList.remove("active"));
            btn.classList.add("active");

            // İleride içerik geçişi yapılacaksa buraya animasyon eklenebilir.
            // Şu an sadece geçiş efekti uygulanıyor.
        });
    });
});

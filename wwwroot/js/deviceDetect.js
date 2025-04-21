document.addEventListener("DOMContentLoaded", () => {
    console.log("JS dosyası yüklendi.");  // Sayfa yüklendiğinde bu log görünmeli

    const btn = document.getElementById("detectBtn");
    const result = document.getElementById("result");

    // Eğer buton bulunamazsa hata mesajı yaz
    if (!btn) {
        console.error("detectBtn id'li buton bulunamadı!");
        return;
    }

    btn.addEventListener("click", async () => {
        console.log("Butona tıklandı.");  // Butona tıklanınca bu log görünmeli
        result.textContent = "Cihaz aranıyor, lütfen izin verin...";

        try {
            // Kullanıcıdan izin iste → popup her zaman açılır
            const port = await navigator.serial.requestPort();
            const info = port.getInfo();

            // VID/PID al
            const vid = info.usbVendorId?.toString(16).toUpperCase().padStart(4, '0');
            const pid = info.usbProductId?.toString(16).toUpperCase().padStart(4, '0');

            // Bilinen cihazlar listesi
            const knownDevices = {
                "10C4:EA60": "Silicon Labs CP210x (ESP32)",
                "2341:0043": "Arduino Uno",
                "2E8A:0005": "Raspberry Pi Pico"
            };

            const key = `${vid}:${pid}`;
            const name = knownDevices[key] || `Bilinmeyen cihaz (VID:${vid} PID:${pid})`;

            result.textContent = `Tespit edilen cihaz: ${name}`;
            console.log("Cihaz tespit edildi:", name);
        } catch (err) {
            // Hata durumlarını ayır
            if (err.name === "NotFoundError") {
                result.textContent = "Hiçbir cihaz seçilmedi veya cihaz bağlı değil.";
                console.warn("Kullanıcı cihaz seçmedi veya cihaz yok.");
            } else if (err.name === "SecurityError") {
                result.textContent = "Güvenlik nedeniyle bağlantıya izin verilmedi.";
                console.error("SecurityError:", err.message);
            } else {
                result.textContent = `Bir hata oluştu: ${err.message}`;
                console.error("Genel hata:", err);
            }
        }
    });
});

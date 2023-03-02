window.addEventListener("load", () => {
    const loading = document.querySelector(".loading");
    loading.classList.add("loading-hidden");

    loading.addEventListener("trasitionend", () => {
        document.body.removeChild("loading");
    })
})
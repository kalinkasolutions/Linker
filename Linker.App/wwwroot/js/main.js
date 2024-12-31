const addLinkButton = document.getElementById("addLinkButton");
const linkInput = document.getElementById("linkInput");
const linkOutput = document.getElementById("linkOutput");
const linkOutputError = document.getElementById("linkOutputError");

const baseUrl = window.location.href;

addLinkButton.addEventListener("click", async () => {
    await addLink();
});

linkInput.addEventListener("keyup", async (e) => {
    if (e.key === "Enter") {
        await addLink();
    }
});

const addLink = async () => {
    if (!linkInput.value) {
        return;
    }

    const response = await fetch(`${baseUrl}l`,
        {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({Url: linkInput.value})
        });
    if (response.status !== 200) {
        linkOutputError.innerHTML = "Not a valid Url";
        linkOutput.innerHTML = "";
    } else {
        const link = await response.text();
        linkOutput.href = `${baseUrl}l/${link}`;
        linkOutput.innerHTML = `${baseUrl}l/${link}`;
        linkInput.value = "";
        linkOutputError.innerHTML = "";
    }
}

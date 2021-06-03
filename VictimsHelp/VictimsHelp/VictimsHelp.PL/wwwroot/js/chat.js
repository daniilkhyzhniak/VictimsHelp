$(document).ready(() => {
    worker();
});

async function worker() {
    const url = window.location.href;
    const email = url.split('/').pop();

    await fetch(`/chat/messages/${email}`, {
        method: 'GET',
        headers: { "Accept": "application/json" }
    }).then((response) => {
        return response.text();
    }).then((view) => {
        $('#chat').html(view);
    });

    setTimeout(worker, 5000);
}
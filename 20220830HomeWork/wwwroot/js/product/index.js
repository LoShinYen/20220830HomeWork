
async function Delete(id) {
    let request = new Request(`/Product/Delete/${id}`, {
        method: "Post",
        headers: { "COntent-Type": "application/json" },
    })
    let deleteFetch = await fetch(request);
    let response = await deleteFetch.json();
    alert(`${response.msg}`)
    setTimeout(function () { location.reload()},1500)
}

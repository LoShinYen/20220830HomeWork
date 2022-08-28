
async function Delete(id) {
    let request = new Request(`/Product/Delete/${id}`, {
        method: "Post",
        headers: { "Content-Type": "application/json" },
    })
    let deleteFetch = await fetch(request);
    let response = await deleteFetch.json();
    alert(`${response.msg}`)
    setTimeout(function () { location.reload()},1500)
}

$('.Btn-Product').click(BtnToggle)
$('.Btn-Cancel').click(BtnToggle)

function BtnToggle() {
    $('.Btn-Product').toggle()
    $('.Btn-Cancel').toggle()
    $('.Product-Box').toggle()
}

let btn_Save = document.querySelector('.Btn-Save')

btn_Save.addEventListener('click', async function () {
    let input = document.querySelectorAll('.Add-Content')
    let request = new Request('/Product/Create', {
        method: "Post",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            ProductName:`${input[0].value}`,
            ProductPrice:`${input[1].value}`,
            ProductStock:`${input[2].value}`,
            CategoryID:`${input[3].value}`
        })
    })
    let createFetch = await fetch(request)
    let response = await createFetch.json()
    debugger
    if (response.success == true) {
        alert(`${response.msg}`)
        BtnToggle()
        setTimeout(function () { location.reload() }, 500)
    }
    else {
        alert(`${response.msg}`)
    }
})
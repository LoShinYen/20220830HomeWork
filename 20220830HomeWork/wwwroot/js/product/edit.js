﻿EditResult()
function EditResult() {
    var msg = document.getElementById('msg')
    if (msg.value !== '') {
        alert(`${msg.value}`)
    }
}

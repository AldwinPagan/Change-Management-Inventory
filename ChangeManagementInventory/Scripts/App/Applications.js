function submitItemsPerPageSelection() {
    window.location.href = "/Applications/Index?page=1&pageSize=" + $("#pageSize").val()
}
function changeLabel() {
    fileName = this.files[0].name;
    console.log("something");
    console.log(fileName);
}

function deleteApplication(appId) {

    $.ajax({
        type: "POST",
        url: "/Applications/Delete",
        data: { Id: appId },
        success: function (data, text) {
            window.location.href = "/Applications/Index?page=1&pageSize=" + $("#pageSize").val()
        },

    })
}

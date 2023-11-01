function InsertWorkOrder() {
    var obj = new Object();

    obj.ReportGuid = $("#reportGuid").val();
    obj.Title = $("#title").val();
    obj.Description = $("#description").val();
    obj.CsEmployeeGuid = $("#cs").val();

    console.log(obj);

    $.ajax({
        url: "/WorkOrder/ToCreate",
        type: "POST",
        data: obj, // Menggunakan 'data' untuk mengirimkan objek JSON
        success: function (result) {
            
            Swal.fire({
                icon: 'success',
                title: 'Success!',
                text: result.message,

            })
        },
        error: function (error) {
            console.log(error);
            let errorMessage;
            if (Array.isArray(error.responseJSON.error)) {
                errorMessage = error.responseJSON.error[0];
            } else {
                errorMessage = error.responseJSON.error;

            }
            Swal.fire({
                icon: 'error',
                title: 'Failed!',
                text: errorMessage,

            });
        }
    });
}
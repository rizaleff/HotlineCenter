$(document).ready(function () {
    $(document).on('click', 'button[data-action="detail"]', function () {

        var reportData = $(this).data('report');
        var reportBy = reportData.reportBy;
        var title = reportData.title;
        var createdDate = reportData.createdDate;
        var status = reportData.status;
        var note = reportData.note;
        var modifiedDate = reportData.modifiedDate;
        var reportPhoto = reportData.reportPhoto;

        $('#reportBy').text(reportBy);
        $('#title').text(title);
        $('#createdDate').text(createdDate);
        $('#status').text(status);
        $('#note').text(note);
        $('#modifiedDate').text(modifiedDate);
        $('#reportPhoto').attr('src', reportPhoto);

        console.log(status)
        var modalFooter = $('#modalFooter');
        modalFooter.empty();
        if (status === 'Sending') {
            // Jika status adalah "sending", tambahkan tombol "Process" dan "Reject"
            var rejectButton = $('<button>')


                .addClass('btn btn-danger')
                .text('Reject')
                .click(function () {
                    $('#reportGuidInput').val(reportData.reportGuid);
                    $('#DetailModal').modal('hide');

                })
                .attr('id', 'rejectButton')
                .attr('data-bs-toggle', 'modal') // Tambahkan atribut data-bs-toggle
                .attr('data-bs-target', '#rejectWoModal') // Tambahkan atribut data-bs-target

            modalFooter.append(rejectButton);


            var processButton = $('<button>')
                .addClass('btn btn-success')
                .text('Process')
                .attr('id', 'processBtn')
                .click(function () {
                    // Tambahkan logika untuk menangani aksi ketika tombol "Process" diklik di sini
                    $('#reportGuidHidden').val(reportData.reportGuid);
                    
                    $("#detailModal").modal("hide");
                    var createWorkOrderModal = new bootstrap.Modal(document.getElementById('createWorkOrderModal'));
                    createWorkOrderModal.show();
                    console.log('Process button clicked');
                });
            modalFooter.append(processButton);


        } else {
            // Jika status bukan "sending", tambahkan tombol "Close"
            var closeButton = $('<button>')
                .addClass('btn btn-secondary')
                .text('Close')
                .attr('data-bs-dismiss', 'modal');

            modalFooter.append(closeButton);
        }
    });
});



function InsertWorkOrder() {
    var obj = new Object();

    obj.ReportGuid = $("#reportGuidHidden").val();
    obj.Title = $("#inputWoTitle").val();
    obj.Description = $("#inputWoDesc").val();
    obj.CsEmployeeGuid = $("#inputCs").val();

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
            $('#rejectWoModal').modal('hide');
            $('#detailModal').modal('hide');

            reportTable.ajax.reload();
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


function UpdateStatusReport() {
    
    var obj = new Object();
    obj.note = $("#noteTextArea").val();
    obj.guid = $("#reportGuidInput").val();
    obj.status = 2;


    $.ajax({
        url: "/Report/UpdateStatus",
        type: "POST",
        data: obj, // Menggunakan 'data' untuk mengirimkan objek JSON

        success: function (result) {
            console.log(result)
            Swal.fire({
                icon: 'success',
                title: 'Success!',
                text: result.message,

            })

            reportTable.ajax.reload();
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
    $('#detailModal').modal('hide');
}



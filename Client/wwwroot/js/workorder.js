let reportTable;
let workOrderTable;
let workReportTable;
$(document).ready(function () {
    $('.js-example-basic-single').select2({
        placeholder: 'Select an option'
    });

    $('.list-cs').select2({
        placeholder: 'Select an option'
    });

    //Datatable
    let reportTable = $("#tableReports").DataTable();
    let workOrderTable = $("#workOrderTable").DataTable();
    let workReportTable = $("#workReportTable").DataTable();

    $(document).on('click', 'button[data-action="detailWorkReport"]', function () {
        var wrData = $(this).data('wr');
        console.log(wrData);
        console.log(typeof wrData);
        var titleWr = wrData.title;
        var descriptionWr = wrData.description;
        var isFinish = wrData.isFinish;
        var createdDateWr = wrData.createdDate;
        var workReportPhoto = wrData.workReportPhoto;
        var reportGuid = wrData.reportGuid;

        console.log("before title")
        $('#titleWr').text(titleWr);
        console.log(wrData.title + " wr data")
        $('#descriptionWr').text(descriptionWr);
        $('#imageWr').attr('src', workReportPhoto);

        console.log("isFInih= " + isFinish)
        console.log("type= " + typeof isFinish)
        var modalFooter = $('#detailWrModalFooter');
        modalFooter.empty();
        if (isFinish === "False") {
            console.log("masuk seleksi konsisi")
            var closeButton = $('<button>')
                .addClass('btn btn-secondary')
                .text('Close')
                .attr('data-bs-dismiss', 'modal');

            modalFooter.append(closeButton);
            var processButton = $('<button>')
                .addClass('btn btn-success')
                .text('Process')
                .attr('id', 'processBtn')
                .click(function () {
                    // Tambahkan logika untuk menangani aksi ketika tombol "Process" diklik di sini
                    $('#reportGuidHidden').val(reportGuid);

                    $("#detailsWorkReportModal").modal("hide");
                    var createWorkOrderModal = new bootstrap.Modal(document.getElementById('createWorkOrderModal'));
                    createWorkOrderModal.show();
                    console.log('Process button clicked');
                });
            modalFooter.append(processButton);


        } else {

            console.log("masuk seleksi konsisi else")
           
            var closeButton = $('<button>')
                .addClass('btn btn-secondary')
                .text('Close')
                .attr('data-bs-dismiss', 'modal');

            modalFooter.append(closeButton);
        }

    });


});
$(document).on('click', 'button[data-action="detail"]', function () {

        var reportData = $(this).data('report');
        var reportBy = reportData.reportBy;
        var title = reportData.title;
    var createdDate = reportData.createdDate;
    var description = reportData.description;
        var status = reportData.status;
        var note = reportData.note;
        var modifiedDate = reportData.modifiedDate;
    var reportPhoto = reportData.reportPhoto;
    console 
        $('#reportBy').text(reportBy);
        $('#title').text(title);
        $('#createdDate').text(createdDate);
        $('#statusReport').text(status);
        $('#note').text(note);
        $('#modifiedDate').text(modifiedDate);
        $('#description').text(description);
        $('#reportPhoto').attr('src', reportPhoto);

    console.log(typeof status)
    switch (status) {
        case "Sending":
            $('#statusReport').addClass("bg-light-success text-succes");
            break;
        case "OnProcess":
            $('#statusReport').addClass("bg-light-warning text-warning");
            break;
        case "Reject":
            $('#statusReport').addClass("bg-light-danger text-danger");
            break;

        default:
            $('#statusReport').addClass("bg-light-info text-info");
            break;
    }

        console.log(status)
        var modalFooter = $('#modalFooter');
        modalFooter.empty();
        if (status === 'Sending') {
            // Jika status adalah "sending", tambahkan tombol "Process" dan "Reject"
            var rejectButton = $('<button>')

                .addClass('btn btn-danger')
                .text('Reject')
                .attr('id', 'rejectButton')
                .click(function () {
                    $('#reportGuidInput').val(reportData.reportGuid);

                    $("#detailModal").modal("hide");
                    var rejectWoModal = new bootstrap.Modal(document.getElementById('rejectWoModal'));

                    rejectWoModal.show();

                    console.log('Reject button clicked');

                });
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

    $(document).on('click', 'button[data-action="detailWorkOrder"]', function () {

        var woData = $(this).data('wo');
        var title = woData.title;
        var description = woData.description;
        var status = woData.status;
        var createdDate = woData.createdDate;
        var reportTitle = woData.reportTitle;
        var reportDescription = woData.reportTitle;
        var note = woData.note;
        var modifiedDate = woData.modifiedDate;
        var reportPhoto = woData.reportPhoto;

        $('#title').text(title);
        $('#createdDate').text(createdDate);
        $('#description').text(description);
        $('#reportDescription').text(reportDescription);
        $('#status').text(status);
        console.log(status);
        $('#note').text(note);
        $('#modifiedDate').text(modifiedDate);
        $('#image').attr('src', reportPhoto);

            
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

            });
           /* $('#rejectWoModal').modal('hide');
            $('#detailModal').modal('hide');
            console.log("succes create Work order")
            reportTable.ajax.reload();*/

            $('#createWorkOrderModal').modal('hide');
            console.log("success create Work order");
            location.reload();
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


var statusElement = document.getElementById("status");

// Ambil nilai status
var statusValue = "NotStarted"; // Ganti dengan nilai status yang sesuai

// Ganti teks dan latar belakang berdasarkan nilai status
switch (statusValue) {
    case "NotStarted":
        statusElement.textContent = "Not Started";
        statusElement.classList.add("bg-danger");
    case "InProgress":
        statusElement.textContent = "Not Started";
        statusElement.classList.add("bg-warning");
    case "Completed":
        statusElement.textContent = "Not Started";
        statusElement.classList.add("bg-success");
        break;
    // Tambahkan kasus lain jika diperlukan
    default:
        statusElement.textContent = statusValue;
        break;
}



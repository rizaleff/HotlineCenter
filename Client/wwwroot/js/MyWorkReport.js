﻿
// Cek apakah kita berada di halaman "myreport"
if (window.location.pathname === '/ServiceWorker/MyWorkReport') {
    // Panggil fungsi getWorkReportByEmployeeGuid dengan parameter yang sesuai
    console.log(thisEmpGuid)
    getWorkReportByEmployeeGuid(thisEmpGuid);
} else if (window.location.pathname === '/ServiceWorker') {

    getWorkOrderByEmployeeGuid(thisEmpGuid);
}

// Tambahkan event listener pada tombol "my report" di navbar

function getWorkReportByEmployeeGuid(employeeGuid) {

    // Gantilah URL_API dengan URL endpoint API Anda
    const URL_API = `/WorkReport/GetWorkReportByEmployeeGuid/?employeeGuid=${employeeGuid}`; // Gantilah dengan URL endpoint API Anda
    console.log(URL_API);
    $.ajax({
        url: URL_API
    }).done((res) => {
        // Menginisialisasi DataTable dengan data JSON yang diterima
        $('#myWorkReportTable').DataTable({
            data: res,
            columns: [
                {
                    "data": "id",
                    render: function (data, type, row, meta) {
                        return meta.row + meta.settings._iDisplayStart + 1;
                    }
                },
                { data: 'title' },
                { data: 'description' },
                {
                    data: null,
                    render: function (data, type, row) {
                        return '<button class="btn btn-primary btn-sm" data-action="detailWorkReport" data-id="' + data.id + '">Details</button> ';
                    },
                },
            ]
        });


    }).fail((err) => {
        console.log(err);
    });
}


function getWorkOrderByEmployeeGuid(employeeGuid) {

    // Gantilah URL_API dengan URL endpoint API Anda
    const URL_API = `/WorkOrder/GetWorkOrderByEmployeeGuid/?employeeGuid=${employeeGuid}`; // Gantilah dengan URL endpoint API Anda
    console.log(URL_API);
    $.ajax({
        url: URL_API
    }).done((res) => {
        // Menginisialisasi DataTable dengan data JSON yang diterima
        $('#workOrderTable').DataTable({
            data: res,
            columns: [
                {
                    "data": "id",
                    render: function (data, type, row, meta) {
                        return meta.row + meta.settings._iDisplayStart + 1;
                    }
                },
                { data: 'title' },
                { data: 'description' },
                {
                    data: null,
                    render: function (data, type, row) {
                        return '<button class="btn btn-primary btn-sm" data-action="detail" data-id="' + data.id + '">Details</button> ';
                    },
                },

            ]
        });


    }).fail((err) => {
        console.log(err);
    });
}

// Tambahkan event listener untuk tombol "Detail"

function fillModalWithWorkOrderData(workOrderData) {
    const URLD = `/WorkOrder/GetWorkOrderDetails/?guid=${workOrderData.guid}`;
    console.log(URLD);
    console.log(workOrderData);
    // Mengisi setiap elemen formulir dengan data yang sesuai
    $.ajax({
        url: URLD
    }).done((workOrderData) => {
        // Menginisialisasi DataTable dengan data JSON yang diterima
        $("#title").text(workOrderData.title);
        $("#description").text(workOrderData.description);
        $("#reportDescription").text(workOrderData.reportDescription);
        $('#image').attr('src', `data:image/png;base64,${workOrderData.reportPhoto}`);
        $("#workOrderGuid").val(workOrderData.guid);
        $("[name='employeeGuid']").val(workOrderData.employeeGuid);

        if (workOrderData.status == 0) {
            // Jika status work order adalah 0, tampilkan tombol "Take Work Order"
            document.getElementById("takeWorkOrderButton").style.display = "block";
            document.getElementById("createWorkOrderReportButton").style.display = "none";
        } else {
            // Jika status work order bukan 0, tampilkan tombol "Create Work Order Report" dan sembunyikan tombol "Take Work Order"
            document.getElementById("takeWorkOrderButton").style.display = "none";
            document.getElementById("createWorkOrderReportButton").style.display = "block";
        }

      
    }).fail((err) => {
        console.log(err);
    });
    console.log(workOrderData.employeeGuid);
    // Menampilkan modal detail
    var myModal = new bootstrap.Modal(document.getElementById('detailsModal'));
    myModal.show();
}

$("#createWorkOrderReportButton").on("click", function () {
    // Munculkan modal createWorkOrderReportModal
    $("#detailsModal").modal("hide");

    var createWorkOrderReportModal = new bootstrap.Modal(document.getElementById('createWorkOrderReportModal'));
    createWorkOrderReportModal.show();

});


$("#takeWorkOrderButton").on("click", function () {

    var obj = new Object();
    obj.guid = $("#workOrderGuid").val();
    obj.status = 1;
    console.log(obj);
    $.ajax({
        url: "/WorkOrder/UpdateStatus/",
        type: "POST",
        data: obj,
        success: function (result) {
            Swal.fire({
                icon: 'success',
                title: 'Success!',
                text: "Sukses mengambil work order",
            });

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
})


$("#submitWorkReport").on("click", function () {
    const title = $("#newTitle").val();
    const description = $("#newDescription").val();
    const workOrderGuid = $("#workOrderGuid").val();
    const employeeGuid = thisEmpGuid;
    const photoInput = $("#photoFile")[0];

    const photoFile = photoInput.files[0];
    // Check if a file is selected
    if (photoInput) {

        const reader = new FileReader();

        reader.onload = function (event) {
            // The result will be an ArrayBuffer
            //const photoArrayBuffer = event.target.result;

            // Convert ArrayBuffer to base64
            //const photoBase64 = arrayBufferToBase64(photoArrayBuffer);
            var base64String = event.target.result.split(',')[1];
            console.log(base64String);
            // Buat objek data yang akan dikirim ke API
            const data = {
                Title: title,
                Description: description,
                WorkOrderGuid: workOrderGuid,
                EmployeeGuid: employeeGuid,
                Photo: base64String
            };

            console.log(data)
            // Kirim data ke API menggunakan AJAX
            $.ajax({
                url: "/WorkReport/CreateWorkReport",
                type: "POST",
                data: data,
                success: function (result) {
                    Swal.fire({
                        icon: 'success',
                        title: 'Success!',
                        text: result.message,
                    });
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
        };

        // Read the selected file as an ArrayBuffer
        //reader.readAsArrayBuffer(photoFile);
        reader.readAsDataURL(photoFile);
    } else {
        // Handle the case when no file is selected
        Swal.fire({
            icon: 'error',
            title: 'Error!',
            text: 'Please select a photo to upload.',
        });
    }
});

function fillModalWithWorkReportData(workReportData) {
    const URLWP = `/WorkReport/GetWorkReportDetails/?guid=${workReportData.guid}`;
    console.log(URLWP);
    console.log(workReportData);
    // Mengisi setiap elemen formulir dengan data yang sesuai
    $.ajax({
        url: URLWP
    }).done((workReportData) => {
        // Menginisialisasi DataTable dengan data JSON yang diterima
        $("#title").text(workReportData.title);
        $("#description").text(workReportData.description);
        $('#image').attr('src', `data:image/png;base64,${workReportData.photo}`);
        $("#workOrderGuid").val(workReportData.workOrderGuid);
        $("#createdDate").val(workReportData.createdDate);
        $("#note").val(workReportData.note);
    }).fail((err) => {
        console.log(err);
    });
    var myModal = new bootstrap.Modal(document.getElementById('detailsWorkReportModal'));
    myModal.show();
}

$("#createWorkOrderReportButton").on("click", function () {
    // Munculkan modal createWorkOrderReportModal
    $("#detailsModal").modal("hide");

    var createWorkOrderReportModal = new bootstrap.Modal(document.getElementById('createWorkOrderReportModal'));
    createWorkOrderReportModal.show();

});

$(document).on('click', 'button[data-action="detailWorkReport"]', function () {
    var data = $('#myWorkReportTable').DataTable().row($(this).parents('tr')).data();
    fillModalWithWorkReportData(data);
});

$(document).on('click', 'button[data-action="detail"]', function () {
    var data = $('#workOrderTable').DataTable().row($(this).parents('tr')).data();
    fillModalWithWorkOrderData(data);
});

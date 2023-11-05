
// Cek apakah kita berada di halaman "myreport"
if (window.location.pathname === '/ServiceWorker/MyWorkReport') {
    // Panggil fungsi getWorkReportByEmployeeGuid dengan parameter yang sesuai
    getWorkReportByEmployeeGuid('a0396d96-aebf-4ea5-6935-08dbda07316d');
} else if (window.location.pathname === '/ServiceWorker') {

    getWorkOrderByEmployeeGuid('a0396d96-aebf-4ea5-6935-08dbda07316d');
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
        $('#workReportTable').DataTable({
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
        $('#workReportTable').DataTable({
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


$("#submitWorkReport").on("click", function () {
    const title = $("#newTitle").val();
    const description = $("#newDescription").val();
    const workOrderGuid = $("#workOrderGuid").val();
    const employeeGuid = "a0396d96-aebf-4ea5-6935-08dbda07316d";
    const photoInput = $("#photoFile")[0];

    // Check if a file is selected
    if (photoInput.files.length > 0) {
        const photoFile = photoInput.files[0];

        const reader = new FileReader();

        reader.onload = function (event) {
            // The result will be an ArrayBuffer
            const photoArrayBuffer = event.target.result;

            // Convert ArrayBuffer to base64
            const photoBase64 = arrayBufferToBase64(photoArrayBuffer);

            
            // Buat objek data yang akan dikirim ke API
            const data = {
                Title: title,
                Description: description,
                WorkOrderGuid: workOrderGuid,
                EmployeeGuid: employeeGuid,
                Photo: photoBase64
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
        reader.readAsArrayBuffer(photoFile);
    } else {
        // Handle the case when no file is selected
        Swal.fire({
            icon: 'error',
            title: 'Error!',
            text: 'Please select a photo to upload.',
        });
    }
});

// Function to convert ArrayBuffer to base64
function arrayBufferToBase64(arrayBuffer) {
    const binary = new Uint8Array(arrayBuffer);
    let base64 = [];
    for (let i = 0; i < binary.length; i++) {
        base64 += String.fromCharCode(binary[i]);
    }
    return btoa(base64);
}







$(document).on('click', 'button[data-action="detail"]', function () {
    var data = $('#workReportTable').DataTable().row($(this).parents('tr')).data();
    fillModalWithWorkOrderData(data);

});

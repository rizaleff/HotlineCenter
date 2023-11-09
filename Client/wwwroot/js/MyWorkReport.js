
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
        res.reverse();
        $('#myWorkReportTable').DataTable({
            data: res,
            order: [[0, 'asc']],
            columns: [
                {
                    data: null,
                    render: function (data, type, row, meta) {
                        // Menggunakan meta.row + 1 agar nomor urut dimulai dari 1
                        return meta.row + 1;
                    }
                },
                { data: 'title' },
                { data: 'description' },
                {
                    data: 'isFinish',
                    render: function (data, type, row) {
                        if (data === false) {
                            return '<span class="bg-light-danger px-2 py-1 text-danger rounded">Not Done Yet</span>';
                        }
                        else {
                            // Jika status bukan nol, tampilkan nilai status yang sebenarnya
                            return '<span class="bg-light-success px-2 py-1 text-success rounded">Done</span>';
                        }
                    },
                },
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
        res.reverse();
        console.log(res);
        $('#workOrderTable').DataTable({
            data: res,
            order: [[0, 'asc']], 
            columns: [
                {
                    data: null,
                    render: function (data, type, row, meta) {
                        // Menggunakan meta.row + 1 agar nomor urut dimulai dari 1
                        return meta.row + 1;
                    }
                },
                { data: 'title' },
                { data: 'description' },
                {
                    data: 'status',
                    render: function (data, type, row) {
                        if (data === 0) {
                            return '<span class="bg-light-danger px-2 py-1 text-danger rounded">Not Started</span>';
                        }
                        else if (data === 1) {
                            return '<span class="bg-light-warning px-2 py-1 text-warning rounded">In Progress</span>';
                        }

                        else {
                            // Jika status bukan nol, tampilkan nilai status yang sebenarnya
                            return '<span class="bg-light-success px-2 py-1 text-success rounded">Done</span>';
                        }
                    },
                },
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
        } else if (workOrderData.status == 1) {
            // Jika status work order bukan 0, tampilkan tombol "Create Work Order Report" dan sembunyikan tombol "Take Work Order"
            document.getElementById("takeWorkOrderButton").style.display = "none";
            document.getElementById("createWorkOrderReportButton").style.display = "block";
        } else {
            console.log("else");
            document.getElementById("takeWorkOrderButton").style.display = "none";
            document.getElementById("createWorkOrderReportButton").style.display = "none";
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

document.addEventListener('DOMContentLoaded', function () {
    var statusSelect = document.getElementById('statusSelect');

    statusSelect.addEventListener('change', function () {
        var selectedValue = statusSelect.value;
        var booleanValue = (selectedValue === 'true'); // Konversi nilai menjadi boolean
        console.log(booleanValue);  // Hasilnya adalah true atau false
    });
});


$("#submitWorkReport").on("click", function () {
    const title = $("#newTitle").val();
    const description = $("#newDescription").val();
    const workOrderGuid = $("#workOrderGuid").val();
    const employeeGuid = thisEmpGuid;
    const photoInput = $("#photoFile")[0];
    const isFinishString = $("#statusSelect").val(); // Ganti ID sesuai dengan elemen select Anda

    // Konversi nilai string menjadi boolean
    const isFinish = (isFinishString === 'true');

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
            
            // Buat objek data yang akan dikirim ke API
            const data = {
                Title: title,
                Description: description,
                WorkOrderGuid: workOrderGuid,
                EmployeeGuid: employeeGuid,
                Photo: base64String,
                IsFinish: isFinish
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
                        willClose: () => {
                            // Reload halaman setelah tombol OK diklik
                            location.reload();
                        }
                    });
                    $('#createWorkOrderReportModal').modal('hide');
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

$(document).on('click', '#tutupCWP', function (e) {
    $(".modal-fade").modal("hide");
    $(".modal-backdrop").remove();
});

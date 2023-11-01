
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
                        return '<button class="btn btn-primary btn-sm" data-action="detail" data-id="' + data.id  + '">Details</button> ';
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
    // Mengisi setiap elemen formulir dengan data yang sesuai
    $("#title").text(workOrderData.title);
    $("#description").text(workOrderData.description);


    console.log(workOrderData);
    // Menampilkan modal detail
    var myModal = new bootstrap.Modal(document.getElementById('detailsModal'));
    myModal.show();
}

$(document).on('click', 'button[data-action="detail"]', function () {
    var data = $('#workReportTable').DataTable().row($(this).parents('tr')).data();
    fillModalWithWorkOrderData(data);

});

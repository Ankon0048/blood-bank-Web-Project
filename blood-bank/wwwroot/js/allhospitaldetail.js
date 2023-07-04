$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/AdminEvent/GetAll' },
        "columns": [
            { data: 'hospitalName' },
            { data: 'opositive' },
            { data: 'onegative' },
            { data: 'apositive' },
            { data: 'anegative' },
            { data: 'bpositive' },
            { data: 'bnegative' },
            { data: 'aBpositive' },
            { data: 'aBnegative' },
            { data: 'capacity' },
            {
                data: 'hospitalName',
                "render": function (data) {
                    return `<a href="/AdminEvent/EditAllHospitalDetail?name=${data}" class="btn btn-info"><i class="bi bi-pencil-square text-light"></i> Edit</a>`
                }
            }
        ]
    });
}
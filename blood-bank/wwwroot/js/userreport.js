$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tbluser').DataTable({
        "ajax": { url: '/AdminReport/Get' },
        "columns": [
            { data: 'userName' },
            { data: 'bloodgroup' },
            { data: 'number' },
            { data: 'status' },
            { data: 'amount' },
            { data: 'action' },
            { data: 'date' },
            { data: 'location' },
        ]
    });
}
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblmoney').DataTable({
        "ajax": { url: '/AdminReport/GetAll' },
        "columns": [
            { data: 'userId' },
            { data: 'userName' },
            { data: 'number' },
            { data: 'amount' },
            { data: 'trixID' },
            { data: 'date' },
        ]
    });
}
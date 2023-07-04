$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblReport').DataTable({
        "ajax": { url: '/AdminReport/Get' },
        "columns": [
            { data: 'userId' },
            { data: 'userName' },
            { data: 'bloodgroup' },
            { data: 'number' },
            { data: 'status' },
            { data: 'amount' },
            { data: 'action' },
            { data: 'date' },
            { data: 'location' },
            {
                data: 'count',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/AdminReport/EditReport?id=${data}" class="btn btn-outline-info mx-2"><i class="bi bi-pencil-square"></i> Edit</a>
                    </div>`
                }
            }
        ]
    });
}
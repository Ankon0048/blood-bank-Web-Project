$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tbluserlist').DataTable({
        "ajax": { url: '/AdminHome/GetAll' },
        "columns": [
            { data: 'userID' },
            { data: 'userName' },
            { data: 'email' },
            { data: 'address' },
            { data: 'bloodgrp' },
            { data: 'number' },
            { data: 'nid' },
            { data: 'dateOfBirth' },
            { data: 'gender'}
        ]
    });
}
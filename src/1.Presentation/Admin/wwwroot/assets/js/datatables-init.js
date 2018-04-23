$(document).ready(function() {
    $('#productCategories').DataTable({
        "columnDefs": [
            {
                "targets": [2],
                "orderable": false,
                "searchable": false,
                "render": function(data, type, row) {
                    return '<a class="btn btn-info btn-rounded m-b-10 m-l-5">Edit</a>' +
                            '<a class="btn btn-danger btn-rounded m-b-10 m-l-5">Delete</a>' ;
                }
            }
        ],
        "pageLength": 25,
        "serverSide": true,
        "ajax": {
            url: '/ProductCategory/List',
            dataSrc: 'data',
            type: "POST",
            contentType: "application/json",
            data: function (d) {
            // note: d is created by datatable, the structure of d is the same with DataTableParameters model above
                console.log(JSON.stringify(d));
                return JSON.stringify(d);
            }
        },
        "columns": [
            {data: 'name', name: 'name'},
            {data: 'parentName', name: 'parentName'},
            {data: '', name: ''}
        ]
    });     
});

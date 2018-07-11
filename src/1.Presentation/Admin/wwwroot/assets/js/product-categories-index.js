$(document).ready(function() {
    var ajaxUrl = $("#ajaxUrl").val();

    $('#productCategories').DataTable({
        "columnDefs": [
            {
                "targets": [2],
                "width": "10%",
                "orderable": false,
                "searchable": false,
                "render": function(data, type, row) {
                    return '<a><span class="fa fa-pencil f-s-25 color-info"></span></a>' +
                            '<a class="ml-3"><span class="fa fa-trash f-s-25 color-danger"></span></a>' ;
                }
            }
        ],
        "pageLength": 25,
        "serverSide": true,
        "ajax": {
            url: ajaxUrl,
            // dataSrc: 'data',
            // type: "POST",
            // contentType: "application/json",
            // data: function (d) {
            // // note: d is created by datatable, the structure of d is the same with DataTableParameters model above
            //     console.log(JSON.stringify(d));
            //     return JSON.stringify(d);
            // }
        },
        "columns": [
            {data: 'name', name: 'name'},
            {data: 'parentName', name: 'parentName'},
            {data: '', name: ''}
        ]
    });     
});

$(document).ready(function() {
    setTimeout(function() {
        // [ Autofill ]
        $('#autofill').DataTable({
            autoFill: true
        });
        // [ KeyTable Integration ]
        $('#Report_table').DataTable({
            keys: false,
            searching: false,
            autoFill: false
        });
        // [ Column Selector ]
        $('#confirm-table').DataTable({
            autoFill: {
                alwaysAsk: true
            }
        });
        $('#colum-select').DataTable({
            columnDefs: [{
                orderable: false,
                className: 'select-checkbox',
                targets: 0
            }],
            select: {
                style: 'os',
                selector: 'td:first-child'
            },
            order: [
                [1, 'asc']
            ],
            autoFill: {
                columns: ':not(:first-child)'
            }
        });
        // [ scroll fill ] 
        var safill = $('#scroll-fill').dataTable({
            scrollY: 400,
            scrollCollapse: true,
            paging: false,
            autoFill: true
        });

    }, 350);
});

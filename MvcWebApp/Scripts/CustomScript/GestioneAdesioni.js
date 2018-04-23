var table = "";

function tableAdesioni() {
    table = $('#adesioniTable').DataTable({
        dom: "Bfrtip",
        "language": {
            "info": "Mostrati da _PAGE_ a _PAGES_ di _TOTAL_ risultati",
            "paginate": {
                "first": "Prima",
                "last": "Ultima",
                "next": "Successiva",
                "previous": "Precedente"
            },
            "search": "Cerca:",
            "loadingRecords": "Caricamento...",
        },
        //ajax: "/GestioneAnagrafica/LoadTable",
        ajax: {
            url: '/AdesioneCollettiva/LoadTable',
            dataSrc: ''
        },
        //pageLength: 1,
        //page : 2,
        //paging: { page: 2},
        columnDefs: [
              {
                  width: "auto",
                  className: "u-textLeft",
                  targets: '_all',
              },
            {
                targets: 0,
                createdCell: function (td, cellData, rowData, row, col) {
                    //var htmlErrori = '<a title="salva" class="salva u-md-margin color-primo u-textClean-Icon u-text-m" >';
                    //htmlErrori += '      <span class="far fa-save" aria-hidden="true"></span>';
                    //htmlErrori += '    <span class="u-hiddenVisually">salva</span>';
                    //htmlErrori += '    </a>';
                var htmlErrori = '   <a title="cancella" class="cancella u-md-margin color-primo u-textClean-Icon u-text-m" >';
                    htmlErrori += '       <span class="far fa-trash-alt" aria-hidden="true"></span>';
                    htmlErrori += '       <span class="u-hiddenVisually">cancella</span>';
                    htmlErrori += '   </a>';
                    htmlErrori += '   <div class="fas fa-exclamation-circle u-color-red u-textClean-Icon u-text-m">';
                    htmlErrori += '       <span class="tooltiptext">';
                    htmlErrori += '           <a title="modifica" class="modifica color-primo u-textClean-Icon u-text-m" >';
                    htmlErrori += '               <span class="far fa-edit  u-margin-bottom-xs" aria-hidden="true"></span>';
                    htmlErrori += '             <span class="u-hiddenVisually">modifica</span>';
                    htmlErrori += '           </a><br>';
                    $(td).html(htmlToInsert);
                }
            }
        ],
        columns: [
            {
                data: null, defaultContent: "", orderable: false
            },
            //{
            //    data: null, render: function (data, type, row) {
            //        // Combine the first and last names into a single table field
            //        return data.Cognome + ' ' + data.Nome;
            //    }
            //},
            { data: "Assicurato", defaultContent: "Pippo" },
            //{ data: "salary", render: $.fn.dataTable.render.number(',', '.', 0, '$') },
            { data: "Codice fiscale", defaultContent: "Pluto CFFFF" },
            { data: "Categoria", defaultContent: "Categ" },
            { data: "Polizza", defaultContent: "Poli" },
            { data: "Età", defaultContent: "45" },
            { data: "Adesione", defaultContent: "AC" },
            { data: "Email", defaultContent: "hotmail" }
        ],
        order: [1, 'asc']

    });
}
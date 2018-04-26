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
                    htmlErrori += '<a title="modifica" class="modifica color-primo u-textClean-Icon u-text-m" >';
                    htmlErrori += ' <span class="far fa-edit" aria-hidden="true"></span>';
                    htmlErrori += '<span class="u-hiddenVisually">modifica</span>';
                    htmlErrori += '</a>';
                    $(td).html(htmlErrori);
                }
            }
        ],
        columns: [
            {
                data: null, defaultContent: "", orderable: false
            },
            {
                data: null, render: function (data, type, row) {
                    // Combine the first and last names into a single table field
                    return data.Soggetto.Nome + ' ' + data.Soggetto.Cognome;
                }
            },
            { data: "Ente.CodiceEnte" },
            //{ data: "salary", render: $.fn.dataTable.render.number(',', '.', 0, '$') },
            { data: "Soggetto.CodiceFiscale"},
            { data: "T_TipoSoggetto.DescTipoSoggetto" },
            { data: "T_TipoAdesione.DescBreve" },
            { data: "Eta"},
            { data: "Soggetto.Telefono", defaultContent: "" },
            { data: "Soggetto.Email", defaultContent: "" }
        ],
        order: [1, 'asc']

    });

    $('#adesioniTable tbody').on('click', 'a.modifica', function () {
        var data = table.row($(this).parents('tr')).data();
        $(this)[0].href = "/AdesioneCollettiva/ModificaAdesione?id=" + data.IdAdesione + "&page=" + table.page().toString();
        //$.ajax({
        //    // edit to add steve's suggestion.
        //    url: "/GestioneAnagrafica/EditSoggettoImportato/" + data.IdSoggetto,
        //    //url: '<%= Url.Action("EditSoggettoImportato", "GestioneAnagrafica", new{id=data.IdSoggetto}) %>',
        //    success: function (data) {
        //        // your data could be a View or Json or what ever you returned in your action method 
        //        // parse your data here
        //        //alert(data);
        //    }
        //});
    });
    $('#adesioniTable tbody').on('click', 'a.cancella', function () {
        var data = table.row($(this).parents('tr')).data();
        $(this)[0].href = "/AdesioneCollettiva/CancellaAdesione?id=" + data.IdAdesione + "&page=" + table.page().toString();
    });
}
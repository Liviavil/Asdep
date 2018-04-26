function GestioneAnagrafica_EnteChange(val) {
    window.location.href = "/GestioneAnagrafica/RisultatiSoggettiImportati?ente=" + val;
}
var table = "";
var numPage = "";

function tableCreate() {

    table= $('#example').DataTable({
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
            url: '/GestioneAnagrafica/LoadTable',
            dataSrc: ''
        },
        //pageLength: 1,
        //page : 2,
        //paging: { page: 2},
        columnDefs: [
              {
                  width:"auto",
                  className: "u-textLeft",
                  targets: '_all',
              },
            {
                targets: 0,
                createdCell: function (td, cellData, rowData, row, col) {
                    if (rowData.ErroriList.length > 0)
                    {
                        var htmlErrori = "";
                        //if (!rowData.AllWarnings) {
                        //    //$(td).addClass("Prose Alert Alert--error Alert--withIcon u-layout-prose u-padding-r-bottom u-padding-r-right   u-margin-r-bottom");
                        //}
                        //else
                        //{
                        //    $(td).addClass("Prose Alert Alert--warning Alert--withIcon u-layout-prose u-padding-r-bottom u-padding-r-right   u-margin-r-bottom");
                        //}
                        //var htmlErrori = '<a title="salva" class="salva u-md-margin color-primo u-textClean-Icon u-text-m" >';
                        //htmlErrori+= '      <span class="far fa-save" aria-hidden="true"></span>';
                        //htmlErrori+=   '    <span class="u-hiddenVisually">salva</span>';
                        //htmlErrori+='    </a>';
                    var htmlErrori ='   <a title="cancella" class="cancella u-md-margin color-primo u-textClean-Icon u-text-m" >';
                        htmlErrori+='       <span class="far fa-trash-alt" aria-hidden="true"></span>';
                        htmlErrori+='       <span class="u-hiddenVisually">cancella</span>';
                        htmlErrori+='   </a>';
                        htmlErrori+='   <div class="fas fa-exclamation-circle u-color-red u-textClean-Icon u-text-m">';
                        htmlErrori+='       <span class="tooltiptext">';
                        htmlErrori+='           <a title="modifica" class="modifica color-primo u-textClean-Icon u-text-m" >';
                        htmlErrori+='               <span class="far fa-edit  u-margin-bottom-xs" aria-hidden="true"></span>';
                        htmlErrori += '             <span class="u-hiddenVisually">modifica</span>';
                        htmlErrori+='           </a><br>';
                       
                        $.each(rowData.ErroriList, function (index, val)
                        {
                            //$(td).html("<div class='tooltiptext'>" + val.ColumnName + ": " + val.Description + "<br>");
                            htmlErrori += "<strong>" + val.Colonna + "</strong>: " + val.DescErrore + "<br>"
                        });
                        htmlErrori += "</span></div>";
                        $(td).html(htmlErrori);
                    }
                    else
                    {
                        var htmlToInsert = "";
                        if (rowData.CodiceFiscaleAssicurato == rowData.CodiceFiscaleCapoNucleo || rowData.TipoTracciato == "Esclusioni") {
                            htmlToInsert = '<a title="salva" class="salva u-md-margin color-primo u-textClean-Icon u-text-m">';
                            htmlToInsert += '      <span class="far fa-save" aria-hidden="true"></span>';
                            htmlToInsert += '      <span class="u-hiddenVisually">salva</span>';
                            htmlToInsert += '     </a>';
                        }
                        htmlToInsert+='     <a title="cancella" class=" cancella u-md-margin color-primo u-textClean-Icon u-text-m">';
                        htmlToInsert+='         <span class="far fa-trash-alt" aria-hidden="true"></span>';
                        htmlToInsert+='         <span class="u-hiddenVisually">cancella</span>';
                        htmlToInsert+=      '</a>';
                        htmlToInsert+=      '<a title="modifica" class="modifica color-primo u-textClean-Icon u-text-m" >';
                        htmlToInsert+=       ' <span class="far fa-edit" aria-hidden="true"></span>';
                        htmlToInsert+=        '<span class="u-hiddenVisually">modifica</span>';
                        htmlToInsert+=      '</a>';
                        //$(td).addClass("Icon-file");
                        $(td).html(htmlToInsert);
                    }
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
                    return data.Cognome + ' ' + data.Nome;
                }
            },
            { data: "Categoria" },
            //{ data: "salary", render: $.fn.dataTable.render.number(',', '.', 0, '$') },
            { data: "NumeroPolizza" },
            { data: "CodiceFiscaleAssicurato" },
            { data: "CodiceFiscaleCapoNucleo" },
            { data: "TipoTracciato" }

        ],
        order: [1, 'asc']
       
    }).on('stateLoaded.dt', function (e, settings, data) {
        var data = data;
        // $('#myInput').val(data.myCustomValue);
    });

    $('#example tbody').on('click', 'a.modifica', function () {
        var data = table.row($(this).parents('tr')).data();  
        $(this)[0].href = "/GestioneAnagrafica/EditSoggettoImportato?id=" + data.IdSoggetto + "&page=" + table.page().toString();
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
    $('#example tbody').on('click', 'a.cancella', function () {
        var data = table.row($(this).parents('tr')).data();
        $(this)[0].href = "/GestioneAnagrafica/Scarta?id=" + data.IdSoggetto + "&page=" + table.page().toString();
    });
    $('#example tbody').on('click', 'a.salva', function () {
        var data = table.row($(this).parents('tr')).data();
        $(this)[0].href = "/GestioneAnagrafica/InviaAdesione?cf=" + data.CodiceFiscaleCapoNucleo + "&page=" + table.page().toString();
    });

}
function changePage(p)
{
    numPage = p;
}






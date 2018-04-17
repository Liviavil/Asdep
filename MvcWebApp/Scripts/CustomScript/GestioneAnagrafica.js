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
        pageLength: 1,
        //page : 2,
        //paging: { page: 2},
        columnDefs: [
            {
                className: "u-textLeft scarta",
                targets: 0,
            },
             {
                 className: "u-textLeft salva",
                 targets: 1,
             },
              {
                  className: "u-textLeft",
                  targets: '_all',
              },
            {
                targets: 2,
                createdCell: function (td, cellData, rowData, row, col) {
                    if (rowData.Errori.length > 0)
                    {
                        if (!rowData.AllWarnings) {
                            $(td).addClass("Prose Alert Alert--error Alert--withIcon u-layout-prose u-padding-r-bottom u-padding-r-right   u-margin-r-bottom");
                        }
                        else
                        {
                            $(td).addClass("Prose Alert Alert--warning Alert--withIcon u-layout-prose u-padding-r-bottom u-padding-r-right   u-margin-r-bottom");
                        }
                        var htmlToInsert = "<div class='tooltiptext'>";
                       
                        $.each(rowData.Errori, function (index, val)
                        {
                            //$(td).html("<div class='tooltiptext'>" + val.ColumnName + ": " + val.Description + "<br>");
                            htmlToInsert += "<strong>" + val.ColumnName + "</strong>: " + val.Description + "<br>"
                        });
                        htmlToInsert += "</div>";
                        $(td).html(htmlToInsert);
                    }
                    else
                    {
                        $(td).addClass("Icon-file");
                    }
                }
            }
        ],
        //data: data,
        columns: [
            {
                data: null, defaultContent: "", orderable: false
            },
             {
                 data: null, defaultContent: "", orderable: false
             },
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
            { data: "CodiceFiscaleCapoNucleo" }

        ],
        order: [3, 'asc']
        //select: true
        //buttons: [
        //    //{
        //    //    extend: "create", editor: editor, formButtons: [
        //    //      {
        //    //          label: 'Crea',
        //    //          fn: function () { this.close(); }
        //    //      },
        //    //      'Create new row'
        //    //    ]
        //    //},
        //    { extend: "edit",  editor: editor,
        //        //formButtons:
        //        //    [
        //        //        {
        //        //            label: 'Modifica',
        //        //            //fn: function () { this.close(); }
        //        //        },
        //        //        'Modifica'
        //        //    ]
        //    }
        //    //,{ extend: "remove", editor: editor }
        //]
    }).on('stateLoaded.dt', function (e, settings, data) {
        var data = data;
        // $('#myInput').val(data.myCustomValue);
    });

    $('#example tbody').on('click', 'td.u-textLeft.Icon-file, td.u-textLeft.Prose', function () {
        var data = table.row($(this).parents('tr')).data();  
        window.location.href = "/GestioneAnagrafica/EditSoggettoImportato?id=" + data.IdSoggetto + "&page="+ table.page().toString() ;
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
    $('#example tbody').on('click', 'td.u-textLeft.scarta', function () {
        var data = table.row($(this).parents('tr')).data();
    });
    $('#example tbody').on('click', 'td.u-textLeft.salva', function () {
        var data = table.row($(this).parents('tr')).data();
    });

   
}
function changePage(p)
{
    numPage = p;
}

$(document).ready(function ()
{
    table.page(numPage).draw(false);
});




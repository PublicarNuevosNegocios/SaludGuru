﻿//init patient search grid
function PatientListGrid(vidDiv) {

    //configure grid
    $('#' + vidDiv).kendoGrid({
        toolbar: [{ template: $("#templateHeader").html() }],
        pageable: true,
        dataSource: {
            pageSize: 2,
            serverPaging: true,
            schema: {
                total: function (data) {
                    if (data && data.length > 0) {
                        return data[0].SearchProfileCount;
                    }
                    return 0;
                }
            },
            transport: {
                read: function (options) {

                    var oSearchCriteria = $('#' + vidDiv + '-txtSearch').val();

                    $.ajax({
                        url: '/api/ProfileApi?SearchCriteria=' + oSearchCriteria + '&PageNumber=' + (new Number(options.data.page) - 1) + '&RowCount=' + options.data.pageSize,
                        dataType: "json",
                        type: "POST",
                        success: function (result) {
                            options.success(result);
                        },
                        error: function (result) {
                            options.error(result);
                        }
                    });
                }
            },
        },
        columns: [{
            field: "Name",
            title: "Nombre",
            template: $("#templateName").html()
        }, {
            field: "Identification",
            title: "Indentificación"
        }, {
            field: "Email",
            title: "Contacto"
        }, {
            field: "Telphone",
            title: "Teléfono"
        }],
    });

    //add search button event
    $('#' + vidDiv + '-Search').click(function () {
        $('#' + vidDiv).getKendoGrid().dataSource.read();
    });
}
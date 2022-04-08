function LoadAGrid() {
    debugger;

    $("#demoGrid").dataTable().fnDestroy();
    $("#demoGrid").DataTable({
        "sDom": "ltipr",
        //   "order": [[11, "desc"]],
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "pageLength": 10,

        "ajax": {
            "url": "/Datable/GetJqGridJson?rn=URAttendance&clientName=A",
            "type": "POST",
            "datatype": "json"
        },

        "columnDefs":
            [{
                "targets": [0],
                "visible": false,
                "searchable": false
            },

            ],


        "columns": [
            { "data": "EmpId", "name": "EmpId", "autoWidth": true },
            { "data": "lastModifyDateEntry", "name": "lastModifyDateEntry", "autoWidth": true },
            { "data": "EmpName", "name": "EmpName", "autoWidth": true },

            {
                "data": "type", "render": function (data, type, full, meta) {
                    if (full["type"] == 'A') {
                        return 'Admin';
                    }
                    else if (full["type"] == 'SA') {
                        return 'Sub Admin';
                    }

                    else {
                        return 'Not Available';
                    }
                }
            },

            {
                "data": "type", "render": function (data, type, full, meta) {
                    if (full["isActive"] == '1') {
                        return 'Active';
                    }

                    if (full["isActive"] == '0') {
                        return 'Non Active';
                    }

                    else {
                        return 'Not Available';
                    }
                }
            },

            { "render": function (data, type, full, meta) { return '<a  data-toggle="modal" class="tooltip1" style="cursor:pointer"   onclick="Edit(' + full["EmpId"] + ')"  ><i class="material-icons edit-icon">edit</i><span class="tooltiptext1">Edit</span> </a>'; }, "width": "10%" },


        ],

    });

}

function LoadNGrid() {
    debugger;
    var appid = $('#appid').val();
    $.get("/houseScanifyEmp/GameAppList", null, house);
    function house(data) {
        var res = '';
        //for (var i = 0; i < data.length; i++) {
        //    res += "<li class=''><a style='cursor:pointer'class='li-hover' onclick='Edit(" + data[i].AppId + ")' id='" + data[i].AppId + "' >" + data[i].AppName + "</a></li>";
        //}
        var url_string = window.location.href; //window.location.href
        var url = new URL(url_string);
        var AppId_New = url.searchParams.get("AppId");

    $("#demoGrid").dataTable().fnDestroy();
    $("#demoGrid").DataTable({
        "sDom": "ltipr",
        //   "order": [[11, "desc"]],
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "pageLength": 10,

        for (var i = 0; i < data.length; i++) {
            res += "<li class='' ><a style='cursor:pointer' class='li-hover' onclick='AppList(" + data[i].AppId + ")' id='" + data[i].AppId + "' >" + data[i].AppName + " ";
            if (data[i].FAQ == 1) {
                res += "<i class='fa fa-circle pull-right' style='color:#fe9428;font-size:12px;margin: 3% auto;'></i>";
            }
            //if (AppId_New == data[i].AppId) {
            //      res += "<i class='fa fa-circle pull-right' style='color:#fe9428;font-size:12px;margin: 3% auto;'></i>";
            //}
            res += "</a></li>";
        }

        "columnDefs":
            [{
                "targets": [0],
                "visible": false,
                "searchable": false
            },

            ],


        "columns": [
            { "data": "EmpId", "name": "EmpId", "autoWidth": true },
            { "data": "lastModifyDateEntry", "name": "lastModifyDateEntry", "autoWidth": true },
            { "data": "EmpName", "name": "EmpName", "autoWidth": true },

            {
                "data": "type", "render": function (data, type, full, meta) {
                    if (full["type"] == 'A') {
                        return 'Admin';
                    }
                    else if (full["type"] == 'SA') {
                        return 'Sub Admin';
                    }

                    else {
                        return 'Not Available';
                    }
                }
            },

            {
                "data": "type", "render": function (data, type, full, meta) {
                    if (full["isActive"] == '1') {
                        return 'Active';
                    }

                    if (full["isActive"] == '0') {
                        return 'Non Active';
                    }

                    else {
                        return 'Not Available';
                    }
                }
            },

            { "render": function (data, type, full, meta) { return '<a  data-toggle="modal" class="tooltip1" style="cursor:pointer"   onclick="Edit(' + full["EmpId"] + ')"  ><i class="material-icons edit-icon">edit</i><span class="tooltiptext1">Edit</span> </a>'; }, "width": "10%" },


        ],

    });

}

function user_route(id) {
    window.location.href = "/HouseScanifyEmp/AddUREmployeeDetails?EmpId=" + id;
};
//////////////////////////////////////////////////////////////////////////////
function showInventoriesGrid() {
   // Search();
}

function Edit(Id) {
    window.location.href = "/HouseScanifyEmp/AddUREmployeeDetails?teamId=" + Id;

};

function AppList(Id) {
    //alert(Id);
    debugger;
    if (Id != null) {
        var url = "/HouseScanifyEmp/HSUserList?AppId=" + Id;
        window.location.href = url;
    }
};





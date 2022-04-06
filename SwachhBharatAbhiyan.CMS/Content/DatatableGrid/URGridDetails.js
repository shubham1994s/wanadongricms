$(document).ready(function () {
    debugger;

    // var ulb_menu=JSON.parse(window.localStorage.getItem("ulb_menu"));
    debugger;
    var appid = $('#appid').val();
    $.get("/HouseScanifyEmp/GetURAppNames", null, house);
    function house(data) {
        var res = '';
        //for (var i = 0; i < data.length; i++) {
        //    res += "<li class=''><a style='cursor:pointer'class='li-hover' onclick='Edit(" + data[i].AppId + ")' id='" + data[i].AppId + "' >" + data[i].AppName + "</a></li>";
        //}
        var url_string = window.location.href; //window.location.href
        var url = new URL(url_string);
        var AppId_New = url.searchParams.get("AppId");


        for (var i = 0; i < data.length; i++) {
            res += "<li class='' ><a style='cursor:pointer' class='li-hover' onclick='Edit(" + data[i].AppId + ")' id='" + data[i].AppId + "' >" + data[i].AppName + " ";
            if (data[i].TotalHouseUpdated_CurrentDay != 0 || data[i].TotalPointUpdated_CurrentDay != 0 || data[i].TotalDumpUpdated_CurrentDay != 0) {
                res += "<i class='fa fa-circle pull-right' style='color:#fe9428;font-size:12px;margin: 3% auto;'></i>";
            }
            //if (AppId_New == data[i].AppId) {
            //      res += "<i class='fa fa-circle pull-right' style='color:#fe9428;font-size:12px;margin: 3% auto;'></i>";
            //}
            res += "</a></li>";
        }


        $('.list-unstyled').html(res);
        $('#img_ldr').css("display", "none");
        $('#' + appid).parents('li').addClass('active');

        $(".li-hover").hover(function () {
            $(this).css("color", "#fff");
        }, function () {
            $(this).css("color", "#6c757d");
        });
        $(".active a").hover(function () {
            $(this).css("color", "#fff");
        }, function () {
            $(this).css("color", "#fff");
        });

    }
    //$.get("/HouseScanifyEmp/GetURAppNames", null, house);

    //function house(data) {
    //    var qqq = $('#appid').val();
    //    for (var i = 0; i < data.length; i++) {

    //        if (data[i].AppId == qqq) {
    //            $('#ulb_name').html(data[i].AppName);
    //        }
    //    }

    //}


    //var UserId = $('#selectnumber').val();

    // var ulb_menu=JSON.parse(window.localStorage.getItem("ulb_menu"));
    debugger;
    var appid = $('#appid').val();
    $.get("/HouseScanifyEmp/GetURAppNames", null, house);
    function house(data) {
        var res = '';
        //for (var i = 0; i < data.length; i++) {
        //    res += "<li class=''><a style='cursor:pointer'class='li-hover' onclick='Edit(" + data[i].AppId + ")' id='" + data[i].AppId + "' >" + data[i].AppName + "</a></li>";
        //}
        var url_string = window.location.href; //window.location.href
        var url = new URL(url_string);
        var AppId_New = url.searchParams.get("AppId");


        for (var i = 0; i < data.length; i++) {
            res += "<li class='' ><a style='cursor:pointer' class='li-hover' onclick='Edit(" + data[i].AppId + ")' id='" + data[i].AppId + "' >" + data[i].AppName + " ";
            if (data[i].TotalHouseUpdated_CurrentDay != 0 || data[i].TotalPointUpdated_CurrentDay != 0 || data[i].TotalDumpUpdated_CurrentDay != 0) {
                res += "<i class='fa fa-circle pull-right' style='color:#fe9428;font-size:12px;margin: 3% auto;'></i>";
            }
            //if (AppId_New == data[i].AppId) {
            //      res += "<i class='fa fa-circle pull-right' style='color:#fe9428;font-size:12px;margin: 3% auto;'></i>";
            //}
            res += "</a></li>";
        }


        $('.list-unstyled').html(res);
        $('#img_ldr').css("display", "none");
        $('#' + appid).parents('li').addClass('active');

        $(".li-hover").hover(function () {
            $(this).css("color", "#fff");
        }, function () {
            $(this).css("color", "#6c757d");
        });
        $(".active a").hover(function () {
            $(this).css("color", "#fff");
        }, function () {
            $(this).css("color", "#fff");
        });

    }
    var UserId = $('#appid').val();
    // alert(UserId);
    $.ajax({
        type: "post",
        url: "/HouseScanify/UserListByAppId?AppId=" + UserId,
        data: { userId: UserId },
        datatype: "json",
        traditional: true,
        success: function (data) {
            district = '<option value="-1">Select Employee</option>';
            console.log(data);
            for (var i = 0; i < data.length; i++) {
                district = district + '<option value=' + data[i].qrEmpId + '>' + data[i].qrEmpName + '</option>';
            }
            //district = district + '</select>';
            $('#selectnumber').html(district);
        }
    });


    $("#demoGrid").DataTable({
        "sDom": "ltipr",
        //   "order": [[11, "desc"]],
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "pageLength": 10,

        "ajax": {
            "url": "/Datable/GetJqGridJson?rn=URAttendance",
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

         

            { "render": function (data, type, full, meta) { return '<a  data-toggle="modal" class="tooltip1" style="cursor:pointer"   onclick="Edit(' + full["EmpId"] + ')"  ><i class="material-icons edit-icon">edit</i><span class="tooltiptext1">Edit</span> </a>'; }, "width": "10%" },


        ],

    });



    Search();

});

function user_route(id) {
    window.location.href = "/HouseScanifyEmp/AddUREmployeeDetails?EmpId=" + id;
};
//////////////////////////////////////////////////////////////////////////////
function showInventoriesGrid() {
    Search();
}

function Edit(Id) {
    window.location.href = "/HouseScanifyEmp/AddUREmployeeDetails?teamId=" + Id;
};

function Search() {
    var txt_fdate, txt_tdate, Client, UserId;
    var name = [];
    var arr = [$('#txt_fdate').val(), $('#txt_tdate').val()];

    for (var i = 0; i <= arr.length - 1; i++) {
        name = arr[i].split("/");
        arr[i] = name[1] + "/" + name[0] + "/" + name[2];
    }

    txt_fdate = arr[0];
    txt_tdate = arr[1];
    UserId = $('#selectnumber').val();
    Client = " ";
    NesEvent = " ";
    var Product = "";
    var catProduct = "";
    var value = txt_fdate + "," + txt_tdate + "," + UserId + "," + $("#s").val();//txt_fdate + "," + txt_tdate + "," + UserId + "," + Client + "," + NesEvent + "," + Product + "," + catProduct + "," + 1;
    // alert(value );
    oTable = $('#demoGrid').DataTable();
    oTable.search(value).draw();
    oTable.search("");
    document.getElementById('USER_ID_FK').value = -1;
}
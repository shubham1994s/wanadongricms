$(document).ready(function () {
    debugger;


    var UserId = $('#selectnumber').val();
    $.ajax({
        type: "post",
        url: "/Location/UserList?rn=NULL",
        data: { userId: UserId },
        datatype: "json",
        traditional: true,
        success: function (data) {
            district = '<option value="-1">Select Employee</option>';
            for (var i = 0; i < data.length; i++) {
                district = district + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
            }
            //district = district + '</select>';
            $('#selectnumber').html(district);
        }
    });

    $('#selecttype').html('<option value=0>Select Monitoring Type</option><option value=S>Waste Collection Monitoring Technology</option><option value=SS>Street Sweeping Monitoring System</option><option value=L>Liquid Waste Cleaning Monitoring System</option>');

    $("#demoGrid").DataTable({
        "sDom": "ltipr",
        "order": [[1, "desc"]],
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        //"pageLength": 10,

        "ajax": {
            "url": "/Datable/GetJqGridJson?rn=MonthlyAttendence",
            "type": "POST",
            "datatype": "json"
        },

        "columnDefs":
            [{
                "targets": [0],
                "visible": false,
                "searchable": false
            }
                //,
            //{
            //    "targets": [15],
            //    "visible": false,
            //    "searchable": false,
            //    "type": "date-eu"
            //}
            ],


        "columns": [
            //{ "data": "daID", "name": "daID", "autoWidth": true },
            { "data": "daID", "name": "daID", "autoWidth": true },
            { "data": "userName", "name": "userName", "autoWidth": true },
            { "data": "month_name", "name": "month_name", "autoWidth": true },

            { "data": "day1", "name": "day1", "autoWidth": true },
            { "data": "day2", "name": "day2", "autoWidth": true },
            { "data": "day3", "name": "day3", "autoWidth": true },
            { "data": "day4", "name": "day4", "autoWidth": true },
            { "data": "day5", "name": "day5", "autoWidth": true },
            { "data": "day6", "name": "day6", "autoWidth": true },
            { "data": "day7", "name": "day7", "autoWidth": true },
            { "data": "day8", "name": "day8", "autoWidth": true },
            { "data": "day9", "name": "day9", "autoWidth": true },
            { "data": "day10", "name": "day10", "autoWidth": true },

            { "data": "day11", "name": "day11", "autoWidth": true },
            { "data": "day12", "name": "day12", "autoWidth": true },
            { "data": "day13", "name": "day13", "autoWidth": true },
            { "data": "day14", "name": "day14", "autoWidth": true },
            { "data": "day15", "name": "day15", "autoWidth": true },
            { "data": "day16", "name": "day16", "autoWidth": true },
            { "data": "day17", "name": "day17", "autoWidth": true },
            { "data": "day18", "name": "day18", "autoWidth": true },
            { "data": "day19", "name": "day19", "autoWidth": true },
            { "data": "day20", "name": "day20", "autoWidth": true },

            { "data": "day21", "name": "day21", "autoWidth": true },
            { "data": "day22", "name": "day22", "autoWidth": true },
            { "data": "day23", "name": "day23", "autoWidth": true },
            { "data": "day24", "name": "day24", "autoWidth": true },
            { "data": "day25", "name": "day25", "autoWidth": true },
            { "data": "day26", "name": "day26", "autoWidth": true },
            { "data": "day27", "name": "day27", "autoWidth": true },
            { "data": "day28", "name": "day28", "autoWidth": true },
            { "data": "day29", "name": "day29", "autoWidth": true },
            { "data": "day30", "name": "day30", "autoWidth": true },
            { "data": "day31", "name": "day31", "autoWidth": true },

          
           
           
        ],
        // Sort: "locId DESC"
    });


});

function test(id) {
    window.location.href = "/Attendence/Location?daId=" + id;
};

function user_route(id) {
    window.location.href = "/Attendence/UserRoute?daId=" + id;
};

function house_route(id) {
    window.location.href = "/Attendence/HouseRoute?daId=" + id;
};
function map(a) {
    window.location.href = "/Location/viewLocation?teamId=" + a;

};
//////////////////////////////////////////////////////////////////////////////
function showInventoriesGrid() {
    Search();
}

function Search() {
    debugger;
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
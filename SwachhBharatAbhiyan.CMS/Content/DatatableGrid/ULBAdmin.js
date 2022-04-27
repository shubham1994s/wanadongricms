$(document).ready(function () {
    var DivisionId = $("#DivisionId").val();
    var DistrictId = $("#DistrictId").val();
    var AppId = $("#AppId").val();
    var UserId = $("#HSID").val();
    $("#demoGrid").DataTable({
        "sDom": "ltipr",
        "order": [[0, "desc"]],
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "pageLength": 10,

        "ajax": {
            "url": "/Datable/GetJqGridJson?rn=ULBAdmin&param1=" + DivisionId + "&param2=" + DistrictId + "&param3=" + AppId + "&userId=" + UserId,
            "type": "POST",
            "datatype": "json"
        },

        "columnDefs":
            [{
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [2],
                "visible": false,
                "searchable": false
            }],

        "columns": [
            { "data": "ULBId", "name": "ULBId", "autoWidth": false },
            { "data": "ULBName", "name": "ULBName", "autoWidth": false },
            { "data": "TotalHouse", "name": "TotalHouse", "autoWidth": false },
            { "data": "TotalHouseScan", "name": "TotalHouseScan", "autoWidth": false },
            { "data": "TotalSeg", "name": "TotalSeg", "autoWidth": false },
            { "data": "TotalMix", "name": "TotalMix", "autoWidth": false },
            { "data": "TotalNotReceived", "name": "TotalNotReceived", "autoWidth": false },

            //<a  data-toggle="modal" style="cursor:pointer;margin-left:10px;" class="tooltip1" style="cursor:pointer" onclick="Delete(' + full["Id"] + ',' + full["Name"] + ')" ><i class="material-icons delete-icon">delete</i><span class="tooltiptext1">Delete</span> </a>
        ]
    });
});

function Edit(Id) {

    if (Id != null) {
        var url = "/MainMaster/AddAreaDetails?teamId=" + Id;
        window.location.href = url;
    }
};

function Delete(Id) {
    if (Id != null && Id != '') {

        if (confirm("Do you want delete selected Area?")) {
            var url = "/MainMaster/DeleteArea?teamId=" + Id;
            window.location.href = url;
        }
    }
};


function Search() {
    var value = ",,," + $("#s").val();//txt_fdate + "," + txt_tdate + "," + UserId + "," + Client + "," + NesEvent + "," + Product + "," + catProduct + "," + 1;
    // alert(value );
    oTable = $('#demoGrid').DataTable();
    oTable.search(value).draw();
    oTable.search("");
    document.getElementById('USER_ID_FK').value = -1;
}

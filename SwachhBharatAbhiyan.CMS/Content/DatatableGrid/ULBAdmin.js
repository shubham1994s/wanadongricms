


var TotalProp = 0;
var TotalPropScan = 0;
var TotalSeg = 0;
var TotalMix = 0;
var TotalNotRecv = 0;
var ParentULB = '';

$(document).ready(function () {
    
    debugger;
    var DivisionId = $("#DivisionId").val();
    var DistrictId = $("#DistrictId").val();
    var AppId = $("#AppId").val();
    var UserId = $("#UserId").val();
    $("#demoGrid").DataTable({
        "sDom": "ltipr",
        "order": [[1, "asc"]],
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
        "drawCallback": function (settings) {
            debugger;
            var api = this.api();
            var rowData = api.rows().data();
            ParentULB = rowData[0]['ParentULB'];
            for (var i = 0; i < rowData.length; i++) {
                TotalProp += rowData[i]['TotalHouse'];
                TotalPropScan += rowData[i]['TotalHouseScan'];
                TotalSeg += rowData[i]['TotalSeg'];
                TotalMix += rowData[i]['TotalMix'];
                TotalNotRecv += rowData[i]['TotalNotReceived'];

            }
            showCharts();
        },
        "columnDefs":
            [{
                "targets": [0],
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

function showCharts() {


    CanvasJS.addColorSet("customColors1", [/*"#ff6384", "#36a2eb", "#ffce56", "#01a800"*/"#388e3c"]);
    var chart = new CanvasJS.Chart("chartContainer", {
        colorSet: "customColors1",
        animationEnabled: true,
        title: {
            text: TotalProp + '',
            verticalAlign: "center",
            dockInsidePlotArea: true,
            fontColor: /*"#ff6384"*/"#595959",
            fontSize: 26,
            fontFamily: "arial"
        },
        toolTip: {
            content: "{name} : {number}",
        },
        legend: {
            verticalAlign: "bottom"
        },
        data: [{
            type: "doughnut",
            startAngle: -90,
            innerRadius: "80%",
            showInLegend: false,
            legendMarkerType: "square",
            dataPoints: [
                { y: 100, name: "Total Properties", number: TotalProp},
            ]
        }]
    });
    //showDefaultText(chart, 'No Data Available', TotalProp);
    showDefaultText(chart, TotalProp, 'Not Available', TotalProp);

    chart.render();

    /*Total Scanning */
    CanvasJS.addColorSet("customColors1", ["#c0dbbe", "#388e3c", "#ffce56", "#01a800"]);
    var ToatalNotScan = TotalProp - TotalPropScan;
    var TotalPropPer = TotalProp;
    if (TotalProp == 0)
        TotalPropPer = null;
    //var totalScanedPerct = TotalPropScan / TotalPropPer * 100;
    //var totalNotScanPerct = ToatalNotScan / TotalPropPer * 100;
    var chart = new CanvasJS.Chart("chartContainer1", {
        colorSet: "customColors1",
        animationEnabled: true,
        title: {
            text: TotalPropScan + '',
            verticalAlign: "center",
            dockInsidePlotArea: true,
            fontColor:/*"#ff6384"*/"#595959",
            fontSize: 26,
            fontFamily: "arial"
        },
        toolTip: {
            content: "{name} : {number}",
        },
        legend: {
            verticalAlign: "bottom"
        },
        data: [{
            type: "doughnut",
            startAngle: -90,
            innerRadius: "80%",
            showInLegend: false,
            legendMarkerType: "square",
            dataPoints: [
                { y: ToatalNotScan, name: "Total Not Scanned", number: ToatalNotScan},
                { y: TotalPropScan, name: "Total Scanned", number: TotalPropScan},
            ]
        }]
    });

    //showDefaultText(chart, 'No Data Available', TotalProp);
    showDefaultText(chart, TotalProp, 'Not Available', TotalProp);


    chart.render();

    /*chart type*//*"#ff6384", "#36a2eb", "#ffce56",*/
    CanvasJS.addColorSet("customColors", ["#388e3c", "#f44336","#fe9436", "#c0dbbe"]);
    var TotalAll = TotalSeg + TotalMix + TotalNotRecv;
    var TotalAllPrec = TotalAll
    if (TotalAll == 0) {
        TotalAllPrec = null;
    }
    //var res_mixed_coll = TotalMix / TotalAllPrec * 100;
    //var res_bif_coll = TotalSeg / TotalAllPrec * 100;
    //var res_not_coll = TotalNotRecv / TotalAllPrec * 100;
    var chart = new CanvasJS.Chart("chartContainer2", {
        colorSet: "customColors",
        animationEnabled: true,
        title: {
            text: TotalAll + '',
            verticalAlign: "center",
            dockInsidePlotArea: true,
            fontColor: "#595959",
            fontSize: 26,
            fontFamily: "arial"
        },
        toolTip: {
            content: "{name} : {number}",
        },
        legend: {
            maxWidth: 90,

            fontSize: 14,
            verticalAlign: "center",
            horizontalAlign: "right"
        },
        data: [{
            type: "doughnut",
            startAngle: -90,
            innerRadius: "80%",
            //yValueFormatString: "###0.00\"%\"",
            //indexLabel: "#percent%",
            percentFormatString: "#0.##",
            legendText: "{name}:{y} (#percent%)",
            showInLegend: true,
            legendMarkerType: "square",
            dataPoints: [
                { y: TotalSeg, name: "Segregated", number: TotalSeg },
                { y: TotalMix, name: "Mixed", number: TotalMix },
                { y: TotalNotRecv, name: "Not Collected", number: TotalNotRecv }
            ]
        }]
    });

    showDefaultText(chart, TotalAll, 'Not Scanned', ToatalNotScan);


    chart.render();


    function showDefaultText(chart, yValue, textName,textNumber) {
        debugger;
        var isEmpty = !(yValue > 0);

        if (isEmpty) {
            chart.options.data[0].dataPoints.push({
                y: 0.000001,
                name: textName,
                number: textNumber,
                showInLegend: false
            });

        }
    }




}
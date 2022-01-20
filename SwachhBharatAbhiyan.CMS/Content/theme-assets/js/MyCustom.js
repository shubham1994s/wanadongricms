
//window.onbeforeunload = function () {
//    debugger;
//    var inputs = document.getElementsById("btnSubmit");
//           /* var inputs = document.getelementsbytagname("button");*/
//           /*var inputs = document.getElementsById("btnSubmit");*/
//    for (var i = 0; i < inputs.length; i++) {
//        debugger;
//        if (inputs[i].type == "button" || inputs[i].type == "submit") {
//            debugger;
//        inputs[i].disabled = true;
//                }
//            }
//        };


//document.getElementById("btnSubmit").onclick = function () {
//    //disable
//    this.disabled = true;

//    //do some validation stuff
//}


//20/01/2022


function disableButton(btn) {
    debugger;
    document.getElementById(btn.id).disabled = true;
    //alert("Button has been disabled.");
}
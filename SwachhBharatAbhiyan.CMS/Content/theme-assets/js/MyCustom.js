//debugger;
window.onbeforeunload = function () {
    //debugger;
            var inputs = document.getElementsByTagName("button");
           /* var inputs = document.getelementsbytagname("button");*/
           /*var inputs = document.getElementsById("btnSubmit");*/
    for (var i = 0; i < inputs.length; i++) {
        //debugger;
        if (inputs[i].type == "button" || inputs[i].type == "submit") {
          //  debugger;
        inputs[i].disabled = true;
                }
            }
        };

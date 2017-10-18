$(document).ready(function () {


    $(".numberBoxes").change(function () {

        var numberBox = this;
        var aid = this.parentNode.parentNode.cells[0].textContent;
        
        var cookieValue = $.cookie("shoppingCart");

        for (var i = 1; i < $("#MainContent_shoppingCartTable").children.length; i++) {

            if (i != 2) {
                this.parentNode.parentNode.cells[i].textContent = "bajs";

            }

        }


    });




});
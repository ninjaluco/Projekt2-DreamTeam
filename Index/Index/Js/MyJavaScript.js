$(document).ready(function () {
	//LoadAllPennor()
	//LoadAllPapper();
	//LoadAllHaftapparater();
	//LoadAllGem();
	function LoadAllPennor() {

		$.getJSON("/Service/Service.aspx?pennor=1").
			done(function (artiklar) {
				$(".row").empty(); console.log(artiklar);


				for (var i = 0; i < artiklar.length; i++) {

					var tableRow =
						"<div></div><div class=\"col-md-3\"> <h4>" + artiklar[i].artikelnamn + "</h4><p " + artiklar[i].pris + "</p><p>&nbsp</p><p>" +
						"<input type=\"button\" class=\"buy\" id=\"" + artiklar[i].AID + "\" value=\"Köp\" /></p></div>";


					$(".row").append(tableRow);


				}
			});

	}
	function LoadAllPapper() {
		$.getJSON("/Service/Service.aspx?papper=1").
			done(function (artiklar) {
				$(".row").empty(); console.log(artiklar);


				for (var i = 0; i < artiklar.length; i++) {

					var tableRow =
						"<div></div><div class=\"col-md-3\"> <h4>" + artiklar[i].artikelnamn + "</h4><p " + artiklar[i].pris + "</p><p>&nbsp</p><p>" +
						"<input type=\"button\" class=\"buy\" id=\"" + artiklar[i].AID + "\" value=\"Köp\" /></p></div>";


					$(".row").append(tableRow);


				}
			});

	}
	function LoadAllHaftapparater() {
		$.getJSON("/Service/Service.aspx?haftapparater=1").
			done(function (artiklar) {
				$(".row").empty(); console.log(artiklar);


				for (var i = 0; i < artiklar.length; i++) {

					var tableRow =
						"<div></div><div class=\"col-md-3\"> <h4>" + artiklar[i].artikelnamn + "</h4><p " + artiklar[i].pris + "</p><p>&nbsp</p><p>" +
						"<input type=\"button\" class=\"buy\" id=\"" + artiklar[i].AID + "\" value=\"Köp\" /></p></div>";


					$(".row").append(tableRow);


				}
			});
	}
	function LoadAllGem() {
		$.getJSON("/Service/Service.aspx?Gem=1").
			done(function (artiklar) {
				$(".row").empty(); console.log(artiklar);


				for (var i = 0; i < artiklar.length; i++) {

					var tableRow =
						"<div></div><div class=\"col-md-3\"> <h4>" + artiklar[i].artikelnamn + "</h4><p " + artiklar[i].pris + "</p><p>&nbsp</p><p>" +
						"<input type=\"button\" class=\"buy\" id=\"" + artiklar[i].AID + "\" value=\"Köp\" /></p></div>";


					$(".row").append(tableRow);


				}
			});
	}


	$(".numberBoxes").change(function () {

        var numberBox = this;
        var aid = this.parentNode.parentNode.cells[0].textContent;
        //problem med att hitta id på tabellen. löser det så här istället.
        var tBody = this.parentNode.parentNode.parentNode;
        var row = this.parentNode.parentNode;
        var cookieValue = $.cookie("shoppingCart");
        var totalsum = 0;
        var totalSumOfAll = 0;
        var price = parseInt(row.cells[3].innerText);
        
        totalsum = price * parseInt(this.value);
        row.cells[4].innerText = totalsum.toString();

        for (var i = 1; i < tBody.children.length - 1; i++) {

            totalSumOfAll += parseInt(tBody.children[i].cells[4].innerText);

        }


        tBody.lastElementChild.cells[4].innerText = totalSumOfAll.toString();
       
        var newCookie = cookieValue.split(',');
        var aidCounter = 0;

        for (var i = 0; i < newCookie.length; i++) {
            if (newCookie[i] === aid) {
                aidCounter++;
            }
        }

        while (aidCounter != parseInt(this.value)) {
            if (parseInt(this.value) < aidCounter) {

                if (newCookie[0] == aid) {
                    cookieValue = cookieValue.replace(aid.toString() + ",", ",");
                    newCookie[0] = "";
                    aidCounter--;
                }
                else {
                    cookieValue = cookieValue.replace("," + aid.toString() + ",", ",");
                    aidCounter--;
                }
                

            }
            else if (parseInt(this.value) > aidCounter) {
                cookieValue += (aid + ",");
                aidCounter++
            }
        }
        $.removeCookie("shoppingCart");

        $.cookie("shoppingCart", cookieValue, { expires: 2 });


       

	});
    $(".row").on("click", ".buy", function () {

        var artikelId = this.id;

        var cookieValue = $.cookie("shoppingCart");

        if (!(cookieValue == null)) {

            cookieValue += (artikelId + ",");

        }
        else {
            cookieValue = (artikelId + ",");
        }

        $.removeCookie("shoppingCart");

        $.cookie("shoppingCart", cookieValue, { expires: 2 });

    });



});


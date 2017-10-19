$(document).ready(function () {
	LoadAllPennor();

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
    $(".deleteButton").click(function () {

        var row = this.parentNode.parentNode;
        var aid = this.parentNode.parentNode.cells[0].textContent;

        alert(aid);

        var cookieValue = $.cookie("shoppingCart");
        var newCookie = cookieValue.split(',');

        var aidCounter = 0;
        for (var i = 0; i < newCookie.length; i++) {
            if (newCookie[i] === aid) {
                aidCounter++;
            }
        }

        while (aidCounter != 0) {


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
        $.removeCookie("shoppingCart");

        $.cookie("shoppingCart", cookieValue, { expires: 2 });


    });


	function LoadAllPennor() {
		$.getJSON("/Service/Service.aspx?all=1").
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
//function LoadAllPennor() {
//	$.getJSON("/Service/Service.aspx?all=1").
//		done(function (artiklar) {
//			$("#PennorBody").empty(); console.log(artiklar);

//			for (var i = 0; i < artiklar.length; i++) {

//				var tableRow = "<tr><td class= " + artiklar[i].kategori + " value= " + artiklar[i].AID + ">" + artiklar[i].artikelnamn + "</td>";
//				tableRow += "<td class=" + artiklar[i].kategori + " value= " + artiklar[i].AID + ">" + artiklar[i].pris + "</td>";
//				tableRow += "<td class=" + artiklar[i].kategori + " value= " + artiklar[i].AID + "><Button ID= 'addButton' runat= 'server' OnClick= 'addButton_Click' Text= 'Lägg till' CommandArgument= '2, ' /></td>";
//				tableRow += "<td class=" + artiklar[i].kategori + " value= " + artiklar[i].AID + "><TextBox ID='amountTextBox' type='number' min='1' runat='server' Width='32px'>1</TextBox></td>";
//				tableRow += "</tr>";
//				$("#PennorBody").append(tableRow);
//			}
//		});

//function CreateBoard(size) {
//	var row = "<div class='divTableRow'>";
//	var divEnd = "</div>";

//	for (var i = 0; i < size; i++) {
//		$("#divTableID").append(row);
//		for (var j = 0; j < size; j++) {
//			var cellID = "cellx" + i + "y" + j; //Genererar ett unikt ID till varje cell.
//			//======= Sparar/skapar en cell(column i en rad) i en variabel, med en gemensam cellklass för alla celler i tabellen samt tilldelar det genererade unika ID:t till cellen.=======//
//			var col = "<div class='divTableCell' id='" + cellID + "'></div>";
//			$("#divTableID").append(col); // lägger till en cell i tabellen från den sparade cell variabeln
//		}
//		$("#divTableID").append(divEnd);// Stänger tabellen när alla celler är skapade.w
//	}
//}
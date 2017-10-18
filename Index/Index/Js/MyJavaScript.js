$(document).ready(function () {
	LoadAllPennor();

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
	function LoadAllPennor() {
		$.getJSON("/Service/Service.aspx?all=1").
			done(function (artiklar) {
				$(".row").empty(); console.log(artiklar);


                for (var i = 0; i < artiklar.length; i++) {

					var tableRow =
						"<div></div><div class=\"col-md - 3\"> <h4>" + artiklar[i].artikelnamn + "</h4><p " + artiklar[i].pris + "</p><p>&nbsp</p><p>" +
						"<input type=\"button\" value=\"Köp\" /></p></div>";
					
					
                    $(".row").append(tableRow);

					
				}
			});
	
			
	}



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
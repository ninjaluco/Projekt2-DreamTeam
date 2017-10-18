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
						"<div></div>"+
					"<div class=\"col-md - 2\"> <h3>" + artiklar[i].artikelnamn + "</h3><p " + artiklar[i].pris + "</p><p>&nbsp</p><p>" +
						"<input type=\"button\" value=\"Delete contact\" /></p>"+
						"<p><TextBox ID='amountTextBox' type='number' min='1' runat='server' Width='32px'>1</TextBox></p></div>";
					
					
					$(".row").append(tableRow);

					//<Button ID='addButton' runat='server' OnClick='addButton_Click' Text='Lägg till' CommandArgument='2, '
				}
			});
		//$("#Pennor").hide
		//$(".Häftapparater").hide
		//$(".Gem").hide
		//$(".Papper").hide
		//<div class="container-fluid">
			
		//	<div class="row">
		//		<div class="col-sm-4" style="background-color:lavender;">.col-sm-4</div>
		//		<div class="col-sm-4" style="background-color:lavenderblush;">.col-sm-4</div>
		//		<div class="col-sm-4" style="background-color:lavender;">.col-sm-4</div>
		//	</div>
		//</div>
			
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
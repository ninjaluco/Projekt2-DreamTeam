$(document).ready(function () {
	LoadAllHaftapparater();
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
});
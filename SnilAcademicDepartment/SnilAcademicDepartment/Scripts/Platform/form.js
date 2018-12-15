$("#sendMessage").submit(function (event) {
	// Stop form from submitting normally
	event.preventDefault();
	var $form = $(this),
		url = $form.attr("action") + `?tn=${$form.find("input[name='__RequestVerificationToken']").val()}`,
		resultTarget = $("div#mailingResult");
	// Send the data using post
	var posting = $.post(url, {
		FullName: $form.find("input[id='name']").val(),
		email: $form.find("input[id='email']").val(),
		company: $form.find("input[id='company']").val(),
		subject: $form.find("input[id='subject']").val(),
		message: $form.find("textarea[name='Message']").val()
	}).done((data) => {
		resultTarget.removeClass("hidden");
		resultTarget.addClass("alert-success");
		resultTarget.html(data.ResultMessage);
	}).fail((jqXHR) => {
		resultTarget.removeClass("hidden");
		resultTarget.addClass("alert-danger");
		if (jqXHR.responseJSON) {
			resultTarget.html(jqXHR.responseJSON.Message);
		} else {
			resultTarget.html(jqXHR.statusText);
		}
	}).always(() => {
		$("fieldset").attr("disabled", "");
	}).catch(() => {
		$("fieldset").attr("disabled", "");
	});
});
var Lab2;
(function (Lab2) {
    var Web;
    (function (Web) {
        var Main = (function () {
            function Main() {
                this.ElementIDs = {
                    SubmitButtonId: "submitButton",
                    InputTypeRadioButtonId: "IsManualInput",
                    ManualInputId: "InputText",
                    FileInputId: "FileInputPath",
                    InputFormId: "inputForm",
                    OutputLabelId: "output",
                    ManualInputRowId: "manualInputRow",
                    FilelInputRowId: "filelInputRow",
                };
                this.init();
            }
            Main.prototype.init = function () {
                var self = this;
                self.waitingdialog = new Web.waitingdialog();
                $('input[name=' + self.ElementIDs.InputTypeRadioButtonId + ']').change(function () {
                    var manualRow = $('#' + self.ElementIDs.ManualInputRowId);
                    var fileRow = $('#' + self.ElementIDs.FilelInputRowId);
                    if (fileRow.hasClass("display-hide")) {
                        fileRow.removeClass("display-hide");
                        manualRow.addClass("display-hide");
                    }
                    else {
                        fileRow.addClass("display-hide");
                        manualRow.removeClass("display-hide");
                    }
                });
                $('#' + self.ElementIDs.SubmitButtonId).click(function () {
                    var isManualInput = $('input[name=' + self.ElementIDs.InputTypeRadioButtonId + ']:checked').val() === "True";
                    var data;
                    if (isManualInput) {
                        data = {
                            IsManualInput: isManualInput,
                            InputText: $('#' + self.ElementIDs.ManualInputId).val()
                        };
                    }
                    else {
                        var form = $('#' + self.ElementIDs.InputFormId)[0];
                        var formData = new FormData(form);
                        var file = formData.get("FileInputPath");
                        data = {
                            IsManualInput: isManualInput,
                            FileInputPath: file.name,
                        };
                    }
                    self.waitingdialog.show("Loading...");
                    $.ajax({
                        url: "/Home/GetHash",
                        method: "post",
                        data: JSON.stringify(data),
                        contentType: "application/json",
                        success: function (response) {
                            $('#' + self.ElementIDs.OutputLabelId).text(response.Result);
                        },
                    }).always(function () {
                        self.waitingdialog.hide();
                    });
                });
            };
            return Main;
        }());
        Web.Main = Main;
        var main = new Main();
    })(Web = Lab2.Web || (Lab2.Web = {}));
})(Lab2 || (Lab2 = {}));
//# sourceMappingURL=main.js.map
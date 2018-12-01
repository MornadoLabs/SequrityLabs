var Lab5;
(function (Lab5) {
    var Web;
    (function (Web) {
        var Main = (function () {
            function Main() {
                this.ElementIDs = {
                    IsManualInputRadioButtonId: "IsManualInput",
                    SignButtonId: "signButton",
                    SaveButtonId: "saveButton",
                    CheckButtonId: "checkButton",
                    FileInputId: "FileInput",
                    InputTextId: "InputText",
                    FileInputSignatureId: "FileInputSignature",
                    ResultSignatureTextBoxId: "resultSignature",
                    InputFormId: "inputForm",
                };
                this.ElementClasses = {
                    Manual: "manual",
                    Nonmanual: "nonmanual"
                };
                this.init();
            }
            Main.prototype.init = function () {
                var self = this;
                self.waitingdialog = new Web.waitingdialog();
                $('input[name=' + self.ElementIDs.IsManualInputRadioButtonId + ']').change(function () {
                    var isManual = $('input[name=' + self.ElementIDs.IsManualInputRadioButtonId + ']:checked').val() === 'True';
                    if (isManual) {
                        $('.' + self.ElementClasses.Nonmanual).addClass('display-hide');
                        $('.' + self.ElementClasses.Manual).removeClass('display-hide');
                    }
                    else {
                        $('.' + self.ElementClasses.Manual).addClass('display-hide');
                        $('.' + self.ElementClasses.Nonmanual).removeClass('display-hide');
                    }
                    $('#' + self.ElementIDs.ResultSignatureTextBoxId).html("");
                });
                $('input[name=' + self.ElementIDs.IsManualInputRadioButtonId + ']:checked').trigger('change');
                $('#' + self.ElementIDs.SignButtonId).click(function () { self.createSignature(); });
                $('#' + self.ElementIDs.SaveButtonId).click(function () { self.saveSignature(); });
                $('#' + self.ElementIDs.CheckButtonId).click(function () { self.checkSignature(); });
            };
            Main.prototype.createSignature = function () {
                var self = this;
                var isManual = $('input[name=' + self.ElementIDs.IsManualInputRadioButtonId + ']:checked').val() === 'True';
                var data = {};
                if (isManual) {
                    data = {
                        IsManualInput: isManual,
                        InputText: $('#' + self.ElementIDs.InputTextId).val(),
                    };
                }
                else {
                    var form = $('#' + self.ElementIDs.InputFormId)[0];
                    var formData = new FormData(form);
                    var inputFile = formData.get(self.ElementIDs.FileInputId);
                    data = {
                        IsManualInput: isManual,
                        FileInput: inputFile.name,
                    };
                }
                self.waitingdialog.show("Loading...");
                $.ajax({
                    url: "/Home/SignData",
                    method: "post",
                    data: JSON.stringify(data),
                    contentType: "application/json",
                    success: function (response) {
                        if (response.Success) {
                            var successMessage = response.SuccessMessage
                                ? response.SuccessMessage
                                : "";
                            $('#' + self.ElementIDs.ResultSignatureTextBoxId).html(response.Result);
                            swal("Success!", successMessage, "success");
                        }
                        else {
                            var errorMessage = response.ErrorMessage
                                ? response.ErrorMessage
                                : "Something went wrong. Please try again.";
                            $('#' + self.ElementIDs.ResultSignatureTextBoxId).html("");
                            swal("Error!", errorMessage, "error");
                        }
                    },
                }).always(function () {
                    self.waitingdialog.hide();
                });
            };
            Main.prototype.saveSignature = function () {
                var self = this;
                var isManual = $('input[name=' + self.ElementIDs.IsManualInputRadioButtonId + ']:checked').val() === 'True';
                var data = {};
                if (isManual) {
                    data = {
                        IsManualInput: isManual,
                        InputText: $('#' + self.ElementIDs.InputTextId).val(),
                    };
                }
                else {
                    var form = $('#' + self.ElementIDs.InputFormId)[0];
                    var formData = new FormData(form);
                    var inputFile = formData.get(self.ElementIDs.FileInputId);
                    data = {
                        IsManualInput: isManual,
                        FileInput: inputFile.name,
                    };
                }
                self.waitingdialog.show("Loading...");
                $.ajax({
                    url: "/Home/SaveSign",
                    method: "post",
                    data: JSON.stringify(data),
                    contentType: "application/json",
                    success: function (response) {
                        if (response.Success) {
                            var successMessage = response.SuccessMessage
                                ? response.SuccessMessage
                                : "";
                            swal("Success!", successMessage, "success");
                        }
                        else {
                            var errorMessage = response.ErrorMessage
                                ? response.ErrorMessage
                                : "Something went wrong. Please try again.";
                            swal("Error!", errorMessage, "error");
                        }
                        $('#' + self.ElementIDs.ResultSignatureTextBoxId).html("");
                    },
                }).always(function () {
                    self.waitingdialog.hide();
                });
            };
            Main.prototype.checkSignature = function () {
                var self = this;
                var isManual = $('input[name=' + self.ElementIDs.IsManualInputRadioButtonId + ']:checked').val() === 'True';
                var data = {};
                if (isManual) {
                    var form = $('#' + self.ElementIDs.InputFormId)[0];
                    var formData = new FormData(form);
                    var signFile = formData.get(self.ElementIDs.FileInputSignatureId);
                    data = {
                        IsManualInput: isManual,
                        InputText: $('#' + self.ElementIDs.InputTextId).val(),
                        FileInputSignature: signFile.name,
                    };
                }
                else {
                    var form = $('#' + self.ElementIDs.InputFormId)[0];
                    var formData = new FormData(form);
                    var inputFile = formData.get(self.ElementIDs.FileInputId);
                    var signFile = formData.get(self.ElementIDs.FileInputSignatureId);
                    data = {
                        IsManualInput: isManual,
                        FileInput: inputFile.name,
                        FileInputSignature: signFile.name,
                    };
                }
                self.waitingdialog.show("Loading...");
                $.ajax({
                    url: "/Home/CheckSign",
                    method: "post",
                    data: JSON.stringify(data),
                    contentType: "application/json",
                    success: function (response) {
                        if (response.Success) {
                            var successMessage = response.SuccessMessage
                                ? response.SuccessMessage
                                : "";
                            swal("Success!", successMessage, "success");
                        }
                        else {
                            var errorMessage = response.ErrorMessage
                                ? response.ErrorMessage
                                : "Something went wrong. Please try again.";
                            swal("Error!", errorMessage, "error");
                        }
                    },
                }).always(function () {
                    self.waitingdialog.hide();
                });
            };
            return Main;
        }());
        Web.Main = Main;
        var main = new Main();
    })(Web = Lab5.Web || (Lab5.Web = {}));
})(Lab5 || (Lab5 = {}));
//# sourceMappingURL=main.js.map
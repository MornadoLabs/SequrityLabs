var Lab4;
(function (Lab4) {
    var Web;
    (function (Web) {
        var Main = (function () {
            function Main() {
                this.ElementIDs = {
                    EncryptButtonId: "encryptButton",
                    DecryptButtonId: "decryptButton",
                    EncryptRSAButtonId: "encryptRSAButton",
                    DecryptRSAButtonId: "decryptRSAButton",
                    EncryptRC5ButtonId: "encryptRC5Button",
                    DecryptRC5ButtonId: "decryptRC5Button",
                    KeyInputId: "RC5Key",
                    RSAFileInputId: "RSAFileInput",
                    RC5FileInputId: "RC5FileInput",
                    InputFormId: "inputForm",
                };
                this.init();
            }
            Main.prototype.init = function () {
                var self = this;
                self.waitingdialog = new Web.waitingdialog();
                $('#' + self.ElementIDs.EncryptButtonId).click(function () {
                    self.sendData("/Home/EncryptData");
                });
                $('#' + self.ElementIDs.DecryptButtonId).click(function () {
                    self.sendData("/Home/DecryptData");
                });
                $('#' + self.ElementIDs.EncryptRSAButtonId).click(function () {
                    self.sendData("/Home/EncryptDataUsingRSA");
                });
                $('#' + self.ElementIDs.DecryptRSAButtonId).click(function () {
                    self.sendData("/Home/DecryptDataUsingRSA");
                });
                $('#' + self.ElementIDs.EncryptRC5ButtonId).click(function () {
                    self.sendData("/Home/EncryptDataUsingRC5");
                });
                $('#' + self.ElementIDs.DecryptRC5ButtonId).click(function () {
                    self.sendData("/Home/DecryptDataUsingRC5");
                });
            };
            Main.prototype.sendData = function (url) {
                var self = this;
                var form = $('#' + self.ElementIDs.InputFormId)[0];
                var formData = new FormData(form);
                var rsaFile = formData.get(self.ElementIDs.RSAFileInputId);
                var rc5File = formData.get(self.ElementIDs.RC5FileInputId);
                var data = {
                    RSAFileInput: rsaFile.name,
                    RC5FileInput: rc5File.name,
                    RC5Key: formData.get(self.ElementIDs.KeyInputId),
                };
                self.waitingdialog.show("Loading...");
                $.ajax({
                    url: url,
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
    })(Web = Lab4.Web || (Lab4.Web = {}));
})(Lab4 || (Lab4 = {}));
//# sourceMappingURL=main.js.map
var Lab3;
(function (Lab3) {
    var Web;
    (function (Web) {
        var Main = (function () {
            function Main() {
                this.ElementIDs = {
                    EncryptButtonId: "encryptButton",
                    DecryptButtonId: "decryptButton",
                    KeyInputId: "Key",
                    FileInputId: "FileInput",
                    WInputId: "W",
                    RInputId: "R",
                    BInputId: "B",
                    InputFormId: "inputForm",
                };
                this.init();
            }
            Main.prototype.init = function () {
                var self = this;
                $('#' + self.ElementIDs.EncryptButtonId).click(function () {
                    self.sendData("/Home/EncryptData");
                });
                $('#' + self.ElementIDs.DecryptButtonId).click(function () {
                    self.sendData("/Home/DecryptData");
                });
            };
            Main.prototype.sendData = function (url) {
                var self = this;
                var form = $('#' + self.ElementIDs.InputFormId)[0];
                var formData = new FormData(form);
                var file = formData.get("FileInput");
                var data = {
                    Key: formData.get("Key"),
                    FileInput: file.name,
                    W: $('#' + self.ElementIDs.WInputId).val(),
                    R: $('#' + self.ElementIDs.RInputId).val(),
                    B: $('#' + self.ElementIDs.BInputId).val(),
                };
                $.ajax({
                    url: url,
                    method: "post",
                    data: JSON.stringify(data),
                    contentType: "application/json",
                    success: function (response) {
                        if (response.Success) {
                            swal("Success!", "", "success");
                        }
                        else {
                            var errorMessage = response.ErrorMessage
                                ? response.ErrorMessage
                                : "Something went wrong. Please try again.";
                            swal("Error!", errorMessage, "error");
                        }
                    },
                });
            };
            return Main;
        }());
        Web.Main = Main;
        var main = new Main();
    })(Web = Lab3.Web || (Lab3.Web = {}));
})(Lab3 || (Lab3 = {}));
//# sourceMappingURL=main.js.map
var Lab3;
(function (Lab3) {
    var Web;
    (function (Web) {
        var Main = (function () {
            function Main() {
                this.ElementIDs = {
                    EncryptButtonId: "encryptButton",
                    KeyInputId: "Key",
                    FileInputId: "FileInput",
                    InputFormId: "inputForm",
                };
                this.init();
            }
            Main.prototype.init = function () {
                var self = this;
                $('#' + self.ElementIDs.EncryptButtonId).click(function () {
                    var form = $('#' + self.ElementIDs.InputFormId)[0];
                    var formData = new FormData(form);
                    var file = formData.get("FileInput");
                    var data = {
                        Key: formData.get("Key"),
                        FileInput: file.name,
                    };
                    $.ajax({
                        url: "/Home/EncryptData",
                        method: "post",
                        data: JSON.stringify(data),
                        contentType: "application/json",
                        success: function (response) {
                            if (response.Success) {
                                swal("Success!", "", "success");
                            }
                            else {
                                swal("Error!", "Something went wrong. Please try again.", "error");
                            }
                        },
                    });
                });
            };
            return Main;
        }());
        Web.Main = Main;
        var main = new Main();
    })(Web = Lab3.Web || (Lab3.Web = {}));
})(Lab3 || (Lab3 = {}));
//# sourceMappingURL=main.js.map
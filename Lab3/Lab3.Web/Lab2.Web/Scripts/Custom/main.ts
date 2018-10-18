namespace Lab3.Web {
    export class Main {

        ElementIDs = {
            EncryptButtonId: "encryptButton",
            DecryptButtonId: "decryptButton",
            
            KeyInputId: "Key",
            FileInputId: "FileInput",

            WInputId: "W",
            RInputId: "R",
            BInputId: "B",

            InputFormId: "inputForm",            
        }        

        constructor() {
            this.init();
        }

        init() {
            let self = this;

            $('#' + self.ElementIDs.EncryptButtonId).click(() => {
                self.sendData("/Home/EncryptData");                
            });

            $('#' + self.ElementIDs.DecryptButtonId).click(() => {
                self.sendData("/Home/DecryptData");                
            });
        }

        sendData(url: string) {
            let self = this;

            let form = $('#' + self.ElementIDs.InputFormId)[0];
            let formData = new FormData(<HTMLFormElement>form);
            let file = <File>formData.get("FileInput");

            let data = {
                Key: formData.get("Key"),
                FileInput: file.name,
                W: $('#' + self.ElementIDs.WInputId).val(),
                R: $('#' + self.ElementIDs.RInputId).val(),
                B: $('#' + self.ElementIDs.BInputId).val(),
            }

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
                        let errorMessage = response.ErrorMessage
                            ? response.ErrorMessage
                            : "Something went wrong. Please try again.";

                        swal("Error!", errorMessage, "error");
                    }
                },
            });
        }
    }

    let main = new Main();
}
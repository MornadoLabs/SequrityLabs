namespace Lab4.Web {
    export class Main {

        ElementIDs = {
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
        }        
        
        waitingdialog: waitingdialog;

        constructor() {
            this.init();
        }

        init() {
            let self = this;
            self.waitingdialog = new waitingdialog();

            $('#' + self.ElementIDs.EncryptButtonId).click(() => {
                self.sendData("/Home/EncryptData");                
            });

            $('#' + self.ElementIDs.DecryptButtonId).click(() => {
                self.sendData("/Home/DecryptData");                
            });

            $('#' + self.ElementIDs.EncryptRSAButtonId).click(() => {
                self.sendData("/Home/EncryptDataUsingRSA");                
            });

            $('#' + self.ElementIDs.DecryptRSAButtonId).click(() => {
                self.sendData("/Home/DecryptDataUsingRSA");                
            });

            $('#' + self.ElementIDs.EncryptRC5ButtonId).click(() => {
                self.sendData("/Home/EncryptDataUsingRC5");                
            });

            $('#' + self.ElementIDs.DecryptRC5ButtonId).click(() => {
                self.sendData("/Home/DecryptDataUsingRC5");                
            });
        }

        sendData(url: string) {
            let self = this;

            let form = $('#' + self.ElementIDs.InputFormId)[0];
            let formData = new FormData(<HTMLFormElement>form);
            let rsaFile = <File>formData.get(self.ElementIDs.RSAFileInputId);
            let rc5File = <File>formData.get(self.ElementIDs.RC5FileInputId);

            let data = {
                RSAFileInput: rsaFile.name,
                RC5FileInput: rc5File.name,
                RC5Key: formData.get(self.ElementIDs.KeyInputId),
            }

            self.waitingdialog.show("Loading...");

            $.ajax({
                url: url,
                method: "post",
                data: JSON.stringify(data),
                contentType: "application/json",
                success: function (response) {
                    if (response.Success) {
                        let successMessage = response.SuccessMessage
                            ? response.SuccessMessage
                            : "";

                        swal("Success!", successMessage, "success");
                    }
                    else {
                        let errorMessage = response.ErrorMessage
                            ? response.ErrorMessage
                            : "Something went wrong. Please try again.";

                        swal("Error!", errorMessage, "error");
                    }
                },
            }).always(() => {
                self.waitingdialog.hide();
            });
        }
    }

    let main = new Main();
}
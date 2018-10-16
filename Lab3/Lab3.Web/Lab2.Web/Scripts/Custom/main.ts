namespace Lab3.Web {
    export class Main {

        ElementIDs = {
            EncryptButtonId: "encryptButton",
            
            KeyInputId: "Key",
            FileInputId: "FileInput",

            InputFormId: "inputForm",            
        }        

        constructor() {
            this.init();
        }

        init() {
            let self = this;

            $('#' + self.ElementIDs.EncryptButtonId).click(() => {

                let form = $('#' + self.ElementIDs.InputFormId)[0];
                let formData = new FormData(<HTMLFormElement>form);
                let file = <File>formData.get("FileInput");

                let data = {
                    Key: formData.get("Key"),
                    FileInput: file.name,
                }

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
        }
    }

    let main = new Main();
}
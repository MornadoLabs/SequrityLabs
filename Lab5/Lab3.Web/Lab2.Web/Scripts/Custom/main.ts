namespace Lab5.Web {
    export class Main {

        ElementIDs = {
            IsManualInputRadioButtonId: "IsManualInput",

            SignButtonId: "signButton",
            SaveButtonId: "saveButton",
            CheckButtonId: "checkButton",
            
            FileInputId: "FileInput",
            InputTextId: "InputText",
            FileInputSignatureId: "FileInputSignature",

            ResultSignatureTextBoxId: "resultSignature",
            
            InputFormId: "inputForm",            
        }        

        ElementClasses = {
            Manual: "manual",
            Nonmanual: "nonmanual"
        }
        
        waitingdialog: waitingdialog;

        constructor() {
            this.init();
        }

        init() {
            let self = this;
            self.waitingdialog = new waitingdialog();

            $('input[name=' + self.ElementIDs.IsManualInputRadioButtonId + ']').change(() => {
                let isManual = $('input[name=' + self.ElementIDs.IsManualInputRadioButtonId + ']:checked').val() === 'True';

                if (isManual) {
                    $('.' + self.ElementClasses.Nonmanual).addClass('display-hide');
                    $('.' + self.ElementClasses.Manual).removeClass('display-hide');
                }
                else {
                    $('.' + self.ElementClasses.Manual).addClass('display-hide');
                    $('.' + self.ElementClasses.Nonmanual).removeClass('display-hide');
                }
            });
            $('input[name=' + self.ElementIDs.IsManualInputRadioButtonId + ']:checked').trigger('change');

            $('#' + self.ElementIDs.SignButtonId).click(() => { self.createSignature() });

            $('#' + self.ElementIDs.SaveButtonId).click(() => { self.saveSignature() });  

            $('#' + self.ElementIDs.CheckButtonId).click(() => { self.checkSignature() });            
        }        

        createSignature() {
            let self = this;
            let isManual = $('input[name=' + self.ElementIDs.IsManualInputRadioButtonId + ']:checked').val() === 'True';
            let data = {};

            if (isManual) {
                data = {
                    IsManualInput: isManual,
                    InputText: $('#' + self.ElementIDs.InputTextId).val(),
                }
            }
            else {
                let form = $('#' + self.ElementIDs.InputFormId)[0];
                let formData = new FormData(<HTMLFormElement>form);
                let inputFile = <File>formData.get(self.ElementIDs.FileInputId);

                data = {
                    IsManualInput: isManual,
                    FileInput: inputFile.name,
                }
            }            

            self.waitingdialog.show("Loading...");

            $.ajax({
                url: "/Home/SignData",
                method: "post",
                data: JSON.stringify(data),
                contentType: "application/json",
                success: function (response) {
                    if (response.Success) {
                        let successMessage = response.SuccessMessage
                            ? response.SuccessMessage
                            : "";

                        $('#' + self.ElementIDs.ResultSignatureTextBoxId).val(response.Result);
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

        saveSignature() {
            let self = this;
            let isManual = $('input[name=' + self.ElementIDs.IsManualInputRadioButtonId + ']:checked').val() === 'True';
            let data = {};

            if (isManual) {
                data = {
                    IsManualInput: isManual,
                    InputText: $('#' + self.ElementIDs.InputTextId).val(),
                }
            }
            else {
                let form = $('#' + self.ElementIDs.InputFormId)[0];
                let formData = new FormData(<HTMLFormElement>form);
                let inputFile = <File>formData.get(self.ElementIDs.FileInputId);
                
                data = {
                    IsManualInput: isManual,
                    FileInput: inputFile.name,
                }
            }

            self.waitingdialog.show("Loading...");

            $.ajax({
                url: "/Home/SaveSign",
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

        checkSignature() {
            let self = this;
            let isManual = $('input[name=' + self.ElementIDs.IsManualInputRadioButtonId + ']:checked').val() === 'True';
            let data = {};

            if (isManual) {
                let form = $('#' + self.ElementIDs.InputFormId)[0];
                let formData = new FormData(<HTMLFormElement>form);
                let signFile = <File>formData.get(self.ElementIDs.FileInputSignatureId);

                data = {
                    IsManualInput: isManual,
                    InputText: $('#' + self.ElementIDs.InputTextId).val(),
                    FileInputSignature: signFile.name,
                }
            }
            else {
                let form = $('#' + self.ElementIDs.InputFormId)[0];
                let formData = new FormData(<HTMLFormElement>form);
                let inputFile = <File>formData.get(self.ElementIDs.FileInputId);
                let signFile = <File>formData.get(self.ElementIDs.FileInputSignatureId);

                data = {
                    IsManualInput: isManual,
                    FileInput: inputFile.name,
                    FileInputSignature: signFile.name,
                }
            }

            self.waitingdialog.show("Loading...");

            $.ajax({
                url: "/Home/CheckSign",
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
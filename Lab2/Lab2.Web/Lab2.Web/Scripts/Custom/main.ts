﻿namespace Lab2.Web {
    export class Main {

        ElementIDs = {
            SubmitButtonId: "submitButton",

            InputTypeRadioButtonId: "IsManualInput",

            ManualInputId: "InputText",
            FileInputId: "FileInputPath",

            InputFormId: "inputForm",
            
            OutputLabelId: "output",

            ManualInputRowId: "manualInputRow",
            FilelInputRowId: "filelInputRow",
        }        

        waitingdialog: waitingdialog;

        constructor() {
            this.init();
        }

        init() {
            let self = this;
            self.waitingdialog = new waitingdialog();

            $('input[name=' + self.ElementIDs.InputTypeRadioButtonId + ']').change(function () {
                let manualRow = $('#' + self.ElementIDs.ManualInputRowId);
                let fileRow = $('#' + self.ElementIDs.FilelInputRowId);
                if (fileRow.hasClass("display-hide")) {
                    fileRow.removeClass("display-hide");
                    manualRow.addClass("display-hide");
                }
                else {
                    fileRow.addClass("display-hide");
                    manualRow.removeClass("display-hide");
                }
            });

            $('#' + self.ElementIDs.SubmitButtonId).click(() => {
                let isManualInput = $('input[name=' + self.ElementIDs.InputTypeRadioButtonId + ']:checked').val() === "True";
                let data;
                if (isManualInput) {
                    data = {
                        IsManualInput: isManualInput,
                        InputText: $('#' + self.ElementIDs.ManualInputId).val()
                    }
                } else {
                    let form = $('#' + self.ElementIDs.InputFormId)[0];
                    let formData = new FormData(<HTMLFormElement>form);
                    let file = <File>formData.get("FileInputPath");
                    data = {
                        IsManualInput: isManualInput,
                        FileInputPath: file.name,
                    }
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
                }).always(() => {
                    self.waitingdialog.hide();
                });
            });
        }
    }

    let main = new Main();
}
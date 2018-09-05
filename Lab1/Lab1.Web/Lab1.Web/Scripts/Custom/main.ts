
namespace Lab1 {
    export class Main {

        ElementIDs = {
            InputTypeRadioButtonId: "InputType",

            VariantDropDownId: "Variant",
            ATextBoxId: "ManualInput_A",
            CTextBoxId: "ManualInput_C",
            MTextBoxId: "ManualInput_M",
            X0TextBoxId: "ManualInput_X0",
            OutputSizeTextBoxId: "OutputSize",

            VariantsRowId: "variantInputRow",
            ManualRowId: "manualInputRow",

            InputFormId: "inputForm"
        }

        URLs = {
            InputDataUrl: "InputDataUrl"
        }

        dataSourceAttr = "data-source-url";

        formValidator: Validator;

        public constructor() {
            this.initialize();
        }

        initialize(): void {
            let self = this;

            $('input[name=' + self.ElementIDs.InputTypeRadioButtonId + ']').change(function () {
                let variantRow = $('#' + self.ElementIDs.VariantsRowId);
                let manualRow = $('#' + self.ElementIDs.ManualRowId);
                if (variantRow.hasClass("display-hide")) {
                    variantRow.removeClass("display-hide");
                    manualRow.addClass("display-hide");
                }
                else {
                    variantRow.addClass("display-hide");
                    manualRow.removeClass("display-hide");
                }
            });

            self.initFormValidation();
        }

        initFormValidation() {
            let self = this;
            self.formValidator = $('#' + self.ElementIDs.InputFormId).validate({
                rules: {
                    "ManualInput.A": {
                        required: true,
                        number: true,
                        min: 0,
                        max: $('#ManualInput_M').val()
                    },
                    "ManualInput.C": {
                        required: true,
                        number: true,
                        min: 0,
                        max: $('#ManualInput_M').val()
                    },
                    "ManualInput.M": {
                        required: true,
                        number: true,
                        min: 0 + Number.MIN_VALUE
                    },
                    "ManualInput.X0": {
                        required: true,
                        number: true,
                        min: 0,
                        max: $('#ManualInput_M').val()
                    },
                    OutputSize: {
                        required: true,
                        number: true,
                        min: 0 + Number.MIN_VALUE
                    }
                },
                // Specify validation error messages
                messages: {
                    "ManualInput.A": {
                        required: "This is required field",
                        number: "The value must be a number",
                        min: "The value must be equals 0 or greater",
                        max: "Tha value must be less than m"
                    },
                    "ManualInput.C": {
                        required: "This is required field",
                        number: "The value must be a number",
                        min: "The value must be equals 0 or greater",
                        max: "Tha value must be less than m"
                    },
                    "ManualInput.M": {
                        required: "This is required field",
                        number: "The value must be a number",
                        min: "The value must be greater than 0"
                    },
                    "ManualInput.X0": {
                        required: "This is required field",
                        number: "The value must be a number",
                        min: "The value must be equals 0 or greater",
                        max: "Tha value must be less than m"
                    },
                    OutputSize: {
                        required: "This is required field",
                        number: "The value must be a number",
                        min: "The value must be greater than 0"
                    }
                },
                // Make sure the form is submitted to the destination defined
                // in the "action" attribute of the form when valid
                submitHandler: function (form) {
                    let isVariant = $('input[name=' + self.ElementIDs.InputTypeRadioButtonId + ']:checked').val();

                    let data;
                    if (isVariant) {
                        data = {
                            Variant: $('#' + self.ElementIDs.VariantDropDownId).val(),
                            InputType: isVariant,
                            OutputSize: $('#' + self.ElementIDs.OutputSizeTextBoxId).val(),
                        }
                    }
                    else {
                        data = {
                            ManualInput: {
                                A: $('#' + self.ElementIDs.ATextBoxId).val(),
                                C: $('#' + self.ElementIDs.CTextBoxId).val(),
                                M: $('#' + self.ElementIDs.MTextBoxId).val(),
                                X0: $('#' + self.ElementIDs.X0TextBoxId).val(),
                            },
                            InputType: isVariant,
                            OutputSize: $('#' + self.ElementIDs.OutputSizeTextBoxId).val(),
                        }
                    }

                    $.ajax({
                        url: $('#' + self.URLs.InputDataUrl).attr(self.dataSourceAttr),
                        method: "post",
                        data: data,
                        async: true,
                        success: function (response) {
                            if (response.Success) {
                                self.loadPage(0);
                            }
                        }
                    });
                },
                errorPlacement: function (error, element) {
                    error.appendTo($('span[data-valmsg-for="' + $(element).attr('name') + '"]', $('#' + self.ElementIDs.InputFormId)));
                }
            });
        }

        loadPage(number: number) {
            
        }
    }

    let main = new Main();
}
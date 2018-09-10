//import swal from 'sweetalert2'
//import 'sweetalert2/src/sweetalert2.scss'

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

            PageNumberLabelId: "pageNumber",
            PeriodLabelId: "period",

            VariantsRowId: "variantInputRow",
            ManualRowId: "manualInputRow",

            InputFormId: "inputForm",

            PrevPageButtonId: "prevPage",
            NextPageButtonId: "nextPage",
            FirstPageButtonId: "firstPage",
            LastPageButtonId: "lastPage",

            OutputScreenId: "outputScreen",
        }

        dataSourceAttr = "data-source-url";

        formValidator: Validator;
        pagesCount: number;
        waitingdialog: waitingdialog;

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

            $('#' + self.ElementIDs.FirstPageButtonId).click(function () {
                self.loadPage(0);
            });

            $('#' + self.ElementIDs.PrevPageButtonId).click(function () {
                self.loadPage(Number($('#' + self.ElementIDs.PageNumberLabelId).text()) - 2);
            });

            $('#' + self.ElementIDs.NextPageButtonId).click(function () {
                self.loadPage(Number($('#' + self.ElementIDs.PageNumberLabelId).text()));
            });

            $('#' + self.ElementIDs.LastPageButtonId).click(function () {
                self.loadPage(self.pagesCount - 1);
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

                    self.waitingdialog = new waitingdialog();
                    self.waitingdialog.show("Loading...");

                    $.ajax({
                        url: "/Home/InputData",
                        method: "post",
                        data: data,
                        success: function (response) {
                            if (response.Success) {
                                self.waitingdialog.hide();
                                self.pagesCount = response.PagesCount;
                                $('#' + self.ElementIDs.PeriodLabelId).text(response.Period);
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
            let self = this;
            $.ajax({
                url: "/Home/LoadPage",
                method: "post",
                data: { number: number },
                success: function (response) {
                    $('#' + self.ElementIDs.OutputScreenId).val(response.PageContent);
                    $('#' + self.ElementIDs.PageNumberLabelId).text(number + 1);
                    self.checkPagesEnabled();
                }
            });
        }

        checkPagesEnabled() {
            let self = this;
            let number = Number($('#' + self.ElementIDs.PageNumberLabelId).text());
            if (number === 1) {
                $('#' + self.ElementIDs.PrevPageButtonId).prop("disabled", true);
                $('#' + self.ElementIDs.FirstPageButtonId).prop("disabled", true);
            }
            else if (number > 1) {
                $('#' + self.ElementIDs.PrevPageButtonId).removeProp("disabled");
                $('#' + self.ElementIDs.FirstPageButtonId).removeProp("disabled");
            }
            if (number === self.pagesCount) {
                $('#' + self.ElementIDs.NextPageButtonId).prop("disabled", true);
                $('#' + self.ElementIDs.LastPageButtonId).prop("disabled", true);
            }
            else if (number < self.pagesCount) {
                $('#' + self.ElementIDs.NextPageButtonId).removeProp("disabled");
                $('#' + self.ElementIDs.LastPageButtonId).removeProp("disabled");
            }
        }
    }
    
    let main = new Main();
}
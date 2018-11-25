namespace Lab5.Web {
    export class waitingdialog {
        dialog = $(
            '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="this.dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
            '<div class="modal-this.dialog modal-m">' +
            '<div class="modal-content">' +
            '<div class="modal-header"><h3 style="margin:0;"></h3></div>' +
            '<div class="modal-body">' +
            '<div class="progress progress-striped active" style="margin-bottom:0;"><div class="progress-bar" style="width: 100%"></div></div>' +
            '</div>' +
            '</div></div></div>');

        /**
         * Opens our this.dialog
         * @param message Custom message
         * @param options Custom options:
         * 				  options.this.dialogSize - bootstrap postfix for this.dialog size, e.g. "sm", "m";
         * 				  options.progressType - bootstrap postfix for progress bar type, e.g. "success", "warning".
         */
        show(message) {
            // Assigning defaults
            if (typeof message === 'undefined') {
                message = 'Loading';
            }
            let settings = {
                dialogSize: 'm',
                progressType: '',
                onHide: null // This callback runs after the this.dialog was hidden
            };

            // Configuring this.dialog
            this.dialog.find('.modal-this.dialog').attr('class', 'modal-this.dialog').addClass('modal-' + settings.dialogSize);
            this.dialog.find('.progress-bar').attr('class', 'progress-bar');
            if (settings.progressType) {
                this.dialog.find('.progress-bar').addClass('progress-bar-' + settings.progressType);
            }
            this.dialog.find('h3').text(message);
            // Adding callbacks
            if (typeof settings.onHide === 'function') {
                this.dialog.off('hidden.bs.modal').on('hidden.bs.modal', function (e) {
                    settings.onHide.call(this.dialog);
                });
            }
            // Opening this.dialog
            this.dialog.modal();
        }
        /**
         * Closes this.dialog
         */
        hide() {
            this.dialog.modal('hide');
        }
    }
}
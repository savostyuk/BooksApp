document.addEventListener('DOMContentLoaded', function () {
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
});

document.addEventListener("DOMContentLoaded", function () {
    var successMessage = '@TempData["SuccessMessage"]';

    if (successMessage) {
        var toastEl = document.getElementById('successToast');
        var toast = new bootstrap.Toast(toastEl, { delay: 2000 });
        toast.show();
    }
});

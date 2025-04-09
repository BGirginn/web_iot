// Toastr configuration
toastr.options = {
    "closeButton": true,
    "debug": false,
    "newestOnTop": false,
    "progressBar": true,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
};

// Initialize tooltips
$(function () {
    $('[data-toggle="tooltip"]').tooltip();
});

// Handle form submissions
$(document).ready(function () {
    // Add CSRF token to all AJAX requests
    $.ajaxSetup({
        headers: {
            'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
        }
    });

    // Handle form validation
    $('form').on('submit', function (e) {
        if (!$(this).valid()) {
            e.preventDefault();
            toastr.error('Please check the form for errors');
        }
    });
});

// Device connection handling
function connectDevice(deviceId) {
    $.post(`/Device/Connect/${deviceId}`, function (response) {
        if (response.success) {
            toastr.success('Device connected successfully');
            updateDeviceStatus(deviceId, true);
        } else {
            toastr.error('Failed to connect to device');
        }
    });
}

function disconnectDevice(deviceId) {
    $.post(`/Device/Disconnect/${deviceId}`, function (response) {
        if (response.success) {
            toastr.success('Device disconnected successfully');
            updateDeviceStatus(deviceId, false);
        } else {
            toastr.error('Failed to disconnect from device');
        }
    });
}

function updateDeviceStatus(deviceId, isConnected) {
    const connectBtn = $(`.connect-btn[data-id="${deviceId}"]`);
    const disconnectBtn = $(`.disconnect-btn[data-id="${deviceId}"]`);
    
    if (isConnected) {
        connectBtn.hide();
        disconnectBtn.show();
    } else {
        connectBtn.show();
        disconnectBtn.hide();
    }
}

// Handle device commands
function sendCommand(deviceId, command) {
    $.post(`/Device/SendCommand/${deviceId}`, { command: command }, function (response) {
        if (response.success) {
            toastr.success('Command sent successfully');
        } else {
            toastr.error('Failed to send command');
        }
    });
} 
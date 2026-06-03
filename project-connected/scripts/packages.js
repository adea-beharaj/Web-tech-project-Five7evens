// ======================================================
// packages.js  –  loads package prices from API
// ======================================================

const API_BASE = 'http://localhost:5000';

$(document).ready(function () {

    // Load package prices from API and display on buttons
    $.ajax({
        url: `${API_BASE}/Packages/GetAll`,
        method: 'GET',
        success: function (packages) {
            packages.forEach(pkg => {
                const btn = $('#' + pkg.value.charAt(0).toUpperCase() + 'price');
                if (btn.length) btn.text(pkg.price);
            });
        },
        error: function () {
            // Fallback to static prices if API is unavailable
            $('#Pprice').text('$899');
            $('#Bprice').text('$699');
            $('#Nprice').text('$799');
            $('#Tprice').text('$1099');
            $('#Rprice').text('$849');
            $('#Dprice').text('$999');
        }
    });

    // Navigate to details page on price button click
    $('#Pprice').on('click', function () { window.location.href = 'details.html#paris'; });
    $('#Bprice').on('click', function () { window.location.href = 'details.html#bali'; });
    $('#Nprice').on('click', function () { window.location.href = 'details.html#nyc'; });
    $('#Tprice').on('click', function () { window.location.href = 'details.html#tokyo'; });
    $('#Rprice').on('click', function () { window.location.href = 'details.html#rome'; });
    $('#Dprice').on('click', function () { window.location.href = 'details.html#dubai'; });

});

const API_BASE = 'http://localhost:5000';

$(document).ready(function () {

    loadBookings();

    // Date validation on change
    $('#date').on('change input blur', function () {
        const dateValue = $(this).val();
        if (!dateValue) { $('#date-error').text(''); $(this).removeClass('error-input'); return; }
        const selectedDate = new Date(dateValue);
        const today = new Date(); today.setHours(0, 0, 0, 0);
        if (selectedDate < today) {
            $('#date-error').text('Date cannot be in the past!');
            $(this).addClass('error-input');
        } else {
            $('#date-error').text('');
            $(this).removeClass('error-input');
        }
    });

    // Submit form
    $('#booking-form').submit(function (e) {
        e.preventDefault();
        $('.error-message').text('');
        $('#form-message').html('');

        const name        = $('#name').val().trim();
        const email       = $('#email').val().trim();
        const destination = $('#destination').val();
        const date        = $('#date').val();
        const guests      = parseInt($('#guests').val());
        let isValid = true;

        if (!name)        { $('#name-error').text('Name is required'); isValid = false; }
        if (!email)       { $('#email-error').text('Email is required'); isValid = false; }
        else if (!email.includes('@') || !email.includes('.')) { $('#email-error').text('Invalid email'); isValid = false; }
        if (!destination) { $('#destination-error').text('Select destination'); isValid = false; }
        if (!date) {
            $('#date-error').text('Select a date'); isValid = false;
        } else {
            const sel = new Date(date); const today = new Date(); today.setHours(0,0,0,0);
            if (sel < today) { $('#date-error').text('Date cannot be in the past!'); isValid = false; }
        }
        if (isNaN(guests) || guests < 1 || guests > 20) { $('#guests-error').text('Guests must be 1-20'); isValid = false; }

        if (!isValid) return;

        const editingId = $('#booking-form').data('editing-id');

        if (editingId) {
            // UPDATE existing booking
            $.ajax({
                url: `${API_BASE}/Bookings/Update`,
                method: 'PUT',
                contentType: 'application/json',
                data: JSON.stringify({ id: editingId, name, email, destination, date, guests }),
                success: function () {
                    $('#form-message').html('<p class="success-message">Booking updated successfully!</p>').show();
                    setTimeout(() => $('#form-message').fadeOut(), 1500);
                    $('#booking-form').removeData('editing-id');
                    $('button[type="submit"]').text('Book Now →');
                    $('#booking-form')[0].reset();
                    loadBookings();
                },
                error: function (xhr) {
                    $('#form-message').html('<p class="error-message">Error updating booking: ' + xhr.responseText + '</p>').show();
                }
            });
        } else {
            // CREATE new booking
            $.ajax({
                url: `${API_BASE}/Bookings/AddNew`,
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify({ name, email, destination, date, guests }),
                success: function () {
                    $('#form-message').html('<p class="success-message">Booking saved successfully!</p>').show();
                    setTimeout(() => $('#form-message').fadeOut(), 1500);
                    $('#booking-form')[0].reset();
                    loadBookings();
                },
                error: function (xhr) {
                    $('#form-message').html('<p class="error-message">Error saving booking: ' + xhr.responseText + '</p>').show();
                }
            });
        }
    });

    // Load bookings from API
    function loadBookings() {
        $.ajax({
            url: `${API_BASE}/Bookings/GetAll`,
            method: 'GET',
            success: function (bookings) {
                let html = '';
                if (!bookings || bookings.length === 0) {
                    html = '<p>No bookings yet.</p>';
                } else {
                    bookings.forEach(b => {
                        const destName = $('#destination option[value="' + b.destination + '"]').text() || b.destination;
                        html += `
                            <div class="booking-item">
                                <strong>${destName}</strong><br>
                                ${b.name} | ${b.email}<br>
                                ${b.date} | ${b.guests} guests
                                <button class="edit-btn"   data-id="${b.id}">Edit</button>
                                <button class="delete-btn" data-id="${b.id}">✖</button>
                            </div>`;
                    });
                }
                $('#bookings-list').html(html);
            },
            error: function () {
                $('#bookings-list').html('<p style="color:red;">Could not connect to API. Make sure the backend is running on http://localhost:5000</p>');
            }
        });
    }

    // Delete booking
    $(document).on('click', '.delete-btn', function () {
        const id = $(this).data('id');
        if (!confirm('Are you sure you want to delete this booking?')) return;
        $.ajax({
            url: `${API_BASE}/Bookings/Delete?id=${id}`,
            method: 'DELETE',
            success: function () { loadBookings(); },
            error: function (xhr) { alert('Error deleting: ' + xhr.responseText); }
        });
    });

    // Edit booking – load data into form
    $(document).on('click', '.edit-btn', function () {
        const id = $(this).data('id');
        $.ajax({
            url: `${API_BASE}/Bookings/GetById?id=${id}`,
            method: 'GET',
            success: function (b) {
                $('#name').val(b.name);
                $('#email').val(b.email);
                $('#destination').val(b.destination);
                $('#date').val(b.date);
                $('#guests').val(b.guests);
                $('#booking-form').data('editing-id', b.id);
                $('button[type="submit"]').text('Update Booking →');
                $('html, body').animate({ scrollTop: $('#booking-form').offset().top - 20 }, 400);
            },
            error: function () { alert('Could not load booking for editing.'); }
        });
    });

});

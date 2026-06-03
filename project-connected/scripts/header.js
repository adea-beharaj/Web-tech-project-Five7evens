 $(document).ready(function() {
    function showWelcomeAlert() {
        alert("Welcome to Five 7evens Agency!");
        }
    function handleBookingClick() {
        alert("Going to booking form");
            window.location.href = 'bookingForm.html';
        }
        showWelcomeAlert();
    $('#search-btn').on('click', handleBookingClick);
                
});

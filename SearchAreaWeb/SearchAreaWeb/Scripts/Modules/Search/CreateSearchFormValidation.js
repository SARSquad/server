$(document).ready(function () {

    $('#createSearchForm').validate({
        rules: {
            Name: {
                required: true,
            },
            NortheastLatitude: {
                required: true,
            }
        },
        messages: {
            Name: "Please enter a name for your search.",
            NortheastLatitude: "This field is required."
        }
    })
})
$(document).ready(function () {

    $('#createSearchForm').validate({
        rules: {
            Name: {
                required: true,
            },
            NortheastLatitude: {
                required: true,
                number: true,
                min: -90,
                max: 90,
            },
            NortheastLongitude: {
                required: true,
                number: true,
                min: -180,
                max: 180,
            },
            SouthwestLatitude: {
                required: true,
                number: true,
                min: -90,
                max: 90,
            },
            SouthwestLongitude: {
                required: true,
                number: true,
                min: -180,
                max: 180,
            }
        },
        messages: {
            Name: "Please enter a name for your search.",
            NortheastLatitude: {
                required: "This field is required.",
                number: "This must be a number between -90 and 90."
            },
            NortheastLongitude: {
                required: "This field is required.",
                number: "This must be a number between -180 and 180."
            },
            SouthwestLatitude: {
                required: "This field is required.",
                number: "This must be a number between -90 and 90."
            },
            SouthwestLongitude: {
                required: "This field is required.",
                number: "This must be a number between -180 and 90180
            },
        }
    })
})
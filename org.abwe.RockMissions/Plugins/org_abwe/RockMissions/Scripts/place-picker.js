function initialize(opts) {
    $(window).on('googleMapsIsLoaded', () => {
        const input = document.getElementById("autocomplete_"+opts.controlId);
        if (!input) return;

        const options = {
            fields: ["address_components", "geometry", "icon", "name"]
        };
        const autocomplete = new google.maps.places.Autocomplete(input, options);
    
        function fillInAddress() {
            // Get the place details from the autocomplete object.
            const place = autocomplete.getPlace();
            let location = place.geometry.location.lat()+","+place.geometry.location.lng();
    
            document.querySelector('#hfGeoDisplayName_'+opts.controlId).value = place.name;
            document.querySelector('#hfGeoPath_'+opts.controlId).value = location;
        }
    
        autocomplete.addListener('place_changed', fillInAddress);
    });

    if (typeof (google) != "undefined") {
        $(window).trigger('googleMapsIsLoaded');
    }
}

window.org_abwe = window.org_abwe || {};
window.org_abwe.placePicker = window.org_abwe.placePicker || { initialize: initialize };
///////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////           Initial
///////////////////////////////////////////////////////////////////////
function initialGmap() {
    $("#my_map")
        .gmap3({
            map: {
                options: {
                    zoom: 2,
                    mapTypeId: window.google.maps.MapTypeId.ROADMAP,
                    center: new window.google.maps.LatLng(48.86745543642139, 2.1407350835937677)
                }
            }
        });
};
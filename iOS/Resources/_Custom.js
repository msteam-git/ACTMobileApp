<script>
        var posmarker, map, updatetime, moved = 0;

        window.onload = function(){
            debugger;
            var bounds = [
                [66.5362608, 20.2477753], // Southwest coordinates
                [66.5992895, 20.3598438]  // Northeast coordinates
            ];

            //var bounds = [
            //    [30.733315, 76.779418], // Southwest coordinates
            //    [30.704095, 76.879325]  // Northeast coordinates
            //];

            //map = L.map('map', {
            //    attributionControl: false,
            //    zoomControl: false,
            //    maxZoom: 18,
            //    minZoom: 13,
            //    maxBounds: bounds,
            //}).setView([30.723315, 20.829325], 13);

            map = L.map('map', {
                attributionControl: false,
                zoomControl: false,
                maxZoom: 17,
                minZoom: 13,
                maxBounds: bounds,
            }).setView([66.575735, 20.324749], 13);


            map.on('movestart', function(){
              moved = true;
              document.getElementsByClassName("top")[0].style.display = 'none';
            });

            L.control.zoom({
                 position:'bottomright'
            }).addTo(map);

            var imageUrl = 'trailmapfinal.jpg',
                imageBounds = bounds;
            L.imageOverlay(imageUrl, imageBounds).addTo(map);

            var firstIcon = L.icon({
                iconUrl: 'Numbers/numbers1.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20] 
                //iconSize: [38, 95], // size of the icon
                //iconAnchor: [22, 94], // point of the icon which will correspond to marker's location
                //popupAnchor: [-3, -76] // point from which the popup should open relative to the iconAnchor
            });
            var secondIcon = L.icon({
                iconUrl: 'Numbers/numbers2.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });

            var fourteenthIcon = L.icon({
                iconUrl: 'Numbers/numbers14.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });

            var thirdIcon = L.icon({
                iconUrl: 'Numbers/numbers3.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });

            var fourthIcon = L.icon({
                iconUrl: 'Numbers/numbers4.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });

            var sixthIcon = L.icon({
                iconUrl: 'Numbers/numbers6.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });

            var seventhIcon = L.icon({
                iconUrl: 'Numbers/numbers7.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });

            var eighthIcon = L.icon({
                iconUrl: 'Numbers/numbers8.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });

            var ninethIcon = L.icon({
                iconUrl: 'Numbers/numbers9.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });

            var tenthIcon = L.icon({
                iconUrl: 'Numbers/numbers10.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });

            var eleventhIcon = L.icon({
                iconUrl: 'Numbers/numbers11.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });

            var twelfthIcon = L.icon({
                iconUrl: 'Numbers/numbers12.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });

            var thirteenthIcon = L.icon({
                iconUrl: 'Numbers/numbers13.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });


            // Icons
            var startIcon = L.icon({
                iconUrl: 'Map_Icons/symb-parkering.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });

            var fieldIcon = L.icon({
                iconUrl: 'Map_Icons/symb-sevardhet-farg.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });

            var waterIcon = L.icon({
                iconUrl: 'Map_Icons/Vattenplats-farg.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });

            var crossingIcon = L.icon({
                iconUrl: 'Map_Icons/Polcirkeln.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });

            var infoIcon = L.icon({
                iconUrl: 'Map_Icons/info.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });

            var forestIcon = L.icon({
                iconUrl: 'Map_Icons/symb-rastplats.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });

            var laneIcon = L.icon({
                iconUrl: 'Map_Icons/symb-fornlamn.png',
                iconSize: [10, 30],
                iconAnchor: [6, 31],
                popupAnchor: [0, -20]
            });

            L.marker([66.578154, 20.351326], { icon: infoIcon }).addTo(map);

            L.marker([66.578692, 20.347191], { icon: startIcon }).addTo(map);

            L.marker([66.578322, 20.340222], { icon: fieldIcon }).addTo(map);

            L.marker([66.576302, 20.320245], { icon: fieldIcon }).addTo(map);

            L.marker([66.573327, 20.334944], { icon: waterIcon }).addTo(map);

            L.marker([66.561937, 20.266138], { icon: crossingIcon }).addTo(map);

            L.marker([66.568683, 20.278006], { icon: infoIcon }).addTo(map);

            L.marker([66.559444, 20.284334], { icon: forestIcon }).addTo(map);

            L.marker([66.562661, 20.281818], { icon: crossingIcon }).addTo(map);

            L.marker([66.567904, 20.271330], { icon: laneIcon }).addTo(map);

            L.marker([66.567951, 20.279028], { icon: laneIcon }).addTo(map);

            L.marker([66.575224, 20.344829], { icon: forestIcon }).addTo(map);

            L.marker([66.578167, 20.349556], { icon: firstIcon }).addTo(map).bindPopup("<b>Start and finish - The Beginning</b><br/><img src='ObjectPage_Images/Start.jpg' class='popupImage' /><br/><audio controls class='popupAudio'  src='ObjectPage_Audio/ACT_Page_6_A_audio_EN.mp3'></audio><br/> This is where to start and finish your hike along Polcirkelleden and where you begin one of your Arctic adventures.<br/>Parking is available at this east entrance to Serri Nature Reserve.<br/>The trail is marked by the red rings painted on trees.<br/>Your starting point coordinates are N66 34.690 E20 20.974<br/><b>How to get there.</b><br/>The trail is located 23.5 km, about 20min, from Vuollerim.<br/>From Arctic Circle Gateway 97, turn left into Murjeksvägen in 600 m turn left in 1.1 km turn right in 5.8 km turn right in 7.2 km turn left in 1.4 km turn right in 7.4 km car park on left", {
                maxHeight: "150", maxWidth:"200"
            });
            
            L.marker([66.576778, 20.346917], { icon: secondIcon }).addTo(map).bindPopup("<b>Gåsmyrtjärnarna (Geese mire ponds)</b><br/><img src='ObjectPage_Images/ACT_Page_6_B_image_1.jpg' class='popupImage' /><br/><audio controls class='popupAudio'  src='ObjectPage_Audio/ACT_Page_6_B_audio_EN.mp3'></audio><br/>A short distance away you will see Gåsmyrtjärnarna. The name is said to come from the fact that many geese stop here during their migrations.<br/>Here on the marshes are also several deep cold-water springs.", {
                maxHeight: "150", maxWidth: "200"
            });

            L.marker([66.576333, 20.344250], { icon: fourteenthIcon }).addTo(map);

            L.marker([66.573472, 20.338806], { icon: fourthIcon }).addTo(map).bindPopup("<b>Suoksåivebäcken (Suoksåive brook)</b><br/><img src='ObjectPage_Images/ACT_Page_6_D_image_1.jpg' class='popupImage' /><br/><audio controls class='popupAudio'  src='ObjectPage_Audio/ACT_Page_6_D_audio_EN.mp3'></audio><br/>A tributary to the Greater and Lesser Lule River.<br/>Stories from the past speak of it as the stream that never froze.<br/>The brook´s Sami name translates to the tool with which to fish flodpärlsmusslor (river pearl mussel). Flodpärlsmusslor were found in the brook as long as the Suoksåivesjön (Suoksåive lake) was dammed to create hay meadows for the settlers.<br/>You can drink the water in this brook.<br/>", {
                maxHeight: "150", maxWidth: "200"
            });

            L.marker([66.576694, 20.326167], { icon: thirdIcon }).addTo(map).bindPopup("<b>Fire Fields</b><br/><img src='ObjectPage_Images/ACT_Page_6_C_image_1.jpg' class='popupImage' /><br/><audio controls class='popupAudio'  src='ObjectPage_Audio/ACT_Page_6_C_audio_EN.mp3'></audio><br/>This fire field shows that a forest fire occurred here not too long ago.<br/>Fires mostly destroys the ground vegetation. For millennia fires have shaped forest landscape.<br/>Some species are dependent upon, or have difficulty, surviving without fires.", {
                maxHeight: "150", maxWidth: "200"
            });

            L.marker([66.561944, 20.290444], { icon: sixthIcon }).addTo(map);

            L.marker([66.568444, 20.274444], { icon: seventhIcon }).addTo(map);

            L.marker([66.559444, 20.287306], { icon: eighthIcon }).addTo(map).bindPopup("<b>TjäderVintjärn (Wood Grouse Pond) - Rest area</b><br/><img src='ObjectPage_Images/ACT_Page_6_H_image_1.jpg' class='popupImage' /><br/><audio controls class='popupAudio'  src='ObjectPage_Audio/ACT_Page_6_H_audio_EN.mp3'></audio><br/>A mating place of the Wood Grouse is called Tjädervin.<br/>Here you will find shelters, toilets (non-water), a woodshed and seating area with a fire pit. If you decide to stay the night then you may put up a tent.<br/>Drinking water can be taken from the cold spring not far from here. Go about 60 meters in a northerly direction from the wind shelter and you will find it.", {
                maxHeight: "150", maxWidth: "200"
            });

            L.marker([66.560833, 20.273361], { icon: ninethIcon }).addTo(map).bindPopup("<b>Garnlav - Yarn Lichen (Alectoria sarmentosa) - Yellow Garlands of the Forest</b><br/><img src='ObjectPage_Images/ACT_Page_6_i_image_1.jpg' class='popupImage' /><br/><audio controls class='popupAudio'  src='ObjectPage_Audio/ACT_Page_6_i_audio_EN.mp3'></audio><br/>These forest lichens grow in older and very pure spruce forest environments.<br/>Lichens are a symbiosis (collaboration) between an alga and a fungus.<br/>Yarn lichen is highly disadvantaged in today's forestry and can only be seen in numbers in uncultivated older spruce forests. The laven spread by small pieces getting attached to an animal or by the wind, to take root on a new tree where it will prosper and create a new life.", {
                maxHeight: "150", maxWidth: "200"
            });

            L.marker([66.562167, 20.269528], { icon: tenthIcon }).addTo(map);

            L.marker([66.567972, 20.273583], { icon: eleventhIcon }).addTo(map).bindPopup("<b>Cultural History</b><br/><img src='ObjectPage_Images/ACT_Page_6_K_image_1.jpg' class='popupImage' /><br/><audio controls class='popupAudio'  src='ObjectPage_Audio/ACT_Page_6_K_audio_EN.mp3'></audio><br/>Haymaking<br/>On your walk you will pass old haymaking equipment from a long gone era, at Slakkamyren (Slakka marsh). The marshes were vitally important to the colonists, which is where they picked fodder for their cattle. They started to propagate the marshes to grow more fodder and ended up sacrificing the forrest to achieve this.<br/>One plant especially sought after by the colonists was horsetail, or rånnings hay. A ‘rånning’ was an area next to quiet flowing streams and lake shores.", {
                maxHeight: "150", maxWidth: "200"
            });

            L.marker([66.568139, 20.274694], { icon: twelfthIcon }).addTo(map).bindPopup("<b>Slåtterkoja - The Old Cutting Hut</b><br/><img src='ObjectPage_Images/ACT_Page_6_L_image_1.jpg' class='popupImage' /><br/><audio controls class='popupAudio'  src='ObjectPage_Audio/ACT_Page_6_L_audio_EN.mp3'></audio><br/>Newly renovated with traditional shingled roof. Tap on the door and take a peek inside. On the wall you will find both scythe and rake.<br/>Please sign the diary available, build a fire and perhaps have a rest.<br/>During your rest you might think of the people who did the work in the surrounding fields.<br/>There is an outhouse available not far from the hut.", {
                maxHeight: "150", maxWidth: "200"
            });

            L.marker([66.564250, 20.269278], { icon: thirteenthIcon }).addTo(map);

            setInterval(function(){
              if(!updatetime || new Date().getTime() - updatetime.getTime() > 10000){
                //document.getElementsByClassName("inactive")[0].style.display = 'block';
                  document.getElementsByClassName("inactive")[0].style.display = 'none';
                document.getElementsByClassName("loading")[0].style.display = 'none';
              } else {
                document.getElementsByClassName("inactive")[0].style.display = 'none';
                }
              setPosition(60.575735, 20.324749);
            }, 7000);

            //L.tileLayer('https://api.tiles.mapbox.com/v4/mapbox.streets/{z}/{x}/{y}.png?access_token=sk.eyJ1Ijoic2FtaW1hcmt1cyIsImEiOiJjajNudWw3dmcwMDBwMzNxZDNzMmEyYjU3In0.A4kMMpg1yDGPUez_eHW7lA', { attribution : "korv" }).addTo(map);

            //setTimeout(function() { setPosition(60.575735, 20.324749); }, 100);
        }
        
        function play() {
            var audio = document.getElementById("audio");
            audio.play();
        }
        function setPosition(latitude, longitude){
            updatetime = new Date();

            if (posmarker) {
              map.removeLayer(posmarker);
            }

            posmarker = L.circleMarker([latitude, longitude], 10, {
              color: 'white',
              fillColor: 'red',
              fillOpacity: 0.7
            }).addTo(map);

            if(!map.getBounds().contains([latitude,longitude])){
                document.getElementsByClassName("inactive")[0].style.display = 'none';
                if(!moved) document.getElementsByClassName("top")[0].style.display = 'block';
                document.getElementsByClassName("loading")[0].style.display = 'none';
            } else {
                document.getElementsByClassName("top")[0].style.display = 'none';
                document.getElementsByClassName("loading")[0].style.display = 'none';
            }
        }
    </script>
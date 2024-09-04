var apiKey = "qkMsAoBwrzxcXQWR7hkYL77G9LF7MjHA";
let size = 10;
var initialZoom = 10;
var centerCoords;
var markers = [];
var lineIds = [];
var basic = createButtonWithTooltip('basic', '<i class="fas fa-sun"></i>', 'Basic');
var satellite = createButtonWithTooltip('satellite', '<i class="fas fa-satellite"></i>', 'Satellite');
var dark = createButtonWithTooltip('dark', '<i class="fas fa-moon"></i>', 'Dark');
var mapStyle = createButtonWithTooltip('styles', '<i class="fas fa-map-marked-alt"></i>', 'Change Style');

var state = {
    mapStyle: '2/basic_street-light'
};

//Map Initialization
var map = tt.map({
    key: apiKey,
    container: "map",
    pitch: 0,//60,
    bearing: 0, //95,
    zoom: 3.7,
    center: [78.72984910255843, 23.473169244264],
    style: getCurrentStyleUrl()
});

map.setLanguage("en-GB");                     //Map Language
var fullscreen = new tt.FullscreenControl();
map.addControl(fullscreen, 'top-left');      //Fullscreen control
var nav = new tt.NavigationControl({         //navigation control
    showPitch: true,
    showExtendedRotationControls: true,
    showExtendedPitchControls: true
});
map.addControl(nav, 'top-left');

document.addEventListener('DOMContentLoaded', function () {
    updateProjectDropdownNames();
    updateSubsystemDropdownNames();
    setupProjectTypeCheckboxes();
    setupSubsystemTypeCheckboxes();
});
map.on('style.load', function () {
    UpdateMapView();
});

//Tooltip for icons on map
function createButtonWithTooltip(id, text, tooltip) {
    var button = document.createElement('button');
    button.className = 'buttons';
    button.innerHTML = text;
    button.id = id;
    var tooltipSpan = document.createElement('span');
    tooltipSpan.className = 'tooltip';
    tooltipSpan.innerHTML = tooltip;
    button.appendChild(tooltipSpan);
    return button;
}

// Create a container div for the buttons
var buttonContainer = document.createElement('div');
buttonContainer.className = 'icons-container';

var additionalButtonsContainer = document.createElement('div');
additionalButtonsContainer.className = 'additional-buttons';
additionalButtonsContainer.style.display = 'none'; // Hide initially

additionalButtonsContainer.appendChild(basic);
additionalButtonsContainer.appendChild(satellite);
additionalButtonsContainer.appendChild(dark);

// Append the mapStyle button and additional buttons container to the main container
buttonContainer.appendChild(mapStyle);
buttonContainer.appendChild(additionalButtonsContainer);

map.getContainer().appendChild(buttonContainer);

mapStyle.addEventListener('click', function () {
    if (additionalButtonsContainer.style.display === 'none') {
        additionalButtonsContainer.style.display = 'flex';
    } else {
        additionalButtonsContainer.style.display = 'none';
    }
});

//Map Styles
basic.addEventListener('click', function () {     //Basic layer
    state.mapStyle = '2/basic_street-light';
    map.setStyle(getCurrentStyleUrl());
});
satellite.addEventListener('click', function () {    //Satellite layer
    state.mapStyle = '2/basic_street-satellite';
    map.setStyle(getCurrentStyleUrl());
});
dark.addEventListener('click', function () {       //Dark layer
    state.mapStyle = '2/basic_street-dark';
    map.setStyle(getCurrentStyleUrl());
});

//Change Map Styles
function getCurrentStyleUrl() {
    var baseStyle = 'https://api.tomtom.com/style/1/style/22.2.1-*?map=' + state.mapStyle + `&poi=2/poi_light&key=${apiKey}`;
    return baseStyle;
}

// Function to update project dropdown names based on selected project types
function updateProjectDropdownNames() {
    const selectedProjectTypeIDs = getSelectedProjectTypeIDs();

    $.ajax({
        url: '/Map/ProjectDetailsDropdown',
        type: 'GET',
        data: { projectTypeIds: selectedProjectTypeIDs },
        traditional: true
    }).done(function (projectResponse) {
        // Handle project name dropdown
        const projectDropdown = $('#projectName');
        projectDropdown.empty();
        projectDropdown.append('<h6 class="dropdown-header">Select Project Name</h6>');
        projectDropdown.append('<a class="dropdown-item"><input type="checkbox" class="select-all-checkbox" id="selectAllProjectNames"><label for="selectAllProjectNames">Select All</label></a>');
        projectResponse.forEach(function (item) {
            projectDropdown.append('<a class="dropdown-item"><input type="checkbox" class="project-name-checkbox" value="' + item.projectID + '"><label for="projectnameid_' + item.projectID + '">' + " " + item.projectName + '</label></a>');
        });
        setupProjectNameCheckboxes();
        $('#selectAllProjectNames').prop('checked', true).trigger('change');
        UpdateMapView();
    }).fail(function (xhr, status, error) {
        console.error('Error: ' + error);
    });
}

// Function to update subsystem dropdown names based on selected subsystem types
function updateSubsystemDropdownNames() {
    const selectedSubsystemTypeIDs = getSelectedSubsystemTypeIDs();

    $.ajax({
        url: '/Map/SubsystemDetailsDropdown',
        type: 'GET',
        data: { subsystemTypeIds: selectedSubsystemTypeIDs },
        traditional: true
    }).done(function (subsystemResponse) {
        // Handle subsystem name dropdown
        const subsystemDropdown = $('#subsystemName');
        subsystemDropdown.empty();
        subsystemDropdown.append('<h6 class="dropdown-header">Select SubSystem Name</h6>');
        subsystemDropdown.append('<a class="dropdown-item"><input type="checkbox" class="select-all-checkbox" id="selectAllSubsystemNames"><label for="selectAllSubsystemNames">Select All</label></a>');
        subsystemResponse.forEach(function (item) {
            subsystemDropdown.append('<a class="dropdown-item"><input type="checkbox" class="subsystem-name-checkbox" value="' + item.subSysID + '"><label for="subsystemnameid_' + item.subSysID + '">' + " " + item.details + '</label></a>');
        });
        setupSubsystemNameCheckboxes();
        $('#selectAllSubsystemNames').prop('checked', true).trigger('change');
        UpdateMapView();
    }).fail(function (xhr, status, error) {
        console.error('Error: ' + error);
    });
}

// Get selected project type IDs
function getSelectedProjectTypeIDs() {
    const selectedProjectTypeIDs = [];
    document.querySelectorAll('.project-type-checkbox:checked').forEach(function (checkedCheckbox) {
        selectedProjectTypeIDs.push(checkedCheckbox.value);
    });
    return selectedProjectTypeIDs;
}

// Get selected subsystem type IDs
function getSelectedSubsystemTypeIDs() {
    const selectedSubsystemTypeIDs = [];
    document.querySelectorAll('.subsystem-type-checkbox:checked').forEach(function (checkedCheckbox) {
        selectedSubsystemTypeIDs.push(checkedCheckbox.value);
    });
    return selectedSubsystemTypeIDs;
}

// Set up project type checkboxes
function setupProjectTypeCheckboxes() {
    const selectAllProjectTypes = document.getElementById('selectAllProjectTypes');
    const projectTypeCheckboxes = document.querySelectorAll('.project-type-checkbox');

    if (selectAllProjectTypes) {
        selectAllProjectTypes.addEventListener('change', function () {
            const isChecked = selectAllProjectTypes.checked;
            projectTypeCheckboxes.forEach(function (checkbox) {
                checkbox.checked = isChecked;


            });
            updateProjectDropdownNamesDebounced();

        });
    }

    projectTypeCheckboxes.forEach(function (checkbox) {
        checkbox.addEventListener('change', function () {

            if (!checkbox.checked) {
                selectAllProjectTypes.checked = false;
            } else if (document.querySelectorAll('.project-type-checkbox:checked').length === projectTypeCheckboxes.length) {
                selectAllProjectTypes.checked = true;
            }
            updateProjectDropdownNamesDebounced();

        });
    });
}

// Set up subsystem type checkboxes
function setupSubsystemTypeCheckboxes() {
    const selectAllSubsystemTypes = document.getElementById('selectAllSubsystemTypes');
    const subsystemTypeCheckboxes = document.querySelectorAll('.subsystem-type-checkbox');

    if (selectAllSubsystemTypes) {
        selectAllSubsystemTypes.addEventListener('change', function () {
            const isChecked = selectAllSubsystemTypes.checked;
            subsystemTypeCheckboxes.forEach(function (checkbox) {
                checkbox.checked = isChecked;
            });
            updateSubsystemDropdownNamesDebounced();
        });
    }

    subsystemTypeCheckboxes.forEach(function (checkbox) {
        checkbox.addEventListener('change', function () {
            if (!checkbox.checked) {
                selectAllSubsystemTypes.checked = false;
            } else if (document.querySelectorAll('.subsystem-type-checkbox:checked').length === subsystemTypeCheckboxes.length) {
                selectAllSubsystemTypes.checked = true;
            }
            updateSubsystemDropdownNamesDebounced();
        });
    });
}

// Set up project name checkboxes
function setupProjectNameCheckboxes() {
    const selectAllProjectNames = document.getElementById('selectAllProjectNames');
    const projectNameCheckboxes = document.querySelectorAll('.project-name-checkbox');

    if (selectAllProjectNames) {
        selectAllProjectNames.addEventListener('change', function () {
            const isChecked = selectAllProjectNames.checked;
            projectNameCheckboxes.forEach(function (checkbox) {
                checkbox.checked = isChecked;
            });
            UpdateMapViewDebounced();
        });
    }

    projectNameCheckboxes.forEach(function (checkbox) {
        checkbox.addEventListener('change', UpdateMapViewDebounced);
    });
    // Select all project name checkboxes initially
    projectNameCheckboxes.forEach(function (checkbox) {
        checkbox.checked = true;
    });
    UpdateMapViewDebounced();
}

// Set up subsystem name checkboxes
function setupSubsystemNameCheckboxes() {
    const selectAllSubsystemNames = document.getElementById('selectAllSubsystemNames');
    const subsystemNameCheckboxes = document.querySelectorAll('.subsystem-name-checkbox');

    if (selectAllSubsystemNames) {
        selectAllSubsystemNames.addEventListener('change', function () {
            const isChecked = selectAllSubsystemNames.checked;
            subsystemNameCheckboxes.forEach(function (checkbox) {
                checkbox.checked = isChecked;
            });
            UpdateMapViewDebounced();
        });
    }

    subsystemNameCheckboxes.forEach(function (checkbox) {
        checkbox.addEventListener('change', UpdateMapViewDebounced);
    });
    // Select all subsystem name checkboxes initially
    subsystemNameCheckboxes.forEach(function (checkbox) {
        checkbox.checked = true;
    });
    UpdateMapViewDebounced();
}

// Function to update the map view based on selected project and subsystem names
function UpdateMapView() {
    const selectedProjectIDs = [];
    const selectedSubsystemIDs = [];
    document.querySelectorAll('.project-name-checkbox:checked').forEach(function (checkedCheckbox) {
        selectedProjectIDs.push(checkedCheckbox.value);
    });
    document.querySelectorAll('.subsystem-name-checkbox:checked').forEach(function (checkedCheckbox) {
        selectedSubsystemIDs.push(checkedCheckbox.value);
    });

    const hardwareCoords = $.ajax({
        url: '/Map/SelectedTSubsystemMasterDetails',
        type: 'GET',
        data: {
            projectIds: selectedProjectIDs,
            subsystemIds: selectedSubsystemIDs
        },
        traditional: true
    });

    const routeCoordinates = $.ajax({
        url: '/Map/SelectedTPositionMasterDetails',
        type: 'GET',
        data: { projectIds: selectedProjectIDs },
        traditional: true
    });

    $.when(hardwareCoords, routeCoordinates).done(function (hardwareResponse, routeResponse) {
        try {
            // Handle first response
            const coordinates = Array.isArray(hardwareResponse[0]) ? hardwareResponse[0] : JSON.parse(hardwareResponse[0]);
            markers.forEach((marker) => marker.remove());
            hardware(coordinates);

            // Handle second response
            const routeCoords = Array.isArray(routeResponse[0]) ? routeResponse[0] : JSON.parse(routeResponse[0]);
            projectStartEnd(routeCoords);
            createRoute(routeCoords);

        } catch (e) {
            console.error('Parsing error:', e);
        }
    }).fail(function (xhr, status, error) {
        console.error('Error: ' + error);
    });
}

// Debounce functions to prevent excessive calls
const updateProjectDropdownNamesDebounced = debounce(updateProjectDropdownNames, 300);
const updateSubsystemDropdownNamesDebounced = debounce(updateSubsystemDropdownNames, 300);
const UpdateMapViewDebounced = debounce(UpdateMapView, 300);

// Debounce function implementation
function debounce(func, wait) {
    let timeout;
    return function () {
        const context = this, args = arguments;
        clearTimeout(timeout);
        timeout = setTimeout(() => func.apply(context, args), wait);
    };
}

//    //dynamic marker icons
function hardware(coordinates) {
    coordinates.forEach(function (coord) {

        var lnglat = [coord.longitude, coord.latitude];
        var iconSize = 30;
        /*   var iconPath=coord.systemImage;*/

        if (coord.alive === true) {
            switch (coord.subSysID) {

                case 2: //mrcs
                    iconSize = 50;
                    break;
                case 3: //ecb
                    iconSize = 20;
                    break;
                case 4: //met
                    iconSize = 50;
                    break;
                case 5: //vids
                    iconSize = 40;
                    break;
                case 26: //atcc
                    iconSize = 20;
                    break;
                case 56: //gsmgateway
                    iconSize = 50;
                    break;

            }
            var customIcon = new Image(iconSize);
            customIcon.src = coord.systemImage;


            if (coord.verified === true) {
                isVerified = 'VERIFIED';
            } else {
                isVerified = 'NOT VERIFIED';
            }

            var popupContent = `
    <div style="padding:10px; border-radius: 11px; border:solid; background-color:beige; margin-top: 6px;">
        <h6><b> ${coord.details}</b> </h6> 
        <p><b>Serial No.:</b> ${coord.serialNo}<br>
         <b>Model       :</b> ${coord.model}<br>
         <b>Address     :</b> ${coord.address}<br>
         <b>Latitude    :</b> ${coord.longitude}<br>
         <b>Longitude   :</b> ${coord.latitude}<br>
         <b> ${isVerified} </b> </p>
    </div>
`;
            var popup = new tt.Popup({
                closeButton: false,
                offset: 35,
            }).setHTML(popupContent);

            if (coord.latitude != 0 && coord.longitude != 0) {
                var marker = new tt.Marker({
                    element: customIcon,
                    draggable: false,
                    clickable: true,
                    anchor: 'bottom',
                }).setLngLat(lnglat)
                    .addTo(map);
                markers.push(marker);

                marker.setPopup(popup);
                marker.getElement().addEventListener('mouseover', function () {
                    popup.addTo(map);
                });
                marker.getElement().addEventListener('mouseout', function () {
                    popup.remove();
                });
                var verifyIcon;
                ////Verified Indication
                if (coord.verified === true) {
                    verifyIcon = new Image(20);
                    verifyIcon.src = '/image/verified.png';
                    verifyIcon.style.marginTop = "46px";

                }
                else if (coord.verified === false) {
                    verifyIcon = new Image(20);
                    verifyIcon.src = '/image/cross.png';
                    verifyIcon.style.marginTop = "47px";

                }
                // Calculate offset to position the marker's top center at (0, 0) relative to its center
                var offset = new tt.Point(0, -80); // 10, -80);

                var vIcon = new tt.Marker({
                    element: verifyIcon,
                    offset: offset,
                    draggable: false,
                    clickable: true,
                    anchor: 'top',
                    //   width:"50px"

                }).setLngLat(lnglat)
                    .addTo(map);
                markers.push(vIcon);
            }
        }
    });
}
function projectStartEnd(routeCoords) {
    var projects = {};
    // Group coordinates by project
    routeCoords.forEach(function (coord) {
        if (!projects[coord.projectID]) {
            projects[coord.projectID] = [];
        }
        projects[coord.projectID].push(coord);
    });

    // Process each project
    Object.keys(projects).forEach(function (project) {
        var projectCoords = projects[project];
        var startCoord = null;
        var endCoord = null;

        // Find the first occurrence of pointType = 1 for the start marker
        for (var i = 0; i < projectCoords.length; i++) {
            if (projectCoords[i].pointType === 1) {
                startCoord = projectCoords[i];
                break;
            }
        }

        // Find the last occurrence of pointType = 2 for the end marker
        for (var i = projectCoords.length - 1; i >= 0; i--) {
            if (projectCoords[i].pointType === 2) {
                endCoord = projectCoords[i];
                break;
            }
        }

        // Add start marker
        if (startCoord) {
            var lnglat = [startCoord.longitude, startCoord.latitude];
            var startIcon = new Image(70);
            startIcon.src = '/image/start.png';
            var popupContent = `
        <div style="font-size:11px;top:-6px;color:black;border-radius:30px;position:relative">
           <p> <b> Project Start ${startCoord.address} <br>
             CH ${startCoord.position.toFixed(3)} KM </b> </p>
        </div>

    `;
            var start = new tt.Marker({
                element: startIcon,
                anchor: 'bottom',
                clickable: true
            })
                .setLngLat(lnglat)
                .addTo(map);
            markers.push(start);

            var startpopup = new tt.Popup({
                className: 'tt-popup',
                offset: -10,
                closeButton: false,
                anchor: 'top',
                closeOnClick: false,
            })
                .setHTML(popupContent);
            start.setPopup(startpopup).togglePopup();
        }

        // Add end marker
        if (endCoord) {
            var lnglat = [endCoord.longitude, endCoord.latitude];
            var endIcon = new Image(70);
            endIcon.src = '/image/end.png';
            var popupContent = `
        <div style="font-size:11px;top:-6px;color:black;border-radius:30px;position:relative">
            <p> <b> Project End ${endCoord.address}</b> <br>
            <b> CH ${endCoord.position.toFixed(3)} KM </b> </p>
        </div>
    `;
            var end = new tt.Marker({
                element: endIcon,
                anchor: 'bottom',
                clickable: true
            })
                .setLngLat(lnglat)
                .addTo(map);
            markers.push(end);

            var endpopup = new tt.Popup({
                className: 'tt-popup',
                offset: -10,
                closeButton: false,

                anchor: 'top',
                closeOnClick: false,
            })
                .setHTML(popupContent);
            end.setPopup(endpopup).togglePopup();
        }
    });
}
var createLine = function (routeGeometry, id) {

    map.addLayer({
        'id': id,
        'type': 'line',
        'source': {
            'type': 'geojson',
            'data': routeGeometry
        },
        'layout': {},
        'paint': {
            'line-color': 'blue',
            'line-width': 9
        }
    });
    lineIds.push(id);
};

var createRoute = function (routeCoords) {
    removeAllLines();
    if (routeCoords.length === 0) return;
    const totalCoords = routeCoords.length;

    let bounds = new tt.LngLatBounds();
    var segmentId = 0;
    var currentSegment = [];
    routeCoords.forEach(function (point) {
        bounds.extend([point.longitude, point.latitude]);
        if (point.pointType === 1 && currentSegment.length > 0) {
            // New segment starts, process the previous segment first
            segmentId++;
            var routeGeoJSON = {
                'type': 'Feature',
                'geometry': {
                    'type': 'LineString',
                    'coordinates': currentSegment.map(function (p) {
                        return [p.longitude, p.latitude];
                    })
                }
            };
            createLine(routeGeoJSON.geometry, 'id' + '-' + segmentId);
            currentSegment = [];
        }

        currentSegment.push(point);
        if (point.pointType === 2) {
            // End the current segment and create the line
            segmentId++;
            var routeGeoJSON = {
                'type': 'Feature',
                'geometry': {
                    'type': 'LineString',
                    'coordinates': currentSegment.map(function (p) {
                        return [p.longitude, p.latitude];
                    })
                }
            };
            createLine(routeGeoJSON.geometry, 'id' + '-' + segmentId);
            currentSegment = [];
        }
    });
    // Handle any remaining segment
    if (currentSegment.length > 0) {
        segmentId++;
        var routeGeoJSON = {
            'type': 'Feature',
            'geometry': {
                'type': 'LineString',
                'coordinates': currentSegment.map(function (p) {
                    return [p.longitude, p.latitude];
                })
            }
        };
        createLine(routeGeoJSON.geometry, id + '-' + segmentId);
    }
    map.fitBounds(bounds, { padding: 60 });
};
var removeAllLines = function () {
    lineIds.forEach(function (id) {
        if (map.getSource(id)) {
            map.removeLayer(id);
            map.removeSource(id);
        }
    });
    lineIds = []; // Clear the array after removing all lines
};
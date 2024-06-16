function showLoader() {
    document.getElementById('overlay').style.display = 'block';
    document.getElementById('loader').style.display = 'block';
}

function hideLoader() {
    document.getElementById('overlay').style.display = 'none';
    document.getElementById('loader').style.display = 'none';
}

// Hide the loader when the page is fully loaded
window.addEventListener('load', function () {
    hideLoader();
});

// Show the loader when the page is about to unload
window.addEventListener('beforeunload', function () {
    showLoader();
});

// Hide the loader when navigating with the back or forward button
window.addEventListener('pageshow', function (event) {
    // Ensure the loader is hidden if the page was retrieved from the cache
    if (event.persisted) {
        hideLoader();
    }
});

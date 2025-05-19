window.chartInterop = {
    initializeChart: function (canvasId, config) {
        const ctx = document.getElementById(canvasId).getContext('2d');
        return new Chart(ctx, config);
    }
};
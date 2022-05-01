var stars = [15, 7, 13, 7, 4, 11, 13, 9, 9, 12];
var frameworks = ['Action', 'Adventure', 'Comedy', 'Crime', 'Documentry', 'War', 'Drama', 'Fantasy', 'Horror', 'Romance'];
var ctx = document.getElementById('myChart');

var myChart = new Chart(ctx, {
    type: 'pie',
    data: {}
}
)

var myChart = new Chart(ctx, {
    type: 'pie',
    data: {
        labels: frameworks,
        datasets: [{
            label: 'Popular JavaScript Frameworks',
            data: stars
        }]
    },

});

var ctx = document.getElementById("myChart");

var stars = [15, 7, 13, 7, 4, 11, 13, 9, 9 , 12];
var frameworks = ['Action', 'Adventure', 'Comedy', 'Crime', 'Documentry', 'War', 'Drama', 'Fantasy', 'Horror', 'Romance'];

var myChart = new Chart(ctx, {
    type: "pie",
    data: {
        labels: frameworks,
        datasets: [
            {
                label: "Github Stars",
                data: stars,
                backgroundColor: [
                    "rgba(255, 99, 132, 0.8)",
                    "rgba(54, 162, 235, 0.8)",
                    "rgba(255, 206, 86, 0.8)",
                    "rgba(75, 192, 192, 0.8)",
                    "rgba(153, 102, 255, 0.8)",
                    "rgba(75, 132, 192, 0.8)",
                    "rgba(75, 102, 64, 0.8)",
                    "rgba(75, 12, 84, 0.8)",
                    "rgba(75, 75, 12, 0.8)",
                    "rgba(75, 145, 192, 0.8)",
                ]
            }
        ]
    }
});
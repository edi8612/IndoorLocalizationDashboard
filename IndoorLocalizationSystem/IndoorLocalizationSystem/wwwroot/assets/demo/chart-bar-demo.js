// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#292b2c';

// Fetch real data for students per course
fetch("/api/dashboard/students-per-course")
    .then(response => response.json())
    .then(data => {
        const labels = data.map(item => item.courseName);
        const values = data.map(item => item.studentCount);

        const ctx = document.getElementById("myBarChart");
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: labels,
                datasets: [{
                    label: "Students",
                    backgroundColor: "rgba(2,117,216,1)",
                    borderColor: "rgba(2,117,216,1)",
                    data: values,
                }],
            },
            options: {
                scales: {
                    xAxes: [{
                        gridLines: { display: false },
                        ticks: { maxTicksLimit: 6 }
                    }],
                    yAxes: [{
                        ticks: {
                            min: 0,
                            stepSize: 1
                        },
                        gridLines: { display: true }
                    }]
                },
                legend: { display: false }
            }
        });
    })
    .catch(error => console.error("Failed to load bar chart data:", error));

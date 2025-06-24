const ANCHOR_POSITIONS = [
    { x: 0.0, y: 0.0 },       // Anchor1
    { x: 3.0, y: 0.0 },       // Anchor2
    { x: 1.059, y: 3.545 }    // Anchor3
];

let positionChart;

window.addEventListener("DOMContentLoaded", async () => {
    const ctx = document.getElementById("classroomCanvas").getContext("2d");

    positionChart = new Chart(ctx, {
        type: "scatter",
        data: {
            datasets: [
                {
                    label: "Anchors",
                    data: ANCHOR_POSITIONS.map(a => ({ x: a.x, y: a.y })),
                    pointBackgroundColor: "black",
                    pointBorderColor: "black",
                    pointRadius: 10,
                    pointStyle: "triangle"
                },
                {
                    label: "Students",
                    data: [], // Will be loaded below
                    pointBackgroundColor: "red",
                    pointBorderColor: "darkred",
                    pointRadius: 8,
                    pointStyle: "circle"
                }
            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                x: {
                    title: { display: true, text: "X (m)" },
                    min: -1,
                    max: 5
                },
                y: {
                    title: { display: true, text: "Y (m)" },
                    min: -1,
                    max: 5
                }
            },
            plugins: {
                legend: { position: "top" },
                tooltip: {
                    callbacks: {
                        label: (context) => {
                            const point = context.raw;
                            return `(${point.x.toFixed(2)}, ${point.y.toFixed(2)})`;
                        }
                    }
                }
            }
        }
    });

    // Load initial student positions
    await updateStudentPositions();
});

async function updateStudentPositions() {
    try {
        const res = await fetch("/api/dashboard/student-positions");
        const students = await res.json();

        // Extract coordinates
        const studentPoints = students
            .filter(s => s.positionX != null && s.positionY != null)
            .map(s => ({ x: s.positionX, y: s.positionY }));

        positionChart.data.datasets[1].data = studentPoints;

        // Dynamically update chart bounds
        const allXs = ANCHOR_POSITIONS.map(a => a.x).concat(studentPoints.map(s => s.x));
        const allYs = ANCHOR_POSITIONS.map(a => a.y).concat(studentPoints.map(s => s.y));

        positionChart.options.scales.x.min = Math.min(...allXs, 0) - 0.5;
        positionChart.options.scales.x.max = Math.max(...allXs, 5) + 0.5;
        positionChart.options.scales.y.min = Math.min(...allYs, 0) - 0.5;
        positionChart.options.scales.y.max = Math.max(...allYs, 5) + 0.5;

        positionChart.update();
    } catch (err) {
        console.error("Failed to load student positions:", err);
    }
}

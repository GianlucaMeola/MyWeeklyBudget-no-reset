//INCOME  CHART
var ctxIn = document.getElementById("incomeChart").getContext('2d');

// income variables
var myIncomArr = [];
myIncomArr[0] = parseInt(document.getElementById("nptIncomeSalary").value);
myIncomArr[1] = parseInt(document.getElementById("nptIncomeLoans").value);
myIncomArr[2] = parseInt(document.getElementById("nptIncomeOthers").value);
var totalIncom = 0;

for (i = 0; i < myIncomArr.length; i++) {
    if (myIncomArr[i] > 0)
        totalIncom += myIncomArr[i];
}


    var incomeChart = new Chart(ctxIn, {
        type: 'pie',
        data: {
            labels: ["Weekly Salary £", "Weekly Credit £", "Others £"],
            datasets: [{
                data: [
                    myIncomArr[0],
                    myIncomArr[1],
                    myIncomArr[2]],
                backgroundColor: [
                    'rgba(50,205,50)',
                    'rgba(54, 162, 235)',
                    'rgba(255, 206, 86)'
                ],
                borderColor: [
                    'rgba(255,255,255, 0.5)',
                    'rgba(255, 255, 255, 0.5)',
                    'rgba(255, 255, 255, 0.5)'
                ],
                borderWidth: 2
            }]
        },
        options: {
            legend: {
                display: true
            },
            animation: {
                duration: 2000
            },
            plugins: {
                deferred: {
                    xOffset: 150,   // defer until 150px of the canvas width are inside the viewport
                    yOffset: '50%', // defer until 50% of the canvas height are inside the viewport
                    delay: 2000      // delay of 2000 ms after the canvas is considered inside the viewport
                }
            }
        }
    });

//EXPENSES CHART
var ctxEs = document.getElementById("exspensesChart").getContext('2d');

//expenses variables
var myEspenArr = [];
myEspenArr[0] = parseInt(document.getElementById("nptExpensesRent").value);
myEspenArr[1] = parseInt(document.getElementById("nptExpensesBills").value);
myEspenArr[2] = parseInt(document.getElementById("nptExpensesCar").value);
myEspenArr[3] = parseInt(document.getElementById("nptExpensesRepayDebts").value);
myEspenArr[4] = parseInt(document.getElementById("nptExpensesHobbies").value);
myEspenArr[5] = parseInt(document.getElementById("nptExpensesMiscellaneous").value);
var totalEs = 0;

for (i = 0; i < myEspenArr.length; i++) {
    if (myEspenArr[i] > 0)
        totalEs += myEspenArr[i];
}

    var exspensesChart = new Chart(ctxEs, {
        type: 'pie',
        data: {
            labels: ["Weekly Rent £", "Weekly Bills £", "Car Allowances £", "Repay Debts £", "Hobbies & Holidays £", "Miscellaneous £"],
            datasets: [{
                data: [
                    myEspenArr[0],
                    myEspenArr[1],
                    myEspenArr[2],
                    myEspenArr[3],
                    myEspenArr[4],
                    myEspenArr[5]],
                backgroundColor: [
                    'rgba(255, 99, 132)',
                    'rgba(54, 162, 235)',
                    'rgba(255, 206, 86)',
                    'rgba(75, 192, 192)',
                    'rgba(153, 102, 255)',
                    'rgba(255, 159, 64)'
                ],
                borderColor: [
                    'rgba(255,255,255, 0.5)',
                    'rgba(255, 255, 255, 0.5)',
                    'rgba(255, 255, 255, 0.5)',
                    'rgba(255, 255, 255, 0.5)',
                    'rgba(153, 255, 255, 0.5)',
                    'rgba(255, 255, 255, 0.5)'
                ],
                borderWidth: 2
            }]
        },
        options: {
            legend: {
                display: true
            },
            animation: {
                duration: 2000
            },
            plugins: {
                deferred: {
                    xOffset: 150,   // defer until 150px of the canvas width are inside the viewport
                    yOffset: '50%', // defer until 50% of the canvas height are inside the viewport
                    delay: 2000      // delay of 2000 ms after the canvas is considered inside the viewport
                }
            }
        }
    });

//TOTAL CALCULATION CHART
    var ctxTot = document.getElementById("totChart").getContext('2d');
    let saved = totalIncom - totalEs;
    let goal = document.getElementById("goal").value;
    
    var incomeChart = new Chart(ctxTot, {
        type: 'pie',
        data: {
            labels: ["Saved £", "Goal £"],
            datasets: [{
                data: [
                    saved,
                    goal],
                backgroundColor: [
                    'rgba(50,205,50)',
                    'rgba(255, 255, 0)'
                ],
                borderColor: [
                    'rgba(255,255,255, 0.5)',
                    'rgba(255, 255, 255, 0.5)'
                ],
                borderWidth: 2
            }]
        },
        options: {
            legend: {
                display: true
            },
            animation: {
                duration: 2000
            },
            plugins: {
                deferred: {
                    xOffset: 150,   // defer until 150px of the canvas width are inside the viewport
                    yOffset: '50%', // defer until 50% of the canvas height are inside the viewport
                    delay: 2000      // delay of 2000 ms after the canvas is considered inside the viewport
                }
            }
        }
    });
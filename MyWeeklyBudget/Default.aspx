<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyWeeklyBudget.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Weekly Budget</title>
    <!--BOOTSTRAP LIBRARY-->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <!--JQUERY LIBRARY-->
    <script src="Scripts/jquery-3.2.1.min.js"></script>
    <!--CHART API-->
    <script src="Scripts/Chart.min.js"></script>
    <script src="Scripts/chartjs-plugin-deferred.min.js"></script>
    <!--ANIMATIONS LIBRARY-->
    <link href="Content/animate.min.css" rel="stylesheet" />
    <!--MY SCRIPT--> 
    <script src="Content/myScript.js" async="async"></script>
    <!--MY STYLE-->
    <link href="Content/myStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

    <div id="mainDiv" class="container-fluid" runat="server">
        <div id="maindiv2" class="jumbotron mainDivG" runat="server">
           
             <!--===================================== MAIN DIV FOR TITLE =====================================--> 
            <div class="row">
                <div id="titolo" class="col-md-12 text-center animated fadeInDownBig" runat="server">
                    <h1 id="title">My Weekly Budget</h1>
                </div>
            </div>

<!--===================================== MAIN DIV FOR WELCOME =====================================--> 
            <div id="introDiv" runat="server" class="row animated zoomIn"> <!--Colletting the goal value -->
                <div id="introDiv1" class="col-md-12 text-center" runat="server">
                    <h2>How Much Do You Want To Save?</h2>
                    <!--Input goal money-->
                    <input id="nptMoneyGoal" type="number" runat="server" />
                    <br />
                    <span id="span1" runat="server" visible="false" class = "glyphicon glyphicon-exclamation-sign" style="color:red"></span>
                    <asp:Label ID="lblErrorGoalInput" runat="server"></asp:Label>
                    <br />
                    <asp:Button ID="btnGoal" CssClass="bottone animated fadeIn" runat="server" Text="Click Me" OnClick="btnGoal_Click" />
                </div>
            </div>

<!--===================================== DIV FOR CALCULATE BTN =====================================--> 
            <div class="row text-center">
                <div id="calculateDiv" runat="server">
                    <asp:Button ID="btnCalculate" CssClass="bottonef flashit" runat="server" Text="Final Calculation" OnClick="btnCalculate_Click" Visible="false" />
                </div>
            </div>
<!--===================================== MAIN DIV TO COLLECT THE INPUT =====================================-->        
            <div id="inputDiv" runat="server" class="animated slideInUp fadeInUp" visible="false"><!--second main div-->
                <div class="row">
                    <div class="carta col-md-4">
<!--===================================== DIV TO COLLECT THE EXPENSES =====================================--> 
                    <div id="exspesesDiv" runat="server" class="text-center animated fadeIn box-ombra" visible="false"><!--Exspeses Div-->
                        
                        <h2>EXPENSES</h2>
                        <label>Weekly Rent &#163</label><br />
                        <input id="nptExpensesRent" type="number" runat="server" /><br />
                        <label>Weekly Bills &#163</label><br />
                        <input id="nptExpensesBills" type="number" runat="server" /><br /><!--Bills Input-->
                        <label>Car Allowances &#163</label><br />
                        <input id="nptExpensesCar" type="number" runat="server" /><br />             
                        <label>Repay Debts &#163</label><br />
                        <input id="nptExpensesRepayDebts" type="number" runat="server" /><br />
                        <label>Hobbies & Holidays &#163</label><br />
                        <input id="nptExpensesHobbies" type="number" runat="server" /><br />
                        <label>Miscellaneous &#163</label><br />
                        <input id="nptExpensesMiscellaneous" type="number" runat="server" />
                        <br />
                        <span id="span2" runat="server" visible="false" class = "glyphicon glyphicon-exclamation-sign" style="color:red"></span>
                        <asp:Label ID="lblErrorEspenses" runat="server"></asp:Label>
                        <br />
                        <asp:Button ID="btnExpenses" CssClass="bottone" runat="server" Text="Click Me" OnClick="btnExpenses_Click" />
                    </div>
<!--===================================== DIV EXPENSES BACK CHART =====================================--> 
                    <div id="expensesBack" runat="server" class="text-center cardBack box-ombra" visible="false">
                        <div class="row text-center"><h2>Your Expenses</h2></div>
                        <div class="row">                            
                            <div class="chart-container" style="position:relative; max-height:100%; max-width:100%;">
                                    <canvas id="exspensesChart" width="100" height="100"></canvas>
                            </div>                           
                        </div>
                        <div class="row text-center">
                            <asp:Label ID="labelTotalEs" runat="server" Text="" CssClass="bottone"></asp:Label>
                        </div>
                    </div>
                    </div>
<!--===================================== DIV TO COLLECT THE INCOME =====================================--> 
                    <div class="carta col-md-4">
                    <div id="incomeDiv" runat="server" class="text-center animated fadeIn box-ombra" visible="false"><!--Income Div-->
                        <h2>REVENUE</h2>
                        <label>Weekly Salary &#163</label><br />
                        <input id="nptIncomeSalary" type="number" runat="server" /><br /><!--Salary Input-->
                        <label>Weekly Credit &#163</label><br />
                        <input id="nptIncomeLoans" type="number" runat="server" /><br />
                        <label>Others &#163</label><br />
                        <input id="nptIncomeOthers" type="number" runat="server" /><br />
                        <br />
                        <span id="span3" runat="server" visible="false" class = "glyphicon glyphicon-exclamation-sign" style="color:red"></span>
                        <asp:Label ID="lblErrorIncome" runat="server"></asp:Label>
                        <br />
                        <asp:Button ID="btnIncome" CssClass="bottone" runat="server" Text="Click Me" OnClick="btnIncome_Click" />
                    </div>
<!--===================================== DIV INCOME BACK CHART =====================================--> 
                    <div id="incomeBack" runat="server" class="text-center cardBack box-ombra" visible="false">
                        <div class="row text-center"><h2>Your Income</h2></div>
                        <div class="row">                            
                            <div class="chart-container" style="position:relative; max-height:100%; max-width:100%;">
                                    <canvas id="incomeChart" width="100" height="100"></canvas>
                            </div>                           
                        </div>
                        <div class="row text-center">
                            <asp:Label ID="labelTotalIncome" runat="server" Text="" CssClass="bottone"></asp:Label>
                        </div>
                    </div>
                    </div>

<!--===================================== DIV FINAL CHAR =====================================--> 
                    <div class="carta col-md-4">
                    <div id="finalChar" runat="server" class="text-center animated flipInY cardBack box-ombra" style="padding-top:1em;" visible="false">
                     
                        <div class="row text-center"><h2>Your Result</h2></div>
                        <div class="row">   
                            <input id="goal" type="number" runat="server" style="display: none;"/>                       
                            <div class="chart-container" style="position:relative; max-height:100%; max-width:100%;">
                                    <canvas id="totChart" width="100" height="100"></canvas>
                            </div>                           
                        </div>
                        <div class="row text-center">
                            <asp:Label ID="labelTotal" runat="server" Text="" CssClass="bottone"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="labelTotal1" runat="server" Text="" CssClass="bottone"></asp:Label>
                        </div>

                    </div>
                    <div id="finalBack" runat="server" class="text-center cardBack" visible="false">BACK </div>
                    </div>


                </div>
                </div><!-- end of panel-->
        </div>
    </div>
    </form>
</body>
</html>

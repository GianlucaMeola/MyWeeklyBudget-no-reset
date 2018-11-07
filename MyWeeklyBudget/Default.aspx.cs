using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeeklyBudget
{
    public partial class Default : System.Web.UI.Page
    {
        static decimal varGoalMoney=0;
        //INCOME VAR
        static decimal varSalary=0;
        static decimal varLoans = 0;
        static decimal varOthers = 0;
        static decimal varTotalIncome = 0;

        //Expenses Var
        static decimal varRent;
        static decimal varBills = 0;
        static decimal varCar = 0;    
        static decimal varRepayDebts = 0;
        static decimal varHobbies = 0;
        static decimal varMiscellaneous = 0;
        static decimal varTotalExpense = 0;

        //FINAL SECTION VAR
        static decimal varSavedMoney = 0;
        static decimal varWeeksNeeded = 0;
        static decimal varDaysneeded = 0;
        static string weeks="";
        static string days = "";

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
//================================== FIST DIV BUTTON ACTION(FISTPAGE) AND COLLETTING GOAL MONEY VALUE ==================================
        protected void btnGoal_Click(object sender, EventArgs e) //button to collect the fist input for the goa value
        {
            bool check = true;//cheker to exit
            titolo.Attributes["class"] = "col-md-12 text-center";
            introDiv.Attributes["class"] = "row";
            btnGoal.CssClass = "bottone";

            decimal x = 0;
            decimal.TryParse(nptMoneyGoal.Value, out  x);

            if (x <= 0)
            {
                span1.Visible = true;
                lblErrorGoalInput.Text = "Please insert the correct value!";            
            }
            else
            {
                lblErrorGoalInput.Text = "";
                varGoalMoney = x;
                check = false;
                inputDiv.Visible = true;
                incomeDiv.Visible = true;
                goal.Value = (""+varGoalMoney);
            }

            if ( check == false)
            {
                maindiv2.Attributes["class"] = "jumbotron classMainFB";
                introDiv1.Attributes["class"] = " col-md-12 text-center animated zoomOut";
                introDiv.Attributes["class"] = "row nascondi nascosto";
                span1.Visible = false;
            }
        }

//================================== RESET BUTTON ==================================
        protected void restartBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
        }
        //================================== SECOND DIV BUTTON ACTION(FIST SUB DIV), COLLETTING INCOME VALUE ==================================
        protected void btnIncome_Click(object sender, EventArgs e)
        {
            //pre-set old animatios
            maindiv2.Attributes["class"] = "jumbotron classMainFB2";
            

            //section animatio to cut-off
            inputDiv.Attributes["class"] = "";
            incomeDiv.Attributes["class"] = "text-center box-ombra";
            introDiv1.Visible = false;

            bool check = true;//cheker to exit

            decimal[] myArray = { 0, 0, 0};
            bool tester=true;

            decimal.TryParse(nptIncomeSalary.Value,out myArray[0]);
            decimal.TryParse(nptIncomeLoans.Value,out myArray[1]);
            decimal.TryParse(nptIncomeOthers.Value,out myArray[2]);
            decimal totCheck = 0;

            foreach (decimal i in myArray)
            {
                totCheck += i;

                if (i < 0){
                    tester=false;
                    break;
                }
                
            }
            if (totCheck == 0)
            {
                tester = false;
            }

            if (tester == false)
            {
                span3.Visible = true;
                lblErrorIncome.Text = "Please insert the correct value!";
            }
            else
            {
                labelTotalIncome.Text = "Total Income of the Week: £" + totCheck;
                lblErrorIncome.Text = "";
                varSalary = myArray[0]; varLoans = myArray[1]; varOthers = myArray[2];
                varTotalIncome = (varSalary + varLoans + varOthers);
                btnIncome.Visible = false;
                exspesesDiv.Visible = true;
                check = false;
            }

            if (check == false)
            {
                span3.Visible = false;
                incomeBack.Visible = true;
                incomeDiv.Attributes["class"] = "text-center rotate box-ombra";
                incomeBack.Attributes["class"] = "text-center cardBack rotate2 box-ombra";
            }  
        }

        //================================== SECOND DIV BUTTON ACTION(SECOND SUB DIV), COLLETTING EXPENSES VALUE ==================================
        protected void btnExpenses_Click(object sender, EventArgs e)
        {
            //stetting-up last step vanish
            incomeDiv.Attributes["class"] = "text-center rotato";
            introDiv.Visible = false;
            incomeBack.Attributes["class"] = "text-center cardBack box-ombra";

            decimal[] myArray = { 0, 0, 0, 0, 0, 0 };
            bool tester = true;
            bool check = true;

            decimal.TryParse(nptExpensesRent.Value, out myArray[0]);
            decimal.TryParse(nptExpensesBills.Value, out myArray[1] );
            decimal.TryParse(nptExpensesCar.Value, out myArray[2]);
            decimal.TryParse(nptExpensesRepayDebts.Value, out myArray[3]);
            decimal.TryParse(nptExpensesHobbies.Value, out myArray[4]);
            decimal.TryParse(nptExpensesMiscellaneous.Value, out myArray[5]);
            decimal totCheck = 0;

            foreach (decimal i in myArray)
            {
                totCheck += i;
                if (i < 0)
                {
                    exspesesDiv.Attributes["class"] = "text-center";
                    tester = false;
                    break;
                }
            }
            if (totCheck == 0)
            {
                exspesesDiv.Attributes["class"] = "text-center";
                tester = false;
            }

            if (tester == false)
            {
                span2.Visible = true;
                lblErrorEspenses.Text = "Please insert the correct value!";
            }
            else
            {
                labelTotalEs.Text =  "Total Spending of the Week: £"+totCheck;
                lblErrorEspenses.Text = "";
                varRent = myArray[0]; varBills = myArray[1]; varCar = myArray[2]; varRepayDebts = myArray[3]; varHobbies = myArray[4]; varMiscellaneous = myArray[5];
                varTotalExpense = (varRent + varBills + varCar + varRepayDebts + varHobbies + varMiscellaneous);
                btnCalculate.Visible = true;
                check = false;
            }
            if (check == false)
            {
                span2.Visible = false;
                expensesBack.Visible = true;
                exspesesDiv.Attributes["class"] = "text-center rotate box-ombra";
                expensesBack.Attributes["class"] = "text-center cardBack rotate2 box-ombra";
                calculateDiv.Attributes["class"] = "deploy"; 
            }
        }

//================================== THIRTH(FINAL) DIV BUTTON ACTION, DISPLAY SAVED MONEY AND CHART ==================================
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            //previous step setting visibility
            exspesesDiv.Attributes["class"] = "text-center rotato box-ombra";
            expensesBack.Attributes["class"] = "text-center cardBack box-ombra";

            finalChar.Visible = true;

            varSavedMoney = (varTotalIncome-varTotalExpense);

            calculateDiv.Attributes["class"] = "nascondi2 nascosto2";

            if (varSavedMoney >= varGoalMoney)
            {
                labelTotal.Text = ("You will save £" + varSavedMoney + " this week!!");
                labelTotal1.Text = ("You Just Reach your Goal!!");
            }
            else if (varSavedMoney == 0)
            {
                labelTotal.Text = ("You will spend the same money that you will earn!!");
                labelTotal1.Text = ("You will never Reach your Goal!");
            }
            else if (varSavedMoney < 0)
            {
                labelTotal.Text = ("You spendmore then earn!!");
                labelTotal1.Text = ("You will never Reach your Goal!");
            }
            else //A LIST OF IF TO CHOOSE IF USE DAYS O WEEKS FORMAT, I CAN ADD MONTHS AND YEARS TOO
            {
                varWeeksNeeded = ((varGoalMoney / varSavedMoney));
                labelTotal.Text = ("You will save £" + varSavedMoney + " this week!!");
                if (Math.Round(varWeeksNeeded) < 2) {
                    varDaysneeded = (varWeeksNeeded * 7);
                    days = Convert.ToString(Math.Round(varDaysneeded));
                    if (Math.Round(varDaysneeded) < 2)
                    {
                        labelTotal1.Text = ("You will need " + days + " day to Reach your Goal!");
                    }
                    else
                    {
                        labelTotal1.Text = ("You will need 1/2 weeks to Reach your Goal!");
                    }
                }
                else
                {
                    weeks = Convert.ToString(Math.Round(varWeeksNeeded));
                    labelTotal1.Text = ("You will need " + weeks + " weeks to Reach your Goal!");
                }
            }
        }
    }
}
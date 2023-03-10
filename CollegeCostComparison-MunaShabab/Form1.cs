using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeCostComparison_MunaShabab
{
    public partial class Form1 : Form
    {

        //Author: Muna Shabab
        //ID:624191
        //Date:9-22-19
        //Goal: to compare costs for two colleges


        //declare variables
        //private string college1Name;
        //private string college2Name;
        //private string state1;
        //private string state2;
        private int tripEst1 = 0;
        private int tripEst2 = 0;
        private int distance1 = 0;
        private int distance2 = 0;
        private decimal appFee1 = 0;
        private decimal appFee2 = 0;
        private decimal tuition1 = 0;
        private decimal tuition2 = 0;
        private decimal roomBoard1 = 0;
        private decimal roomBoard2 = 0;
        private decimal fuelCost1 = 0;
        private decimal fuelCost2 = 0;
        private decimal totalCost1 = 0;
        private decimal totalCost2 = 0;
        private decimal FuelCostPerGallon = 2.5m;
        private decimal MilesPerGallon = 25;

        public Form1()
        {
            InitializeComponent();
        }

        //method to calculate total fuel cost
         private decimal MunaShababMETHODCalcOneYearFuelCost(int tripNum, int distance, decimal MyFuelCostPerGallon,
            decimal MyMilesPerGallon)
        {
            decimal local_OneYearFuelCostDec = ((2 * tripNum * distance) / MilesPerGallon) * FuelCostPerGallon;
            return local_OneYearFuelCostDec;
        }

        private void CalcTotalButton_Click(object sender, EventArgs e)
        {
            

            //get the values for the variables from the textBoxes and validate them
            if(!(int.TryParse(tripEst1TextBox.Text, out tripEst1))||(tripEst1<=0))
            {
                MessageBox.Show("Please enter a valid number for trips ");
                tripEst1TextBox.Focus();
            }
            else if(!(int.TryParse(tripEst2TextBox.Text,out tripEst2 ))||(tripEst2<=0))
            {
                MessageBox.Show("Please enter a valid number for trips ");
                tripEst2TextBox.Focus();
            }
            else if(!(int.TryParse(dist1TextBox.Text,out distance1))||distance1<=0)
            {
                MessageBox.Show("Please enter a valid number for distance ");
                dist1TextBox.Focus();
            }
            else if(!(int.TryParse(dist2TextBox.Text,out distance2))||(distance2<=0))
            {
                MessageBox.Show("Please enter a valid number for distance ");
                dist2TextBox.Focus();
            }
            else if(!(decimal.TryParse(appFee1TextBox.Text,out appFee1))||(appFee1<=0))
            {
                MessageBox.Show("Please enter a valid number for application fee ");
                appFee1TextBox.Focus();
            }
            else if(!(decimal.TryParse(appFee2TextBox.Text,out appFee2))||(appFee2<=0))
            {
                MessageBox.Show("Please enter a valid number for application fee ");
                appFee2TextBox.Focus();
            }
            else if(!(decimal.TryParse(annualTuition1TextBox.Text,out tuition1))||(tuition1<=0))
            {
                MessageBox.Show("Please enter a valid number for tuition");
                annualTuition1TextBox.Focus();
            }
            else if(!(decimal.TryParse(annualTuition2TextBox.Text,out tuition2))||(tuition2<=0))
            {
                MessageBox.Show("Please enter a valid number for tuition");
                annualTuition2TextBox.Focus();
            }
            else if(!(decimal.TryParse(roomBoard1TextBox.Text, out roomBoard1))||(roomBoard1<=0))
            {
                MessageBox.Show("Please enter a valid number for room and board");
                roomBoard1TextBox.Focus();
            }
            else if (!(decimal.TryParse(roomBoard2TextBox.Text, out roomBoard2))||(roomBoard2<=0))
            {
                MessageBox.Show("Please enter a valid number for room and board");
                roomBoard2TextBox.Focus();
            }
             // if all the info are valid then do the calculations
             else

            {
                //caculate cost of fuel using the method
                fuelCost1 = MunaShababMETHODCalcOneYearFuelCost(tripEst1, distance1, FuelCostPerGallon, MilesPerGallon);
                fuelCost2 = MunaShababMETHODCalcOneYearFuelCost(tripEst2, distance2, FuelCostPerGallon, MilesPerGallon);

                //display fuel cost for each college
                calcTotalFuel1Lable.Text = fuelCost1.ToString("c");
                calcTotalFuel2Lable.Text = fuelCost2.ToString("c");

                //calculate total cost for attending college
                totalCost1 = appFee1 + 4 * (fuelCost1 + tuition1 + roomBoard1);
                totalCost2 = appFee2 + 4 * (fuelCost2 + tuition2 + roomBoard2);


                //change the backColor for the lable with the higher cost
                if (totalCost1 > totalCost2)
                {
                    totalCost1Lable.BackColor = Color.Red;
                    totalCost2Lable.BackColor =SystemColors.Control;
                }
                else
                {
                    if (totalCost1 == totalCost2)
                    {
                        totalCost2Lable.BackColor = SystemColors.Control;
                        totalCost1Lable.BackColor = SystemColors.Control;
                    }
                    else
                    {
                        totalCost2Lable.BackColor = Color.Red;
                        totalCost1Lable.BackColor = SystemColors.Control;
                    }
                }

               

                //display the total costs
                totalCost1Lable.Text = totalCost1.ToString("c");
                totalCost2Lable.Text = totalCost2.ToString("c");

            }

        }
    }
}

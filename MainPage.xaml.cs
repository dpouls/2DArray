using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace _2DArr
{
    public partial class MainPage : ContentPage
    {
        //variable for max # of rows
        const int MAX_ROW = 5;
        //variable for max # of columns
        const int MAX_COLUMN = 3;
        //declare our variable that contains all the seat prices by doing a 2d array
        decimal[,] prices =
        {
            { 450m, 450m,450m,450m},
            { 425m, 425m,425m,425m},
            { 400m, 400m,400m,400m},
            { 375m, 375m,375m,375m},
            { 375m, 375m,375m,375m},
            { 350m, 350m,350m,350m}
        };
        public MainPage()
        {
            InitializeComponent();       
        }
        /// <summary>
        /// displays the seat price if input validation is accepted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDisplayPrice_Clicked(object sender, EventArgs e)
        {
            //define variables for row and column
            int row = -1, column = -1;
            //we check to make sure integers were input
            if (GetRowValue(ref row) && GetColumnValue(ref column))
            {
                //if they were validated then we display the designated seat pricec by calling the display results method.
               DisplayResults(row, column);
            };
            

            
        }
        /// <summary>
        /// displays seat price
        /// </summary>
        private void DisplayResults(int row, int column)
        {
            //change LblResults text to the seat price of the updated column/row coordinate
            LblResults.Text = $"Seat Price: {prices[row, column].ToString("c")}";
        }
        /// <summary>
        /// makes sure the column value is input correctly
        /// </summary>
        private bool GetColumnValue(ref int column)
        {
            //if the input is an integer and greater than zero and less than the MAX_COLUMN variable then we return true. 
            if (int.TryParse(EntryColumn.Text, out column) && column >= 0 && column <= MAX_COLUMN) return true;  
            //this code only runs if the above line is false, alerts the user of the input error. 
            DisplayAlert("Invalid Input", "Please enter an integer for the column.", "Close");
            //returns false
            return false;
           
        }
        /// <summary>
        /// makes sure the row value is input correctly
        /// </summary>
        /// <returns></returns>
        private bool GetRowValue(ref int row)
        {
            //if the input is an integer and greater than zero and less than the MAX_ROW variable then we return true. 
            if (int.TryParse(EntryRow.Text, out row) && row >= 0 && row <= MAX_ROW) return true;
            //this code only runs if the above line is false, alerts the user of the input error. 
            DisplayAlert("Invalid Input", "Please enter an integer for the row.", "Close");
            // returns false;
            return false;        
        }
        /// <summary>
        /// sums up all the seat prices and alerts the result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMaxRevenue_Clicked(object sender, EventArgs e)
        {
            //assign our variable that will be our running total
            decimal total = 0;
            //for loop that loops through each row.
            for(int i = 0; i<= MAX_ROW; i++)
            {
                //for loop that loops through each column in the current row in the above for loop
                for (int j = 0; j < MAX_COLUMN; j++)
                {
                    //adds the value of the coordinate of i and j to the total variable
                    total += prices[i, j];
                }
            };
            //alerts the user of the total revenue.
            DisplayAlert("Total Revenue", $"Total revenue is: {total.ToString("c")}", "Close");
        }
    }
}

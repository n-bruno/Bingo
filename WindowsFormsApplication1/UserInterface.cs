/*
 * Coder: Nich Bruno
 * Name: Bingo Card Fun
 * Description: An emulation of a bingo game
 * 
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bingo
{
    public partial class UserInterface : Form
    {
        private const int RNGRange = 15;        //range of number per bingo column
        private const int BINGOCARDSIZE = 5;    //a constant to delcare a card's size

        private CalledNumbersList used = new CalledNumbersList(RNGRange * BINGOCARDSIZE);
        //stores if a number has been called

        private Button[,] newButton;            //stores all the bingo card's buttons


        //a class that stores values to calculate if the player has bingo
        private InternalCardClass2DimArray record = new InternalCardClass2DimArray(BINGOCARDSIZE);

        public UserInterface()
        {
            InitializeComponent();
        }

        //A class to generate the next random number
        private void getNextNumber()
        {
            RNGType rand = new RNGType();
            textBox_number_called.Text = Convert.ToString(rand.getNextUniqueRandomValue(1,
                                                BINGOCARDSIZE * RNGRange, used));
        }
        /*
         * Executes the program and confirms a name has been entered
         */
        private void Button_go_Click(object sender, EventArgs e)
        {
            if (textBox_enter_name.Text != "")
            {        //check if the name is not empty 
                CreateCard();                           //creates the bingo card
                button_dont_have.Visible = true;        //make the don't have button visible
                textBox_number_called.Visible = true;   //number called field visible
                button_go.Enabled = false;              //disable go button
                textBox_enter_name.Enabled = false;     //disable name enter text
                label_your_name.Enabled = false;        //disable name textfield
                getNextNumber();                        //get a RNG-ed number
            }
            else
                MessageBox.Show("You haven't entered a name.", "Error");
        }

        private void Button_exit_Click(object sender, EventArgs e)
        { //if the x is pressed, terminate the program
            MessageBox.Show("Now exiting the program. Press OK to continue.", "Message", MessageBoxButtons.OK);
            Application.Exit();
        }
        /*
         *  Professor Friedman's code that creates the GUI of the card
         *  Speaks for itself, no?
         */
        private void CreateCard()
        {
            int numOfPossibleNumbers = BINGOCARDSIZE * RNGRange;

            // Total width and height of a card cell
            int cardCellWidth = numOfPossibleNumbers;
            int cardCellHeight = numOfPossibleNumbers;
            int barWidth = 6;  // Width or thickness of horizontal and vertical bars
            int xcardUpperLeft = numOfPossibleNumbers;
            int ycardUpperLeft = numOfPossibleNumbers;
            int padding = 10;

            //rng object for this method
            CalledNumbersList ButtonRNGused = new CalledNumbersList(RNGRange * BINGOCARDSIZE);

            int topMargin = 175;

            // An array of button references must be declared and created as a global
            //    (class) attribute elsewhere in the main form code.
            // Among other things, in this code we will create each Bingo card button as 
            //    we need it and assign the reference to this button to the appropriate
            //    button reference variable in the array
            Size size = new Size(numOfPossibleNumbers, numOfPossibleNumbers);
            Point loc = new Point(0, 0);

            int x, y;
            newButton = new Button[BINGOCARDSIZE + 1, BINGOCARDSIZE + 1];

            // Draw Column indexes
            y = 0;

            x = xcardUpperLeft;
            y = ycardUpperLeft;

            RNGType RNGObj = new RNGType();
            char[] bingoLetters = new char[BINGOCARDSIZE + 1];

            bingoLetters[1] = 'B'; //bingo letters
            bingoLetters[2] = 'I';
            bingoLetters[3] = 'N';
            bingoLetters[4] = 'G';
            bingoLetters[5] = 'O';

            for (int xx = 1; xx <= BINGOCARDSIZE; xx++)
            {
                loc.Y = topMargin + xx * (size.Height + padding);
                int extraLeftPadding = 50;
                for (int yy = 1; yy <= BINGOCARDSIZE; yy++)
                {
                    newButton[xx, yy] = new Button();
                    newButton[xx, yy].Location = new Point(extraLeftPadding + (yy - 1) * (size.Width + padding) + barWidth, loc.Y);
                    newButton[xx, yy].Size = size;
                    newButton[xx, yy].Font = new Font("Arial", 24, FontStyle.Bold);

                    if (xx == BINGOCARDSIZE / 2 + 1 && yy == BINGOCARDSIZE / 2 + 1)
                    {
                        newButton[xx, yy].Font = new Font("Arial", 10, FontStyle.Bold);
                        newButton[xx, yy].Text = "Free \n Space";
                        newButton[xx, yy].BackColor = System.Drawing.Color.Orange;
                        newButton[xx, yy].Enabled = false;
                    }
                    else
                    {
                        newButton[xx, yy].Font = new Font("Arial", 24, FontStyle.Bold);
                        newButton[xx, yy].Text = RNGObj.getRandomValue(bingoLetters[yy], ButtonRNGused).ToString();
                        newButton[xx, yy].Enabled = true;
                    }

                    newButton[xx, yy].Name = "btn" + xx.ToString() + yy.ToString();

                    // Associates the same event handler with each of the buttons generated
                    newButton[xx, yy].Click += new EventHandler(Button_Click);

                    // Add button to the form
                    this.Controls.Add(newButton[xx, yy]);

                    // Draw vertical delimiter                 
                    x += cardCellWidth + padding;
                } // end for col
                // One row now complete

                // Draw bottom square delimiter if square complete
                x = xcardUpperLeft - 20;
                y = y + cardCellHeight + padding;

                Label blabel = new Label();
                blabel.Location = new Point(extraLeftPadding + padding, 200);
                blabel.Font = new Font("Arial", 26);
                //blabel.BackColor = System.Drawing.Color.Black;
                blabel.Text = "B        I       N      G      O";
                blabel.Size = new Size(1000, 35);

                this.Controls.Add(blabel);
            } // end for row
        } // end createBoard

        /*
         * An event for clicking the bingo numbers
         */
        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //checks if called number matches the bingo card's numbers
            //Change "!=" to "==" for easy debugging
            if (int.Parse(textBox_number_called.Text) != int.Parse(btn.Text)) //not the right number
                MessageBox.Show("This isn't the number called!", "Message", MessageBoxButtons.OK);
            else
            { //there's a match

                /* grab the bingo button's coordinates from its name.
                 * in the create card method we made it so the card's internal name
                 * contains how we store information about it internally for being marked.
                 */

                int xcoord = Convert.ToInt16(btn.Name.Substring(3, 1));
                int ycoord = Convert.ToInt16(btn.Name.Substring(4, 1));

                //record the bingo buttons coordinate as called in the record variable
                record.RecordCalledNumber(xcoord, ycoord);

                btn.Enabled = false;    //disable the number you marked that matches the called number

                //this method returns how many bingos the player has
                //and stores how many in the int "win"
                int win = record.IsWinner();
                if (win > 0)
                { //at least one bingo?
                    //You win!
                    button_dont_have.Enabled = false;

                    if (win == 1) //use singular if only 1 bingo 
                        MessageBox.Show("Won with one bingo\nStarting a new" +
                        " game", "You Win!", MessageBoxButtons.OK);
                    else //plural if multiple bingos
                        MessageBox.Show("Won with " + win + " bingos\nStarting a new" +
                        " game", "You Win!", MessageBoxButtons.OK);
                    //set up things for a new game

                    for (int row = 1; row <= BINGOCARDSIZE; row++)
                    { //remove all buttons
                        for (int col = 1; col <= BINGOCARDSIZE; col++)
                        {
                            this.Controls.Remove(newButton[row, col]);
                        }
                    }

                    used = new CalledNumbersList(RNGRange * BINGOCARDSIZE);
                    record = new InternalCardClass2DimArray(BINGOCARDSIZE);

                    CreateCard();                           //creates new bingo card
                    button_dont_have.Enabled = true;
                }

                getNextNumber();            //call another number
                button_dont_have.Focus();   //focus on the don't have button
            }
        }

        /*
         * Method for when you click the "don't have" button"
         */
        private void Button_dont_have_Click(object sender, EventArgs e)
        {
            bool isPlayerWrong = false;

            /*
             * Check every button in the newButton array to confirm the player 
             * actually doesn't have the number. Store the results in "isPlayerWrong"
             */
            for (int i = 1; i <= BINGOCARDSIZE && !isPlayerWrong; i++)
            {
                for (int j = 1; j <= BINGOCARDSIZE && !isPlayerWrong; j++)
                {
                    if (newButton[i, j].Text.Equals(textBox_number_called.Text))
                    {
                        isPlayerWrong = true; //set this variable to false to exit the loops
                    }
                }
            }
            //was the player wrong about not having the called number?
            if (!isPlayerWrong)
                getNextNumber(); //they were right!
            else
                MessageBox.Show("Check Again", "Message", MessageBoxButtons.OK); //they were wrong
        }

        private void UserInterface_Load(object sender, EventArgs e)
        {
            this.CenterToScreen(); //put window in center of screen
        }
    }
}

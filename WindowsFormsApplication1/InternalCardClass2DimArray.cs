/* 
 * Programmer:  Nich Bruno
 * Class:       InternalCardClass2DimArray
 * Description: Stores data for calculating bingo and storing 
 *              what buttons have been marked as used.
 */

namespace Bingo
{
    class InternalCardClass2DimArray
    {
        private int cardSize;

        private bool[,] cardArray; //stores which buttons have been used
        private const int
            ZERO = 0,
            NUMBERSPERCOLUMN = 15;

        private int[]
            rowCount,
            colCount;

        private int
            diagForwardsCount = 1, //to account for the freespace
            diagBackwardsCount = 1; //to account for the freespace

        public InternalCardClass2DimArray(int thisCardSize)
        {
            cardSize = thisCardSize; //5
            cardArray = new bool[cardSize + 1, cardSize + 1]; //create an array of 5x5

            rowCount = new int[cardSize + 1]; //the '0' index in dex is never used
            colCount = new int[cardSize + 1]; //the '0' index in dex is never used

            rowCount[cardSize / 2 + 1] = 1; //to account for the freespace
            colCount[cardSize / 2 + 1] = 1; //to account for the freespace
        }

        public void RecordCalledNumber(int x, int y)
        {
            cardArray[x, y] = true; //marked this coordinate as called

            rowCount[x]++;
            colCount[y]++;

            /* I made a diagram that led me to create
             * a formula to check for forwards diagnal spaces
             * 
             * cardsize = 5
             * 
             * o o o o x
             * o o o x o
             * o o x o o    BINGO
             * o x o o o
             * x o o o o
             * 
             * (1, 5) -->    1 + 5 = 6 //all add of to the card's size - 1
             * (2, 4) -->    2 + 3 = 6
             * (3, 3) -->    "
             * (4, 2) -->    "
             * (5, 1) -->    "
             */

            //check for a forward diagnal --> /
            if (x + y - 1 == cardSize)
                diagForwardsCount++;

            //check for a backwards diagnal --> \
            //backwards diagnal is when row and colum coordinates are the same
            if (x == y)
                diagBackwardsCount++;
        }

        //Check if player has bingo(s) and return the amount ... if any
        public int IsWinner()
        {
            int bingoNo = 0; //store amount of bingos had
            //if any of the counters are the cardsize's values, that's a bingo

            if (diagBackwardsCount >= cardSize)
                bingoNo++;
            if (diagForwardsCount >= cardSize)
                bingoNo++;

            //traverse through row and col arrays for their sizes
            for (int i = 1; i <= cardSize; i++)
            {
                if (rowCount[i] >= cardSize)
                    bingoNo++;
                if (colCount[i] >= cardSize)
                    bingoNo++;
            }
            return bingoNo;
        }
    }
}
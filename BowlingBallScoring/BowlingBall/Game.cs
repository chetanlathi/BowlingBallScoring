// Author : Chetan Lathi.   
// Created BowlingBall Game for Tavisca
// Created on : 20 September 2021

// Solution Details :
//1. The game consists of 10 frames,In each frame the player has two opportunities to knock
//   down 10 pins.
//2. The GetScore method gives total socre which is calculated by the total number of pins knocked down,
//   plus bonuses for strikes and spares.
//3. A spare is when the player knocks down all 10 pins in two tries. The bonus for that frame is the number of pins
//   knocked down by the next roll.
//4. A strike is when the player knocks down all 10 pins on his first try. The bonus for that frame is the value of the
//   next two balls rolled.
//5. Assumtions : The solution should assume valid inputs at all times and does not need to include unnecessary validations
//   trying to prevent bad input data.

namespace BowlingBall
{
    public class Game
    {
        private int[] _rolls = new int[21];
        private int[] _frame = new int[10];
        private int _currentRoll = 0;

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }     

        public int GetScore()
        {
            int score = 0;
            int index = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (VerifyStrike(index))
                {
                    score += CalculateStrikeScore(index);
                    index++;
                }
                else if (VerifySpare(index))
                {
                    score += CalculateSpareScore(index);
                    index += 2;
                }
                else
                {
                    score += CalculateStandardScore(index);
                    index += 2;
                }
            }
            return score;
        }

        private bool VerifyStrike(int frameIndex)
        {
            return _rolls[frameIndex] == 10;
        }

        private bool VerifySpare(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
        }

        private int CalculateStrikeScore(int index)
        {
            return 10 + _rolls[index + 1] + _rolls[index + 2];           
        }

        private int CalculateSpareScore(int index)
        {
            return 10 + _rolls[index + 2];
        }

        private int CalculateStandardScore(int index)
        {
            return _rolls[index] + _rolls[index + 1];
        }
    }
}

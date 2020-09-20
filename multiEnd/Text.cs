using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace multiEnd
{
    public static class Text
    {
        public static int currentQuestion = 0;
        public static int finalResults = 0;

        public static void NextQuestion()
        {
            if (currentQuestion < questionArray.Length)
                currentQuestion++;
        }

        public static string[] questionArray =
        {
            "This is a question 1",
            "This is a question 2",
            "This is a question 3",
            "This is a question 4",
            "This is a question 5",
            "This is a question 6",
            "This is a question 7",
            "This is a question 8",
            "This is a question 9",
            "This is a question 10",
            "This is a question 11",
            "This is a question 12",
            "This is a question 13",
            "This is a question 14",
            "This is a question 15",
            "This is a question 16",
            "This is a question 17",
            "This is a question 18"
        };

        public static string[] resultsArray =
        {
            "This is result 1, A > B && A > C",
            "This is result 2, B > A && B > C",
            "This is result 3, C > A && C > B",
            "This is result 4, A == B && A > C",
            "This is result 5, B == C && B > A",
            "This is result 6, C == A && C > B",
            "This is result 7, A == B && A == C",
            "This is result 8, A == 0 && B != 0 && C != 0",
            "This is result 9, B == 0 && A != 0 && C != 0",
            "This is result 10, C == 0 && A != 0 && B != 0",
            "This is result 11, A > questionArray.Length - 3",
            "This is result 12, B > questionArray.Length - 3",
            "This is result 13, C > questionArray.Length - 3"
        };

        public static void Results(int A, int B, int C)
        {
            if (A > questionArray.Length - 3)
                finalResults = 10;
            else if (A > B && A > C)
                finalResults = 0;
            if (B > questionArray.Length - 3)
                finalResults = 11;
            else if (B > A && B > C)
                finalResults = 1;
            if (C > questionArray.Length - 3)
                finalResults = 12;
            else if (C > A && C > B)
                finalResults = 2;

            if (A == B && A > C)
                finalResults = 3;
            if (B == C && B > A)
                finalResults = 4;
            if (C == A && C > B)
                finalResults = 5;

            if (A == B && A == C)
                finalResults = 6;

            if (A == 0 && B != 0 && C != 0)
                finalResults = 7;
            if (B == 0 && A != 0 && C != 0)
                finalResults = 8;
            if (C == 0 && A != 0 && B != 0)
                finalResults = 9;
        }
    }
}

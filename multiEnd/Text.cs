using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace multiEnd
{
    public static class Text
    {
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
        };

        public static int currentQuestion = 0;
        public static int finalResults = 0;

        public static void NextQuestion()
        {
            if (currentQuestion < questionArray.Length)
            currentQuestion++;
        }

        public static void Results(int A, int B, int C)
        {
            if (A > B && A > C)
                finalResults = 0;
            if (B > A && B > C)
                finalResults = 1;
            if (C > A && C > B)
                finalResults = 2;
            if (A == B && A > C)
                finalResults = 3;
            if (B == C && B > A)
                finalResults = 4;
            if (C == A && C > B)
                finalResults = 5;
            if (A == B && A == C)
                finalResults = 6;
        }
    }
}

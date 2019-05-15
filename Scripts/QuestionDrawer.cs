using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class QuestionDrawer
    {
        //Level 1
        public readonly static Dictionary<int, Question> ForestQuestions = new Dictionary<int, Question>
        {
            [0] = new Question
            {
                QuestionText = "Question 1: How many flowers did you see?",
                CorrectAnswer = "2",
                WrongAnswers = new[] { "1", "3", "4" }
            },
            [1] = new Question
            {
                QuestionText = "Question 2: What was the name of the lady guiding you?",
                CorrectAnswer = "Sara",
                WrongAnswers = new[] { "Eva", "Sophia", "Stoyan" }
            },
            [2] = new Question
            {
                QuestionText = "Question 3: What was the weather inside of the scene?",
                CorrectAnswer = "Sunny",
                WrongAnswers = new[] { "Rainy", "Stormy", "Windy" }
            },
            [3] = new Question

            {
                QuestionText = "Question 4: How many animals did you see?",
                CorrectAnswer = "0",
                WrongAnswers = new[] { "1", "2", "3" }
            },
            [4] = new Question
            {
                QuestionText = "Question 5: Were there any clouds in the sky?",
                CorrectAnswer = "Yes",
                WrongAnswers = new[] { "Not sure", "No", "Idk" }
            },
        };

        //Level 2
        public readonly static Dictionary<int, Question> MountainQuestions = new Dictionary<int, Question>
        {
            [0] = new Question
            {
                QuestionText = "Question 1: Was Sara near the fire?",
                CorrectAnswer = "Yes",
                WrongAnswers = new[] { "No", "Not sure", "Perhaps" }
            },
            [1] = new Question
            {
                QuestionText = "Question 2: How many campfires did you see?",
                CorrectAnswer = "1",
                WrongAnswers = new[] { "2", "3", "Stoyan" }
            },
            [2] = new Question
            {
                QuestionText = "Question 3: What time of day was it?",
                CorrectAnswer = "Sundown",
                WrongAnswers = new[] { "Sunrise", "Night", "Morning" }
            },
            [3] = new Question

            {
                QuestionText = "Question 4: How much is 10 + 10*10 - 10?",
                CorrectAnswer = "100",
                WrongAnswers = new[] { "110", "90", "20" }
            },
            [4] = new Question
            {
                QuestionText = "Question 5: Are you having fun?",
                CorrectAnswer = "Yes",
                WrongAnswers = new[] { "No", "No", "No" }
            },
        };

        //Level 3
        public readonly static Dictionary<int, Question> VillageQuestions = new Dictionary<int, Question>
        {
            [0] = new Question
            {
                QuestionText = "Question 1: Where were you last located?",
                CorrectAnswer = "Village",
                WrongAnswers = new[] { "Forest", "Mountain", "Desert" }
            },
            [1] = new Question
            {
                QuestionText = "Question 2: Were there any fireflies in the scene?",
                CorrectAnswer = "Yes",
                WrongAnswers = new[] { "No", "Not really", "Maybe" }
            },
            [2] = new Question
            {
                QuestionText = "Question 3: How many fireflies could you count?",
                CorrectAnswer = "Infinite",
                WrongAnswers = new[] { "100", "50", "250" }
            },
            [3] = new Question

            {
                QuestionText = "Question 4: What part of the day was it?",
                CorrectAnswer = "Night",
                WrongAnswers = new[] { "Morning", "Sunrise", "Dawn" }
            },
            [4] = new Question
            {
                QuestionText = "Question 5: Were the neighbours at home?",
                CorrectAnswer = "Yes",
                WrongAnswers = new[] { "Not sure", "No", "Idk" }
            },
        }; 
    }
}

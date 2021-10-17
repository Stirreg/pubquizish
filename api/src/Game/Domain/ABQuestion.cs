using System;

namespace Pubquizish.Game.Domain
{
    public class ABQuestion
    {
        private readonly string _question = default!;
        private readonly string _answerA = default!;
        private readonly string _answerB = default!;

        public ABQuestion(string question, string answerA, string answerB)
        {
            if (string.IsNullOrEmpty(question))
            {
                throw new ArgumentException("There has to be a question.");
            }
            if (string.IsNullOrEmpty(answerA))
            {
                throw new ArgumentException("There has to be an answerA.");
            }
            if (string.IsNullOrEmpty(answerB))
            {
                throw new ArgumentException("There has to be an answerB.");
            }
            _question = question;
            _answerA = answerA;
            _answerB = answerB;
        }
    }
}

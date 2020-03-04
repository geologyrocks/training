using System;

namespace QandALibrary
{
    public enum VoteEnum
    {
        Up,
        Down
    }

    public class Question
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public String Title { get; set; }
        public String Message { get; set; }
        public bool Answered { get; set; }
        public int Votes { get; set; }
        public User User { get; set; }
        public bool Closed { get; set; }

        public void Vote(VoteEnum direction)
        {
            if (Closed)
            {
                throw new QuestionException("Cannot vote on closed question");
            }

            if (direction == VoteEnum.Up)
            {
                Votes++;
            }
            else
            {
                Votes--;
            }
            User.QuestionVotedOn(direction);
        }
    }
}

namespace QandALibrary
{
    public class User
    {
        public const int RATING_RISE_ON_VOTE = 10;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }

        public void QuestionVotedOn(VoteEnum direction)
        {
            if (direction == VoteEnum.Up)
            {
                Rating += RATING_RISE_ON_VOTE;
            }
            else
            {
                Rating -= RATING_RISE_ON_VOTE;
            }
        }
    }
}

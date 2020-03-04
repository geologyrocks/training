using Xunit;
using QandALibrary;

namespace QandATests
{
    public class QuestionTests
    {
        private Question question;
        private User user;

        public QuestionTests()
        {
            question = new Question();
            user = new User();
            question.User = user;
        }

        [Fact]
        public void VotesShouldBeIncrementedWhenQuestionIsVotedUp()
        {
            question.Vote(VoteEnum.Up);
            Assert.Equal(1, question.Votes);
        }

        [Fact]
        public void VotesShouldBeDecrementedWhenQuestionIsVotedDown()
        {
            question.Vote(VoteEnum.Down);
            Assert.Equal(-1, question.Votes);
        }

        [Fact]
        public void UsersRatingRisesWhenQuestionIsVotedUp()
        {
            int initialRating = 100;
            user.Rating = initialRating;
            question.Vote(VoteEnum.Up);
            Assert.Equal(initialRating + User.RATING_RISE_ON_VOTE, user.Rating);
        }

        [Fact]
        public void UsersRatingRisesWhenQuestionIsVotedDown()
        {
            int initialRating = 100;
            user.Rating = initialRating;
            question.Vote(VoteEnum.Down);
            Assert.Equal(initialRating - User.RATING_RISE_ON_VOTE, user.Rating);
        }

        [Fact]
	    public void VoteShouldThrowAnExceptionWhenQuestionHasBeenClosed()
        {
            int initialVoteCount = 4;
            question.Votes = initialVoteCount;
            question.Closed = true;

            Assert.Throws<QuestionException>(() => {
                question.Vote(VoteEnum.Up);
            }); 
        }
    }
}

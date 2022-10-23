namespace PrincessProblem.model;

public class Friend
{
    private readonly Hall _hall;

    public Friend(Hall hall)
    {
        _hall = hall;
    }

    public IContender CompareContenders(Contender contender1, Contender contender2,
        int contendersNumberWhoVisitedPrincess)
    {
        if (_hall.IsContenderVisitedPrincess(contender1, contendersNumberWhoVisitedPrincess) &
            _hall.IsContenderVisitedPrincess(contender2, contendersNumberWhoVisitedPrincess))
        {
            return contender1.Score > contender2.Score ? contender1 : contender2;
        }

        throw new Exception("Friend trying to compare contenders, who didn't meet princess");
    }
}
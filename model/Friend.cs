namespace PrincessProblem.model;

public class Friend
{
    private readonly Hall _hall;

    public Friend(Hall hall)
    {
        _hall = hall;
    }

    public IContender CompareContenders(IContender contender1, IContender contender2)
    {
        if (_hall.IsContenderVisitedPrincess(contender1) &
            _hall.IsContenderVisitedPrincess(contender2))
        {
            return _hall.GetContenderScore(contender1.Name) > _hall.GetContenderScore(contender2.Name)
                ? contender1
                : contender2;
        }

        throw new Exception("Friend trying to compare contenders, who didn't meet princess");
    }
}
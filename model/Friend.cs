namespace PrincessProblem.model;

public class Friend
{
    public IContender CompareContenders(IContender contender1, IContender contender2)
    {
        return contender1.Score > contender2.Score ? contender1 : contender2;
    }
}
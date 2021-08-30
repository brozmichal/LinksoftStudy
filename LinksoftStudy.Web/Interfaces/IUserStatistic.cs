namespace LinksoftStudy.Web.Interfaces
{
    public interface IUserStatistic
    {
        IUser Person { get; set; }

        int TotalFriendShips { get; set; }
    }
}

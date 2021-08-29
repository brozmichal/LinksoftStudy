namespace LinksoftStudy.Web.Interfaces
{
    public interface IUserStatistic
    {
        IPerson Person { get; set; }

        int TotalFriendShips { get; set; }
    }
}

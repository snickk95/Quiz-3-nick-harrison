namespace UserActionTrackingApp.Services
{
    //interface for all functions to do with page counting
    public interface IPageCount
    {
        //function takes in the current page name for that page and incrments count then returns the new value
        public int IncrementPageCount(string pageName);
    }
}

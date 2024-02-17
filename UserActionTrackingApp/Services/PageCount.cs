namespace UserActionTrackingApp.Services
{
    public class PageCount: IPageCount
    {

        //IPageCount count;//interface for the counting
        private int numVisits;//track the number of visits to the page
       Dictionary<string, int> counts = new Dictionary<string,int>();//create dictionary OBJ
        public PageCount() 
        {
            //fill dictionary
            counts.Add("Home", 0);
            counts.Add("other", 0);
        }
        //function takes in the current page name for that page and incrments count then returns the new value
        public int IncrementPageCount(string pageName)
        {
            
            if (counts.TryGetValue(pageName, out numVisits))//check the value exists in the dictionary
            {
                numVisits++;
                counts[pageName] = numVisits;//update dictionary 
                return numVisits;
            }
            else
            {
                return -1;//return -1 for the page not found in dictionary
            }
        }
        
    }
}

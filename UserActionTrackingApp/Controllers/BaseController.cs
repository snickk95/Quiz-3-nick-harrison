using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;

namespace UserActionTrackingApp.Controllers
{
    public class BaseController : Controller
    {
        public int cookieVal;
        //function to update the cookie and create a new cookie if it doesn't exist
       public void UpdateCookie(string key, int value)
       {
            //check if the cookie exists
            if(Request.Cookies.ContainsKey(key))
            {
                //overwrite a cookie with the value
                Response.Cookies.Append(key, value.ToString());
            }
            else
            {
                //add a cookie with the value
                Response.Cookies.Append(key, value.ToString());
            }
        }

        //takes in a string key to get the value for that cookie and return it to the controller
        public int getCookieValue(string key)
        {
            if (Request.Cookies.ContainsKey(key))
            {
                Request.Cookies.TryGetValue(key, out var value);
               //make sure value is not null
                if (value != null)
                {
                    cookieVal = int.Parse(value);
                    return cookieVal;
                }
                else 
                {
                    //return a value of 0 if null since no previous vists were found
                    return 0; 
                }
            }
            else 
            { 
                //return a value of 0 since no previous vists found
                return 0; 
            }
               
        }
    }
}

   

using System.Collections.Generic;

namespace BlazorApp.Services
{
    public class AddictionalService
    {
        public List<string> GetEmails()
        {
            return new List<string>()
            {
                "1@mail.ru",
                "workmail736@gmail.com",
                "andreyrapterror@mail.ru"
            };
        }
    }
}

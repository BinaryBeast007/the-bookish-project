using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookish.Models
{
    public class OpenLibraryResponse
    {
        public int NumFound { get; set; }
        public int Start { get; set; }
        public int NumFoundExact { get; set; }
        public List<OpenLibraryBook> Docs { get; set; }
    }

    public class OpenLibraryBook
    {
        public string Title { get; set; }
        public List<string> AuthorName { get; set; }
        public string FirstPublishYear { get; set; }
    }

}
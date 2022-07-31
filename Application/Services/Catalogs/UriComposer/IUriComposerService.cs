using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UriComposer
{
   public interface IUriComposerService
    {
        string ComposeImageUri(string URl);
    }

    public class UriComposerService : IUriComposerService
    {
        public string ComposeImageUri(string URl)
        {
          return  "https://localhost:44361/" + URl.Replace("\\", "//");
    }
    }
}

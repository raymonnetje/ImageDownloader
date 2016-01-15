using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownloader
{
    public class Grabber
    {
        CustomsearchService customSearchService;
        string searchEngineId; 

        public Grabber(string apiKey, string searchEngineId)
        {
            customSearchService = new CustomsearchService(new Google.Apis.Services.BaseClientService.Initializer() { ApiKey = apiKey });
            this.searchEngineId = searchEngineId;
        }


       
  
       

        public void search(string query)
        {

            Google.Apis.Customsearch.v1.CseResource.ListRequest listRequest = customSearchService.Cse.List(query);
            listRequest.Cx = searchEngineId;
            listRequest.SearchType = Google.Apis.Customsearch.v1.CseResource.ListRequest.SearchTypeEnum.Image;

            List<Result> result = new List<Result>();
            
            for (int i = 0; i < 10; i++)
            {

                listRequest.Start = (i * 10) + 1;
                Search search = listRequest.Execute();

                foreach (var item in search.Items)
                {
                    result.Add(item);
                }
            }

            int j = 0;

            foreach (var item in result)
            {
                j++;
                Console.WriteLine("Nr: " + j + " Title : " + item.Title + Environment.NewLine + "Link : " + item.Link + Environment.NewLine + Environment.NewLine);
            }
            
        }
    }
}

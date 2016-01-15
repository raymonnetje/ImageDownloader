using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using System;
using System.Collections;
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
        ArrayList objArray;


        public Grabber(string apiKey, string searchEngineId)
        {
            
            customSearchService = new CustomsearchService(new Google.Apis.Services.BaseClientService.Initializer() { ApiKey = apiKey });
            this.searchEngineId = searchEngineId;
        }






        public ArrayList search(string query)
        {
            objArray = new ArrayList();

            Google.Apis.Customsearch.v1.CseResource.ListRequest listRequest = customSearchService.Cse.List(query);
            listRequest.Cx = searchEngineId;
            listRequest.SearchType = Google.Apis.Customsearch.v1.CseResource.ListRequest.SearchTypeEnum.Image;

            for (int i = 0; i < 1; i++)
            {

                listRequest.Start = (i*10) + 1;
                Search search = listRequest.Execute();

                foreach (var item in search.Items)
                {
                    Image tempimg = new Image();
                    tempimg.title = item.Title;
                    tempimg.link = item.Link;


                    objArray.Add(tempimg);
                }
            }
            return objArray;
        }
    }
}
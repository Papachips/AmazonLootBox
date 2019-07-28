using Nager.AmazonProductAdvertising;
using Nager.AmazonProductAdvertising.Model;
using System.Collections.Generic;

namespace AmazonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Authentication
            var authentication = new AmazonAuthentication();
            authentication.AccessKey = "amazon access key here";
            authentication.SecretKey = "amazon secret key here";

            //Search critera and result
            var wrapper = new AmazonWrapper(authentication, AmazonEndpoint.US, "amazon associate tag here");
            var searchOperation = wrapper.ItemSearchOperation("canon eos", AmazonSearchIndex.Electronics);
            searchOperation.MaxPrice(200000); //2000 USD
            var xmlResponse = wrapper.Request(searchOperation);
            var result = XmlHelper.ParseXml<ItemSearchResponse>(xmlResponse.Content);

            //Create cart and add items to it
            var items = new List<AmazonCartItem>();
            items.Add(new AmazonCartItem("item code here"));
            var cart = wrapper.CartCreate(items);

            //Debuging
            /*wrapper.XmlReceived += (xml) => { System.Diagnostics.Debug.WriteLine(xml); };
            wrapper.ErrorReceived += (errorResonse) => { System.Diagnostics.Debug.WriteLine(errorResonse.Error.Message); };
            var errors = wrapper.Lookup(new string[] { "item code here" });*/
        }
    }
}

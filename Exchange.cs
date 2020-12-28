using System;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace _net_homework{
    class Exchange{

        public string Url{get;set;}
        private List<string> currenyNames = new List<string>();
        private List<int> amounts = new List<int>();
        private List<float> currencyValues = new List<float>();
        private List<float> normalizedValues = new List<float>();
        private Dictionary<string,float> map = new Dictionary<string, float>();


        private string result;
        public Exchange(){}

        public Exchange(string url){
            Url=url;
        }

        public string GetData(){
            var request = WebRequest.Create(Url) as HttpWebRequest;
            var response = request.GetResponse();

            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            result =  readStream.ReadToEnd();
            return result;
        }

        public List<string> MatchCurrencyName(){

            string pattern =  @"(<td>[A-Z\s]{3})";

            Regex rg = new Regex(pattern);
            MatchCollection matchedText = rg.Matches(result);

            for (int count = 0; count < matchedText.Count; count++){
                string currency = matchedText[count].Value.Remove(0,4);
                currenyNames.Add(currency);
            }

            return currenyNames;
        }
        public List<float> MatchCurrencyValue(){
           
            string pricePattern = @"([0-9]*[.][0-9][0-9]+)";

            Regex priceRegex = new Regex(pricePattern);
            MatchCollection matchedCurrency = priceRegex.Matches(result);

            for(int i=0;i<matchedCurrency.Count;i++){
                if(i%2==0){
                    float num = float.Parse(matchedCurrency[i].Value);
                    currencyValues.Add(num);
                }
                
            }
            return currencyValues;
        }

        public List<int> GetAmountOfEachCurrency(){

            string pattern = @"(<td>[0-9]+)";

            Regex rg = new Regex(pattern);
            MatchCollection matchedAmount = rg.Matches(result);

            for(int i=0;i<matchedAmount.Count;i++){
                if(i%3==0){
                    int amount  = int.Parse(matchedAmount[i].Value.Remove(0,4));
                    amounts.Add(amount);
                }
            }
            return amounts;
        }
        public List<float> NormalizeValues(){ 

            // calculating values for one currency to gel
            for(int i=0;i<currencyValues.Count;i++){
                normalizedValues.Add(currencyValues[i]/amounts[i]);
            }

            return normalizedValues;
        }
        public Dictionary<string,float> BuildExchangeMap(){

            for(int i=0;i<normalizedValues.Count;i++){
                map[currenyNames[i]] = normalizedValues[i];
            }
            
            return map;
        }

        public double exchangeRate(string from, string to){
            
            return map[from]/map[to];
        }
    }
}
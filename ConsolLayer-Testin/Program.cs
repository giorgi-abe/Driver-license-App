using System;

namespace ConsolLayer_Testin
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }


        public static List<Topic> GetTickets(string fileName)
        {​​​​​​
            using (StreamReader reader = new StreamReader(fileName))
            {​​​​​​
                var json = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<List<Topic>>(json);
                return data;
            }​​​​​​
        }​​​​​​
    }
}

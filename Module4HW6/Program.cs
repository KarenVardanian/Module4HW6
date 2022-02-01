using System;
using System.Threading.Tasks;

namespace Module4HW6
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            using (var context =  new SampleContextFactory().CreateDbContext(args))
            {
                //new InsertData(context).AddData();
                // new  InsertData(context).QueryTwo();
                 await new  InsertData(context).QueryThree();
            }



        }
    }
}

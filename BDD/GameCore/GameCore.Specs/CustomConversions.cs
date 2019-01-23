using System;
using TechTalk.SpecFlow;

namespace GameCore.Specs
{
    [Binding]
    class CustomConversions
    {

        [StepArgumentTransformation(@"(\d+) days ago")]
        public DateTime DatsAgoTransformation(int daysAgo)
        {
            return DateTime.Now.Subtract(TimeSpan.FromDays(daysAgo));
        }
    }
}

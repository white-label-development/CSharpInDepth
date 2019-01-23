using System;
using System.Collections;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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

        [StepArgumentTransformation]
        public IEnumerable<Weapon> WeaponsTransformations(Table table)
        {
            return table.CreateSet<Weapon>();
        }
    }
}

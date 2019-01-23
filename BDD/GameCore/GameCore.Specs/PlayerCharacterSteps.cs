using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace GameCore.Specs
{
    [Binding]
    public class PlayerCharacterSteps
    {

        private PlayerCharacter _player;

        [Given(@"I'm a new player")]
        public void GivenImANewPlayer()
        {
            _player = new PlayerCharacter();

        }

        [When(@"I take (.*) damage")]
        public void WhenITakeDamage(int p0)
        {
            _player.Hit(p0);
        }

        [Then(@"My health should now be (.*)")]
        public void ThenMyHealthShouldNowBe(int expectedHealth)
        {
            Assert.Equal(expectedHealth, _player.Health);
        }

        //[When(@"I take 40 damage")]
        //public void WhenITake40Damage()
        //{
        //    _player.Hit(40);
        //}


        //[Then(@"My health should now be 60")]
        //public void ThenMyHealthShouldNowBe60()
        //{
        //    Assert.Equal(60, _player.Health);
        //}

        //[When(@"I take 100 damage")]
        //public void WhenITake100Damage()
        //{
        //    _player.Hit(100);
        //}

        [Then(@"I should be dead")]
        public void ThenIShouldBeDead()
        {
            Assert.True(_player.IsDead);
        }

        [Given(@"I have a damage resistance of (.*)")]
        public void GivenIHaveADamageResistanceOf(int p0)
        {
            _player.DamageResistance = p0;
        }

        [Given(@"I'm an Elf")]
        public void GivenImAnElf()
        {
            _player.Race = "Elf";
        }

        //[Given(@"I have the following attributes")]
        //public void GivenIHaveTheFollowingAttributes(Table table)
        //{
        //    _player.Race = table.Rows.First(x => x["attribute"] == "Race")["value"];
        //    _player.DamageResistance = int.Parse(table.Rows.First(x => x["attribute"] == "Resistance")["value"]);
        //}

        // #strongly typed version with concrete class
        //[Given(@"I have the following attributes")]
        //public void GivenIHaveTheFollowingAttributes(Table table)
        //{
        //    var attributes = table.CreateInstance<PlayerAttributes>();
        //    _player.Race = attributes.Race;
        //    _player.DamageResistance = attributes.Resistance;
        //}

        // #strongly typed version with dynamic class
        [Given(@"I have the following attributes")]
        public void GivenIHaveTheFollowingAttributes(Table table)
        {
            //var attributes = table.CreateInstance<PlayerAttributes>();
            dynamic attributes = table.CreateDynamicInstance();

            _player.Race = attributes.Race;
            _player.DamageResistance = attributes.Resistance;
        }

        [Given(@"My character class is set to (.*)")]
        public void GivenMyCharacterClassIsSetTo(CharacterClass characterClass)
        {
            _player.CharacterClass = characterClass;
        }

        [When(@"Cast a healing spell")]
        public void WhenCastAHealingSpell()
        {
            _player.CastHealingSpell();
        }

        [Given(@"I have the following magical items")]
        public void GivenIHaveTheFollowingMagicalItems(Table table)
        {

            IEnumerable<MagicalItem> items = table.CreateSet<MagicalItem>(); //pour table data into variable
            _player.MagicalItems.AddRange(items);

            //an alternative dynamic method to extract from the table is
            IEnumerable<dynamic> items2 = table.CreateDynamicSet();
            foreach (var magicalItem in items2)
            {
                var nameForDynamicObect = magicalItem.name;
                //_player.MagicalItems.Add(....
            }
        }

        [Then(@"My total magical power should be (.*)")]
        public void ThenMyTotalMagicalPowerShouldBe(int p0)
        {
            Assert.Equal(p0, _player.MagicalPower); 
        }

        //capture entire phrase "x days ago"

        [Given(@"I last slept (.* days ago)")]
        public void GivenILastSleptDaysAgo(DateTime lastSlept)
        {
            _player.LastSleepTime = lastSlept;
        }

        [When(@"I read a restore health scroll")]
        public void WhenIReadARestoreHealthScroll()
        {
            _player.ReadHealthScroll();
        }


    }
}

﻿
using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using OOP21_Chess_csharp.MarcoRaggini;
using OOP21_Chess_csharp.Speranza.User;
using OOP21_Chess_csharp.Tosi.Utils;


namespace OOP21_Chess_TestCsharp.MarcoRagginiTest
{
    public class TurnTest
    {
        public KeyValuePair<User, Side> player1 = new KeyValuePair<User, Side>(new User("Giorgio"), Side.White);
        public KeyValuePair<User, Side> player2 = new KeyValuePair<User, Side>(new User("Carla"), Side.Black);


        [SetUp]
        public void Setup()
        {
        }
 
        [Test]
        public void TryGetOppositeColor()
        {
            ITurn turnTest = new Turn(1, player1, player2);
            Assert.AreEqual(Side.White, turnTest.GetOppositeColor(Side.Black));
        }

        [Test]
        public void TryGetUserTurn()
        {
            ITurn turnTest = new Turn(1, player1, player2);
            Assert.AreEqual(Side.White, turnTest.GetUserTurn());
        }

        [Test]
        public void TryGetPairByColor()
        {
            ITurn turnTest = new Turn(1, player1, player2);
            Assert.AreEqual(player1, turnTest.GetPairByColor(Side.White));
        }

        [Test]
        public void TryGetUsers()
        {
            ITurn turnTest = new Turn(1, player1, player2);
            Assert.AreEqual(new KeyValuePair<User, User>(player1.Key, player2.Key)
                                    , turnTest.GetUsers());
        }
    }
}
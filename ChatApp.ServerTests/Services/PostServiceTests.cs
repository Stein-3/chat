﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatApp.Server.Services;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Internal;
using NUnit.Framework;
using ChatApp.ServerTests.ContextBase;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Server.Services.Tests
{
    [TestClass()]
    public class PostServiceTests
    {
        public PostServiceBase Fixture { get; set; }

        public PostServiceTests()
        {
            Fixture = new PostServiceBase();
        }

        // [TestMethod()]
        // public async Task ReadPostWhenWindowOpenedTest()
        // {
        //     using var transaction = Fixture.Connection.BeginTransaction();
        //     using var context = Fixture.CreateContext(transaction);

        //     var roomId = context.Rooms
        //         .Where(room => room.Name == "room1")
        //         .Single()
        //         .Id;

        //     var service = new PostService(context);

            // var result = await service.ReadPosts(roomId, DateTime.Now, 50);

        //     Assert.AreEqual(50, result.Count());
        // }
    }
}
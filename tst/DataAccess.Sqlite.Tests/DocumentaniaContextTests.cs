// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentaniaContextTests.cs" company="BaerDev">
// Copyright (c) BaerDev. All rights reserved.
// </copyright>
// <summary>
// The file 'DocumentaniaContextTests.cs'.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

namespace DataAccess.Sqlite.Tests
{
    using System.IO;
    using System.Runtime.CompilerServices;
    using ExAs;

    [TestFixture]
    [Ignore("Sqlite is not used")]
    public class DocumentaniaContextTests
    {
        [OneTimeSetUp]
        public void TestsInitialize()
        {
            using (var db = new DocumentaniaContext())
            {
                db.Database.EnsureCreated();
            }
        }

        [Test]
        public void DatabaseIsCreated_Under_Documentania_DB()
        {
            File.Exists("Documentania.db").Evaluate(x => x);
        }
    }
}
﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Configuration;
using System.Text;
using Microsoft.Data.Entity.AzureTableStorage.Extensions;
using Microsoft.Data.Entity.AzureTableStorage.FunctionalTests;
using Microsoft.Data.Entity.ChangeTracking;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Xunit;
using Xunit.Abstractions;

// TODO  Until extensions are implemented, these tests will not work
//namespace Microsoft.Data.Entity.AzureTableStorage.FunctionalTests
//{
//    public class BatchTests : IClassFixture<CloudTableFixture>
//    {
//        private TestContext _context;
//        private CloudTable _table;
//        private string _testParition;

//        private BatchTests(CloudTableFixture fixture)
//        {

//            var connectionString = ConfigurationManager.AppSettings["TestConnectionString"];
//            _context = new TestContext();
//            fixture.GetOrCreateTable("AzureStorageBatchEmulatorEntity", connectionString);
//            //fixture.DeleteOnDispose = true;
//            _testParition = "BatchTests-" + DateTime.UtcNow.ToString("O");
//        }

//        [Theory]
//        [InlineData(100)]
//        [InlineData(1000)]
//        [InlineData(10000)]
//        [InlineData(100000)]
//        public void It_creates_many_items(int count)
//        {
//            for (var i = 0; i < count; i++)
//            {
//                var item = new AzureStorageBatchEmulatorEntity { Count = i, PartitionKey = _testParition, RowKey = i.ToString() };
//                _context.Items.Add(item);
//            }
//            var changes = _context.SaveChangesAsBatch();
//            Assert.Equal(count, changes);
//        }

//        [Fact]
//        public void It_separates_by_partition_key()
//        {
//            var partition1 = new AzureStorageBatchEmulatorEntity { PartitionKey = _testParition + "A", RowKey = "0" };
//            var partition2 = new AzureStorageBatchEmulatorEntity { PartitionKey = _testParition + "B", RowKey = "0" };
//            _context.Items.AddRange(new[] { partition1, partition2 });
//            var changes = _context.SaveChangesAsBatch();
//            Assert.Equal(2, changes);
//        }

//        [Fact]
//        public void It_handles_many_changes()
//        {
//            var item = new AzureStorageBatchEmulatorEntity { PartitionKey = _testParition, RowKey = "z" };
//            _context.Items.Add(item);
//            item.Count = 12435;
//            _context.Items.Remove(item);
//            var changes = _context.SaveChangesAsBatch();
//            Assert.Equal(2, changes);
//        }

//        private class TestContext : DbContext
//        {
//            public DbSet<AzureStorageBatchEmulatorEntity> Items { get; set; }
//            protected override void OnModelCreating(Metadata.ModelBuilder builder)
//            {
//                builder.Entity<AzureStorageBatchEmulatorEntity>().Key(s => s.Key);
//            }

//            protected override void OnConfiguring(DbContextOptions builder)
//            {
//                builder.UseAzureTableStorge(ConfigurationManager.AppSettings["TestConnectionString"]);
//            }
//        }
//        private class AzureStorageBatchEmulatorEntity : TableEntity
//        {
//            public string Key { get { return PartitionKey + RowKey; } }
//            public int Count { get; set; }
//        }

//    }

//}
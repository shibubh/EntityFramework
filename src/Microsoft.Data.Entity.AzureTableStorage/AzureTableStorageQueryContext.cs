﻿using Microsoft.Data.Entity.ChangeTracking;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Query;
using Microsoft.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Data.Entity.AzureTableStorage
{
    public class AzureTableStorageQueryContext : QueryContext
    {
        private readonly AzureTableStorageConnection _database;

        public AzureTableStorageQueryContext(
            IModel model,
            ILogger logger,
           StateManager stateManager,
            AzureTableStorageConnection database)
            : base(model, logger, stateManager)
        {
            _database = database;
        }

        public virtual AzureTableStorageConnection Database
        {
            get { return _database; }
        }
    }

}

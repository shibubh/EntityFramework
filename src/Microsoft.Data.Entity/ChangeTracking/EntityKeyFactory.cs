// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.Data.Entity.Metadata;

namespace Microsoft.Data.Entity.ChangeTracking
{
    public abstract class EntityKeyFactory
    {
        public abstract EntityKey Create(
            [NotNull] IEntityType entityType, [NotNull] IReadOnlyList<IProperty> properties, [NotNull] StateEntry entry);

        public abstract EntityKey Create(
            [NotNull] IEntityType entityType, [NotNull] IReadOnlyList<IProperty> properties, [NotNull] IValueReader valueReader);
    }
}

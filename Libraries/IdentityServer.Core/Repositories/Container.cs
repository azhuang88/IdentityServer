/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System.ComponentModel.Composition.Hosting;

namespace IdentityServer.Repositories
{
    public static class Container
    {
        public static CompositionContainer Current { get; set; }
    }
}
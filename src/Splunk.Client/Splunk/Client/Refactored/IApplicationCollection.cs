﻿/*
 * Copyright 2014 Splunk, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"): you may
 * not use this file except in compliance with the License. You may obtain
 * a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 */

//// TODO:
//// [0] Contracts
//// [O] Documentation

namespace Splunk.Client.Refactored
{
    using Splunk.Client;

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides an operational interface to the Splunk application collection.
    /// </summary>
    [ContractClass(typeof(IApplicationCollectionContract<>))]
    public interface IApplicationCollection<TApplication> : IPaginated, IEntityCollection<TApplication> 
        where TApplication : ResourceEndpoint, IApplication, new()
    {
        /// <summary>
        /// Asynchronously creates a new Splunk application from a template.
        /// </summary>
        /// <param name="template">
        /// 
        /// </param>
        /// <param name="attributes">
        /// 
        /// </param>
        /// <returns>
        /// An object representing the Splunk application created.
        /// </returns>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/SzKzNX">POST 
        /// apps/local</a> endpoint to create the current <see cref=
        /// "Application"/>.
        /// </remarks>
        Task<TApplication> CreateAsync(string template, ApplicationAttributes attributes = null);

        /// <summary>
        /// Asynchronously retrieves select entities in the current application 
        /// entity collection.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> representing the operation.
        /// </returns>
        /// <remarks>
        /// Following completion of the operation the list of entities in the
        /// current application entity collection will contain all changes 
        /// since the select entities were last retrieved.
        /// </remarks>
        Task GetSliceAsync(ApplicationCollection.Filter criteria);

        /// <summary>
        /// Asynchronously installs an application from a Splunk application
        /// archive file.
        /// </summary>
        /// <param name="path">
        /// Specifies the location of a Splunk application archive file.
        /// </param>
        /// <param name="name">
        /// Optionally specifies an explicit name for the application. This
        /// value overrides the name of the application as specified in the
        /// archive file.
        /// </param>
        /// <param name="update">
        /// <c>true</c> if Splunk should allow the installation to update an
        /// existing application. The default value is <c>false</c>.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/SzKzNX">POST 
        /// apps/local</a> endpoint to install the application from the archive
        /// file on <paramref name="path"/>.
        /// </remarks>
        Task<TApplication> InstallAsync(string path, string name = null, bool update = false);
    }

    [ContractClassFor(typeof(IApplicationCollection<>))]
    abstract class IApplicationCollectionContract<TApplication> : IApplicationCollection<TApplication>
        where TApplication : ResourceEndpoint, IApplication, new()
    {
        #region Properties

        public abstract TApplication this[int index] { get; }
        public abstract int Count { get; }
        public abstract IReadOnlyList<Message> Messages { get; }
        public abstract Pagination Pagination { get; }

        #endregion

        #region Methods

        public Task<TApplication> CreateAsync(string name, ApplicationAttributes attributes)
        {
            Contract.Requires<ArgumentNullException>(name != null);
            return default(Task<TApplication>);
        }

        public abstract Task GetAllAsync();

        public abstract Task<TApplication> GetAsync(string name);

        public abstract IEnumerator<TApplication> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return default(IEnumerator<TApplication>);
        }

        public abstract Task GetSliceAsync(params Argument[] arguments);

        public Task GetSliceAsync(IEnumerable<Argument> arguments)
        {
            return default(Task);
        }

        public Task GetSliceAsync(ApplicationCollection.Filter criteria)
        {
            Contract.Requires<ArgumentNullException>(criteria != null);
            return default(Task);
        }

        public Task<TApplication> InstallAsync(string path, string name = null, bool update = false)
        {
            Contract.Requires<ArgumentNullException>(path != null);
            return default(Task<TApplication>);
        }

        public abstract Task ReloadAsync();

        #endregion
    }
}

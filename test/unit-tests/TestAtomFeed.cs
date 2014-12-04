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

namespace Splunk.Client.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Xml;
    using System.Xml.Linq;
    using System.Threading.Tasks;

    using Xunit;

    public class TestAtomFeed
    {
        public static readonly string Directory = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Data", "Client"));
        
        [Trait("unit-test", "Splunk.Client.AtomEntry")]
        [Fact]
        public async Task CanReadAtomEntry()
        {
            var entry = await ReadEntry(Path.Combine(Directory, "Job.GetAsync.xml"));
            Assert.Equal(
                "AtomEntry(Title=search search index=_internal | head 1000, Author=admin, Id=https://localhost:8089/services/search/jobs/scheduler__admin__search__RMD50aa4c13eb03d1730_at_1401390000_866, Published=5/29/2014 12:00:01 PM, Updated=5/29/2014 1:01:08 PM)", 
                entry.ToString());
        }

        [Trait("unit-test", "Splunk.Client.AtomFeed")]
        [Fact]
        public async Task CanReadAtomFeed()
        {
            var feed = await ReadFeed(Path.Combine(Directory, "JobCollection.GetAsync.xml"));
            Assert.Equal(
                "AtomFeed(Title=jobs, Author=Splunk, Id=https://localhost:8089/services/search/jobs, Updated=5/29/2014 12:13:01 PM)",
                feed.ToString());
        }

        [Trait("unit-test", "Splunk.Client.AtomFeed")]
        [Fact]
        // TODO: move this test to a more appropriate place
        public async Task CheckFieldOrder()
        {   

            var xml = File.ReadAllText(Path.Combine(Directory, "..", "badFieldOrder.xml"));

            var response = new HttpResponseMessage();
            response.Content = new StringContent(xml);
            var searchResultStream = await SearchResultStream.CreateAsync(response);
            foreach (var result in searchResultStream)
            {
                System.Diagnostics.Debug.WriteLine(result.ToString());
            }
        }

        public static async Task<AtomEntry> ReadEntry(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var reader = XmlReader.Create(stream, TestAtomFeed.XmlReaderSettings);
                var entry = new AtomEntry();
                await entry.ReadXmlAsync(reader);

                return entry;
            }
        }

        public static async Task<AtomFeed> ReadFeed(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var reader = XmlReader.Create(stream, TestAtomFeed.XmlReaderSettings);
                var feed = new AtomFeed();
                await feed.ReadXmlAsync(reader);

                return feed;
            }
        }

        #region Privates/internals

        static readonly XmlReaderSettings XmlReaderSettings = new XmlReaderSettings()
        {
            Async = true,
            ConformanceLevel = ConformanceLevel.Fragment,
            IgnoreComments = true,
            IgnoreProcessingInstructions = true,
            IgnoreWhitespace = true
        };

        #endregion
    }
}

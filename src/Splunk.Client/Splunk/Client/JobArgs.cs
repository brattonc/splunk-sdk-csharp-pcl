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
//// [ ]  Documentation
//// [ ] Class for specifying a time string.

namespace Splunk.Client
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.Runtime.Serialization;

    /// <summary>
    /// Provides arguments for creating a search <see cref="Job"/>.
    /// </summary>
    /// <remarks>
    /// <para><b>References:</b></para>
    /// <list type="number">
    /// <item><description>
    ///   <a href="http://goo.gl/OWTUws">REST API Reference: POST search/jobs</a>.
    /// </description></item>
    /// </list>
    /// </remarks>
    public sealed class JobArgs : Args<JobArgs>
    {
        /// <summary>
        /// Gets or sets a value that specifies how long a <see cref="Job"/> 
        /// may be inactive before it is automatically cancelled.
        /// </summary>
        /// <remarks>
        /// A value of <c>0</c> specifies that a <see cref="Job"/> is never 
        /// automatically cancelled.
        /// </remarks>
        [DataMember(Name = "auto_cancel", EmitDefaultValue = false)]
        public int? AutoCancel
        { get; set; }
        
        /// <summary>
        /// Gets or sets a value that specifies how many events a <see cref=
        /// "Job"/> must process before it is automatically finalized.
        /// </summary>
        /// <remarks>
        /// A value of <c>0</c> specifies that a <see cref="Job"/> is never 
        /// automatically finalized.
        /// </remarks>
        [DataMember(Name = "auto_finalize_ec", EmitDefaultValue = false)]
        public int? AutoFinalizeEventCount
        { get; set; }

        /// <summary>
        /// Gets or sets a value that specifies how long a <see cref="Job"/> 
        /// may run before it is automatically paused.
        /// </summary>
        /// <remarks>
        /// A value of <c>0</c> specifies that a <see cref="Job"/> is never 
        /// automatically paused.
        /// </remarks>
        [DataMember(Name = "auto_pause", EmitDefaultValue = false)]
        public int? AutoPause
        { get; set; }

        /// <summary>
        /// Gets or sets a time string that specifies the earliest inclusive 
        /// time bounds for a <see cref="Job"/>. 
        /// </summary>
        /// <remarks>
        /// The time string can be either a UTC time (with fractional seconds), 
        /// a relative time specifier (to now) or a formatted time string.
        /// Refer to <a href="http://goo.gl/4P41jH">Time modifiers for search
        /// </a> for information and examples of specifying a time string.
        /// </remarks>
        [DataMember(Name = "earliest_time", EmitDefaultValue = false)]
        public string EarliestTime
        { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether lookups should be 
        /// applied to events processed by a search <see cref="Job"/>.
        /// </summary>
        /// <remarks>
        /// The default value is <c>true</c>. Depending on the nature of the
        /// lookups a search <see cref="Job"/> may take significantly longer
        /// to execute when the value of this property is <c>true</c>.
        /// </remarks>
        [DataMember(Name = "enable_lookups", EmitDefaultValue = false)]
        public bool? EnableLookups
        { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ExecutionMode"/> for a search <see 
        /// cref="Job"/>.
        /// </summary>
        /// <remarks>
        /// The default value is <see cref="ExecutionMode"/>.Normal.
        /// </remarks>
        [DataMember(Name = "exec_mode", EmitDefaultValue = false)]
        public ExecutionMode? ExecutionMode
        { get; set; }

        /// <summary>
        /// Specifies whether a <see cref="Job"/> should cause (and wait 
        /// depending on the value of <see cref="SyncBundleReplication"/> for
        /// bundle synchronization with all search peers. 
        /// </summary>
        /// <remarks>
        /// The default value is <c>false</c>.
        /// </remarks>
        [DataMember(Name = "force_bundle_replication", EmitDefaultValue = false)]
        public bool? ForceBundleReplication
        { get; set; }

        /// <summary>
        /// Specify the search ID (SID).
        /// </summary>
        /// <remarks>
        /// A random SID is generated by default.
        /// </remarks>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id
        { get; set; }

        /// <summary>
        /// A time string that specifies the earliest inclusive time bounds for
        /// a <see cref="Job"/> based on the index time bounds. 
        /// </summary>
        /// <remarks>
        /// The time string can be either a UTC time (with fractional seconds), 
        /// a relative time specifier (to now) or a formatted time string.
        /// Refer to <a href="http://goo.gl/4P41jH">Time modifiers for search
        /// </a> for information and examples of specifying a time string.
        /// </remarks>
        [DataMember(Name = "index_earliest", EmitDefaultValue = false)]
        public string IndexEarliest
        { get; set; }

        /// <summary>
        /// A time string that specifies the latest exclusive time bounds for 
        /// a <see cref="Job"/> based on the index time bounds. 
        /// </summary>
        /// <remarks>
        /// The time string can be either a UTC time (with fractional seconds), 
        /// a relative time specifier (to now) or a formatted time string.
        /// Refer to <a href="http://goo.gl/4P41jH">Time modifiers for search
        /// </a> for information and examples of specifying a time string.
        /// </remarks>
        [DataMember(Name = "index_latest", EmitDefaultValue = false)]
        public string IndexLatest
        { get; set; }

        /// <summary>
        /// A time string that specifies the latest exclusive time bounds for 
        /// a <see cref="Job"/>. 
        /// </summary>
        /// <remarks>
        /// The time string can be either a UTC time (with fractional seconds), 
        /// a relative time specifier (to now) or a formatted time string.
        /// Refer to <a href="http://goo.gl/4P41jH">Time modifiers for search
        /// </a> for information and examples of specifying a time string.
        /// </remarks>
        [DataMember(Name = "latest_time", EmitDefaultValue = false)]
        public string LatestTime
        { get; set; }

        /// <summary>
        /// The number of events that can be accessible in any given status 
        /// bucket.
        /// </summary>
        /// <remarks>
        /// In transforming mode this value also specifies the maximum number
        /// of results to store. The default value is <c>10000</c>.
        /// </remarks>
        [DataMember(Name = "max_count", EmitDefaultValue = false)]
        public int? MaxCount
        { get; set; }

        /// <summary>
        /// Gets or sets the number of seconds to run a <see cref="Job"/>
        /// before finalizing.
        /// </summary>
        /// <remarks>
        /// A value of <c>0</c> specifies that a <see cref="Job"/> should never
        /// finalize.
        /// </remarks>
        [DataMember(Name = "max_time", EmitDefaultValue = false)]
        public int? MaxTime
        { get; set; }

        /// <summary>
        /// The application namespace in which to restrict searches. 
        /// </summary>
        /// <remarks>
        /// The namespace corresponds to the identifier recognized in the 
        /// /services/apps/local endpoint.
        /// </remarks>
        [DataMember(Name = "namespace", EmitDefaultValue = false)]
        public string Namespace
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "now", EmitDefaultValue = false)]
        public string Now
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "reduce_freq", EmitDefaultValue = false)]
        public int? ReduceFrequency
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "reload_macros", EmitDefaultValue = false)]
        public bool? ReloadMacros
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "remote_server_list", EmitDefaultValue = false)]
        public string RemoteServerList
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "rf", EmitDefaultValue = false)]
        public IReadOnlyList<string> RequiredFieldList
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "reuse_max_seconds_ago", EmitDefaultValue = false)]
        public int? ReuseMaxSecondsAgo
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "rt_blocking", EmitDefaultValue = false)]
        public bool? RealTimeBlocking
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "rt_indexfilter", EmitDefaultValue = false)]
        public bool? RealTimeIndexFilter
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "rt_maxblocksecs", EmitDefaultValue = false)]
        public int? RealTimeMaxBlockSeconds
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "rt_queue_size", EmitDefaultValue = false)]
        public int? RealTimeQueueSize
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "search_listener", EmitDefaultValue = false)]
        public string SearchListener
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "search_mode", EmitDefaultValue = false)]
        public SearchMode? SearchMode
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "spawn_process", EmitDefaultValue = false)]
        public bool? SpawnProcess
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "status_buckets", EmitDefaultValue = false)]
        public int? StatusBuckets
        { get; set; }

        /// <summary>
        /// Specifies whether a <see cref="Job"/> should wait for bundle
        /// synchronization with all search peers.
        /// </summary>
        /// <remarks>
        /// The default value is <c>false</c>.
        /// </remarks>
        [DataMember(Name = "sync_bundle_replication", EmitDefaultValue = false)]
        public bool? SyncBundleReplication
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "time_format", EmitDefaultValue = false)]
        public string TimeFormat
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "timeout", EmitDefaultValue = false)]
        public int? Timeout
        { get; set; }
    }
}
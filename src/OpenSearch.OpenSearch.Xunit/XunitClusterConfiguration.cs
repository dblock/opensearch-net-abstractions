/* SPDX-License-Identifier: Apache-2.0
*
* The OpenSearch Contributors require contributions made to
* this file be licensed under the Apache-2.0 license or a
* compatible open source license.
*
* Modifications Copyright OpenSearch Contributors. See
* GitHub history for details.
*
*  Licensed to Elasticsearch B.V. under one or more contributor
*  license agreements. See the NOTICE file distributed with
*  this work for additional information regarding copyright
*  ownership. Elasticsearch B.V. licenses this file to you under
*  the Apache License, Version 2.0 (the "License"); you may
*  not use this file except in compliance with the License.
*  You may obtain a copy of the License at
*
* 	http://www.apache.org/licenses/LICENSE-2.0
*
*  Unless required by applicable law or agreed to in writing,
*  software distributed under the License is distributed on an
*  "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
*  KIND, either express or implied.  See the License for the
*  specific language governing permissions and limitations
*  under the License.
*/

using System;
using OpenSearch.OpenSearch.Ephemeral;
using OpenSearch.OpenSearch.Ephemeral.Plugins;
using OpenSearch.Stack.ArtifactsApi;

namespace OpenSearch.OpenSearch.Xunit
{
	public class XunitClusterConfiguration : EphemeralClusterConfiguration
	{
		public XunitClusterConfiguration(
			OpenSearchVersion version,
			ServerType serverType,
			ClusterFeatures features = ClusterFeatures.None,
			OpenSearchPlugins plugins = null,
			int numberOfNodes = 1)
			: base(version, serverType, features, plugins, numberOfNodes) =>
			AdditionalAfterStartedTasks.Add(new PrintXunitAfterStartedTask());

		/// <inheritdoc />
		protected override string NodePrefix => "xunit";

		/// <summary>
		///     The maximum number of tests that can run concurrently against a cluster using this configuration.
		/// </summary>
		public int MaxConcurrency { get; set; }

		/// <summary>
		///     The maximum amount of time a cluster can run using this configuration.
		/// </summary>
		public TimeSpan? Timeout { get; set; }
	}
}

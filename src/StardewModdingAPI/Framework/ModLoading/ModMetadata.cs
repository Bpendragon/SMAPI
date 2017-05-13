﻿using StardewModdingAPI.Framework.Models;

namespace StardewModdingAPI.Framework.ModLoading
{
    /// <summary>Metadata for a mod.</summary>
    internal class ModMetadata
    {
        /*********
        ** Accessors
        *********/
        /// <summary>The mod's display name.</summary>
        public string DisplayName { get; }

        /// <summary>The mod's full directory path.</summary>
        public string DirectoryPath { get; }

        /// <summary>The mod manifest.</summary>
        public IManifest Manifest { get; }

        /// <summary>Optional metadata about a mod version that SMAPI should assume is compatible or broken, regardless of whether it detects incompatible code.</summary>
        public ModCompatibility Compatibility { get; }

        /// <summary>The metadata resolution status.</summary>
        public ModMetadataStatus Status { get; set; }

        /// <summary>The reason the metadata is invalid, if any.</summary>
        public string Error { get; set; }


        /*********
        ** Public methods
        *********/
        /// <summary>Construct an instance.</summary>
        /// <param name="displayName">The mod's display name.</param>
        /// <param name="directoryPath">The mod's full directory path.</param>
        /// <param name="manifest">The mod manifest.</param>
        /// <param name="compatibility">Optional metadata about a mod version that SMAPI should assume is compatible or broken, regardless of whether it detects incompatible code.</param>
        public ModMetadata(string displayName, string directoryPath, IManifest manifest, ModCompatibility compatibility)
            : this(displayName, directoryPath, manifest, compatibility, ModMetadataStatus.Found, null)
        {
            this.DisplayName = displayName;
            this.DirectoryPath = directoryPath;
            this.Manifest = manifest;
            this.Compatibility = compatibility;
        }

        /// <summary>Construct an instance.</summary>
        /// <param name="displayName">The mod's display name.</param>
        /// <param name="directoryPath">The mod's full directory path.</param>
        /// <param name="manifest">The mod manifest.</param>
        /// <param name="compatibility">Optional metadata about a mod version that SMAPI should assume is compatible or broken, regardless of whether it detects incompatible code.</param>
        /// <param name="status">The metadata resolution status.</param>
        /// <param name="error">The reason the metadata is invalid, if any.</param>
        public ModMetadata(string displayName, string directoryPath, IManifest manifest, ModCompatibility compatibility, ModMetadataStatus status, string error)
        {
            this.DisplayName = displayName;
            this.DirectoryPath = directoryPath;
            this.Manifest = manifest;
            this.Compatibility = compatibility;
            this.Status = status;
            this.Error = error;
        }
    }

    /// <summary>Indicates the status of a mod's metadata resolution.</summary>
    internal enum ModMetadataStatus
    {
        /// <summary>The mod has been found, but hasn't been processed yet.</summary>
        Found,

        /// <summary>The mod cannot be loaded.</summary>
        Failed
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace IGeekFan.AspNetCore.RapiDoc
{
    /// <summary>
    /// https://mrin9.github.io/RapiDoc/api.html  now not support
    /// </summary>
    class GenericRapiConfig
    {
        /// <summary>
        /// url of the OpenAPI spec to view
        /// </summary>
        public string SpecUrl { get; set; }
        /// <summary>
        /// Allowed: true | false To list tags in alphabetic order, otherwise tags will be ordered based on how it is specified under the tags section in the spec.
        /// </summary>
        public bool SortTags { get; set; }
        /// <summary>
        /// Allowed: path | method | summary Sort endpoints within each tags by path, method or summary  |  Example
        /// </summary>
        public string SortEndpointsBy { get; set; }
        public string HeadingText { get; set; }
        public string GotoPath { get; set; }
        public bool FillRequestFieldsWithExample { get; set; }
        public string Theme { get; set; }
        public string BgColor { get; set; }
        public string TextColor { get; set; }
        public string HeaderColor { get; set; }
        public string PrimaryColor { get; set; }
        public bool LoadFonts { get; set; }
        public string RegularFont { get; set; }
        public string MonoFont { get; set; }
        public string FontSize { get; set; }
        public bool UsePathInNavBar { get; set; }
        public string NavBgColor { get; set; }
        public string NavBgImage { get; set; }
        public string NavBgImageSize { get; set; }
        public string NavBgImageRepeat { get; set; }
        public string NavTextColor { get; set; }
        public string NavHoverBgColor { get; set; }
        public string NavHoverTextColor { get; set; }
        public string NavAccentColor { get; set; }
        /// <summary>
        /// Allowed: default | compact | relaxed Controls navigation item spacing  |  Example
        /// </summary>
        public string NavItemSpacing { get; set; } = "default";
        public string Layout { get; set; }
        public string RenderStyle { get; set; }
        public string OnNavTagClick { get; set; }
        public string SchemaStyle { get; set; }
        public string SchemaExpandLevel { get; set; }
        public string SchemaDescriptionExpanded { get; set; }
        public string SchemaHideReadOnly { get; set; }
        public string SchemaHideWriteOnly { get; set; }
        public string DefaultSchemaTab { get; set; }
        public string ResponseAreaHeight { get; set; }
        public string ShowInfo { get; set; }
        public string InfoDescriptionHeadingsInNavbar { get; set; }
        public string ShowComponents { get; set; }
        public string ShowHeader { get; set; }
        public string AllowAuthentication { get; set; }
        public string AllowSpecUrlLoad { get; set; }
        public string AllowSpecFileLoad { get; set; }
        public string AllowSearch { get; set; }
        public string AllowAdvancedSearch { get; set; }
        public string AllowTry { get; set; }
        public string AllowServerSelection { get; set; }
        public string AllowSchemaDescriptionExpandToggle { get; set; }
        public string ServerUrl { get; set; }
        public string DefaultApiServer { get; set; }
        public string ApiKeyName { get; set; }
        public string ApiKeyLocation { get; set; }
        public string ApiKeyValue { get; set; }
        public string FetchCredentials { get; set; }
    }
}

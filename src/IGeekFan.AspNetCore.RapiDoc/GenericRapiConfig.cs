using System;
using System.Collections.Generic;
using System.Text;
namespace IGeekFan.AspNetCore.RapiDoc
{
    /// <summary>
    /// https://mrin9.github.io/RapiDoc/api.html 
    /// </summary>
    public class GenericRapiConfig
    {
        /// <summary>
        /// url of the OpenAPI spec to view
        /// </summary>
        public string SpecUrl { get; set; } = "";

        /// <summary>
        /// Allowed: true | false 
        /// setting true will update the url on browser's location whenever a new section is visited either by scrolling or clicking
        /// </summary>
        public bool UpdateRoute { get; set; } = true;

        /// <summary>
        /// routes for each operation/api is generated based on the api path. however you may add a custom prefix to these routes to support third party routing needs
        /// </summary>
        public string RoutePrefix { get; set; }

        /// <summary>
        /// Allowed: true | false To list tags in alphabetic order,
        /// otherwise tags will be ordered based on how it is specified under the tags section in the spec.
        /// </summary>
        public bool SortTags { get; set; } = false;

        /// <summary>
        /// Allowed: path | method | summary | none 
        /// Sort endpoints within each tag by path, method or summary. none leaves the sort order unmodified.
        /// &nbsp;|&nbsp; Example
        /// </summary>
        public string SortEndpointsBy { get; set; } = "path";

        /// <summary>
        /// Heading text on top-left corner
        /// </summary>
        public string HeadingText { get; set; } = "";

        /// <summary>
        /// Initial location on the document (identified by method and path) where you want to go after the spec is loaded.
        /// 
        /// goto-path should be in the form of {method}-{path}
        /// 
        /// for instance you want to scrollTo  GET /user/login 
        /// you should provide the location as  get-/user/login
        /// </summary>
        public string GotoPath { get; set; } = "";

        /// <summary>
        /// Allowed: true | false  
        /// Request fields will be filled with example value (if provided in spec)
        /// </summary>
        public bool FillRequestFieldsWithExample { get; set; } = true;

        /// <summary>
        /// Allowed: true | false  
        /// Authentication will be persisted to localStorage
        /// </summary>
        public bool PersistAuth { get; set; } = false;

        /// <summary>
        /// Allowed: light | dark
        ///  Is the base theme, which is used for calculating colors for various UI components.
        /// 'theme', 'bg-color' and 'text-color' are the base attributes for generating a custom theme
        /// </summary>
        public string Theme { get; set; } = "dark";

        /// <summary>
        /// Hex color code for main background
        /// </summary>
        public string BgColor { get; set; } = "";

        /// <summary>
        /// Hex color code for text
        /// </summary>
        public string TextColor { get; set; } = "";

        /// <summary>
        /// Hex color code for the header's background
        /// </summary>
        public string HeaderColor { get; set; } = "";

        /// <summary>
        /// Hex color code on various controls such as buttons, tabs
        /// </summary>
        public string PrimaryColor { get; set; } = "";

        /// <summary>
        /// Allowed:true | false
        /// RapiDoc will attempt to load fonts from CDN, if this is not intended, then set this to false.
        /// </summary>
        public bool LoadFonts { get; set; } = true;

        /// <summary>
        /// Font name(s) to be used for regular text
        /// </summary>
        public string RegularFont { get; set; } = "'Open Sans', Avenir, 'Segoe UI', Arial, sans-serif";

        /// <summary>
        /// Font name(s) to be used for mono-spaced text
        /// </summary>
        public string MonoFont { get; set; } = "Monaco, 'Andale Mono', 'Roboto Mono', 'Consolas' monospace";

        /// <summary>
        /// Allowed: default | large  | largest 
        ///  sets the relative font sizes for the entire document  &nbsp;|&nbsp; Example
        /// </summary>
        public string FontSize { get; set; } = "default";

        /// <summary>
        /// Allowed: false | as-plain-text | as-colored-text | as-colored-block
        /// shows API Method names in the navigation bar (if you customized nav-background make sure there is a proper contrast)
        /// &nbsp;|&nbsp; Example
        /// </summary>
        public string ShowMethodInNavBar { get; set; } = "false";

        /// <summary>
        /// Allowed: true | false
        /// set true to show API paths in the navigation bar instead of summary/description
        /// &nbsp;|&nbsp; Example
        /// </summary>
        public bool UsePathInNavBar { get; set; } = false;

        /// <summary>
        /// Navigation bar's background color
        /// &nbsp;|&nbsp; Example
        /// </summary>
        public string NavBgColor { get; set; }

        /// <summary>
        /// Navigation bar's Text color
        /// </summary>
        public string NavTextColor { get; set; }

        /// <summary>
        /// background color of the navigation item on mouse-over
        /// </summary>
        public string NavHoverBgColor { get; set; }

        /// <summary>
        /// text color of the navigation item on mouse-over
        /// </summary>
        public string NavHoverTextColor { get; set; }

        /// <summary>
        /// Accent color used in navigtion Bar (such as background of active navigation item)
        /// </summary>
        public string NavAccentColor { get; set; }

        /// <summary>
        /// Text color used in navigtion bar selected items
        /// </summary>
        public string NavAccentTextColor { get; set; }

        /// <summary>
        /// Navigation active item indicator styles
        /// </summary>
        public string NavActiveItemMarker { get; set; } = "left-bar";

        /// <summary>
        /// Allowed: default | compact | relaxed
        /// Controls navigation item spacing
        /// &nbsp;|&nbsp; Example
        /// </summary>
        public string NavItemSpacing { get; set; } = "default";

        /// <summary>
        /// Allowed: expand-collapse | show-description -
        /// applies only to focused render-style. It determinses the behavior of clicking on a Tag in navigation bar.
        /// It can either expand-collapse the tag or take you to the tag's description page.
        /// </summary>
        public string OnNavTagClick { get; set; } = "expand-collapse";

        /// <summary>
        /// Allowed: row | column
        /// Layout helps in placement of request/response sections. In column layout, request & response sections are placed one below the other,
        /// In row layout they are placed side by side.
        /// This attribute is applicable only when the device width is more than 768px and the render-style  is 'view'.
        /// </summary>
        public string Layout { get; set; } = "row";

        /// <summary>
        /// Allowed: read | view | focused -
        /// determines display of api-docs. Currently there are three modes supported.
        /// 
        ///   
        ///     view
        ///     friendly for quick exploring (expand/collapse the section of your interest) &nbsp;|&nbsp; Example
        ///   
        ///   
        ///     read
        ///     suitable for reading (like a continuous web-page) &nbsp;|&nbsp; Example 
        ///   
        ///   
        ///     focused
        ///     similar to read but focuses on a single endpoint at a time (good for large specs) &nbsp;|&nbsp; Example
        ///   
        ///
        /// 
        /// 'read' - more suitable for reading 'view' more friendly for quick exploring
        /// </summary>
        public string RenderStyle { get; set; } = "read";

        /// <summary>
        /// Allowed: valid css height value such as 400px, 50%, 60vh etc -
        /// Use this value to control the height of response textarea
        /// </summary>
        public string ResponseAreaHeight { get; set; } = "300px";

        /// <summary>
        /// show/hide the documents info section
        /// Info section contains information about the spec, such as the title and description of the spec, the version, terms of services etc.
        /// In certain situation you may not need to show this section. For instance you are embedding this element inside a another help document.
        /// Chances are, the help doc may already have this info, in that case you may want to hide this section.
        /// </summary>
        public bool ShowInfo { get; set; } = true;

        /// <summary>
        /// Include headers from info -> description section to the Navigation bar (applies to read mode only)
        /// 
        /// Will get the headers from the markdown in info - description (h1 and h2) into the menu on the left (in read mode) along with links to them.
        /// This option allows users to add navigation bar items using Markdown
        /// &nbsp;|&nbsp; Example
        /// </summary>
        public bool InfoDescriptionHeadingsInNavbar { get; set; } = false;

        /// <summary>
        /// show/hide the components section both in document and menu
        /// (available only in focused render-style)
        /// 
        /// Will show the components section containing schemas, responses, examples, requestBodies, headers, securitySchemes, links and callbacks
        /// </summary>
        public bool ShowComponents { get; set; } = false;

        /// <summary>
        /// show/hide the header.
        /// If you do not want your user to open any other api spec, other than the current one, then set this attribute to false
        /// </summary>
        public bool ShowHeader { get; set; } = true;

        /// <summary>
        /// Authentication feature, allows the user to select one of the authentication mechanism thats available in the spec.
        /// It can be http-basic, http-bearer or api-key.
        /// If you do not want your users to go through the authentication process, instead want them to use a pre-generated api-key
        /// then you may hide authentication section by setting this attribute to false
        /// and provide the api-key details using various api-key-???? attributes.
        /// </summary>
        public bool AllowAuthentication { get; set; } = true;

        /// <summary>
        /// If set to 'false', user will not be able to load any spec url from the UI.
        /// </summary>
        public bool AllowSpecUrlLoad { get; set; } = true;

        /// <summary>
        /// If set to 'false', user will not be able to load any spec file from the local drive.
        /// This attribute is applicable only when the device width is more than 768px, else this feature is not available
        /// </summary>
        public bool AllowSpecFileLoad { get; set; } = true;

        /// <summary>
        /// If set to 'true', it provide buttons in the overview section to download the spec or open it in a new tab.
        /// </summary>
        public bool AllowSpecFileDownload { get; set; } = false;

        /// <summary>
        /// Provides quick filtering of API
        /// </summary>
        public bool AllowSearch { get; set; } = true;

        /// <summary>
        /// Provides advanced search functionality, to search through API-paths, API-description, API-parameters and API-Responses
        ///   &nbsp;|&nbsp; Example
        /// </summary>
        public bool AllowAdvancedSearch { get; set; } = true;

        /// <summary>
        /// The 'TRY' feature allows you to make REST calls to the API server.
        /// To disable this feature, set it to false.
        /// &nbsp;|&nbsp; Example
        /// </summary>
        public bool AllowTry { get; set; } = true;

        /// <summary>
        /// If set to 'true', the cURL snippet is displayed between the request and the response without clicking on TRY &nbsp;|&nbsp; Example
        /// </summary>
        public bool ShowCurlBeforeTry { get; set; } = false;

        /// <summary>
        /// If set to 'false', user will not be able to see or select API server (Server List will be hidden, however users will be able to see the server url near the 'TRY' button, to know in advance where the TRY will send the request).
        /// The URL specified in the server-url attribute will be used if set, else the first server in the API specification file will be used.
        /// </summary>
        public bool AllowServerSelection { get; set; } = true;

        /// <summary>
        /// Allowed: true | false
        /// allow or hide the ability to expand/collapse field descriptions in the schema
        /// </summary>
        public bool AllowSchemaDescriptionExpandToggle { get; set; } = true;

        /// <summary>
        /// Allowed: tree | table -
        /// Two different ways to display object-schemas in the responses and request bodies
        /// &nbsp;|&nbsp; Example
        /// </summary>
        public string SchemaStyle { get; set; } = "tree";

        /// <summary>
        /// Schemas are expanded by default, use this attribute to control how many levels in the schema should be expanded
        /// &nbsp;|&nbsp; Example
        /// </summary>
        public string SchemaExpandLevel { get; set; } = "999";

        /// <summary>
        /// Allowed: true | false -
        /// Constraint and descriptions information of fields in the schema are collapsed to show only the first line.
        /// Set it to true if you want them to fully expanded
        /// </summary>
        public bool SchemaDescriptionExpanded { get; set; } = false;

        /// <summary>
        /// Allowed: default | never  -
        /// default will show read-only schema attributes in Responses, and in Requests of Webhook / Callback
        /// 
        /// If you do not want to hide read-only fields in schema then you may set it to 'never'
        /// 
        /// Note:This do not effect example generation.
        /// &nbsp;|&nbsp; Example
        /// </summary>
        public string SchemaHideReadOnly { get; set; } = "default";

        /// <summary>
        /// Allowed: default | never  -
        /// default will show write-only schema attributes in Requests, and in Responses of Webhook / Callback
        /// 
        /// If you do not want to hide write-only fields in schema then you may set it to 'never'
        /// 
        /// Note:This do not effect example generation.
        /// &nbsp;|&nbsp; Example
        /// </summary>
        public string SchemaHideWriteOnly { get; set; } = "default";

        /// <summary>
        /// Allowed: schema | example -
        /// The schemas are displayed in two tabs - Model and Example.
        /// This option allows you to pick the default tab that you would like to be active
        /// </summary>
        public string DefaultSchemaTab { get; set; } = "model";

        /// <summary>
        /// OpenAPI spec has a provision for providing the server url. The UI will list all the server URLs provided in the spec.
        /// The user can then select one URL to which he or she intends to send API calls while trying out the apis.
        /// However, if you want to provide an API server of your own which is not listed in the spec, you can use this property to provide one.
        /// It is helpful in the cases where the same spec is shared between multiple environment say Dev and Test and each have their own API server.
        /// </summary>
        public string ServerUrl { get; set; } = "";

        /// <summary>
        /// If you have multiple api-server listed in the spec, use this attribute to select the default API server, where all the API calls will goto.
        /// This can be changed later from the UI
        /// </summary>
        public string DefaultApiServer { get; set; } = "";

        /// <summary>
        /// Name of the API key that will be send while trying out the APIs
        /// </summary>
        public string ApiKeyName { get; set; } = "";

        /// <summary>
        /// Allowed: header, query -
        /// determines how you want to send the api-key.
        /// </summary>
        public string ApiKeyLocation { get; set; } = "";

        /// <summary>
        /// Value of the API key that will be send while trying out the APIs.
        /// This can also be provided/overwritten from UI.
        /// </summary>
        public string ApiKeyValue { get; set; } = "";

        /// <summary>
        /// Allowed: omit | same-origin | include
        /// enables passing credentials/cookies in cross domain calls, as defined in the 
        /// Fetch standard, in CORS requests 
        /// that are sent by the browser
        /// </summary>
        public string FetchCredentials { get; set; } = "";
    }
}
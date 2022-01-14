#region License
// Copyright (C) 2021 Rejuvena Team, MIT License
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Rejuvena.BuildConfigurer
{
    public class BuildFile
    {
        public string DisplayName { get; set; } = "Name Not Specified";

        public string Author { get; set; } = "No Author";

        public Version Version { get; set; } = new Version();

        public List<string> DllReferences { get; set; } = new List<string>();

        public List<string> ModReferences { get; set; } = new List<string>();

        public List<string> WeakReferences { get; set; } = new List<string>();

        public bool NoCompile { get; set; } = false;

        public string Homepage { get; set; } = "";

        public bool HideCode { get; set; } = false;

        public bool HideResources { get; set; } = false;

        public bool IncludeSource { get; set; } = false;

        public List<string> BuildIgnore { get; set; } = new List<string>
        {
            "build.txt",
            ".git/*",
            ".vs/*",
            "bin/*",
            "obj/*",
            "Thumbs.db"
        };

        public bool IncludePdb { get; set; } = true;

        public ModSide Side { get; set; } = ModSide.Both;

        public List<string> SortAfter { get; set; } = new List<string>();

        public List<string> SortBefore { get; set; } = new List<string>();

        protected StringBuilder WriteOption(StringBuilder stringBuilder, string optionName, string optionValue) =>
            stringBuilder.AppendLine($"{optionName} = {optionValue}");

        protected StringBuilder WriteOption(StringBuilder stringBuilder, string optionName, List<string> optionValues) =>
            stringBuilder.AppendLine($"{optionName} = {string.Join(", ", optionValues)}");

        protected StringBuilder WriteOption(StringBuilder stringBuilder, string optionName, bool optionValue) =>
            stringBuilder.AppendLine($"{optionName} = {(optionValue ? "true" : "false")}");

        public virtual string WriteFile()
        {
            StringBuilder builder = new StringBuilder();

            WriteOption(builder, "displayName", DisplayName);
            WriteOption(builder, "author", Author);
            WriteOption(builder, "version", Version.ToString());
            WriteOption(builder, "dllReferences", DllReferences);
            WriteOption(builder, "modReferences", ModReferences);
            WriteOption(builder, "weakReferences", WeakReferences);
            WriteOption(builder, "noCompile", NoCompile);
            WriteOption(builder, "homepage", Homepage);
            WriteOption(builder, "hideCode", HideCode);
            WriteOption(builder, "hideResources", HideResources);
            WriteOption(builder, "includeSource", IncludeSource);
            WriteOption(builder, "buildIgnore", BuildIgnore);
            WriteOption(builder, "includePDB", IncludePdb);
            WriteOption(builder, "side", Side.ToString());
            WriteOption(builder, "sortAfter", SortAfter);
            WriteOption(builder, "sortBefore", SortBefore);

            return builder.ToString();
        }
    }
}

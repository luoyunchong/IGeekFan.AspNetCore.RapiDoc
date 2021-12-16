using System;

namespace IGeekFan.AspNetCore.RapiDoc
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class RapiDocLabelAttribute : Attribute
    {
        public RapiDocLabelAttribute(string label, RapiDocColor color = RapiDocColor.BLUE)
        {
            Label = label ?? throw new ArgumentNullException(nameof(label));
            Color = color;
        }
        public string Label { get; }
        public RapiDocColor Color { get;  }
    }
    public enum RapiDocColor
    {
        RED,
        GREEN,
        ORANGE,
        BLUE,
        PRIMARY_COLOR
    }
}

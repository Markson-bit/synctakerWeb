using Microsoft.AspNetCore.Components;

namespace synctakerWeb.Classes
{
    public static class MarkupStatic
    {
        public static MarkupString GetPriorityMarkup(string priority)
        {
            string label = "[?]";
            string color = "gray";

            if (!string.IsNullOrWhiteSpace(priority) && priority.Contains("["))
            {
                var startIndex = priority.IndexOf("[");
                var endIndex = priority.IndexOf("]");
                if (startIndex >= 0 && endIndex > startIndex)
                {
                    label = priority.Substring(startIndex, endIndex - startIndex + 1);

                    if (label == "[L]") color = "gray";
                    else if (label == "[N]") color = "green";
                    else if (label == "[H]") color = "red";
                }
            }

            return new MarkupString($"<span style='color: {color};'>{label}</span>");
        }
    }
}
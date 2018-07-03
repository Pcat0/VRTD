using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

//TODO: better rich text
[ExecuteInEditMode]
public class TextController : MonoBehaviour {
    [Multiline]
    public string templateText;
    //public string[] values;
    public IDictionary<string, string> values = new Dictionary<string, string>();
    //values.Add("wave", "1");
    public Text textElement;
    private void Update() {
        textElement.text = Format(templateText, values);
    }
    public string Format(string template, IDictionary<string, string> values) {
        StringBuilder builder = new StringBuilder();
        MatchCollection matches = Regex.Matches(template, @"{([\w]+)}");
        int prevIndex = 0;
        foreach (Match match in matches) {

            string key = match.Groups[1].Value;
            string replacement;
            builder.Append(template.Substring(prevIndex, match.Index - prevIndex));

            if (values.TryGetValue(key, out replacement)) {
                builder.Append(replacement);
            } else {
                builder.Append(match.Value);
            }
            prevIndex = match.Index + match.Length;
        }
        builder.Append(template, prevIndex, template.Length - prevIndex);
        return builder.ToString();
    }
}

using Newtonsoft.Json.Linq;

namespace RSO.Core.BL.LogicModels;

/// <summary>
/// GraphQL query class.
/// </summary>
public class GraphQLQuery
{
    public string OpertaionName { get; set; }

    public string NamedQuery { get; set; }

    public string Query { get; set; }

    public JObject Variables { get; set; }
}

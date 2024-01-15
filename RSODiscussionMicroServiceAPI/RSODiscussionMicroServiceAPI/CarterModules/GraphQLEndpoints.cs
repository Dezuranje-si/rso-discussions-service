//using Carter;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Mvc;
//using RSO.Core.BL.LogicModels;
//using RSO.Core.DiscussionModels;

//namespace UserServiceRSO.CarterModules;

//public class GraphQLEndpoints : ICarterModule
//{
//    public void AddRoutes(IEndpointRouteBuilder app)
//    {
//        app.MapHealthChecks("/api/user/health").WithTags("Health");

//        app.MapPost("/api/graphQL", SendGraphQLData).WithName(nameof(SendGraphQLData))
//            .WithTags("GraphQL");
//    }

//    private static SendGraphQLData([FromBody] GraphQLQuery query)
//    {
//        //var inputs = query.Variables.ToInputs();


//        //var inputs = new Inputs(query.Variables);

//        var d = new DiscussionCodeFirst();
//        return TypedResults.Ok(d);
//    }

//}

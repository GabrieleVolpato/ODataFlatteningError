using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataFlattening.DTOs;

namespace ODataFlattening
{
    public static class EdmModelBuilder
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<ParentDTO>("Parents");
            builder.EntitySet<ChildDTO>("Children");

            return builder.GetEdmModel();
        }
    }
}

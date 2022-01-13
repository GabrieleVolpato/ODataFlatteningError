using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataFlattening.DTOs;

namespace ODataFlattening.Controllers
{
    [ODataAttributeRouting]
    public class ParentsController : ODataController
    {
        private readonly FlatteningContext _flatteningContext;
        private readonly IMapper _mapper;

        public ParentsController(FlatteningContext flatteningContext, IMapper mapper)
        {
            _flatteningContext = flatteningContext;
            _mapper = mapper;
        }

        [EnableQuery]
        public IQueryable<ParentDTO> Get()
        {
            try
            {
                return _flatteningContext.Parents.ProjectTo<ParentDTO>(_mapper.ConfigurationProvider);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

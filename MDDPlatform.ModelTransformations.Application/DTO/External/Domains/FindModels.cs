using MDDPlatform.ModelTransformations.Application.DTO.Common;

namespace MDDPlatform.ModelTransformations.Application.DTO.External;
public class FindModels
{
    public FilterDto<Guid> FilterByProblemDomain {get;set;}
    public FilterDto<Guid> FilterByDomain {get;set;}
    public FilterDto<string> FilterByName {get;set;}
    public FilterDto<string> FilterByAbstractionLevel {get;set;}
    public FilterDto<string> FilterByTag {get;set;}
    public FilterDto<Guid> FilterByLnaguage {get;set;}

    public FindModels(FilterDto<Guid> filterByProblemDomain, FilterDto<Guid> filterByDomain, FilterDto<string> filterByName, FilterDto<string> filterByAbstractionLevel, FilterDto<string> filterByTag, FilterDto<Guid> filterByLnaguage)
    {
        FilterByProblemDomain = filterByProblemDomain;
        FilterByDomain = filterByDomain;
        FilterByName = filterByName;
        FilterByAbstractionLevel = filterByAbstractionLevel;
        FilterByTag = filterByTag;
        FilterByLnaguage = filterByLnaguage;
    }
}
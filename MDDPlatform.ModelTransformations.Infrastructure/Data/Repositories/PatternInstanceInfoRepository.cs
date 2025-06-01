using MDDPlatform.DataStorage.MongoDB.Repositories;
using MDDPlatform.ModelTransformations.Application.Queries;
using MDDPlatform.ModelTransformations.Application.ReadModels;
using MDDPlatform.ModelTransformations.Application.ReadModels.Repositories;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Models;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Repositories;
public class PatternInstanceInfoRepository : IPatternInstanceInfoRepository
{
    private IMongoRepository<PatternInstanceInfoDocument,Guid> _repository;

    public PatternInstanceInfoRepository(IMongoRepository<PatternInstanceInfoDocument, Guid> repository)
    {
        _repository = repository;
    }

    public async Task CreatePatternInstanceInfoAsync(PatternInstanceInfo info)
    {
        await _repository.AddAsync(PatternInstanceInfoDocument.CreateFrom(info));
    }

    public async Task DeletePatternInstanceInfoAsync(Guid patternInstanceId)
    {
        await _repository.DeleteAsync(patternInstanceId);
    }

    public async Task<List<PatternInstanceInfo>> FindPatternInstancesAsync(FindPatternInstanceQuery query)
    {

        var results = await Task.Run(()=>
        {
            var queryableCollection = _repository.GetQueryableCollection();
            if(query.FilterByProblemDomain.IsApplied)
                queryableCollection = queryableCollection.Where(instanceInfo => instanceInfo.ProblemDomainId == query.FilterByProblemDomain.Value);
        
            ////////////////Filter Input Model//////////////////
            if(query.FilterByInputMetaModel.IsApplied)
                queryableCollection = queryableCollection.Where(instanceInfo=>instanceInfo.InputModels.Any(model=>model.LanguageId == query.FilterByInputMetaModel.Value));

            if(query.FilterByInputModelType.IsApplied && !string.IsNullOrEmpty(query.FilterByInputModelType.Value))
                queryableCollection = queryableCollection.Where(instanceInfo=>instanceInfo.InputModels.Any(model=>model.Type == query.FilterByInputModelType.Value));
                
            //////////Filter Output Model//////////
            if(query.FilterByOutputMetamodel.IsApplied)
                queryableCollection = queryableCollection.Where(instanceInfo=>instanceInfo.OutputModels.Any(model=>model.LanguageId == query.FilterByOutputMetamodel.Value));

            if(query.FilterByOutputModelType.IsApplied && !string.IsNullOrEmpty(query.FilterByOutputModelType.Value))
                queryableCollection = queryableCollection.Where(instanceInfo=>instanceInfo.OutputModels.Any(model=>model.Type == query.FilterByOutputModelType.Value));




            return queryableCollection.ToList();
        });
        // var results = queryableCollection.ToList();

        return results.Select(instanceInfoDoc=>instanceInfoDoc.ToPatternInstanceInfo()).ToList();
    }
}

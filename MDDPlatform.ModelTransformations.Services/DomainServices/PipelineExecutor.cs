using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.ModelTransformations.Services.Interfaces;
using MDDPlatform.ModelTransformations.Services.Repositories;
using MDDPlatform.ModelTransformations.Services.Saga;

namespace MDDPlatform.ModelTransformations.Services.DomainServices;
public class PipelineExecutor : IPipelineExecutor
{
    private IPipelineRepository _pipelineRepository;
    private ITransformationService _transformationService;
    private IPipelineNotificationService _pipelineNotificationService;
    private IPatternInstanceService _patternInstanceService;
    private ISagaRepository _sagaRepository;

    public PipelineExecutor(IPipelineRepository pipelineRepository, ITransformationService transformationService, IPipelineNotificationService pipelineNotificationService, IPatternInstanceService patternInstanceService, ISagaRepository sagaRepository)
    {
        _pipelineRepository = pipelineRepository;
        _transformationService = transformationService;
        _pipelineNotificationService = pipelineNotificationService;
        _patternInstanceService = patternInstanceService;
        _sagaRepository = sagaRepository;
    }

    public async Task ExecutePipelineAsync(Pipeline pipeline)
    {
        if(Equals(pipeline,null))
            throw new Exception("Pipeline Execution Exeception : Pipeline Not found");

        var stage = pipeline.Next();        
        if(stage !=null && stage.Type == StageType.Automatic)
        {
            var saga = PipelineSaga.Create(pipeline.Id,stage.Id);
            await _sagaRepository.CreateAsync(saga);

            var coordinationId = saga.ExternalCoordinationId;
            var stepId = saga.ExternalStepId;

            try
            {
                var taskId = stage.TaskId;
                pipeline.StartStage(stage.Id);
                await _pipelineNotificationService.NotifyPipelineStageStarted(pipeline.Id,stage.Id,pipeline.Status);
                await _pipelineRepository.UpdatePipelineAsync(pipeline);

                var patternInstance = await _patternInstanceService.GetInstanceAsync(taskId);                
                if(Equals(patternInstance,null))
                    throw new Exception("Pipeline Execution Exeception : Pattern Instance Not Found");

                var patternName = patternInstance.Template.PatternName;
                var fieldValues = patternInstance.FieldValues.ToList();

                await _transformationService.ExecutePatternInstanceAsync(patternName,fieldValues,coordinationId,stepId);
            }catch(Exception ex)
            {
                Console.WriteLine("------------Pipeline Executor Failed -------------");
                Console.WriteLine(ex.Message);
                pipeline.ResetStage(stage.Id);
                await _pipelineRepository.UpdatePipelineAsync(pipeline);
                await _sagaRepository.DeleteAsync(saga.Id);
            }
        }
    }
}
